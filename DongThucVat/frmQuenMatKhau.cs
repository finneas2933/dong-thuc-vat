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
    public partial class frmQuenMatKhau : Form
    {
        SqlConnection conn;
        string sql = "";

        public frmQuenMatKhau()
        {
            InitializeComponent();
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text == "" || txtMatKhauMoi.Text == "" || txtNhapLaiMatKhau.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtEmail.Focus();
            }
            if (txtMatKhauMoi.Text != txtNhapLaiMatKhau.Text)
            {
                MessageBox.Show("Mật khẩu nhập lại chưa chính xác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNhapLaiMatKhau.Focus();
            }
            if (userCheck() == false)
            {
                MessageBox.Show("Tài khoản không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtEmail.Focus();
            }
            if (userCheck() == true && txtMatKhauMoi.Text == txtNhapLaiMatKhau.Text)
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                sql = "UPDATE [user] SET password = @Password WHERE email = @Email";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = txtMatKhauMoi.Text.Trim();
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = txtEmail.Text;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                conn.Close();
                MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK);
                this.Dispose();
            }
        }

        public bool userCheck()
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            sql = "SELECT * FROM [user] WHERE email = @Email AND is_admin = @IsAdmin";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = txtEmail.Text;
            cmd.Parameters.Add("@IsAdmin", SqlDbType.Bit).Value = rbtAdmin.Checked ? 1 : 0;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            cmd.Dispose();
            conn.Close();

            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
                return false;
        }

        private void btHuy_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btPW1_Click(object sender, EventArgs e)
        {
            if (txtMatKhauMoi.UseSystemPasswordChar == true)
            {
                txtMatKhauMoi.UseSystemPasswordChar = false;
            }
            else
            {
                txtMatKhauMoi.UseSystemPasswordChar = true;
            }
        }

        private void btPW2_Click(object sender, EventArgs e)
        {
            if (txtNhapLaiMatKhau.UseSystemPasswordChar == true)
            {
                txtNhapLaiMatKhau.UseSystemPasswordChar = false;
            }
            else
            {
                txtNhapLaiMatKhau.UseSystemPasswordChar = true;
            }
        }

        private void frmQuenMatKhau_Load(object sender, EventArgs e)
        {
            conn = Connect.ConnectDB();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
