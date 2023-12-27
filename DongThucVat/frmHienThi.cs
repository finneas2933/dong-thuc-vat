using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DongThucVat
{
    public partial class frmHienThi : Form
    {
        string pictureFolder = ConfigurationManager.AppSettings["PictureFolder"];

        SqlConnection conn;
        private List<string> hinhAnhList = new List<string>();
        private string id;
        public string IdHienThi { get => id; set => id = value; }

        public frmHienThi()
        {
            InitializeComponent();
        }

        private void frmHienThi_Load(object sender, EventArgs e)
        {
            conn = Connect.ConnectDB();
            layNguonNoiDung();
        }

        public void hinhAnhLoad()
        {
            try
            {
                string loaiFolderPath = pictureFolder + "\\" + id.ToString();
                try
                {
                    if (Directory.Exists(loaiFolderPath))
                    {
                        // Lấy tất cả các đường dẫn file trong thư mục
                        string[] allFiles = Directory.GetFiles(loaiFolderPath);
                        // Lọc ra các file ảnh (có thể thêm các định dạng file ảnh khác vào đây)
                        string[] imageExtensions = { ".jpg", ".jpeg", ".png" };
                        //string[] imageFiles = Directory.GetFiles(loaiFolderPath, "*.jpg;*.jpeg;*.png");
                        foreach (string filePath in allFiles)
                        {
                            string extension = Path.GetExtension(filePath).ToLower();

                            if (Array.Exists(imageExtensions, e => e == extension))
                            {
                                hinhAnhList.Add(filePath);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
                foreach (string imageName in hinhAnhList)
                {
                    if (File.Exists(imageName))
                    {
                        PictureBox pictureBox = new PictureBox();
                        pictureBox.Image = Image.FromFile(imageName);
                        pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                        pictureBox.Width = 200;
                        pictureBox.Height = 200;

                        // Gán sự kiện Click để mở ảnh phóng to
                        pictureBox.Click += pictureBox_Click;

                        fpnlHinhAnh.Controls.Add(pictureBox);
                    }
                    else
                    {
                        // MessageBox.Show("Không tìm thấy ảnh: " + imagePath);
                        // Nếu không tìm thấy tệp hình ảnh hiển thị hình ảnh mặc định
                        PictureBox pictureBox = new PictureBox();
                        pictureBox.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "\\picture\\Image File.png");
                        pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                        pictureBox.Width = 200;
                        pictureBox.Height = 200;
                        fpnlHinhAnh.Controls.Add(pictureBox);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            // Lấy PictureBox được nhấp
            PictureBox pictureBox = sender as PictureBox;

            if (pictureBox != null)
            {
                // Tạo cửa sổ mới và chuyển ảnh phóng to vào đó
                frmZoomAnh frm = new frmZoomAnh(pictureBox.Image);
                frm.ShowDialog();
            }
        }

        public void layNguonNoiDung()
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            SqlCommand cmd = new SqlCommand("HienThi", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = Int32.Parse(id);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            cmd.Dispose();
            conn.Close();

            DataTable dt = new DataTable();
            da.Fill(dt);
            // Lấy giá trị từ dòng đầu tiên của DataTable
            lbTenTiengViet.Text = dt.Rows[0]["TenTiengViet"].ToString();
            lbTenLatinh.Text = dt.Rows[0]["TenLatinh"].ToString();
            lbTenKhac.Text = dt.Rows[0]["TenKhac"].ToString();
            lbHo.Text = dt.Rows[0]["Ho"].ToString();
            lbBo.Text = dt.Rows[0]["Bo"].ToString();
            lbLop.Text = dt.Rows[0]["Lop"].ToString();
            lbNganh.Text = dt.Rows[0]["Nganh"].ToString();
            lbUICN.Text = dt.Rows[0]["muc_do_bao_ton_iucn"].ToString();
            lbSDVN.Text = dt.Rows[0]["muc_do_bao_ton_sdvn"].ToString();
            lbND84.Text = dt.Rows[0]["muc_do_bao_ton_ndcp"].ToString();
            lbND64.Text = dt.Rows[0]["muc_do_bao_ton_nd64cp"].ToString();
            rtxtDacDiem.Text = dt.Rows[0]["dac_diem"].ToString(); ;
            rtxtCongDung.Text = dt.Rows[0]["gia_tri_su_dung"].ToString();

            hinhAnhLoad();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmHienThi_Shown(object sender, EventArgs e)
        {
            this.AutoScrollPosition = new Point(-10, -10);
        }
    }
}
