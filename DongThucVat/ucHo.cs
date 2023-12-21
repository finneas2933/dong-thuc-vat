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
    public partial class ucHo : UserControl
    {
        SqlConnection conn;
        string sql = "";
        string tenTiengViet, tenLatinh, status;
        int id, idFK;
        DataGridViewCellMouseEventArgs vitri;
        public event Action loadDGV;

        private int loai;
        private string idUser;
        public int LoaiHo { get => loai; set => loai = value; }
        public string IdUserHo { get => idUser; set => idUser = value; }

        public ucHo()
        {
            InitializeComponent();
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            using (frmHoUpdate frm = new frmHoUpdate())
            {
                frm.KtThemHoUpdate = true;
                frm.IdUserHoUpdate = idUser;
                frm.LoaiHoUpdate = loai;
                frm.loadDGV += dgvLoad;
                frm.ShowDialog();
            }
            vitri = null;
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            if (id == 0 || vitri == null)
            {
                MessageBox.Show("Bạn chưa chọn họ!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            using (frmHoUpdate frm = new frmHoUpdate())
            {
                frm.KtThemHoUpdate = false;
                frm.IdUserHoUpdate = idUser;
                frm.IdHoUpdate = id;
                frm.IdFKHoUpdate = idFK;
                frm.LoaiHoUpdate = loai;
                frm.TenTiengVietHoUpdate = tenTiengViet;
                frm.TenLatinhHoUpdate = tenLatinh;
                frm.StatusHoUpdate = status;
                frm.loadDGV += dgvLoad;
                frm.ShowDialog();
            }
            vitri = null;
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (id == 0 || vitri == null)
            {
                MessageBox.Show("Bạn chưa chọn họ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa họ " + tenTiengViet + " không?", "Thông báo",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                sql = "DELETE FROM Ho WHERE id = " + id;
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                conn.Close();

                vitri = null;
                cbLoad();
                dgvLoad();
            }
        }

        private void ucHo_Load(object sender, EventArgs e)
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
                sql = "SELECT h.*, b.name AS namefk FROM Ho h JOIN Bo b ON h.id_dtv_bo = b.id WHERE b.loai = " + loai;
            else
                sql = "SELECT h.*, b.name AS namefk FROM Ho h JOIN Bo b ON h.id_dtv_bo = b.id WHERE b.loai = " + loai + " AND h.id_dtv_bo = " + cb.SelectedValue;
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
            sql = "SELECT id, name FROM Bo WHERE loai = " + loai;
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter daCB = new SqlDataAdapter();
            daCB.SelectCommand = cmd;
            cmd.Dispose();
            conn.Close();

            DataTable dtCB = new DataTable();
            daCB.Fill(dtCB);

            DataRow r = dtCB.NewRow();
            r["name"] = "--Lọc theo bộ--";
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
