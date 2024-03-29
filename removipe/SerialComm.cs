﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using log4net;
using removipe.Common;

namespace removipe
{
    public class SerialComm
    {
        private SerialPort serialPort;
        List<SensorStatus> status;
        Queue<byte> receiveQueue = new Queue<byte>();
        Queue<List<int>> sendQueue = new Queue<List<int>>();
        Thread sendThread = null;
        ValveManual valveManual;

        private static Semaphore semaphore = new Semaphore(1, 1);
        //
        const int SOL_VALVE_NUM = 1;
        const int TOTAL_COUNT = 0;
        int TIME_OUT_COUNT = 0;

        // simulator
        float INLET_DEBUG = 10.2F;
        float OUTLET_DEBUG = 10.2F;

        public static bool flag = true;
        public static int simpleCount = 0;


        public bool portOpen(string portName, List<SensorStatus> sensorStatus, ValveManual valveManualStatus)
        {
            try
            {
                if (serialPort == null)
                {
                    serialPort = new SerialPort();
                }

                status = sensorStatus;
                valveManual = valveManualStatus;

                serialPort.PortName = portName;
                serialPort.BaudRate = 19200;
                serialPort.DataBits = 8;
                serialPort.Parity = Parity.None;
                serialPort.StopBits = StopBits.One;
                serialPort.ReceivedBytesThreshold = 1;
                serialPort.ReadBufferSize = 1024;
                serialPort.DataReceived += new SerialDataReceivedEventHandler(serialDataReceiver);

                if (serialPort.IsOpen == false)
                {

                    serialPort.Open();
                    TraceManager.AddLog("Serial Port Open");

                    MessageBoxForm messageBox = new MessageBoxForm("Port Open");
                    messageBox.ShowDialog();

                    Thread valveThread = new Thread(valveCtrThread);
                    valveThread.IsBackground = true;
                    valveThread.Start();
                }
                else
                {
                    TraceManager.AddLog("Serial Port가 이미 열려있습니다.");
                    MessageBoxForm messageBox = new MessageBoxForm("Port가 이미 열려있습니다.");
                    messageBox.ShowDialog();
                }

                return true;
            }
            catch (Exception ex)
            {
                TraceManager.AddLog("Serial Port Open 중 Err: " + ex);
                return false;
            }
        }

        public bool portIsOpen()
        {
            if (serialPort == null || serialPort.IsOpen == false)
            {
                return false;
            }
            return true;
        }

        public void portClose()
        {
            try
            {
                if (serialPort == null)
                {
                    MessageBoxForm messageBox = new MessageBoxForm("Serial Port Close");
                    messageBox.ShowDialog();
                    return;
                }

                if (serialPort.IsOpen == true)
                {
                    serialPort.Close();
                    MessageBoxForm messageBox = new MessageBoxForm("Serial Port Close");
                    messageBox.ShowDialog();
                }

                if (sendThread != null)
                {
                    sendThread.Abort();
                }

                TraceManager.AddLog("Serial Port Close");
            }
            catch (Exception e)
            {
                TraceManager.AddLog("Port Close 중 Err: " + e.StackTrace);
                return;
            }
        }

        public void valveCtrQueue(int interval, int repeat, int valveInterval, int type)
        {
            try
            {
                List<int> valve = new List<int>() { interval, repeat, valveInterval, type };
                sendQueue.Enqueue(valve);
                string autoType = "Press diff";
                if ( type == 1)
                {
                    autoType = "Time diff";
                }

                TraceManager.AddLog("Enqueue: type=" + autoType + "interval=" + interval + "repeat=" + repeat + "valveInterval=" + valveInterval );
            }
            catch (Exception e)
            {
                TraceManager.AddLog("Valve Queue Inser Err: " + e);
                return;
            }
        }
        public void valveCtrThread()
        {
            try
            {
                int interval = 0;
                int repeat = 0;
                int valveInterval = 0;
                bool valveStatus = false;
                string type = "";

                while (true)
                {
                    if (status[0].SolValve == false && valveManual.Status == false && valveManual.Use == true)
                    {
                        if (sendQueue.Count >= 1)
                        {
                            valveManual.Use = false;

                            List<int> valve = new List<int>();
                            valve = sendQueue.Dequeue();
                            interval = valve[0];
                            repeat = valve[1];
                            valveInterval = valve[2];
                            if (valve[3] == 1)
                            {
                                type = "Time diff";
                            }
                            else
                            {
                                type = "Press diff";
                            }

                            TraceManager.AddLog("Valve Ctrol Start: type=" + type + "interval=" + interval + "repeat=" + repeat + "valveInterval=" + valveInterval);
                            RemoPipe.remopipe.listViewAdd(type, "Auto", interval, repeat);

                            for (int i = 0; i < repeat; i++)
                            {

                                if (openSolValve())
                                {
                                    TraceManager.AddLog("Valve Open");
                                   RemoPipe.remopipe.listViewAdd(type, "Valve Open", interval, repeat);
                                }
                                else
                                {
                                    TraceManager.AddLog("Valve Open Fail");
                                    RemoPipe.remopipe.listViewAdd(type, "Valve Open Fail", interval, repeat);
                                }

                                Thread.Sleep(interval);

                                if (closeSolValve())
                                {
                                    TraceManager.AddLog("Valve Close");
                                    RemoPipe.remopipe.listViewAdd(type, "Valve Close", interval, repeat);
                                }
                                else
                                {
                                    TraceManager.AddLog("Valve Close Fial");
                                    RemoPipe.remopipe.listViewAdd(type, "Valve Close Fail", interval, repeat);
                                }
                                Thread.Sleep(interval);
                            }

                            Thread.Sleep(valveInterval);
                            valveManual.Use = true;
                        }
                    }
                    Thread.Sleep(10);
                }
            }
            catch (Exception ex)
            {
                TraceManager.AddLog("valveCtrThread Err: " + ex);
            }
        }

