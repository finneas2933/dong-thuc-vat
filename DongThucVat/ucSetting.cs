using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        string fileName, fileLogo;
        private List<string> selectedImages = new List<string>();

        public ucSetting()
        {
            InitializeComponent();
        }

        private void btHuy_Click(object sender, EventArgs e)
        {
            layNguonNoiDung();
            DisplayLogo();
            LoadImages();
            DisplayImages();
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            if (MessageBox.Show("Bạn có muốn sửa thông tin hiển thị không?", "Thông báo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            SqlCommand cmd = new SqlCommand("UpdateThongTin", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = 1;
            cmd.Parameters.Add("@logo", SqlDbType.NVarChar).Value = fileLogo;
            cmd.Parameters.Add("@tieude", SqlDbType.NVarChar).Value = txtTieuDe.Text;
            cmd.Parameters.Add("@noidung1", SqlDbType.NVarChar).Value = rtxtNoiDung1.Text;
            cmd.Parameters.Add("@noidung2", SqlDbType.NVarChar).Value = rtxtNoiDung2.Text;
            cmd.Parameters.Add("@noidung3", SqlDbType.NVarChar).Value = rtxtNoiDung3.Text;
            cmd.Parameters.Add("@noidung4", SqlDbType.NVarChar).Value = rtxtNoiDung4.Text;
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
            rtxtNoiDung1.Text = dt.Rows[0]["noidung1"].ToString();
            rtxtNoiDung2.Text = dt.Rows[0]["noidung2"].ToString();
            rtxtNoiDung3.Text = dt.Rows[0]["noidung3"].ToString();
            rtxtNoiDung4.Text = dt.Rows[0]["noidung4"].ToString();
        }

        private void ucSetting_Load(object sender, EventArgs e)
        {
            conn = Connect.ConnectDB();
            selectedImages.Clear();
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
                    if (File.Exists(fileLogo))
                    {
                        PictureBox pictureBox = new PictureBox();
                        pictureBox.Image = Image.FromFile(fileLogo);
                        pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                        pictureBox.Width = 300;
                        pictureBox.Height = 300;
                        fpnlLogo.Controls.Add(pictureBox);
                    }
                    else
                        return;
                }
                else 
                    return;
            }
            catch (Exception ex) { }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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
            }
        }

        private void btChonAnh_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string fileName in openFileDialog.FileNames)
                {
                    selectedImages.Add(fileName);
                }
                DisplayImages();
                MessageBox.Show("Đã chọn " + openFileDialog.FileNames.Length + " ảnh.");
            }
        }

        private void btChonLogo_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileLogo = openFileDialog.FileName;
                DisplayLogo();
            }
        }

        private void btXoaLogo_Click(object sender, EventArgs e)
        {
            fpnlLogo.Controls.Clear();
            fileLogo = "";
        }

        private void btXoaAnh_Click_1(object sender, EventArgs e)
        {
            fpnlHinhAnh.Controls.Clear();
            selectedImages.Clear();
            DisplayImages();
        }
    }
}
