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
    public partial class DangKyHocPhanUC : UserControl
    {
        SinhVien sinhVien;
        public DangKyHocPhanUC()
        {
            InitializeComponent();
            sinhVien = SinhVien.getInstance();
        }

        public async void RenderEverything()
        {
            RenderInfo();
            RenderRegistered();
        }
        public async void RenderInfo()
        {
            SinhVienInfo info = await new SinhVienInfoCreator(sinhVien).getInfoAsync();
            if (info == null)
            {
                LogHelper.Log("Can't get info!");
                throw new Exception();
            }
            //label_count.Text = info.curCount;
            label_maxtc.Text = info.maxTC;
            label_nganh.Text = info.nganh;
            label_namhoc.Text = info.nam;
            //LogHelper.Log(info.ToString());
        }

        public async void RenderRegistered()
        {
            List<HocPhan> listHocPhan = await new ListHocPhanCreator(sinhVien).getListRegisteredAsync();

            listView1.Columns.Add("Mã học phần", 120);
            listView1.Columns.Add("Tên học phần", 200);
            listView1.Columns.Add("Số tín chỉ", 110);
            listView1.Columns.Add("Sĩ số", 80);
            listView1.Columns.Add("Đã đăng ký", 100);
            listView1.Columns.Add("Năm học", 120);
            for (int i = 0; i < listHocPhan.Count; i++)
            {
                string[] arr = new string[6];
                arr[0] = listHocPhan[i].maHocPhan;
                arr[1] = listHocPhan[i].tenHocPhan;
                arr[2] = listHocPhan[i].soTinChi.ToString();
                arr[3] = listHocPhan[i].maxSV.ToString();
                arr[4] = listHocPhan[i].daDK.ToString();
                arr[5] = listHocPhan[i].namHoc;
                listView1.Items.Add(new ListViewItem(arr));
            }
            label_count.Text = listHocPhan.Count.ToString();
            //LogHelper.Log(listHocPhan[i].ToString());
        }
    }
}
