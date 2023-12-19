using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
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
            LoadImagePathsFromDatabase(); // Lấy đường dẫn ảnh từ cơ sở dữ liệu
            InitializeImageTimer();
        }

        private void LoadImagePathsFromDatabase()
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            sql = "SELECT hinhanh FROM ThongTin";
            SqlCommand command = new SqlCommand(sql, conn);
            try
            {
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string imagePath = reader["hinhanh"].ToString();
                        imagePaths.Add(imagePath);
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void ImageTimer_Tick(object sender, EventArgs e)
        {
            // Kiểm tra xem có ảnh trong danh sách không
            if (imagePaths.Count > 0)
            {
                // Hiển thị ảnh tiếp theo
                pbHome.ImageLocation = imagePaths[currentImageIndex];
                currentImageIndex = (currentImageIndex + 1) % imagePaths.Count;
            }
            else
            {
                MessageBox.Show("Không tìm thấy ảnh!");
            }
        }

        private void InitializeImageTimer()
        {
            imageTimer.Interval = 1500; // Thời gian chuyển đổi giữa các ảnh
            imageTimer.Tick += ImageTimer_Tick;
            imageTimer.Start();
        }
    }
}
