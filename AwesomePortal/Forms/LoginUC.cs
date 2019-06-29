using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AwesomePortal.Controllers;

namespace AwesomePortal.Forms
{
    public partial class LoginUC : UserControl
    {
        public delegate void LoginSuccess(int errorCode);
        public event LoginSuccess OnLoginSuccess;
        public LoginUC()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            // Send some auth
            string username = textBox1.Text;
            string password = textBox2.Text;
            bool auth = await AuthChecker.sendAuth(username, password);
            // Raise an event
            if (auth)
                OnLoginSuccess(0);
            else
                OnLoginSuccess(-1);
        }
    }
}
