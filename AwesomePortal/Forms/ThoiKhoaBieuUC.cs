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
    public partial class ThoiKhoaBieuUC : UserControl
    {
        // Năm, kì, thứ, tiết
        private string[,,,] data = new string[99, 4, 8, 13];
        public ThoiKhoaBieuUC()
        {
            InitializeComponent();
            LoadTableHeaders();
            SetUpComboBox();
        }

        private void SetUpComboBox()
        {
            for(int i=1;i<=3;i++)
                cb_ky.Items.Add(i);
            cb_ky.SelectedIndex = 0;
        }

        public void SetData(List<HocPhan> hocPhans)
        {
            List<int> listNam = new List<int>();
            foreach(HocPhan h in hocPhans)
            {
                for (int tiet = h.thoiGian.tietBatDau; tiet <= h.thoiGian.tietKetThuc; tiet++)
                    try
                    {
                        int nam = Int32.Parse(h.namHoc.Split('-')[0]);
                        int ky = h.hocKy;
                        if (!listNam.Contains(nam))
                            listNam.Add(nam);
                        data[nam-2000, ky, h.thoiGian.thu, tiet] = h.tenHocPhan;
                    }
                    catch(IndexOutOfRangeException e)
                    {
                        LogHelper.Log("ERROR TKB UC: " + e);
                    }
            }
            foreach(int nam in listNam)
            {
                cb_nam.Items.Add(nam);
            }
            cb_nam.SelectedIndex = 0;
        }

        public void SetData(List<DangKyHocPhan> dangKyHocPhans)
        {
            List<HocPhan> arr = new List<HocPhan>();
            foreach(var d in dangKyHocPhans)
            {
                arr.Add(d.hocPhan);
            }
            SetData(arr);
        }

        public void RenderData()
        {
            int nRows = tableLayoutPanel1.RowCount;
            int nCols = tableLayoutPanel1.ColumnCount;
            int nam = Int32.Parse(cb_nam.Text);
            int ky = Int32.Parse(cb_ky.Text);
            for (int row = 1; row < nRows; row++)
            {
                for (int col = 1; col < nCols; col++)
                {
                    SetCellLabel(row, col, data[nam-2000, ky, col, row]);
                }
            }
        }

        private void LoadTableHeaders()
        {
            int nRows = tableLayoutPanel1.RowCount;
            int nCols = tableLayoutPanel1.ColumnCount;
            for(int row = 0; row < nRows; row++)
            {
                for(int col = 0; col < nCols; col++)
                {
                    if(row != 0 && col == 0)
                    {
                        SetHeaderCellLabel(row, col, row.ToString());
                    }
                    if(row == 0 && col != 0)
                    {
                        SetHeaderCellLabel(row, col, "Thứ " + (col + 1));
                    }
                }
            }
        }

        private void SetHeaderCellLabel(int row, int col, string text)
        {
            Label label = new Label();
            label.Text = text;
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.BackColor = Color.Transparent;
            label.ForeColor = Color.GhostWhite;
            label.Font = new Font(label.Font.FontFamily, 13f, FontStyle.Bold);
            label.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(label, col, row);
        }
        private void SetCellLabel(int row, int col, string text)
        {
            Label label = new Label();
            label.Text = text;
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.BackColor = Color.Transparent;
            label.Font = new Font(label.Font.FontFamily, 13f, FontStyle.Regular);
            label.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(label, col, row);
        }

        private void tableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            int top = e.CellBounds.Top, bot = e.CellBounds.Bottom, left = e.CellBounds.Left, right = e.CellBounds.Right;
            if (e.Row == 0 || e.Column == 0)
            {
                e.Graphics.FillRectangle(Brushes.Gray, e.CellBounds);
            }

            if (e.Row == 0 || e.Row == 6)
            {
                e.Graphics.DrawLine(new Pen(Brushes.Black, 2), new Point(left, bot), new Point(right, bot));
            }

            e.Graphics.DrawLine(new Pen(Brushes.Black, 2), new Point(right, top), new Point(right, bot));
        }
        

        private void cb_ky_TextChanged(object sender, EventArgs e)
        {
            RenderData();
        }
    }
}
