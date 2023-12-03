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
    public partial class frmLopUpdate : Form
    {
        SqlConnection conn;
        string sql = "";

        private string idUser, tenTiengViet, tenLatinh, status;
        private int id, idFK, loai;
        private bool ktThem;
        public bool ktThemLopUpdate
        {
            get { return ktThem; }
            set { ktThem = value; }
        }
        public string idUserLopUpdate
        {
            get { return idUser; }
            set { idUser = value; }
        }
        public int idLopUpdate
        {
            get { return id; }
            set { id = value; }
        }
        public int idFKLopUpdate
        {
            get { return idFK; }
            set { idFK = value; }
        }
        public int loaiLopUpdate
        {
            get { return loai; }
            set { loai = value; }
        }
        public string tenTiengVietLopUpdate
        {
            get { return tenTiengViet; }
            set { tenTiengViet = value; }
        }
        public string tenLatinhLopUpdate
        {
            get { return tenLatinh; }
            set { tenLatinh = value; }
        }
        public string statusLopUpdate
        {
            get { return status; }
            set { status = value; }
        }
        public frmLopUpdate()
        {
            InitializeComponent();
        }

        private void frmLopUpdate_Load(object sender, EventArgs e)
        {
            conn = Connect.ConnectDB();
            xoaTrang(ktThem);
            if (loai == 0)
                lbNganh.Text = "LỚP ĐỘNG VẬT";
            if (loai == 1)
                lbNganh.Text = "LỚP THỰC VẬT";
            txtTenTiengViet.Text = tenTiengViet;
            txtTenLatinh.Text = tenLatinh;
            cb.SelectedValue = idFK;
            if (status != null)
            {
                if (Boolean.Parse(status) == true)
                    rbtOn.Checked = true;
                if (Boolean.Parse(status) == false)
                    rbtOff.Checked = true;
            }
        }

        public void cbLoad()
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            sql = "SELECT id, name FROM Nganh WHERE loai = " + loai;
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter daCB = new SqlDataAdapter();
            daCB.SelectCommand = cmd;
            cmd.Dispose();
            conn.Close();

            DataTable dtCB = new DataTable();
            daCB.Fill(dtCB);

            DataRow r = dtCB.NewRow();
            r["name"] = "--Chọn ngành--";
            r["id"] = 0;
            dtCB.Rows.InsertAt(r, 0);

            cb.DataSource = dtCB;
            cb.DisplayMember = "name";
            cb.ValueMember = "id";
        }

        public void xoaTrang(bool b)
        {
            txtTenTiengViet.Text = "";
            txtTenLatinh.Text = "";
            rbtOn.Checked = false;
            rbtOff.Checked = true;
            cbLoad();
        }

        private void btHuy_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            if (txtTenTiengViet.Text == "" && txtTenLatinh.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên lớp!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTenTiengViet.Focus();
                return;
            }
            if (cb.SelectedIndex < 0)
            {
                MessageBox.Show("Bạn chưa chọn ngành!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cb.Focus();
                return;
            }
            if (ktThem == true)
            {
                if (MessageBox.Show("Bạn có muốn thêm lớp " + txtTenTiengViet.Text + " không?", "Thông báo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                DateTime createdAt = DateTime.Now;
                sql = "INSERT INTO Lop (name, name_latinh, loai, id_dtv_nganh, status, created_at, created_by) VALUES (N'" + txtTenTiengViet.Text.Trim() + "', N'" + txtTenLatinh.Text.Trim() + "', " + loai + ", " + cb.SelectedValue + ", " + (rbtOn.Checked == true ? 1 : 0) + ", '" + createdAt + "', " + Int32.Parse(idUser) + ")";
            }
            else
            {
                if (MessageBox.Show("Bạn có muốn sửa lớp " + tenTiengViet + " không?", "Thông báo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                DateTime updatedAt = DateTime.Now;
                sql = "UPDATE Lop SET name = N'" + txtTenTiengViet.Text.Trim() + "', name_latinh = N'" + txtTenLatinh.Text.Trim() + "', id_dtv_nganh = " + Int32.Parse(cb.SelectedValue.ToString()) + ", status = " + (rbtOn.Checked == true ? 1 : 0) + ", updated_at = '" + updatedAt + "', updated_by = " + Int32.Parse(idUser) + " WHERE id = " + id;
            }
            if (conn.State != ConnectionState.Open)
                conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();

            xoaTrang(true);
            this.Dispose();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
