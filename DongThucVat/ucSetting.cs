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
        string fileName;
        public ucSetting()
        {
            InitializeComponent();
        }

        private void btHuy_Click(object sender, EventArgs e)
        {
            layNguonNoiDung();
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
            cmd.Parameters.Add("@logo", SqlDbType.NVarChar).Value = fileName;
            cmd.Parameters.Add("@tieude", SqlDbType.NVarChar).Value = txtTieuDe.Text;
            cmd.Parameters.Add("@noidung1", SqlDbType.NVarChar).Value = rtxtNoiDung1.Text;
            cmd.Parameters.Add("@noidung2", SqlDbType.NVarChar).Value = rtxtNoiDung2.Text;
            cmd.Parameters.Add("@noidung3", SqlDbType.NVarChar).Value = rtxtNoiDung3.Text;

            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
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
            fileName = dt.Rows[0]["logo"].ToString();
            txtTieuDe.Text = dt.Rows[0]["tieude"].ToString();
            rtxtNoiDung1.Text = dt.Rows[0]["noidung1"].ToString();
            rtxtNoiDung2.Text = dt.Rows[0]["noidung2"].ToString();
            rtxtNoiDung3.Text = dt.Rows[0]["noidung3"].ToString();
        }

        private void ucSetting_Load(object sender, EventArgs e)
        {
            conn = Connect.ConnectDB();
            layNguonNoiDung();
            DisplayImages();
        }

        private void DisplayImages()
        {
            try
            {
                if (fileName != "")
                {
                    if (File.Exists(fileName))
                    {
                        PictureBox pictureBox = new PictureBox();
                        pictureBox.Image = Image.FromFile(fileName);
                        pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                        pictureBox.Width = 300;
                        pictureBox.Height = 300;
                        fpnlHinhAnh.Controls.Add(pictureBox);
                    }
                    else
                        return;
                }
                else 
                    return;
            }
            catch (Exception ex) { }
        }

        private void btChonAnh_Click(object sender, EventArgs e)
        {
            if (fpnlHinhAnh.Controls.Count > 0)
                fpnlHinhAnh.Controls.Clear();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialog.FileName;
                DisplayImages();
            }
        }

        private void btXoaAnh_Click(object sender, EventArgs e)
        {
            fpnlHinhAnh.Controls.Clear();
            fileName = "";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
