using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DongThucVat
{
    public partial class ucSearch : UserControl
    {
        string pictureFolder = ConfigurationManager.AppSettings["PictureFolder"];
        List<int> listID = new List<int>();
        List<KetQua> kqList = new List<KetQua>();
        SqlConnection conn;
        string sql = "";
        string hinhanh;
        private int id, loai;
        public int Loai { get => loai; set => loai = value; }

        public class KetQua
        {
            public string ID { get; set; }
            public string TenLoai { get; set; }
            public string Ho { get; set; }
            public string Bo { get; set; }
            public string Lop { get; set; }
            public string Nganh { get; set; }
        }

        public ucSearch()
        {
            InitializeComponent();
        }

        public void cbNganhLoad()
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            sql = "SELECT id, name FROM Nganh WHERE loai = " + loai;
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter daNganh = new SqlDataAdapter();
            daNganh.SelectCommand = cmd;
            cmd.Dispose();
            conn.Close();

            DataTable dtNganh = new DataTable();
            daNganh.Fill(dtNganh);

            DataRow r = dtNganh.NewRow();
            r["name"] = "--Ngành--";
            r["id"] = 0;
            dtNganh.Rows.InsertAt(r, 0);

            cbNganh.DataSource = dtNganh;
            cbNganh.DisplayMember = "name";
            cbNganh.ValueMember = "id";
        }

        public void cbLopLoad()
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            if (cbNganh.SelectedIndex > 0)
            {
                sql = "SELECT id, name FROM Lop WHERE loai = " + loai + " AND id_dtv_nganh = " + Int32.Parse(cbNganh.SelectedValue.ToString());
            }
            else
               sql = "SELECT id, name FROM Lop WHERE loai = " + loai;
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter daLop = new SqlDataAdapter();
            daLop.SelectCommand = cmd;
            cmd.Dispose();
            conn.Close();

            DataTable dtLop = new DataTable();
            daLop.Fill(dtLop);

            DataRow r = dtLop.NewRow();
            r["name"] = "--Lớp--";
            r["id"] = 0;
            dtLop.Rows.InsertAt(r, 0);

            cbLop.DataSource = dtLop;
            cbLop.DisplayMember = "name";
            cbLop.ValueMember = "id";
        }

        public void cbBoLoad()
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            if (cbLop.SelectedIndex > 0)
            {
                sql = "SELECT id, name FROM Bo WHERE loai = " + loai + " AND id_dtv_lop = " + Int32.Parse(cbLop.SelectedValue.ToString());
            }
            else
                sql = "SELECT id, name FROM Bo WHERE loai = " + loai;
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter daBo = new SqlDataAdapter();
            daBo.SelectCommand = cmd;
            cmd.Dispose();
            conn.Close();

            DataTable dtBo = new DataTable();
            daBo.Fill(dtBo);

            DataRow r = dtBo.NewRow();
            r["name"] = "--Bộ--";
            r["id"] = 0;
            dtBo.Rows.InsertAt(r, 0);

            cbBo.DataSource = dtBo;
            cbBo.DisplayMember = "name";
            cbBo.ValueMember = "id";
        }

        public void cbHoLoad()
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            if (cbBo.SelectedIndex > 0)
            {
                sql = "SELECT id, name FROM Ho WHERE loai = " + loai + " AND id_dtv_bo = " + Int32.Parse(cbBo.SelectedValue.ToString());
            }
            else
                sql = "SELECT id, name FROM Ho WHERE loai = " + loai;
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter daHo = new SqlDataAdapter();
            daHo.SelectCommand = cmd;
            cmd.Dispose();
            conn.Close();

            DataTable dtHo = new DataTable();
            daHo.Fill(dtHo);

            DataRow r = dtHo.NewRow();
            r["name"] = "--Họ--";
            r["id"] = 0;
            dtHo.Rows.InsertAt(r, 0);

            cbHo.DataSource = dtHo;
            cbHo.DisplayMember = "name";
            cbHo.ValueMember = "id";
        }

        public void listItemLoad()
        {
            fpnlKetQua.Controls.Clear();
            ucListItem[] listItem = new ucListItem[kqList.Count];
            for (int i = 0; i < listItem.Length; i++)
            {
                listItem[i] = new ucListItem();
                listItem[i].Stt = i + 1;
                if (i < kqList.Count)
                {
                    KetQua kq = kqList[i];

                    // Gán giá trị từ kq vào listItem[i]
                    string hinhanhloai = anhListItemLoad(kq.ID);
                    if (!string.IsNullOrWhiteSpace(hinhanhloai))
                    {
                        listItem[i].Anh = hinhanhloai;
                    }
                    if (!string.IsNullOrWhiteSpace(kq.TenLoai))
                    {
                        listItem[i].Tenloai = kq.TenLoai;
                    }
                    if (!string.IsNullOrWhiteSpace(kq.Ho))
                    {
                        listItem[i].Ho = kq.Ho;
                    }
                    if (!string.IsNullOrWhiteSpace(kq.Bo))
                    {
                        listItem[i].Bo = kq.Bo;
                    }
                    if (!string.IsNullOrWhiteSpace(kq.Lop))
                    {
                        listItem[i].Lop = kq.Lop;
                    }
                    if (!string.IsNullOrWhiteSpace(kq.Nganh))
                    {
                        listItem[i].Nganh = kq.Nganh;
                    }

                    // Thêm listItem[i] vào fpnlKetQua.Controls
                    fpnlKetQua.Controls.Add(listItem[i]);
                }
            }
        }

        public string anhListItemLoad(string idloai)
        {
            hinhanh = "";
            if (conn.State != ConnectionState.Open)
                conn.Open();

            try
            {
                string query = "SELECT TOP 1 hinhanh FROM HinhAnhLoai WHERE id_dtv_loai = @Id ORDER BY id DESC; ";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", Int32.Parse(idloai));
                    object result = cmd.ExecuteScalar();

                    if (result is string hinhanhValue)
                    {
                        hinhanh = pictureFolder + "\\" + hinhanhValue;
                    }
                }
            }
            catch
            {
                string anhmacdinh = AppDomain.CurrentDomain.BaseDirectory + "\\picture\\Image File.png";
                return anhmacdinh;
            }
            finally
            {
                conn.Close();
            }

            return hinhanh;
        }

        private void ucSearch_Load(object sender, EventArgs e)
        {
            conn = Connect.ConnectDB();
            fpnlKetQua.Controls.Clear();
            cbNganhLoad();
            cbLopLoad();
            cbBoLoad();
            cbHoLoad();
            cbIUCN.SelectedIndex = 0; cbSDVN.SelectedIndex = 0; cbND84.SelectedIndex = 0; cbND64.SelectedIndex = 0;
            dgvLoad();
        }

        private void cbNganh_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbLopLoad();
            cbBoLoad();
            cbHoLoad();
        }

        private void cbLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbBoLoad();
            cbHoLoad();
        }

        private void cbBo_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbHoLoad();
        }

        private void btTim_Click(object sender, EventArgs e)
        {
            dgvLoad();
        }

        private void dgv_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgv.Rows.Count > 0)
                {
                    if (e.RowIndex >= 0)
                    {
                        using (frmHienThi frm = new frmHienThi())
                        {
                           DataGridViewRow row = dgv.Rows[e.RowIndex];
                            frm.IdHienThi = row.Cells[0].Value.ToString();
                            frm.ShowDialog();
                        }
                    }
                }
            }
            catch (Exception ev)
            {
                MessageBox.Show("Lỗi: " + ev.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void dgvLoad()
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            SqlCommand cmd = new SqlCommand("Search", conn);
            cmd.Parameters.Add("@loai", SqlDbType.Int).Value = loai;
            cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = txtTenTiengViet.Text.Trim();
            cmd.Parameters.Add("@name_latinh", SqlDbType.NVarChar).Value = txtTenLatinh.Text.Trim();
            cmd.Parameters.Add("@id_dtv_nganh", SqlDbType.Int).Value = cbNganh.SelectedIndex <= 0 ? DBNull.Value : cbNganh.SelectedValue;
            cmd.Parameters.Add("@id_dtv_lop", SqlDbType.Int).Value = cbLop.SelectedIndex <= 0 ? DBNull.Value : cbLop.SelectedValue;
            cmd.Parameters.Add("@id_dtv_bo", SqlDbType.Int).Value = cbBo.SelectedIndex <= 0 ? DBNull.Value : cbBo.SelectedValue;
            cmd.Parameters.Add("@id_dtv_ho", SqlDbType.Int).Value = cbHo.SelectedIndex <= 0 ? DBNull.Value : cbHo.SelectedValue;
            cmd.Parameters.Add("@muc_do_bao_ton_iucn", SqlDbType.NVarChar).Value = cbIUCN.SelectedIndex == 0 ? "" : cbIUCN.SelectedItem?.ToString();
            cmd.Parameters.Add("@muc_do_bao_ton_sdvn", SqlDbType.NVarChar).Value = cbSDVN.SelectedIndex == 0 ? "" : cbSDVN.SelectedItem?.ToString();
            cmd.Parameters.Add("@muc_do_bao_ton_ndcp", SqlDbType.NVarChar).Value = cbND84.SelectedIndex == 0 ? "" : cbND84.SelectedItem?.ToString();
            cmd.Parameters.Add("@muc_do_bao_ton_nd64cp", SqlDbType.NVarChar).Value = cbND64.SelectedIndex <= 0 ? "" : cbND64.SelectedItem?.ToString();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();

            SqlDataAdapter daGRV = new SqlDataAdapter();
            daGRV.SelectCommand = cmd;

            DataTable dtGRV = new DataTable();
            daGRV.Fill(dtGRV);

            dgv.DataSource = dtGRV;
            dgv.Refresh();

            cmd.Dispose();
            conn.Close();
            listID.Clear();
            kqList.Clear();

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (int.TryParse(row.Cells[0].Value.ToString(), out id))
                {
                    listID.Add(id);
                }
                if (!row.IsNewRow && row.Index != -1)
                {
                    KetQua kq = new KetQua();

                    kq.ID = row.Cells[0].Value.ToString();
                    kq.TenLoai = row.Cells[1].Value.ToString();
                    kq.Ho = row.Cells[4].Value.ToString();
                    kq.Bo = row.Cells[5].Value.ToString();
                    kq.Lop = row.Cells[6].Value.ToString();
                    kq.Nganh = row.Cells[7].Value.ToString();

                    kqList.Add(kq);
                }
            }

            listItemLoad();
        }
    }
}
