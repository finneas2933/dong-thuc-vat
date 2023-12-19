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
    public partial class ucGioiThieu : UserControl
    {
        SqlConnection conn;
        string sql = "";

        public ucGioiThieu()
        {
            InitializeComponent();
        }

        private void ucGioiThieu_Load(object sender, EventArgs e)
        {
            conn = Connect.ConnectDB();
            layNguonNoiDung();
        }

        public void layNguonNoiDung()
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            sql = "SELECT noidung FROM ThongTin WHERE id = " + 1;
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            cmd.Dispose();
            conn.Close();

            DataTable dt = new DataTable();
            da.Fill(dt);
            // Lấy giá trị từ dòng đầu tiên của DataTable
            lbNoiDung.Text = dt.Rows[0]["noidung"].ToString();
        }
    }
}
