using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace removipe
{
    public partial class SettingForm : MetroFramework.Forms.MetroForm
    {
        CommonSetting newCommonSetting;
        public string receiveData;

        public SettingForm(CommonSetting commonSetting)
        {
            InitializeComponent();
            newCommonSetting = commonSetting;
        }

        private void SettingForm_Load(object sender, System.EventArgs e)
        {
            chk_press_open.Checked = newCommonSetting.ValvePressOpen;
            txt_press_interval.Text = newCommonSetting.ValvePressInterval.ToString();
            txt_press_open_value.Text = String.Format("{0,1:0.0}", newCommonSetting.ValvePressOpenValue);
            txt_press_repeat_value.Text = newCommonSetting.ValvePressRepeatValue.ToString();
            txt_press_count.Text = newCommonSetting.ValvePressCount.ToString();


            if (chk_press_open.Checked == false)
            {
                txt_press_interval.Enabled = false;
                txt_press_open_value.Enabled = false;
                txt_press_repeat_value.Enabled = false;
                txt_press_count.Enabled = false;
            }

            chk_time_open.Checked = newCommonSetting.ValveTimeOpen;
            txt_time_open_value.Text = newCommonSetting.ValveTimeOpenValue.ToString();
            txt_time_interval.Text = newCommonSetting.ValveTimeInterval.ToString();
            txt_time_repeat_value.Text = newCommonSetting.ValveTimeRepeatValue.ToString();

            if (chk_time_open.Checked == false)
            {
                txt_time_open_value.Enabled = false;
                txt_time_interval.Enabled = false;
                txt_time_repeat_value.Enabled = false;
            }

            txt_valve_interval.Text = newCommonSetting.ValveInterval.ToString();
            chk_simul_mode.Checked = newCommonSetting.SimulatorMode;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_apply_Click(object sender, EventArgs e)
        {

            if (settingValidation())
            {
                newCommonSetting.ValvePressOpen = chk_press_open.Checked;
                newCommonSetting.ValveTimeOpen = chk_time_open.Checked;

                newCommonSetting.ValvePressOpenValue = float.Parse(txt_press_open_value.Text);
                newCommonSetting.ValvePressRepeatValue = Convert.ToInt32(txt_press_repeat_value.Text);
                newCommonSetting.ValvePressInterval = Convert.ToInt32(txt_press_interval.Text);

                newCommonSetting.ValveTimeOpenValue = Convert.ToInt32(txt_time_open_value.Text);
                newCommonSetting.ValveTimeRepeatValue = Convert.ToInt32(txt_time_repeat_value.Text);
                newCommonSetting.ValveTimeInterval = Convert.ToInt32(txt_time_interval.Text);

                newCommonSetting.ValveInterval = Convert.ToInt32(txt_valve_interval.Text);

                newCommonSetting.SimulatorMode = chk_simul_mode.Checked;

                this.Close();
            }

        }

        private void chk_press_open_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_press_open.Checked == false)
            {
                txt_press_interval.Enabled = false;
                txt_press_open_value.Enabled = false;
                txt_press_repeat_value.Enabled = false;
                txt_press_count.Enabled = false;
            }
            else
            {
                txt_press_interval.Enabled = true;
                txt_press_open_value.Enabled = true;
                txt_press_repeat_value.Enabled = true;
                txt_press_count.Enabled = true;
            }
        }

        private void chk_time_open_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_time_open.Checked == false)
            {
                txt_time_open_value.Enabled = false;
                txt_time_interval.Enabled = false;
                txt_time_repeat_value.Enabled = false;
            }
            else
            {
                txt_time_open_value.Enabled = true;
                txt_time_interval.Enabled = true;
                txt_time_repeat_value.Enabled = true;
            }
        }

        private bool settingValidation()
        {
            string message = "설정완료";
            bool result = true;
            try
            {
                if (chk_press_open.Checked)
                {
                    if (0.1 > float.Parse(txt_press_open_value.Text) || 10.0 < float.Parse(txt_press_open_value.Text))
                    {
                        message = "유효하지않은 Press 차이 값입니다.";
                        result = false;
                    }
                    if (1 > Convert.ToInt32(txt_press_repeat_value.Text) || 10 < Convert.ToInt32(txt_press_repeat_value.Text))
                    {
                        message = "배수 반복횟수는 1~10회 입니다.";
                        result = false;
                    }
                    if (500 > Convert.ToInt32(txt_press_interval.Text))
                    {
                        message = "Interval은 500ms 이상입니다.";
                        result = false;
                    }
                    if (5 > Convert.ToInt32(txt_press_count.Text))
                    {
                        message = "count 최소값은 5입니다.";
                        result = false;
                    }
                }

                if (chk_time_open.Checked)
                {
                    if (1 > Convert.ToInt32(txt_time_open_value.Text))
                    {
                        message = "벨브 작동 간격은 1분 이상입니다.";
                        result = false;
                    }
                    if (1 > Convert.ToInt32(txt_time_repeat_value.Text) || 10 < Convert.ToInt32(txt_time_repeat_value.Text))
                    {
                        message = "배수 반복횟수는 1~10회 입니다.";
                        result = false;
                    }
                    if (500 > Convert.ToInt32(txt_time_interval.Text))
                    {
                        message = "Interval은 500ms 이상입니다.";
                        result = false;
                    }
                }

                if (1000 > Convert.ToInt32(txt_valve_interval.Text))
                {
                    message = "이전 배수 간격 설정은 1초 이상입니다.";
                    result = false;
                }

                MessageBoxForm messageBox = new MessageBoxForm(message);
                messageBox.ShowDialog();
            }
            catch
            {

                MessageBoxForm messageBox = new MessageBoxForm("올바르지 않은 값이 들어있습니다.");
                messageBox.ShowDialog();
                return false;
            }
 

            return result;
        }

        private void txt_press_open_value_TextChanged(object sender, EventArgs e)
        {
            ViewPassword viewPass = new ViewPassword("setting");
            viewPass.Owner = this;
            if (viewPass.ShowDialog() == DialogResult.OK)
            {
                txt_press_open_value.Text = String.Format("{0,1:0.00}", float.Parse(receiveData));
            }
        }

        private void txt_press_repeat_value_TextChanged(object sender, EventArgs e)
        {
            ViewPassword viewPass = new ViewPassword("setting");
            viewPass.Owner = this;
            if (viewPass.ShowDialog() == DialogResult.OK)
            {
                txt_press_repeat_value.Text = receiveData;
            }
        }

        private void txt_press_interval_TextChanged(object sender, EventArgs e)
        {
            ViewPassword viewPass = new ViewPassword("setting");
            viewPass.Owner = this;
            if (viewPass.ShowDialog() == DialogResult.OK)
            {
                txt_press_interval.Text = receiveData;
            }
        }

        private void txt_time_open_value_TextChanged(object sender, EventArgs e)
        {
            ViewPassword viewPass = new ViewPassword("setting");
            viewPass.Owner = this;
            if (viewPass.ShowDialog() == DialogResult.OK)
            {
                txt_time_open_value.Text = receiveData;
            }
        }

        private void txt_time_repeat_value_TextChanged(object sender, EventArgs e)
        {
            ViewPassword viewPass = new ViewPassword("setting");
            viewPass.Owner = this;
            if (viewPass.ShowDialog() == DialogResult.OK)
            {
                txt_time_repeat_value.Text = receiveData;
            }
        }

        private void txt_time_interval_TextChanged(object sender, EventArgs e)
        {
            ViewPassword viewPass = new ViewPassword("setting");
            viewPass.Owner = this;
            if (viewPass.ShowDialog() == DialogResult.OK)
            {
                txt_time_interval.Text = receiveData;
            }
        }

        private void txt_valve_interval_TextChanged(object sender, EventArgs e)
        {
            ViewPassword viewPass = new ViewPassword("setting");
            viewPass.Owner = this;
            if (viewPass.ShowDialog() == DialogResult.OK)
            {
                txt_valve_interval.Text = receiveData;
            }
        }

    }
}
