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
    public partial class ucNganh : UserControl
    {
        SqlConnection conn;
        string sql = "";
        string tenTiengViet, tenLatinh, status, search;
        int id;
        DataGridViewCellMouseEventArgs vitri;

        private int loai;
        private string idUser;
        public string idUserNganh//Đọc, ghi biến nhận từ form trước
        {
            get { return idUser; }
            set {idUser = value; }
        }
        public int loaiNganh
        {
            get { return loai; }
            set {loai = value; }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            if (id == 0 || vitri == null)
            {
                MessageBox.Show("Bạn chưa chọn ngành!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            using (frmNganhUpdate frm = new frmNganhUpdate())
            {
                frm.ktThemNganhUpdate = false;
                frm.idUserNganhUpdate = idUser;
                frm.idNganhUpdate = id;
                frm.loaiNganhUpdate = loai;
                frm.tenTiengVietNganhUpdate = tenTiengViet;
                frm.tenLatinhNganhUpdate = tenLatinh;
                frm.statusNganhUpdate = status;
                frm.ShowDialog();
            }
            vitri = null;
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (id == 0 || vitri == null)
            {
                MessageBox.Show("Bạn chưa chọn ngành!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa ngành " + tenTiengViet + " không?", "Thông báo",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                sql = "DELETE FROM Nganh WHERE id = " + id;
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                conn.Close();

                dgvLoad();
                vitri = null;
            }
        }

        public ucNganh()
        {
            InitializeComponent();
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            dgvLoad();
            vitri = null;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            search = txtSearch.Text.Trim();
            dgvLoad();
        }

        private void ucNganh_Load(object sender, EventArgs e)
        {
            conn = Connect.ConnectDB();
            txtSearch.Text = "";
            dgvLoad();
            vitri = null;
        }

        public void dgvLoad()
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            if (search == "")
                sql = "SELECT * FROM Nganh WHERE loai = " + loai;
            else
                sql = "SELECT * FROM Nganh WHERE loai = " + loai + " AND (name LIKE N'%" + search + "%' OR name_latinh LIKE N'%" + search + "%')";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter daGRV = new SqlDataAdapter();
            daGRV.SelectCommand = cmd;
            cmd.Dispose();
            conn.Close();

            DataTable dtGRV = new DataTable();
            daGRV.Fill(dtGRV);

            dgv.DataSource = dtGRV;
            dgv.Refresh();
            //lbThongBao.Text = "Có " + dgvNganh.Rows.Count + " ngành động vật.";
        }

        /*
        public void layNguoncbSearch()
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            sql = "SELECT * FROM " + bang;
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter daCB = new SqlDataAdapter();
            daCB.SelectCommand = cmd;
            cmd.Dispose();
            conn.Close();

            DataTable dtCB = new DataTable();
            daCB.Fill(dtCB);

            DataRow r = dtCB.NewRow();
            r["name"] = "--Chọn cột--";
            r["id"] = 0;
            dtCB.Rows.InsertAt(r, 0);

            cbSearch.DataSource = dtCB;
            cbSearch.DisplayMember = "name";
            cbSearch.ValueMember = "id";
        }
        */

        private void btThem_Click(object sender, EventArgs e)
        {
            using (frmNganhUpdate frm = new frmNganhUpdate())
            {
                frm.ktThemNganhUpdate = true;
                frm.idUserNganhUpdate = idUser;
                frm.loaiNganhUpdate = loai;
                frm.ShowDialog();
            }
            vitri = null;
        }

        private void dgv_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgv.Rows.Count > 0)
                {
                    if (e.RowIndex >= 0)
                    {
                        vitri = e;
                        DataGridViewRow row = dgv.Rows[e.RowIndex];
                        id = Int32.Parse(row.Cells[0].Value.ToString());
                        tenTiengViet = row.Cells[1].Value.ToString();
                        tenLatinh = row.Cells[2].Value.ToString();
                        status = row.Cells[4].Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi" + ex.Message, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
