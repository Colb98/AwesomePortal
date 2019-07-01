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
        DangKyHocPhanController dkhpController = new DangKyHocPhanController();

        public DangKyHocPhanUC()
        {
            InitializeComponent();
            sinhVien = SinhVien.getInstance();
        }

        public async void RenderEverything()
        {
            ClearAllData();
            RenderInfo();
            await RenderRegistered();
            await RenderRegistable();
            RenderUnRegistable();
            GreyOutOptions();
        }
        public void ClearAllData()
        {
            label_maxtc.Text = "max_tc";
            label_nganh.Text = "nganh";
            label_namhoc.Text = "nam";
            dkhpController.Reset();

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
            label_maxtc.Text = sinhVien.maxTC.ToString();
            label_nganh.Text = info.nganh;
            //label_namhoc.Text = info.nam;
            dkhpController.maxTC = sinhVien.maxTC;
            //LogHelper.Log(info.ToString());
        }

        public async Task<bool> RenderRegistered()
        {
            List<HocPhan> listHocPhan = await new ListHocPhanCreator(sinhVien).getListRegisteredAsync();

            listView1.Columns.Add("Mã học phần", 120);
            listView1.Columns.Add("Tên học phần", 200);
            listView1.Columns.Add("Lớp", 150);
            listView1.Columns.Add("Số tín chỉ", 110);
            listView1.Columns.Add("Sĩ số", 80);
            listView1.Columns.Add("Đã đăng ký", 100);
            listView1.Columns.Add("Năm học", 120);
            for (int i = 0; i < listHocPhan.Count; i++)
            {
                string[] arr = new string[7];
                arr[0] = listHocPhan[i].maHocPhan;
                arr[1] = listHocPhan[i].tenHocPhan;
                arr[2] = listHocPhan[i].lop;
                arr[3] = listHocPhan[i].soTinChi.ToString();
                arr[4] = listHocPhan[i].maxSV.ToString();
                arr[5] = listHocPhan[i].daDK.ToString();
                arr[6] = listHocPhan[i].namHoc;
                ListViewItem item = new ListViewItem(arr);
                item.Tag = listHocPhan[i].id;
                listView1.Items.Add(item);
                dkhpController.currentTC += listHocPhan[i].soTinChi;
            }
            label_count.Text = listHocPhan.Count.ToString();
            if (listHocPhan.Count > 0)
                label_namhoc.Text = listHocPhan[0].nam.ToString() + " - " + (listHocPhan[0].nam+1).ToString();
            return true;
            //LogHelper.Log(listHocPhan[i].ToString());
        }

        public async Task<bool> RenderRegistable()
        {
            List<HocPhan> listHocPhan = await new ListHocPhanCreator(sinhVien).getListRegistableAsync();

            listView2.Columns.Add("Mã học phần", 120);
            listView2.Columns.Add("Tên học phần", 200);
            listView2.Columns.Add("Lớp", 150);
            listView2.Columns.Add("Số tín chỉ", 110);
            listView2.Columns.Add("Sĩ số", 80);
            listView2.Columns.Add("Đã đăng ký", 100);
            listView2.Columns.Add("Năm học", 120);
            for (int i = 0; i < listHocPhan.Count; i++)
            {
                string[] arr = new string[7];
                arr[0] = listHocPhan[i].maHocPhan;
                arr[1] = listHocPhan[i].tenHocPhan;
                arr[2] = listHocPhan[i].lop;
                arr[3] = listHocPhan[i].soTinChi.ToString();
                arr[4] = listHocPhan[i].maxSV.ToString();
                arr[5] = listHocPhan[i].daDK.ToString();
                arr[6] = listHocPhan[i].namHoc;
                ListViewItem item = new ListViewItem(arr);
                item.UseItemStyleForSubItems = true;
                item.Tag = listHocPhan[i].id;
                listView2.Items.Add(item);
            }
            if (listHocPhan.Count > 0)
                label_namhoc.Text = listHocPhan[0].nam.ToString() + " - " + (listHocPhan[0].nam + 1).ToString();
            return true;
        }

        public async Task<bool> RenderUnRegistable()
        {
            List<ListHocPhanCreator.HocPhanExtend> listHocPhan = await new ListHocPhanCreator(sinhVien).getListUnRegistableAsync();

            listView3.Columns.Add("Mã học phần", 120);
            listView3.Columns.Add("Tên học phần", 200);
            listView3.Columns.Add("Lớp", 150);
            listView3.Columns.Add("Số tín chỉ", 110);
            listView3.Columns.Add("Lý do", 400);
            for (int i = 0; i < listHocPhan.Count; i++)
            {
                string[] arr = new string[6];
                arr[0] = listHocPhan[i].hocPhan.maHocPhan;
                arr[1] = listHocPhan[i].hocPhan.tenHocPhan;
                arr[2] = listHocPhan[i].hocPhan.lop;
                arr[3] = listHocPhan[i].hocPhan.soTinChi.ToString();
                arr[4] = listHocPhan[i].lyDo;
                ListViewItem item = new ListViewItem(arr);
                item.UseItemStyleForSubItems = true;
                item.Tag = listHocPhan[i].hocPhan.id;
                listView3.Items.Add(item);
            }
            if (listHocPhan.Count > 0)
                label_namhoc.Text = listHocPhan[0].hocPhan.nam.ToString() + " - " + (listHocPhan[0].hocPhan.nam + 1).ToString();
            return true;
        }

        // Xám màu các môn không nên dc chọn trong list các môn có thể đăng ký
        private void GreyOutOptions()
        {
            // Reset màu
            foreach (ListViewItem item in listView2.Items)
                item.BackColor = SystemColors.Window;

            // Xám màu những môn cùng tên đã dc chọn
            foreach(ListViewItem item in listView2.CheckedItems)
            {
                string name = GetSubjectName(item.SubItems[1].Text);
                foreach(ListViewItem item2 in listView2.Items)
                {
                    if (item2 == item)
                        continue;
                    if (GetSubjectName(item2.SubItems[1].Text) == name)
                        GreyOutItem(item2);
                }
            }

            // Xám màu những môn cùng tên đã đăng ký
            foreach (ListViewItem item in listView1.Items)
            {
                string name = GetSubjectName(item.SubItems[1].Text);
                foreach (ListViewItem item2 in listView2.Items)
                {
                    if (item2 == item)
                        continue;
                    if (GetSubjectName(item2.SubItems[1].Text) == name)
                        GreyOutItem(item2);
                }
            }

            // Xám màu những môn đã đạt tối đa
            foreach (ListViewItem item in listView2.Items)
                if (item.SubItems[4].Text == item.SubItems[5].Text)
                    GreyOutItem(item);
        }

        private void GreyOutItem(ListViewItem item)
        {
            if (item.Selected)
                item.Selected = false;
            item.BackColor = SystemColors.GrayText;
        }

        private string GetSubjectName(string name)
        {
            return name;
        }

        // Trước khi chọn 1 môn, kiểm tra xem nó có thực sự có thể được chọn ko (có bị xám hay ko)
        // Kiểm tra xem đã chọn đủ số tín chỉ tối đa chưa
        private void listView2_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            bool isGreyedOut = listView2.Items[e.Index].BackColor == SystemColors.GrayText;
            if (isGreyedOut)
            {
                e.NewValue = e.CurrentValue;
                return;
            }

            int thisTC = int.Parse(listView2.Items[e.Index].SubItems[3].Text);
            if (e.NewValue == CheckState.Checked)
            {
                if (dkhpController.currentTC + thisTC > dkhpController.maxTC)
                {
                    e.NewValue = e.CurrentValue;
                    MessageBox.Show("Bạn chọn quá số tín chỉ tối đa\r\nHãy bỏ chọn bớt", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    dkhpController.currentTC += thisTC;
                }
            }
            else
            {
                dkhpController.currentTC -= thisTC;
            }
        }

        // Chọn xong 1 môn thì đánh xám màu những môn tương đương
        private void listView2_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            GreyOutOptions();
        }

        // Nếu đã xám thì ko cho select luôn
        private void listView2_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            bool isGreyedOut = e.Item.BackColor == SystemColors.GrayText;
            if (isGreyedOut && e.IsSelected)
                e.Item.Selected = false;
        }

        delegate Task<bool> PostListSubjectDelegate(List<int> list);
        private async void btn_cancel_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            ListView linkedListView;
            PostListSubjectDelegate postDelegate;
            if (button.Name == "btn_cancel")
            {
                linkedListView = listView1;
                postDelegate = dkhpController.SetListCancelled;
            }
            else if (button.Name == "btn_enrol")
            {
                linkedListView = listView2;
                postDelegate = dkhpController.SetListEnrol;
            }
            else
                return;

            List<int> listIdMon = new List<int>();
            foreach(ListViewItem item in linkedListView.CheckedItems)
            {
                listIdMon.Add((int)item.Tag);
            }
            // Nếu thành công thì load lại
            if(await postDelegate(listIdMon))
            {
                RenderEverything();
            }
        }
    }
}
