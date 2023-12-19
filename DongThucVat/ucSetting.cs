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
    public partial class ucSetting : UserControl
    {
        SqlConnection conn;
        string sql = "";
        string fileLogo, logoPath;
        string imageFolder = ConfigurationManager.AppSettings["PictureFolder"];
        private List<string> selectedImages = new List<string>();

        public ucSetting()
        {
            InitializeComponent();
        }

        public void LoadImages()
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                string sql = "SELECT hinhanh FROM ThongTin WHERE is_image = @IsImage";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@IsImage", SqlDbType.Bit).Value = true;

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string imagePath = reader["hinhanh"].ToString();
                    if (!string.IsNullOrEmpty(imagePath))
                    {
                        selectedImages.Add(imagePath);
                    }
                }
                reader.Close();
            }
            catch (Exception ex){ }
        }

        public void layNguonNoiDung()
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            sql = "SELECT * FROM ThongTin WHERE id = " + 1;
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            cmd.Dispose();
            conn.Close();

            DataTable dt = new DataTable();
            da.Fill(dt);
            // Lấy giá trị từ dòng đầu tiên của DataTable
            fileLogo = dt.Rows[0]["logo"].ToString();
            txtTieuDe.Text = dt.Rows[0]["tieude"].ToString();
            rtxtNoiDung.Text = dt.Rows[0]["noidung"].ToString();
        }

        private void ucSetting_Load(object sender, EventArgs e)
        {
            conn = Connect.ConnectDB();
            selectedImages.Clear();
            txtFolder.Text = imageFolder;
            layNguonNoiDung();
            DisplayLogo();
            LoadImages();
            DisplayImages();
        }

        public string GenerateImagePath(string uploadedFileName)
        {
            // Kết hợp đường dẫn cố định với tên của hình ảnh được tải lên
            string fullPath = Path.Combine(imageFolder, uploadedFileName);

            return fullPath;
        }

        private void DisplayLogo()
        {
            if (fpnlLogo.Controls.Count > 0)
                fpnlLogo.Controls.Clear();
            try
            {
                if (logoPath != "")
                {
                    if (File.Exists(logoPath))
                    {
                        PictureBox pictureBox = new PictureBox();
                        pictureBox.Image = Image.FromFile(logoPath);
                        pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                        pictureBox.Width = 200;
                        pictureBox.Height = 200;
                        fpnlLogo.Controls.Add(pictureBox);
                    }
                    else
                        return;
                }
                else 
                    return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void DisplayImages()
        {
            if (fpnlHinhAnh.Controls.Count > 0)
                fpnlHinhAnh.Controls.Clear();
            foreach (string imagePath in selectedImages)
            {
                if (File.Exists(imagePath))
                {
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Image = Image.FromFile(imagePath);
                    pictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
                    pictureBox.Width = 140;
                    pictureBox.Height = 140;
                    fpnlHinhAnh.Controls.Add(pictureBox);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy ảnh!");
                }
            }
        }

        private void btChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string fileName in openFileDialog.FileNames)
                {
                    string imagePath = GenerateImagePath(Path.GetFileName(fileName));
                    selectedImages.Add(imagePath);
                }
                DisplayImages();
                MessageBox.Show("Đã chọn " + openFileDialog.FileNames.Length + " ảnh.");
            }
        }

        private void btXoaLogo_Click_1(object sender, EventArgs e)
        {
            fpnlLogo.Controls.Clear();
            fileLogo = "";
        }

        private void btChonLogo_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileLogo = openFileDialog.FileName;
                logoPath = GenerateImagePath(Path.GetFileName(fileLogo));
                DisplayLogo();
            }
        }

        private void btLuu_Click_1(object sender, EventArgs e)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            if (MessageBox.Show("Bạn có muốn sửa thông tin hiển thị không?", "Thông báo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["PictureFolder"].Value = txtFolder.Text;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");

            SqlCommand cmd = new SqlCommand("UpdateThongTin", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = 1;
            cmd.Parameters.Add("@logo", SqlDbType.NVarChar).Value = fileLogo;
            cmd.Parameters.Add("@tieude", SqlDbType.NVarChar).Value = txtTieuDe.Text;
            cmd.Parameters.Add("@noidung", SqlDbType.NVarChar).Value = rtxtNoiDung.Text;
            cmd.ExecuteNonQuery();
            cmd.Dispose();

            if (selectedImages.Count <= 0)
            {
                sql = "DELETE FROM ThongTin WHERE is_image = @IsImage";
                SqlCommand delCmd = new SqlCommand(sql, conn);
                delCmd.Parameters.Add("@IsImage", SqlDbType.Bit).Value = true;
                delCmd.ExecuteNonQuery();
                delCmd.Dispose();
            }
            if (selectedImages.Count > 0)
            {
                sql = "DELETE FROM ThongTin WHERE is_image = @IsImage";
                SqlCommand deleteCmd = new SqlCommand(sql, conn);
                deleteCmd.Parameters.Add("@IsImage", SqlDbType.Bit).Value = true;
                deleteCmd.ExecuteNonQuery();
                deleteCmd.Dispose();

                foreach (string imagePath in selectedImages)
                {
                    sql = "INSERT INTO ThongTin (is_image, hinhanh) VALUES (@IsImage, @Hinhanh)";
                    SqlCommand insCmd = new SqlCommand(sql, conn);
                    insCmd.Parameters.Add("@IsImage", SqlDbType.Bit).Value = true;
                    insCmd.Parameters.Add("@Hinhanh", SqlDbType.NVarChar).Value = imagePath;
                    insCmd.ExecuteNonQuery();
                    insCmd.Dispose();
                }
            }

            conn.Close();
            DisplayImages();
            selectedImages.Clear();
            fileLogo = "";
        }

        private void btHuy_Click_1(object sender, EventArgs e)
        {
            txtFolder.Text = imageFolder;
            layNguonNoiDung();
            DisplayLogo();
            LoadImages();
            DisplayImages();
        }

        private void btXoaAnh_Click(object sender, EventArgs e)
        {
            fpnlHinhAnh.Controls.Clear();
            selectedImages.Clear();
            DisplayImages();
        }
    }
}
