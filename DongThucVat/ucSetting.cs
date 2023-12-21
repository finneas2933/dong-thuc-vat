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
        string fileLogo;
        string pictureFolder = ConfigurationManager.AppSettings["PictureFolder"];

        private List<string> selectedImages = new List<string>();

        public event Action LogoChanged;

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
            catch { }
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
            fileLogo = "";
            txtFolder.Text = pictureFolder;
            layNguonNoiDung();
            DisplayLogo();
            LoadImages();
            DisplayImages();
        }

        private void DisplayLogo()
        {
            if (fpnlLogo.Controls.Count > 0)
                fpnlLogo.Controls.Clear();
            try
            {
                if (fileLogo != "")
                {
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Image = Image.FromFile(pictureFolder + "\\" + fileLogo);
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox.Width = 195;
                    pictureBox.Height = 195;
                    fpnlLogo.Controls.Add(pictureBox);
                }
            }
            catch
            {
                // Nếu không tìm thấy tệp hình ảnh hiển thị hình ảnh mặc định
                PictureBox pictureBox = new PictureBox();
                pictureBox.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "\\picture\\Image File.png");
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox.Width = 195;
                pictureBox.Height = 195;
                fpnlLogo.Controls.Add(pictureBox);
            }
        }

        private void DisplayImages()
        {
            if (fpnlHinhAnh.Controls.Count > 0)
                fpnlHinhAnh.Controls.Clear();
            foreach (string imageName in selectedImages)
            {
                try
                {
                    string imagePath = pictureFolder + "\\" + imageName;
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Image = Image.FromFile(imagePath);
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox.Width = 125;
                    pictureBox.Height = 125;

                    fpnlHinhAnh.Controls.Add(pictureBox);
                }
                catch
                {
                    // Nếu không tìm thấy tệp hình ảnh hiển thị hình ảnh mặc định
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "\\picture\\Image File.png");
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox.Width = 125;
                    pictureBox.Height = 125;

                    fpnlHinhAnh.Controls.Add(pictureBox);
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
                // Kiểm tra và tạo thư mục nếu chưa tồn tại
                if (!Directory.Exists(pictureFolder))
                {
                    Directory.CreateDirectory(pictureFolder);
                }

                foreach (string fileName in openFileDialog.FileNames)
                {
                    // Lấy tên của ảnh từ đường dẫn
                    string imageName = Path.GetFileName(fileName);
                    // Kiểm tra xem ảnh đã tồn tại trong thư mục cấu hình chưa
                    string imagePath = pictureFolder + "\\" + imageName;
                    if (!File.Exists(imagePath))
                    {
                        // Nếu chưa tồn tại thì copy ảnh vào thư mục cấu hình
                        File.Copy(fileName, imagePath);
                    }
                    // Thêm đường dẫn của ảnh đã chọn vào danh sách
                    selectedImages.Add(imageName);
                }

                DisplayImages();
                MessageBox.Show("Đã chọn " + openFileDialog.FileNames.Length + " ảnh.");
            }
        }

        private void btXoaLogo_Click_1(object sender, EventArgs e)
        {
            fpnlLogo.Controls.Clear();
            fileLogo = "";
            DisplayLogo();
        }

        private void btChonLogo_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
            // Kiểm tra và tạo thư mục nếu chưa tồn tại
            if (!Directory.Exists(pictureFolder))
            {
                Directory.CreateDirectory(pictureFolder);
            }
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                // Lấy tên của ảnh từ đường dẫn
                string imageName = Path.GetFileName(fileName);
                // Kiểm tra xem ảnh đã tồn tại trong thư mục cấu hình chưa
                string imagePath = pictureFolder + "\\" + imageName;
                if (!File.Exists(imagePath))
                {
                    // Nếu chưa tồn tại thì copy ảnh vào thư mục cấu hình
                    File.Copy(fileName, imagePath);
                }
                fileLogo = imageName;
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

            selectedImages.Clear();
            fileLogo = "";
            txtFolder.Text = pictureFolder;
            layNguonNoiDung();
            DisplayLogo();
            LoadImages();
            DisplayImages();

            LogoChanged?.Invoke();
        }

        private void btHuy_Click_1(object sender, EventArgs e)
        {
            txtFolder.Text = pictureFolder;
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

        private void btFolder_Click(object sender, EventArgs e)
        {
            // Tạo hộp thoại FolderBrowserDialog
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            // Hiển thị hộp thoại
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                // Lấy đường dẫn của thư mục đã chọn
                txtFolder.Text = folderBrowserDialog.SelectedPath;
            }
        }
    }
}
