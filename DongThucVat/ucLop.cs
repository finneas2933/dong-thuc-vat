using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DongThucVat
{
    public partial class ucLop : UserControl
    {
        SqlConnection conn;
        string sql = "";
        string tenTiengViet, tenLatinh, status;
        int id, idFK;
        DataGridViewCellMouseEventArgs vitri;

        private int loai;
        private string idUser;
        public string idUserLop//Đọc, ghi biến nhận từ form trước
        {
            get { return idUser; }
            set { idUser = value; }
        }
        public int loaiLop
        {
            get { return loai; }
            set { loai = value; }
        }

        public ucLop()
        {
            InitializeComponent();
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            using (frmLopUpdate frm = new frmLopUpdate())
            {
                frm.ktThemLopUpdate = true;
                frm.idUserLopUpdate = idUser;
                frm.loaiLopUpdate = loai;
                frm.loadDGV += dgvLoad;
                frm.ShowDialog();
            }
            vitri = null;
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            if (id == 0 || vitri == null)
            {
                MessageBox.Show("Bạn chưa chọn lớp!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            using (frmLopUpdate frm = new frmLopUpdate())
            {
                frm.ktThemLopUpdate = false;
                frm.idUserLopUpdate = idUser;
                frm.idLopUpdate = id;
                frm.idFKLopUpdate = idFK;
                frm.loaiLopUpdate = loai;
                frm.tenTiengVietLopUpdate = tenTiengViet;
                frm.tenLatinhLopUpdate = tenLatinh;
                frm.statusLopUpdate = status;
                frm.loadDGV += dgvLoad;
                frm.ShowDialog();
            }
            vitri = null;
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (id == 0 || vitri == null)
                {
                    MessageBox.Show("Bạn chưa chọn lớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (MessageBox.Show("Bạn có muốn xóa lớp " + tenTiengViet + " không?", "Thông báo",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    sql = "DELETE FROM Lop WHERE id = " + id;
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    conn.Close();

                    vitri = null;
                    cbLoad();
                    dgvLoad();
                }
            }
            catch (SqlException ex)
            {
                // Lỗi xảy ra khi có dữ liệu liên quan
                if (ex.Number == 547)
                {
                    MessageBox.Show("Không thể xóa dữ liệu này do có dữ liệu liên quan!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Xử lý các loại lỗi khác
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            cbLoad();
            dgvLoad();
            vitri = null;
        }

        private void ucLop_Load(object sender, EventArgs e)
        {
            conn = Connect.ConnectDB();
            cbLoad();
            dgvLoad();
            vitri = null;
        }

        public void dgvLoad()
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            if (idFK == 0)
                sql = "SELECT lp.*, n.name AS namefk FROM Lop lp JOIN Nganh n ON lp.id_dtv_nganh= n.id WHERE lp.loai = " + loai;
            else
                sql = "SELECT lp.*, n.name AS namefk FROM Lop lp JOIN Nganh n ON lp.id_dtv_nganh= n.id WHERE lp.loai = " + loai + " AND lp.id_dtv_nganh = " + cb.SelectedValue;
                //sql = "SELECT * FROM Lop WHERE loai = " + loai + " AND id_dtv_nganh = " + idFK + "AND (name LIKE N'%" + search + "%' OR name_latinh LIKE N'%" + search + "%')";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter daGRV = new SqlDataAdapter();
            daGRV.SelectCommand = cmd;
            cmd.Dispose();
            conn.Close();

            DataTable dtGRV = new DataTable();
            daGRV.Fill(dtGRV);

            dgv.DataSource = dtGRV;
            dgv.Refresh();
        }

        private void dgv_CellMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
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
                        idFK = Int32.Parse(row.Cells[4].Value.ToString());
                        status = row.Cells[5].Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi" + ex.Message, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb.SelectedItem is DataRowView selectedItem)
            {
                // Lấy giá trị từ cột "id" trong DataRowView
                if (int.TryParse(selectedItem["id"].ToString(), out int intValue))
                {
                    // Giá trị đã được chuyển đổi thành kiểu int (intValue)
                    idFK = intValue;
                    vitri = null;
                }
                else
                {
                    // Xử lý trường hợp không chuyển đổi được sang int
                    idFK = 0;
                }
            }
            dgvLoad();
            vitri = null;
        }

        /*
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            search = txtSearch.Text.Trim();
            dgvLoad();
        }
        */

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
            r["name"] = "--Lọc theo ngành--";
            r["id"] = 0;
            dtCB.Rows.InsertAt(r, 0);

            cb.DataSource = dtCB;
            cb.DisplayMember = "name";
            cb.ValueMember = "id";
        }
    }
}
