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
    public partial class MessageBoxForm : MetroFramework.Forms.MetroForm
    {
        public MessageBoxForm(string message)
        {
            InitializeComponent();
            label.Text = message;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
