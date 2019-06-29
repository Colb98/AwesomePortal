using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AwesomePortal
{
    public partial class LoginForm : Form
    {
        SinhVien s = SinhVien.getInstance();
        public LoginForm()
        {
            InitializeComponent();
        }
    }
}
