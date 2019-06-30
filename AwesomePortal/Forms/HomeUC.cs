using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AwesomePortal.Models;
using AwesomePortal.Controllers;

namespace AwesomePortal.Forms
{
    public partial class HomeUC : UserControl
    {
        public delegate void MoveToUserControl(string UCname);
        public event MoveToUserControl OnClickButtonNavigate;

        public HomeUC()
        {
            InitializeComponent();
        }

        // Mỗi button có tag, khi click vào gửi tag đó vào 1 event của form chính
        private void MoveToPageButton_Click(object sender, EventArgs e)
        {
            try
            {
                Button b = (Button)sender;
                OnClickButtonNavigate(b.Tag.ToString());
            }
            catch(Exception ex)
            {
                LogHelper.Log("ERROR at Home: " + ex);
            }
        }

        // Update thông tin sinh viên (mọi thứ :D)
        public async void GetSinhVienDetail()
        {
            SinhVienInfoCreator creator = new SinhVienInfoCreator(SinhVien.getInstance());
            SinhVien sv = await creator.GetSinhVienDetailAsync();
        }
    }
}