        public bool openSolValve()
        {
            byte[] bytes = new byte[5];
            bytes[0] = 0xff;
            bytes[1] = 0x02;
            bytes[2] = (byte)SOL_VALVE_NUM;
            bytes[3] = 0x01;
            bytes[4] = (byte)(bytes[1] ^ bytes[2] ^ bytes[3]);

            return communicationBoard(bytes, false);
        }

        public bool closeSolValve()
        {
            byte[] bytes = new byte[5];
            bytes[0] = 0xff;
            bytes[1] = 0x02;
            bytes[2] = (byte)SOL_VALVE_NUM;
            bytes[3] = 0x00;
            bytes[4] = (byte)(bytes[1] ^ bytes[2] ^ bytes[3]);

            return communicationBoard(bytes, false);
        }

        public bool getAllState(int MAX_STAGE_COUNT, bool simulatorMode)
        {
            byte[] bytes = new byte[5];
            bytes[0] = 0xff;
            bytes[1] = 0x07;
            bytes[2] = 0x00;
            bytes[3] = 0x00;
            bytes[4] = (byte)(bytes[1] ^ bytes[2] ^ bytes[3]);

            return communicationBoard(bytes, simulatorMode);
        }

        private bool communicationBoard(byte[] send, bool simulatorMode)
        {
            if (serialPort == null)
            {
                MessageBoxForm messageBox = new MessageBoxForm("Port가 닫혀있습니다.");
                messageBox.ShowDialog();
                return false;
            }

            try
            {
                semaphore.WaitOne();

                byte[] command = send;


                receiveQueue.Clear();
                serialPort.DiscardInBuffer();
                serialPort.Write(command, 0, command.Length);

                bool result = false;
                if (command[1] == 0x02)
                {
                    if (command[3] == 0x01)
                    {
                        Console.WriteLine(DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff:") + "start openSolValve");
                    }
                    else
                    {
                        Console.WriteLine(DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff:") + "start closeSolValve");
                    }

                    byte[] rdata = new byte[3];
                    result = WaitInRecvData(0x00, ref rdata);
                }
                else
                {
                    Console.WriteLine(DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff:") + "start getAllState");

                    byte[] rdata = new byte[69];

                    result = WaitInRecvData(0x00, ref rdata);
                    if (result)
                    {
                        int MAX_STAGE_COUNT = 16;

                        //chksume 
                        byte chksume = rdata[68]; //52->68

                        //1 : sol valve On 0: sol valve Off
                        byte solU = rdata[0]; //U  (9-16)
                        byte solL = rdata[1]; //L  (1-8)
                        bool[] solData = getSensorInfo(solU, solL);

                        byte photoU = rdata[2];
                        byte photoL = rdata[3];
                        bool[] photoData = getSensorInfo(photoU, photoL);

                        int no = 0; //STAGE_No  0~1
                        for (int i = 36; i < 68; i += 2)
                        {
                            try
                            {
                                int rawMin = 819;
                                int rawMax = status[no].RawOffsetPresureMax;//4095
                                int rawDiff = Math.Abs(rawMax - rawMin); //3276
                                int rawData = rdata[i] << 8 | rdata[i + 1];  //RAW데이터

                                double dataMin = status[no].PresureMin;// 0;//Kpa
                                double dataMax = status[no].PresureMax;// 2.0;//Kpa
                                double dataDiff = Math.Abs(dataMax - dataMin); // 2.0
                                double dataOffset = status[no].PresureSensorOffset;// 0;
                                float dValue = 0;//L/min
                                string rd3 = "";
                                float PresureSensor = 0;


                                if (rawData <= rawMin)
                                {
                                    dValue = 0;
                                }
                                else
                                {
                                    dValue = (float)((float)(rawData - rawMin) / (float)rawDiff * 10.2);
                                }


                                if (simulatorMode == true)
                                {
                                    if (no == 0)
                                    {
                                        SimulatorMode();
                                        dValue = INLET_DEBUG;
                                    }
                                    else if (no == 2)

                                    {
                                        SimulatorMode();
                                        dValue = OUTLET_DEBUG;
                                    }

                                    rd3 = string.Format("{0:0.##}", dValue);
                                    PresureSensor = (float.Parse(rd3));

                                    status[no].PresureSensorRaw = rawData;
                                    status[no].PresureSensor = PresureSensor;
                                }
                                else
                                {
                                    rd3 = string.Format("{0:0.##}", dValue);
                                    PresureSensor = (float.Parse(rd3));

                                    status[no].PresureSensorRaw = rawData;
                                    status[no].PresureSensor = PresureSensor;

                                    float tmp = 0;

                                    // inlet 2, outlet 0 위치가 이상한 이슈가 있어서 스왑.
                                    if (no == 2)
                                    {
                                        tmp = status[0].PresureSensor;
                                        status[0].PresureSensor = status[2].PresureSensor;
                                        status[2].PresureSensor = tmp;
                                    }
                                }
                                no++;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(string.Format(DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff:") + "구형 Presure Raw Mapping Error no={0}:", no) + ex.Message + ex.StackTrace);
                            }
                        }

                        for (int i = 0; i < MAX_STAGE_COUNT - 1; i++)
                        {
                            status[i].SolValve = solData[i];
                        }
                    }
                }

                return result;

            }
            catch (Exception ex)
            {
                TraceManager.AddLog("communicationBoardErr: " + ex);
                return false;
            }
            finally
            {
                semaphore.Release();
            }

        }

        private void serialDataReceiver(object sender, SerialDataReceivedEventArgs e)
        {
            int byLength = serialPort.BytesToRead;
            byte[] rcvBytes = new byte[byLength];
            int rcv = serialPort.Read(rcvBytes, 0, byLength);
            if (byLength == rcv)
            {
                string msg = "";
                for (int i = 0; i < rcvBytes.Length; i++)
                {
                    msg += string.Format("{0:X},", rcvBytes[i]);
                    receiveQueue.Enqueue(rcvBytes[i]);
                }
                TraceManager.AddLog("msg: " + msg);
            }
            else
            {
                MessageBoxForm messageBox = new MessageBoxForm("에러를 수신하였습니다.");
                messageBox.ShowDialog();
            }
        }

        private bool WaitInRecvData(byte command, ref byte[] rdata)
        {
            try
            {
                TIME_OUT_COUNT++;

                double TOTAL_TIME_OUT = 500;
                DateTime dtmStart = DateTime.Now;
                while (true)
                {

                    TimeSpan sp = DateTime.Now - dtmStart;
                    if (sp.TotalMilliseconds > TOTAL_TIME_OUT)
                    {
                        TIME_OUT_COUNT++;
                        return false;
                    }

                    if (receiveQueue.Count > 0)
                    {
                        byte byHeader = receiveQueue.Dequeue();
                        if (byHeader == 0xFF)
                        {
                            Console.WriteLine("Recv Check 0xFF Header");

                            while (true)
                            {
                                TimeSpan sp2 = DateTime.Now - dtmStart;
                                if (sp2.TotalMilliseconds > TOTAL_TIME_OUT)
                                {
                                    TIME_OUT_COUNT++;
                                    return false;
                                }

                                if (receiveQueue.Count >= 1)
                                {
                                    byte rcommand = receiveQueue.Dequeue();

                                    //
                                    if (rcommand == 0x00 || rcommand == 0x01 || rcommand == 0x02 || rcommand == 0x08 || rcommand == 0x09)//0x00,0x01,0x02,0x08
                                    {
                                        //0x00
                                        while (true)
                                        {
                                            TimeSpan sp3 = DateTime.Now - dtmStart;
                                            if (sp3.TotalMilliseconds > TOTAL_TIME_OUT)
                                            {
                                                TIME_OUT_COUNT++;
                                                return false;
                                            }

                                            if (receiveQueue.Count >= 3)
                                            {
                                                rdata[0] = receiveQueue.Dequeue();
                                                rdata[1] = receiveQueue.Dequeue();
                                                rdata[2] = receiveQueue.Dequeue(); //checksume

                                                TraceManager.AddLog(string.Format("<<{0:X} {1:X} {2:X} {3:X} chksum={4:X}", byHeader, rcommand, rdata[0], rdata[1], rdata[2]));

                                                receiveQueue.Clear();
                                                return true;
                                            }
                                            Thread.Sleep(10);
                                        }
                                    }

                                    //센서값 읽기 상태
                                    if (rcommand == 0x07)//0x00,0x01,0x02
                                    {

                                        Console.WriteLine("Recv Check 0x07 Header");

                                        //0x00
                                        while (true)
                                        {
                                            TimeSpan sp3 = DateTime.Now - dtmStart;
                                            if (sp3.TotalMilliseconds > TOTAL_TIME_OUT)
                                            {
                                                TIME_OUT_COUNT++;
                                                return false;
                                            }

                                            if (receiveQueue.Count >= (69))
                                            {

                                                for (int i = 0; i < 69; i++)
                                                {
                                                    rdata[i] = receiveQueue.Dequeue();
                                                }
                                                TraceManager.AddLog(string.Format("<<{0:X} {1:X} {2:X} {3:X}  length = {4} chksum={5:X}", byHeader, rcommand, rdata[0], rdata[1], rdata.Length, rdata[52]));

                                                receiveQueue.Clear();
                                                return true;
                                            }
                                            System.Threading.Thread.Sleep(10);

                                        }
                                    }

                                    if (rcommand == 0x80)
                                    {
                                        TraceManager.AddLog("RECV 0x80 ERROR ############## (0x81) NORMAL STATUS CHECKSUME ERROR ###############");
                                        receiveQueue.Clear();
                                        return false;
                                    }

                                    if (rcommand == 0x81)
                                    {
                                        TraceManager.AddLog("RECV 0x81 ERROR ############## (0x81) Sol valve output A CHECK SUM ERROR ###############");
                                        receiveQueue.Clear();
                                        return false;
                                    }
                                    if (rcommand == 0x82)
                                    {
                                        TraceManager.AddLog("RECV 0x82 ERROR  ############## (0x82) Sol valve output B CHECK SUM ERROR ###############");
                                        receiveQueue.Clear();
                                        return false;
                                    }
                                    if (rcommand == 0x83)
                                    {
                                        TraceManager.AddLog("RECV 0x83 ERROR  ############## CHECK SUM ERROR ###############");
                                        receiveQueue.Clear();
                                        return false;
                                    }
                                    if (rcommand == 0x84)
                                    {
                                        TraceManager.AddLog("RECV 0x84 ERROR  ############## CHECK SUM ERROR ###############");
                                        receiveQueue.Clear();
                                        return false;
                                    }
                                    if (rcommand == 0x85)
                                    {
                                        TraceManager.AddLog("RECV 0x85 ERROR  ############## CHECK SUM ERROR ###############");
                                        receiveQueue.Clear();
                                        return false;
                                    }
                                    if (rcommand == 0x86)
                                    {
                                        TraceManager.AddLog("RECV 0x86 ERROR  ############## CHECK SUM ERROR ###############");
                                        receiveQueue.Clear();
                                        return false;
                                    }
                                    if (rcommand == 0x87)
                                    {
                                        TraceManager.AddLog("RECV 0x87 ERROR  ############## Read ALL  CHECK SUM ERROR ###############");
                                        receiveQueue.Clear();
                                        return false;
                                    }
                                    //0x07
                                }//end of 

                                Thread.Sleep(10);
                            }
                            Thread.Sleep(10);
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                TraceManager.AddLog(ex.Message + ex.StackTrace);
                return false;
            }
        }

        public bool[] getSensorInfo(byte U, byte L)
        {
            List<bool> ret = new List<bool>();

            //LOW
            for (int i = 0; i < 8; i++)
            {
                byte bData = (byte)((L >> i) & 0x01);
                ret.Add(bData == 0x01);
            }

            for (int i = 0; i < 8; i++)
            {
                byte bData = (byte)((U >> i) & 0x01);
                ret.Add(bData == 0x01);
            }

            return ret.ToArray();
        }

        public void SimulatorMode()
        {
            if (INLET_DEBUG <= 8.5)
            {
                INLET_DEBUG = 10.2F;
            }
            else
            {
                INLET_DEBUG = INLET_DEBUG - 0.5F;
            }

            if (OUTLET_DEBUG <= 0)
            {
                OUTLET_DEBUG = 10.2F;
            }
            else
            {
                OUTLET_DEBUG = OUTLET_DEBUG - 0.5F;
            }
        }
    }


}
