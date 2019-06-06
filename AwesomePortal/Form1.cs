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
    public partial class Form1 : Form
    {
        SinhVien s;
        public Form1()
        {
            InitializeComponent();
            Button b = new Button();
            b.Text = "Đăng nhập";
            b.Click += B_Click;
            Button b2 = new Button();
            b2.Text = "Đăng xuất";
            b2.Click += B1_Click;
            b2.Location = new Point(50, 50);
            this.Controls.Add(b);
            this.Controls.Add(b2);
        }

        private void B1_Click(object sender, EventArgs e)
        {
            s.DangXuat();
        }

        private void B_Click(object sender, EventArgs e)
        {
            s = new SinhVien();
            s.DangNhap("aa", "bb");
        }
    }
}
