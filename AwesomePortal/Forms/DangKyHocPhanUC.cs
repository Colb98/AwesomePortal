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

        public void RenderEverything()
        {
            ClearAllData();
            RenderInfo();
            RenderRegistered();
            RenderRegistable();
            RenderUnRegistable();
        }
        public void ClearAllData()
        {
            label_maxtc.Text = "max_tc";
            label_nganh.Text = "nganh";
            label_namhoc.Text = "nam";

            listView1.Clear();
            listView2.Clear();
            listView3.Clear();
        }
        public async void RenderInfo()
        {
            SinhVienInfo info = await new SinhVienInfoCreator(sinhVien).getOveralInfo();
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

        public async void RenderRegistable()
        {
            List<HocPhan> listHocPhan = await new ListHocPhanCreator(sinhVien).getListRegistableAsync();

            listView2.Columns.Add("Mã học phần", 120);
            listView2.Columns.Add("Tên học phần", 200);
            listView2.Columns.Add("Số tín chỉ", 110);
            listView2.Columns.Add("Sĩ số", 80);
            listView2.Columns.Add("Đã đăng ký", 100);
            listView2.Columns.Add("Năm học", 120);
            for (int i = 0; i < listHocPhan.Count; i++)
            {
                string[] arr = new string[6];
                arr[0] = listHocPhan[i].maHocPhan;
                arr[1] = listHocPhan[i].tenHocPhan;
                arr[2] = listHocPhan[i].soTinChi.ToString();
                arr[3] = listHocPhan[i].maxSV.ToString();
                arr[4] = listHocPhan[i].daDK.ToString();
                arr[5] = listHocPhan[i].namHoc;
                ListViewItem item = new ListViewItem(arr);
                item.UseItemStyleForSubItems = true;
                listView2.Items.Add(item);
            }
            label_count.Text = listHocPhan.Count.ToString();
            GreyOutOptions(listView2);
        }

        public async void RenderUnRegistable()
        {
            List<ListHocPhanCreator.HocPhanExtend> listHocPhan = await new ListHocPhanCreator(sinhVien).getListUnRegistableAsync();

            listView3.Columns.Add("Mã học phần", 120);
            listView3.Columns.Add("Tên học phần", 200);
            listView3.Columns.Add("Số tín chỉ", 110);
            listView3.Columns.Add("Lý do", 400);
            for (int i = 0; i < listHocPhan.Count; i++)
            {
                string[] arr = new string[6];
                arr[0] = listHocPhan[i].hocPhan.maHocPhan;
                arr[1] = listHocPhan[i].hocPhan.tenHocPhan;
                arr[2] = listHocPhan[i].hocPhan.soTinChi.ToString();
                arr[3] = listHocPhan[i].lyDo;
                ListViewItem item = new ListViewItem(arr);
                item.UseItemStyleForSubItems = true;
                listView3.Items.Add(item);
            }
            label_count.Text = listHocPhan.Count.ToString();
        }

        private void GreyOutOptions(ListView listView)
        {
            // Reset màu
            foreach (ListViewItem item in listView.Items)
                item.BackColor = SystemColors.Window;

            // Xám màu những môn cùng tên đã dc chọn
            foreach(ListViewItem item in listView.CheckedItems)
            {
                string name = GetSubjectName(item.SubItems[1].Text);
                foreach(ListViewItem item2 in listView.Items)
                {
                    if (item2 == item)
                        continue;
                    if (GetSubjectName(item2.SubItems[1].Text) == name)
                        GreyOutItem(item2);
                }
            }

            // Xám màu những môn đã đạt tối đa
            foreach (ListViewItem item in listView.Items)
                if (item.SubItems[3].Text == item.SubItems[4].Text)
                    GreyOutItem(item);
        }

        private void GreyOutItem(ListViewItem item)
        {
            if (item.Selected)
                item.Selected = false;
            item.BackColor = SystemColors.GrayText;
        }

        private string GetSubjectName(string nameAndClass)
        {
            return nameAndClass.Substring(0, nameAndClass.LastIndexOf(' '));
        }

        private void listView2_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            bool isGreyedOut = listView2.Items[e.Index].BackColor == SystemColors.GrayText;
            if (isGreyedOut)
                e.NewValue = e.CurrentValue;
        }

        private void listView2_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            GreyOutOptions(listView2);
        }

        private void listView2_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            bool isGreyedOut = e.Item.BackColor == SystemColors.GrayText;
            if (isGreyedOut && e.IsSelected)
                e.Item.Selected = false;
        }
    }
}
