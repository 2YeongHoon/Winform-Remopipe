using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;
using log4net;
using log4net.Config;
using System.IO;

namespace removipe
{

    public partial class RemoPipe : Form
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(Form));

        /*
                SerialComm serialcom = new SerialComm(log);*/
        SerialComm serialcom = new SerialComm();
        CommonSetting commonSetting = new CommonSetting();
        ValveManual valveManual = new ValveManual(false, true);
        List<SensorStatus> sensorStatus = new List<SensorStatus>();
        DateTime lastValveOpenTime = DateTime.Now;
        Thread updateSensorDataThread = null;
        Thread valveControlThread = null;
        public static RemoPipe remopipe;

        const string portName = "COM7";
        const string password = "1234";
        const int MAX_STAGE_COUNT = 16;
        public string receivePassword;

        public RemoPipe()
        {
            InitializeComponent();
            remopipe = this;

            XmlConfigurator.Configure(new FileInfo("log4net.xml"));

            this.FormClosed += new FormClosedEventHandler(RemoPipe_Closing);
        }

        public void RemoPipe_Closing(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (updateSensorDataThread != null)
                {
                    updateSensorDataThread.Abort();
                }
                if (valveControlThread != null)
                {
                    valveControlThread.Abort();
                }
                log.Info("RemoPipe 종료");
                Application.Exit();
            }
            catch (Exception ex)
            {
                log.Info("RemoPipe 종료중 문제발생 " + ex);
            }
        }

        private void RemoPipe_Load(object sender, System.EventArgs e)
        {
            log.Info("RemoPipe 실행");


            for (int i = 0; i < MAX_STAGE_COUNT; i++)
            {
                SensorStatus sensor = new SensorStatus();
                sensorStatus.Add(sensor);
            }

            bool result = serialcom.portOpen(portName, sensorStatus, valveManual);

            if (result == false)
            {
                log.Info("보드 연결상태 확인");
                MessageBoxForm messageBox = new MessageBoxForm("보드와 연결을 확인해주세요");
                messageBox.ShowDialog();
                Application.Exit();
            }
            else
            {
                // valve 상태 초기화
                serialcom.closeSolValve();
                sensorStatus[0].SolValve = false;
                Thread.Sleep(1000);

                // UI Sensor Data 갱신 Thread Start
                updateSensorDataThread = new Thread(new ThreadStart(updateSensorData));
                updateSensorDataThread.IsBackground = true;
                updateSensorDataThread.Start();

                // 자동 Valve Control Thread Start
                valveControlThread = new Thread(new ThreadStart(valveControl));
                updateSensorDataThread.IsBackground = true;
                valveControlThread.Start();
            }

            panel_close.Visible = true;

            lbl_close.Visible = true;
            lbl_open.Visible = false;
            pnl_monitoring.Visible = true;
            lbl_Inlet_Flow.Visible = true;
            lbl_Outlet_Flow.Visible = true;
            lbl_Inlet_Flow_Value.Visible = true;
            lbl_Outlet_Flow_Value.Visible = true;
            lbl_Valve.Visible = true;
            listview_log.Visible = false;

            pro_inlet.Value = 0;
            pro_outlet.Value = 0;
        }

        private void valveControl()
        {
            try
            {
                bool valvePressOpen;
                int valvePressInterval;
                int valvePressRepeatValue;
                float valvePressOpenValue;

                bool valveTimeOpen;
                int valveTimeInterval;
                int valveTimeRepeatValue;
                int valveTimeOpenValue;
                int valveInterval;

                int pressCount;
                int count = 0;

                bool simulatorMode = false;


                while (true)
                {

                    /*                    if (!serialcom.CheckCommunication())
                                        {
                                            MessageBoxForm messageBox = new MessageBoxForm("보드 연결상태 확인");
                                            messageBox.ShowDialog();
                                            log.Info("보드 연결상태 확인");
                                            return;
                                        }*/

                    // 화면 데이터 수신
                    serialcom.getAllState(MAX_STAGE_COUNT, simulatorMode);

                    // TODO 센서 수신 주기
                    Thread.Sleep(1000);

                    // 설정 값 갱신
                    valvePressOpen = commonSetting.ValvePressOpen;
                    valvePressInterval = commonSetting.ValvePressInterval;
                    valvePressRepeatValue = commonSetting.ValvePressRepeatValue;
                    valvePressOpenValue = commonSetting.ValvePressOpenValue;

                    valveTimeOpen = commonSetting.ValveTimeOpen;
                    valveTimeInterval = commonSetting.ValveTimeInterval;
                    valveTimeRepeatValue = commonSetting.ValveTimeRepeatValue;
                    valveTimeOpenValue = commonSetting.ValveTimeOpenValue;
                    valveInterval = commonSetting.ValveInterval;
                    pressCount = commonSetting.ValvePressCount;

                    simulatorMode = commonSetting.SimulatorMode;


                    if (valvePressOpen == true)
                    {
                        float pressure = 0;

                        pressure = sensorStatus[0].PresureSensor - sensorStatus[2].PresureSensor;

                        if (pressure <= valvePressOpenValue)
                        {
                            if (count < pressCount)
                            {
                                count++;
                            }
                            else
                            {
                                // 0 == press
                                serialcom.valveCtrQueue(valvePressInterval, valvePressRepeatValue, valveInterval, 0);
                                count = 0;
                            }
                        }
                        else
                        {
                            count = 0;
                        }
                    }

                    if (valveTimeOpen == true)
                    {
                        DateTime nowTime = DateTime.Now;

                        if (valveTimeOpenValue <= valveOpenTime(nowTime))
                        {
                            // 1 == time
                            serialcom.valveCtrQueue(valveTimeInterval, valveTimeRepeatValue, valveInterval, 1);
                            lastValveOpenTime = nowTime;
                        }
                    }
                    Thread.Sleep(100);
                }
            }
            catch (Exception ex)
            {
                log.Info("센서 제어 중 에러: " + ex);
                MessageBoxForm messageBox = new MessageBoxForm("화면갱신 종료");
                messageBox.ShowDialog();
            }
        }

        /// <summary>
        /// valve Last Open 시간계산 함수
        /// </summary>
        /// <returns> Minites </returns>
        private int valveOpenTime(DateTime nowTime)
        {
            TimeSpan dateDiff = nowTime - lastValveOpenTime;
            return dateDiff.Minutes;
        }

        private void updateSensorData()
        {
            crossThread(lbl_Inlet_Flow_Value, lbl_Outlet_Flow_Value, lbl_close, lbl_open, sensorStatus, lbl_time);
        }

        /// <summary>
        /// Monitoring Sensor값 갱신 함수
        /// </summary>
        public void crossThread(Control inlet, Control outlet, Control close, Control open, List<SensorStatus> sensorStatus, Control time)
        {
            try
            {
                while (true)
                {
                    float inletValue = 0;
                    float outletValue = 0;

                    inletValue = sensorStatus[0].PresureSensor;
                    outletValue = sensorStatus[2].PresureSensor;

                    if (time.InvokeRequired)
                    {
                        time.BeginInvoke(new MethodInvoker(delegate ()
                        {
                            DateTime dateTime = DateTime.Now;
                            time.Text = dateTime.ToString("HH:mm:ss");
                        }));
                    }

                    if (inlet.InvokeRequired)
                    {
                        inlet.BeginInvoke(new MethodInvoker(delegate ()
                        {
                            inlet.Text = inletValue.ToString() + " kgf/cm2";
                        }));
                    }

                    if (pro_inlet.InvokeRequired)
                    {
                        pro_inlet.Invoke(new MethodInvoker(delegate ()
                        {
                            pro_inlet.Value = (int)inletValue * 10;
                        }));
                    }

                    if (pro_outlet.InvokeRequired)
                    {
                        pro_outlet.Invoke(new MethodInvoker(delegate ()
                        {
                            pro_outlet.Value = (int)outletValue * 10;
                        }));
                    }

                    if (outlet.InvokeRequired)
                    {
                        outlet.BeginInvoke(new MethodInvoker(delegate ()
                        {
                            outlet.Text = outletValue.ToString() + " kgf/cm2";
                        }));
                    }

                    if (close.InvokeRequired)
                    {
                        close.BeginInvoke(new MethodInvoker(delegate ()
                        {
                            if (sensorStatus[0].SolValve == true)
                            {
                                close.Visible = false;
                                open.Visible = true;
                            }
                            else
                            {
                                close.Visible = true;
                                open.Visible = false;
                            }
                        }));
                    }

                    // TODO 화면 갱신 주기
                    Thread.Sleep(1000);
                }
            }
            catch (Exception ex)
            {
                log.Info("화면 갱신 중 에러: " + ex);
            }
        }

        /// <summary>
        /// Setting Click Event
        /// </summary>
        private void btn_setting_Click(object sender, EventArgs e)
        {
            string rvPassword = "";
            ViewPassword viewPass = new ViewPassword("main");
            viewPass.Owner = this;
            if (viewPass.ShowDialog() == DialogResult.OK)
            {
                rvPassword = receivePassword;

                if (rvPassword == password)
                {
                    SettingForm settingForm = new SettingForm(commonSetting);
                    settingForm.ShowDialog();
                }
                else
                {
                    MessageBoxForm messageBox = new MessageBoxForm("패스워드를 확인해주세요");
                    messageBox.ShowDialog();
                }
            }
            else
            {
            }
        }

        /// <summary>
        /// Monitoring Click Event
        /// </summary>
        private void btn_monitoring_Click(object sender, EventArgs e)
        {
            listview_log.Visible = false;
        }

        /// <summary>
        /// Log Click Event
        /// </summary>
        private void btn_log_Click(object sender, EventArgs e)
        {
            listview_log.Visible = true;
        }

        /// <summary>
        /// Exit Click Event
        /// </summary>
        private void btn_exit_Click(object sender, EventArgs e)
        {
            try
            {
                string rvPassword = "";
                ViewPassword viewPass = new ViewPassword("main");
                viewPass.Owner = this;
                if (viewPass.ShowDialog() == DialogResult.OK)
                {
                    rvPassword = receivePassword;
                }
                if (rvPassword == password)
                {
                    serialcom.portClose();
                    if (updateSensorDataThread != null)
                    {
                        updateSensorDataThread.Abort();
                    }
                    if (valveControlThread != null)
                    {
                        valveControlThread.Abort();
                    }
                    Application.Exit();
                }
                else
                {
                    MessageBoxForm messageBox = new MessageBoxForm("패스워드를 확인해주세요");
                    messageBox.ShowDialog();
                }

            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Valve Close Click Event
        /// </summary>
        private void btn_valve_close_Click(object sender, EventArgs e)
        {
            try
            {
                bool result = false;
                if (sensorStatus[0].SolValve == false)
                {
                    log.Info("벨브가 이미 닫혀있습니다.");
                    MessageBoxForm messageBox = new MessageBoxForm("벨브가 이미 닫혀있습니다.");
                    messageBox.ShowDialog();
                }
                else
                {
                    if (valveManual.Status == false)
                    {
                        log.Info("Manual Open시 사용할 수 있습니다.");
                        MessageBoxForm messageBox = new MessageBoxForm("Manual Open시 사용할 수 있습니다.");
                        messageBox.ShowDialog();
                    }
                    else
                    {
                        listViewAdd("Manual Close", 0, 0);
                        Thread.Sleep(1000);
                        result = serialcom.closeSolValve();
                        log.Info("밸브 메뉴얼 Close");
                        sensorStatus[0].SolValve = false;
                        valveManual.Status = false;
                        panel_close.Visible = true;
                        lbl_close.Visible = true;
                        lbl_open.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                log.Info("벨브 메뉴얼 close 중 에러: " + ex);
            }

        }

        /// <summary>
        /// Valve Open Click Event
        /// </summary>
        private void btn_valve_open_Click(object sender, EventArgs e)
        {
            try
            {
                bool result = false;

                if (sensorStatus[0].SolValve == true || valveManual.Status == true)
                {
                    log.Info("벨브가 이미 열려있습니다.");
                    MessageBoxForm messageBox = new MessageBoxForm("벨브가 이미 열려있습니다.");
                    messageBox.ShowDialog();
                }
                else
                {
                    if (valveManual.Use == false)
                    {
                        log.Info("벨브 동작이 진행중입니다. 잠시후 다시 시도해주세요.");
                        MessageBoxForm messageBox = new MessageBoxForm("벨브 동작이 진행중입니다. 잠시후 다시 시도해주세요.");
                        messageBox.ShowDialog();
                    }
                    else
                    {
                        listViewAdd("Manual Open", 0, 0);
                        valveManual.Use = false;
                        // 이전 작업 마무리 시간
                        Thread.Sleep(1000);
                        log.Info("벨브 메뉴얼 Open");
                        result = serialcom.openSolValve();
                        valveManual.Status = true;
                        sensorStatus[0].SolValve = true;
                        valveManual.Use = true;
                        panel_close.Visible = false;
                        lbl_close.Visible = false;
                        lbl_open.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                log.Info("벨브 메뉴얼 Open중 에러: " + ex);
            }
        }

        public void listViewAdd(string type, int repre, int interval)
        {
            DateTime dateTime = DateTime.Now;

            List<string> arr = new List<string>();
            arr.Add(type);
            arr.Add(dateTime.ToString("yyyy-MM-dd HH:mm:dd"));
            arr.Add(repre.ToString() + " 회");
            arr.Add(interval.ToString() + " ms");

            ListViewItem lvi = new ListViewItem(arr.ToArray());
            listview_log.Items.Add(lvi);
        }
    }
}

