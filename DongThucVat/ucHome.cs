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
    public partial class ucHome : UserControl
    {
        SqlConnection conn;
        string sql = "";
        int t;
        string pictureFolder = ConfigurationManager.AppSettings["PictureFolder"];
        string defaultImagePath = AppDomain.CurrentDomain.BaseDirectory + "\\picture\\Image File.png";

        private List<string> imagePaths = new List<string>();
        private int currentImageIndex = 0;
        private Timer imageTimer = new Timer();

        public ucHome()
        {
            InitializeComponent();
        }

        private void ucHome_Load(object sender, EventArgs e)
        {
            conn = Connect.ConnectDB();
            LoadText();
            LoadImagePathsFromDatabase(); // Lấy đường dẫn ảnh từ cơ sở dữ liệu
            InitializeImageTimer();
            //InitializeTextTimer();
        }

        private void LoadImagePathsFromDatabase()
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            sql = "SELECT hinhanh FROM ThongTin WHERE is_image = 1";
            SqlCommand command = new SqlCommand(sql, conn);
            try
            {
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string imageName = reader["hinhanh"].ToString();
                        string imagePath = pictureFolder + "\\" + imageName;
                        if (File.Exists(imagePath))
                        {
                            imagePaths.Add(imagePath);
                        }
                        else
                        {
                            imagePaths.Add(defaultImagePath);
                        }
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        public void LoadText()
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            sql = "SELECT text_effect FROM ThongTin WHERE id = 1";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            cmd.Dispose();
            conn.Close();

            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                // Lấy giá trị từ dòng đầu tiên của DataTable
                txtWelcome.Text = dt.Rows[0]["text_effect"].ToString() + " ";
            }
        }

        private void ImageTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem có ảnh trong danh sách không
                if (imagePaths.Count > 0)
                {
                    // Hiển thị ảnh tiếp theo
                    pbHome.ImageLocation = imagePaths[currentImageIndex];
                    currentImageIndex = (currentImageIndex + 1) % imagePaths.Count;
                }
            }
            catch { }
        }

        private void InitializeImageTimer()
        {
            imageTimer.Interval = 1500; // Thời gian chuyển đổi giữa các ảnh
            imageTimer.Tick += ImageTimer_Tick;
            imageTimer.Start();
        }

        //private void InitializeTextTimer()
        //{
        //    //textTimer.Interval = 200;
        //    //textTimer.Tick += Texttimer_Tick;
        //    textTimer.Start();
        //}

        //private void Texttimer_Tick(object sender, EventArgs e)
        //{
        //    //string x = lbTextRun.Text.Substring(0, 1);
        //    //string y = lbTextRun.Text.Substring(1) + x;
        //    //lbTextRun.Text = y;
        //    t = 200;
        //    if (t == lbTextRun.Left)
        //    {
        //        lbTextRun.Left = -300;
        //    }
        //    else
        //    {
        //        lbTextRun.Left = lbTextRun.Left + 2;
        //    }

        //}
    }
}
