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
    public partial class frmNganhUpdate : Form
    {
        SqlConnection conn;
        string sql = "";

        private string idUser, tenTiengViet, tenLatinh, status;
        private int id, loai;
        private bool ktThem;
        public bool ktThemNganhUpdate
        {
            get { return ktThem; }
            set { ktThem = value; }
        }
        public string idUserNganhUpdate
        {
            get { return idUser; }
            set { idUser = value; }
        }
        public int idNganhUpdate
        {
            get { return id; }
            set { id = value; }
        }
        public int loaiNganhUpdate
        {
            get { return loai; }
            set { loai = value; }
        }
        public string tenTiengVietNganhUpdate
        {
            get { return tenTiengViet; }
            set { tenTiengViet = value; }
        }
        public string tenLatinhNganhUpdate
        {
            get { return tenLatinh; }
            set { tenLatinh = value; }
        }
        public string statusNganhUpdate
        {
            get { return status; }
            set { status = value; }
        }

        public void xoaTrang(bool b)
        {
            txtTenTiengViet.Text = "";
            txtTenLatinh.Text = "";
            rbtOn.Checked = false;
            rbtOff.Checked = true;
        }

        private void btHuy_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            if (txtTenTiengViet.Text == "" && txtTenLatinh.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên ngành!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTenTiengViet.Focus();
                return;
            }
            if (ktThem == true)
            {
                if (MessageBox.Show("Bạn có muốn thêm ngành " + txtTenTiengViet.Text + " không?", "Thông báo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                DateTime createdAt = DateTime.Now;
                sql = "INSERT INTO Nganh (name, name_latinh, loai, status, created_at, created_by) VALUES (N'" + txtTenTiengViet.Text.Trim() + "', N'" + txtTenLatinh.Text.Trim() + "', " + loai + ", " + (rbtOn.Checked == true ? 1 : 0) + ", '" + createdAt + "', " + Int32.Parse(idUser) + ")";
            }
            else
            {
                if (MessageBox.Show("Bạn có muốn sửa ngành " + tenTiengViet + " không?", "Thông báo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                DateTime updatedAt = DateTime.Now;
                sql = "UPDATE Nganh SET name = N'" + txtTenTiengViet.Text.Trim() + "', name_latinh = N'" + txtTenLatinh.Text.Trim() + "', status = " + (rbtOn.Checked == true ? 1 : 0) + ", updated_at = '" + updatedAt + "', updated_by = " + Int32.Parse(idUser) + " WHERE id = " + id;
            }
            if (conn.State != ConnectionState.Open)
                conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();

            // Gọi sự kiện DataUpdatedEvent để thông báo rằng dữ liệu đã được cập nhật
            //DataUpdatedEvent?.Invoke();
            xoaTrang(true);
            this.Dispose();
        }

        private void frmNganhUpdate_Load(object sender, EventArgs e)
        {
            conn = Connect.ConnectDB();
            xoaTrang(ktThem);
            if (loai == 0)
                lbNganh.Text = "NGÀNH ĐỘNG VẬT";
            if (loai == 1)
                lbNganh.Text = "NGÀNH THỰC VẬT";
            txtTenTiengViet.Text = tenTiengViet;
            txtTenLatinh.Text = tenLatinh;
            if (status != null)
            {
                if (Boolean.Parse(status) == true)
                    rbtOn.Checked = true;
                if (Boolean.Parse(status) == false)
                    rbtOff.Checked = true;
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public frmNganhUpdate()
        {
            InitializeComponent();
        }
    }
}
