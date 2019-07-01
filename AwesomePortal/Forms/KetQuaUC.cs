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

namespace AwesomePortal.Forms
{
    public partial class KetQuaUC : UserControl
    {
        List<DangKyHocPhan> data;
        public KetQuaUC()
        {
            InitializeComponent();
            InitComboBox();
            PrepareCols();
        }

        private void InitComboBox()
        {
            cb_nam.Items.Add("Tất cả");
            cb_ky.Items.Add("Tất cả");
            cb_ky.Items.Add(1);
            cb_ky.Items.Add(2);
            cb_ky.Items.Add(3);
        }

        public void SetData(List<DangKyHocPhan> data)
        {
            this.data = data;
            SetUpComboBoxWithData();
        }

        private void SetUpComboBoxWithData()
        {
            cb_ky.Items.Clear();
            cb_nam.Items.Clear();
            InitComboBox();

            List<int> listNam = new List<int>();
            foreach (DangKyHocPhan d in data)
            {
                HocPhan h = d.hocPhan;
                for (int tiet = h.thoiGian.tietBatDau; tiet <= h.thoiGian.tietKetThuc; tiet++)
                    try
                    {
                        int nam = h.nam;
                        int ky = h.hocKy;
                        if (!listNam.Contains(nam))
                            listNam.Add(nam);
                    }
                    catch (IndexOutOfRangeException e)
                    {
                        LogHelper.Log("ERROR KetQuaUC: " + e);
                    }
            }
            listNam.Sort();
            listNam.Reverse();
            foreach (int nam in listNam)
            {
                cb_nam.Items.Add(nam);
            }
            cb_nam.SelectedIndex = 0;
        }

        public void PrepareCols()
        {
            listView1.Columns.Add("Mã học phần", 120);
            listView1.Columns.Add("Tên học phần", 200);
            listView1.Columns.Add("Số tín chỉ", 110, HorizontalAlignment.Center);
            listView1.Columns.Add("Điểm giữa kỳ", 150, HorizontalAlignment.Center);
            listView1.Columns.Add("Điểm cuối kỳ", 150, HorizontalAlignment.Center);
            listView1.Columns.Add("Điểm tổng kết", 150, HorizontalAlignment.Center);
        }

        public void RenderData()
        {
            listView1.Items.Clear();
            // Điều kiện tất cả
            if (cb_nam.SelectedIndex < 0)
                cb_nam.SelectedIndex = 0;
            if (cb_ky.SelectedIndex < 0)
                cb_ky.SelectedIndex = 0;
            int nam;
            int ky;
            if (cb_nam.SelectedIndex != 0)
                nam = Int32.Parse(cb_nam.Text);
            else
                nam = -1;
            if (cb_ky.SelectedIndex != 0)
                ky = Int32.Parse(cb_ky.Text);
            else
                ky = -1;

            int sumTinChi = 0;
            float avgTongKet = 0;
            foreach(DangKyHocPhan dk in data)
            {
                if(nam == dk.hocPhan.nam || nam == -1)
                {
                    if(ky == dk.hocPhan.hocKy || ky == -1)
                    {
                        string[] arr = new string[6];
                        arr[0] = dk.hocPhan.maHocPhan;
                        arr[1] = dk.hocPhan.tenHocPhan;
                        arr[2] = dk.hocPhan.soTinChi.ToString();
                        arr[3] = dk.diem.giuaKy.ToString();
                        arr[4] = dk.diem.cuoiKy.ToString();
                        arr[5] = dk.diem.tongKet.ToString();
                        listView1.Items.Add(new ListViewItem(arr));
                        sumTinChi += dk.hocPhan.soTinChi;
                        avgTongKet += dk.diem.tongKet * dk.hocPhan.soTinChi;
                    }
                }
            }
            avgTongKet /= sumTinChi;
            string[] tongket = new string[6];
            tongket[0] = "";
            tongket[1] = "Tổng kết";
            tongket[2] = sumTinChi.ToString();
            tongket[3] = "";
            tongket[4] = "";
            tongket[5] = avgTongKet.ToString();
            ListViewItem item = new ListViewItem(tongket);
            item.Font = new Font(listView1.Font, FontStyle.Bold);
            listView1.Items.Add(item);
        }

        private void cb_nam_SelectedIndexChanged(object sender, EventArgs e)
        {
            RenderData();
        }
    }
}
