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
    public partial class ucBo : UserControl
    {
        SqlConnection conn;
        string sql = "";
        string tenTiengViet, tenLatinh, status;
        int id, idFK;
        DataGridViewCellMouseEventArgs vitri;

        private int loai;
        private string idUser;
        public int LoaiBo 
        {
            get => loai;
            set => loai = value; 
        }
        public string IdUserBo
        {
            get => idUser;
            set => idUser = value;
        }

        public ucBo()
        {
            InitializeComponent();
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            using (frmBoUpdate frm = new frmBoUpdate())
            {
                frm.KtThemBoUpdate = true;
                frm.IdUserBoUpdate = idUser;
                frm.LoaiBoUpdate = loai;
                frm.loadDGV += dgvLoad;
                frm.ShowDialog();
            }
            vitri = null;
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            if (id == 0 || vitri == null)
            {
                MessageBox.Show("Bạn chưa chọn bộ!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            using (frmBoUpdate frm = new frmBoUpdate())
            {
                frm.KtThemBoUpdate = false;
                frm.IdUserBoUpdate = idUser;
                frm.IdBoUpdate = id;
                frm.IdFKBoUpdate = idFK;
                frm.LoaiBoUpdate = loai;
                frm.TenTiengVietBoUpdate = tenTiengViet;
                frm.TenLatinhBoUpdate = tenLatinh;
                frm.StatusBoUpdate = status;
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
                    MessageBox.Show("Bạn chưa chọn bộ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (MessageBox.Show("Bạn có muốn xóa bộ " + tenTiengViet + " không?", "Thông báo",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    sql = "DELETE FROM Bo WHERE id = " + id;
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

        private void ucBo_Load(object sender, EventArgs e)
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
                sql = "SELECT b.*, l.name AS namefk FROM Bo b JOIN Lop l ON b.id_dtv_lop = l.id WHERE b.loai = " + loai;
            else
                sql = "SELECT b.*, l.name AS namefk FROM Bo b JOIN Lop l ON b.id_dtv_lop = l.id WHERE b.loai = " + loai + " AND b.id_dtv_lop = " + cb.SelectedValue;
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

        public void cbLoad()
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            sql = "SELECT id, name FROM Lop WHERE loai = " + loai;
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter daCB = new SqlDataAdapter();
            daCB.SelectCommand = cmd;
            cmd.Dispose();
            conn.Close();

            DataTable dtCB = new DataTable();
            daCB.Fill(dtCB);

            DataRow r = dtCB.NewRow();
            r["name"] = "--Lọc theo lớp--";
            r["id"] = 0;
            dtCB.Rows.InsertAt(r, 0);

            cb.DataSource = dtCB;
            cb.DisplayMember = "name";
            cb.ValueMember = "id";
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            cbLoad();
            dgvLoad();
            vitri = null;
        }

        private void cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb.SelectedItem is DataRowView selectedItem)
            {
                if (int.TryParse(selectedItem["id"].ToString(), out int intValue))
                {
                    idFK = intValue;
                    vitri = null;
                }
                else
                {
                    idFK = 0;
                }
            }
            dgvLoad();
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
    }
}
