using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace removipe
{
    public partial class ViewPassword : Form
    {
        string value;
        public ViewPassword(string obj)
        {
            InitializeComponent();

            value = obj;
            this.txtPwd.Text = ""; //Debug
            this.Dock = DockStyle.Fill;
        }

        string _inputKey = "";
        private void Number_Click(object sender, EventArgs e)
        {
            Button pic = sender as Button;
            string key = pic.Tag.ToString();

            if (key.Equals("c"))
            {
                if (_inputKey.Length > 0)
                {
                    _inputKey = "";

                }
            }
            else if (key.Equals("e"))
            {
                _inputKey = txtPwd.Text.ToString();
                if (_inputKey == "")
                {
                    MessageBoxForm messageBox = new MessageBoxForm("입력값이 없습니다.");
                    messageBox.ShowDialog();
                }
                else
                {
                    if (value == "main")
                    {
                        DialogResult = DialogResult.OK;
                        RemoPipe remoPipe = (RemoPipe)Owner;
                        remoPipe.receivePassword = _inputKey;
                    }
                    else
                    {
                        DialogResult = DialogResult.OK;
                        SettingForm settingForm = (SettingForm)Owner;
                        settingForm.receiveData = txtPwd.Text.ToString();
                    }
                    this.Close();
                }
            }
            else if (key.Equals("."))
            {
                _inputKey += ".";

            }
            else if (key.Equals("cancel"))
            {
                DialogResult = DialogResult.No;
                this.Close();
            }
            else
            {
                _inputKey += key;
            }

            this.txtPwd.Text = _inputKey;
            Thread.Sleep(10);
        }
    }
}
