using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DongThucVat
{
    public partial class ucHome : UserControl
    {
        public ucHome()
        {
            InitializeComponent();
        }
        /*
        private List<Loai> loadHinhAnhLoai(DataGridView dataGridView)
        {
            List<Loai> loaiDataList = new List<Loai>();

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                // Kiểm tra nếu dòng không phải là dòng trống hoặc dòng mới
                if (!row.IsNewRow)
                {
                    Loai loaiData = new Loai
                    {
                        ImagePath = row.Cells["hinhanh"].Value?.ToString(),
                        Nganh = row.Cells["Nganh"].Value?.ToString(),
                        Lop = row.Cells["Lop"].Value?.ToString(),
                        Bo = row.Cells["Bo"].Value?.ToString(),
                        Ho = row.Cells["Ho"].Value?.ToString()
                    };

                    loaiDataList.Add(loaiData);
                }
            }
            foreach (var loaiData in loaiDataList)
            {
                // Tạo Panel cho mỗi loài thực vật
                Panel pnl = taoPanel(
                    loaiData.ImagePath,
                    loaiData.Nganh,
                    loaiData.Lop,
                    loaiData.Bo,
                    loaiData.Ho
                );

                // Thêm Panel con vào FlowLayoutPanel chính
                fpnlKetQua.Controls.Add(pnl);
            }
            loaiDataList.Clear();
        }


        private Panel taoPanel(string imagePath, string nganh, string lop, string bo, string ho)
        {
            // Tạo Panel mới
            Panel plantPanel = new Panel();
            plantPanel.Width = 200;
            plantPanel.Height = 150;

            // Tạo PictureBox để hiển thị hình ảnh
            PictureBox pictureBox = new PictureBox();
            pictureBox.ImageLocation = imagePath; // Đường dẫn đến hình ảnh
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Dock = DockStyle.Top;
            pictureBox.Height = 100;

            // Tạo các Label để hiển thị thông tin
            Label nganhLabel = new Label();
            nganhLabel.Text = "Ngành: " + nganh;
            nganhLabel.Dock = DockStyle.Top;

            Label lopLabel = new Label();
            lopLabel.Text = "Lớp: " + lop;
            lopLabel.Dock = DockStyle.Top;

            Label boLabel = new Label();
            boLabel.Text = "Bộ: " + bo;
            boLabel.Dock = DockStyle.Top;

            Label hoLabel = new Label();
            hoLabel.Text = "Họ: " + ho;
            hoLabel.Dock = DockStyle.Top;

            // Thêm PictureBox và Labels vào Panel
            plantPanel.Controls.Add(pictureBox);
            plantPanel.Controls.Add(nganhLabel);
            plantPanel.Controls.Add(lopLabel);
            plantPanel.Controls.Add(boLabel);
            plantPanel.Controls.Add(hoLabel);

            return plantPanel;
        }


        private class Loai
        {
            public string ImagePath { get; set; }
            public string Nganh { get; set; }
            public string Lop { get; set; }
            public string Bo { get; set; }
            public string Ho { get; set; }
        }
        */
    }
}
