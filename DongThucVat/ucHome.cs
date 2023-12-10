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

        public ucHome()
        {
            InitializeComponent();
        }

        private void ucHome_Load(object sender, EventArgs e)
        {
            conn = Connect.ConnectDB();
            layNguonNoiDung();
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
            lbTieuDe.Text = dt.Rows[0]["tieude"].ToString();
            lbNoiDung1.Text = dt.Rows[0]["noidung1"].ToString();
            lbNoiDung2.Text = dt.Rows[0]["noidung2"].ToString();
            lbNoiDung3.Text = dt.Rows[0]["noidung3"].ToString();
        }
    }
}
