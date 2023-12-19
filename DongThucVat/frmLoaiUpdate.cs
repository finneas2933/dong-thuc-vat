using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DongThucVat
{
    public partial class frmLoaiUpdate : Form
    {
        SqlConnection conn;
        string sql = "";

        // Tạo một đối tượng của lớp ConfigurationManager để đọc thông tin cấu hình từ file app.config
        // string pictureFolder;
        private List<string> selectedImages = new List<string>();
        private string idUser, tenTiengViet;
        private int id, loai;
        private bool ktThem;
        public string IdUserLoaiUpdate { get => idUser; set => idUser = value; }
        public int IdLoaiUpdate { get => id; set => id = value; }
        public int LoaiLoaiUpdate { get => loai; set => loai = value; }
        public bool KtThemLoaiUpdate { get => ktThem; set => ktThem = value; }

        public frmLoaiUpdate()
        {
            InitializeComponent();
            //pictureFolder = ConfigurationManager.AppSettings["PictureFolder"];
        }

        public void cbLoad()
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            sql = "SELECT id, name FROM Ho WHERE loai = " + loai;
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter daCB = new SqlDataAdapter();
            daCB.SelectCommand = cmd;
            cmd.Dispose();
            conn.Close();

            DataTable dtCB = new DataTable();
            daCB.Fill(dtCB);

            DataRow r = dtCB.NewRow();
            r["name"] = "--Chọn họ--";
            r["id"] = 0;
            dtCB.Rows.InsertAt(r, 0);

            cbFK.DataSource = dtCB;
            cbFK.DisplayMember = "name";
            cbFK.ValueMember = "id";
        }

        public void layNguonControls()
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            sql = "SELECT * FROM Loai WHERE id = " + id;
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            cmd.Dispose();
            conn.Close();

            DataTable dt = new DataTable();
            da.Fill(dt);
            // Lấy giá trị từ dòng đầu tiên của DataTable
            tenTiengViet = dt.Rows[0]["name"].ToString();
            txtTenTiengViet.Text = dt.Rows[0]["name"].ToString();
            txtTenLatinh.Text = dt.Rows[0]["name_latinh"].ToString();
            txtTenKhac.Text = dt.Rows[0]["ten_khac"].ToString();
            txtPhanBo.Text = dt.Rows[0]["phan_bo"].ToString();
            txtNguonTaiLieu.Text = dt.Rows[0]["nguon_tai_lieu"].ToString();
            cbFK.SelectedValue = dt.Rows[0]["id_dtv_ho"].ToString();
            cbIUCN.SelectedItem = dt.Rows[0]["muc_do_bao_ton_iucn"].ToString();
            cbSDVN.SelectedItem = dt.Rows[0]["muc_do_bao_ton_sdvn"].ToString();
            cbNDCP.SelectedItem = dt.Rows[0]["muc_do_bao_ton_ndcp"].ToString();
            cbND64CP.SelectedItem = dt.Rows[0]["muc_do_bao_ton_nd64cp"].ToString();
            rtxtCongDung.Text = dt.Rows[0]["gia_tri_su_dung"].ToString();
            rtxtDacDiem.Text = dt.Rows[0]["dac_diem"].ToString(); ;
            if (Boolean.Parse(dt.Rows[0]["status"].ToString()) == true)
                rbtOn.Checked = true;
            if (Boolean.Parse(dt.Rows[0]["status"].ToString()) == false)
                rbtOff.Checked = true;
        }

        public void xoaTrang(bool b)
        {
            txtTenTiengViet.Text = "";
            txtTenLatinh.Text = "";
            txtTenKhac.Text = "";
            txtPhanBo.Text = "";
            txtNguonTaiLieu.Text = "";
            cbIUCN.SelectedIndex = 0;
            cbSDVN.SelectedIndex = 0;
            cbNDCP.SelectedIndex = 0;
            cbND64CP.SelectedIndex = 0;
            rtxtCongDung.Text = "";
            rtxtDacDiem.Text = "";
            rbtOn.Checked = false;
            rbtOff.Checked = true;
            cbLoad();
            selectedImages.Clear();
        }

        public void LoadImages()
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                string sql = "SELECT hinhanh FROM HinhAnhLoai WHERE id_dtv_loai = @loaiId";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@loaiId", id);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string imagePath = reader["hinhanh"].ToString();
                    if (!string.IsNullOrEmpty(imagePath))
                    {
                        selectedImages.Add(imagePath);
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void DisplayImages()
        {
            foreach (string imagePath in selectedImages)
            {
                if (File.Exists(imagePath))
                {
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Image = Image.FromFile(imagePath);
                    pictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
                    pictureBox.Width = 50;
                    pictureBox.Height = 50;
                    fpnlHinhAnh.Controls.Add(pictureBox);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy ảnh: " + imagePath);
                }
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmLoaiUpdate_Load(object sender, EventArgs e)
        {
            conn = Connect.ConnectDB();
            xoaTrang(ktThem);
            cbLoad();
            if (loai == 0)
                lbNganh.Text = "LOÀI ĐỘNG VẬT";
            if (loai == 1)
                lbNganh.Text = "LOÀI THỰC VẬT";
            if (ktThem == false)
            {
                layNguonControls();
                LoadImages();
                DisplayImages();
            }
            /*
            txtTenTiengViet.Text = tenTiengViet;
            txtTenLatinh.Text = tenLatinh;
            txtTenKhac.Text = tenkhac;
            txtPhanBo.Text = phanbo;
            txtNguonTaiLieu.Text = nguontailieu;
            cbFK.SelectedValue = idFK;
            cbIUCN.SelectedItem = iucn;
            cbSDVN.SelectedValue = sdvn;
            cbNDCP.SelectedValue = ndcp;
            cbND64CP.SelectedValue = nd64cp;
            rtxtCongDung.Text = congdung;
            rtxtDacDiem.Text = dacdiem;
            if (status != null)
            {
                if (Boolean.Parse(status) == true)
                    rbtOn.Checked = true;
                if (Boolean.Parse(status) == false)
                    rbtOff.Checked = true;
            }
            */
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            if (txtTenTiengViet.Text == "" && txtTenLatinh.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên loài!", "Thông báo",
                    MessageBoxButtons.OK);
                txtTenTiengViet.Focus();
                return;
            }
            if (cbFK.SelectedIndex <= 0 || cbFK.SelectedValue == null)
            {
                MessageBox.Show("Bạn chưa chọn họ!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbFK.Focus();
                return;
            }
            if (conn.State != ConnectionState.Open)
                conn.Open();
            if (ktThem == true)
            {
                if (MessageBox.Show("Bạn có muốn thêm loài " + txtTenTiengViet.Text + " không?", "Thông báo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                DateTime createdAt = DateTime.Now;
                SqlCommand cmd = new SqlCommand("InsertLoai", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = txtTenTiengViet.Text.Trim();
                cmd.Parameters.Add("@name_latinh", SqlDbType.NVarChar).Value = txtTenLatinh.Text.Trim();
                cmd.Parameters.Add("@loai", SqlDbType.Bit).Value = loai;
                cmd.Parameters.Add("@id_dtv_ho", SqlDbType.Int).Value = cbFK.SelectedValue;
                cmd.Parameters.Add("@ten_khac", SqlDbType.NVarChar).Value = txtTenKhac.Text.Trim();
                cmd.Parameters.Add("@dac_diem", SqlDbType.NVarChar).Value = rtxtDacDiem.Text;
                cmd.Parameters.Add("@gia_tri_su_dung", SqlDbType.NVarChar).Value = rtxtCongDung.Text;
                cmd.Parameters.Add("@phan_bo", SqlDbType.NVarChar).Value = txtPhanBo.Text.Trim();
                cmd.Parameters.Add("@nguon_tai_lieu", SqlDbType.NVarChar).Value = txtNguonTaiLieu.Text.Trim();
                cmd.Parameters.Add("@muc_do_bao_ton_iucn", SqlDbType.NVarChar).Value = cbIUCN.SelectedIndex == 0 ? "" : cbIUCN.SelectedItem?.ToString();
                cmd.Parameters.Add("@muc_do_bao_ton_sdvn", SqlDbType.NVarChar).Value = cbSDVN.SelectedIndex == 0 ? "" : cbSDVN.SelectedItem?.ToString();
                cmd.Parameters.Add("@muc_do_bao_ton_ndcp", SqlDbType.NVarChar).Value = cbNDCP.SelectedIndex == 0 ? "" : cbNDCP.SelectedItem?.ToString();
                cmd.Parameters.Add("@muc_do_bao_ton_nd64cp  ", SqlDbType.NVarChar).Value = cbND64CP.SelectedIndex == 0 ? "" : cbND64CP.SelectedItem?.ToString();
                cmd.Parameters.Add("@status", SqlDbType.Bit).Value = rbtOn.Checked ? 1 : 0;
                cmd.Parameters.Add("@created_at", SqlDbType.DateTime).Value = createdAt;
                cmd.Parameters.Add("@created_by", SqlDbType.Int).Value = Int32.Parse(idUser);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            else
            {
                if (MessageBox.Show("Bạn có muốn sửa loài " + tenTiengViet + " không?", "Thông báo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                DateTime updatedAt = DateTime.Now;
                SqlCommand cmd = new SqlCommand("UpdateLoai", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = txtTenTiengViet.Text.Trim();
                cmd.Parameters.Add("@name_latinh", SqlDbType.NVarChar).Value = txtTenLatinh.Text.Trim();
                cmd.Parameters.Add("@id_dtv_ho", SqlDbType.Int).Value = cbFK.SelectedValue;
                cmd.Parameters.Add("@ten_khac", SqlDbType.NVarChar).Value = txtTenKhac.Text.Trim();
                cmd.Parameters.Add("@dac_diem", SqlDbType.NVarChar).Value = rtxtDacDiem.Text;
                cmd.Parameters.Add("@gia_tri_su_dung", SqlDbType.NVarChar).Value = rtxtCongDung.Text;
                cmd.Parameters.Add("@phan_bo", SqlDbType.NVarChar).Value = txtPhanBo.Text.Trim();
                cmd.Parameters.Add("@nguon_tai_lieu", SqlDbType.NVarChar).Value = txtNguonTaiLieu.Text.Trim();
                cmd.Parameters.Add("@muc_do_bao_ton_iucn", SqlDbType.NVarChar).Value = cbIUCN.SelectedIndex == 0 ? "" : cbIUCN.SelectedItem?.ToString();
                cmd.Parameters.Add("@muc_do_bao_ton_sdvn", SqlDbType.NVarChar).Value = cbSDVN.SelectedIndex == 0 ? "" : cbSDVN.SelectedItem?.ToString();
                cmd.Parameters.Add("@muc_do_bao_ton_ndcp", SqlDbType.NVarChar).Value = cbNDCP.SelectedIndex == 0 ? "" : cbNDCP.SelectedItem?.ToString();
                cmd.Parameters.Add("@muc_do_bao_ton_nd64cp  ", SqlDbType.NVarChar).Value = cbND64CP.SelectedIndex == 0 ? "" : cbND64CP.SelectedItem?.ToString();
                cmd.Parameters.Add("@status", SqlDbType.Bit).Value = rbtOn.Checked ? 1 : 0;
                cmd.Parameters.Add("@updated_at", SqlDbType.DateTime).Value = updatedAt;
                cmd.Parameters.Add("@updated_by", SqlDbType.Int).Value = Int32.Parse(idUser);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            if (ktThem == true && selectedImages.Count > 0)
            {
                foreach (string imagePath in selectedImages)
                {
                    string sql = "INSERT INTO HinhAnhLoai (id_dtv_loai, hinhanh) VALUES((SELECT MAX(id) FROM Loai), @hinhanh)";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.Add("@hinhanh", SqlDbType.NVarChar).Value = imagePath;

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
            }
            else
            {
                sql = "DELETE FROM HinhAnhLoai WHERE id_dtv_loai = @id_dtv_loai";
                SqlCommand deleteCmd = new SqlCommand(sql, conn);
                deleteCmd.Parameters.AddWithValue("@id_dtv_loai", id);
                deleteCmd.ExecuteNonQuery();
                deleteCmd.Dispose();

                foreach (string imagePath in selectedImages)
                {
                    // Thực hiện việc lưu imageData vào cơ sở dữ liệu cho loài tương ứng
                    sql = "INSERT INTO HinhAnhLoai (id_dtv_loai, hinhanh) VALUES (@id_dtv_loai, @hinhanh)";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id_dtv_loai", id);
                    cmd.Parameters.AddWithValue("@hinhanh", imagePath);

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }

            }
            conn.Close();

            selectedImages.Clear();
            xoaTrang(true);
            this.Dispose();
        }

        private void btHuy_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string fileName in openFileDialog.FileNames)
                {
                    selectedImages.Add(fileName);
                }
                DisplayImages();
                MessageBox.Show("Đã chọn " + openFileDialog.FileNames.Length + " ảnh.");
            }
        }

        private void btXoaAnh_Click(object sender, EventArgs e)
        {
            fpnlHinhAnh.Controls.Clear();
            selectedImages.Clear();
            DisplayImages();
        }
    }
}
