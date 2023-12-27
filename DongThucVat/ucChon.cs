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
    public partial class ucChon : UserControl
    {
        private int loai;
        private string id;

        public string idChon// Đọc, ghi biến nhận từ form trước
        {
            get { return id; }
            set { id = value; }
        }
        public int loaiChon
        {
            get { return loai; }
            set { loai = value; }
        }

        public ucChon()
        {
            InitializeComponent();

        }

        private void btLop_Click(object sender, EventArgs e)
        {
            frmHome.Instance.tieuDe.Visible = false;
            if (!frmHome.Instance.pnlControl.Controls.ContainsKey("ucLop"))
            {
                ucLop uc = new ucLop();
                uc.idUserLop = id;
                uc.loaiLop = loai;

                uc.Dock = DockStyle.Fill;
                frmHome.Instance.pnlControl.Controls.Add(uc);
            }
            frmHome.Instance.pnlControl.Controls["ucLop"].BringToFront();
            frmHome.Instance.buttonBack.Visible = true;
        }

        private void btBo_Click(object sender, EventArgs e)
        {
            frmHome.Instance.tieuDe.Visible = false;
            if (!frmHome.Instance.pnlControl.Controls.ContainsKey("ucBo"))
            {
                ucBo uc = new ucBo();
                uc.IdUserBo = id;
                uc.LoaiBo = loai;

                uc.Dock = DockStyle.Fill;
                frmHome.Instance.pnlControl.Controls.Add(uc);
            }
            frmHome.Instance.pnlControl.Controls["ucBo"].BringToFront();
            frmHome.Instance.buttonBack.Visible = true;
        }

        private void btHo_Click(object sender, EventArgs e)
        {
            frmHome.Instance.tieuDe.Visible = false;
            if (!frmHome.Instance.pnlControl.Controls.ContainsKey("ucHo"))
            {
                ucHo uc = new ucHo();
                uc.IdUserHo = id;
                uc.LoaiHo = loai;

                uc.Dock = DockStyle.Fill;
                frmHome.Instance.pnlControl.Controls.Add(uc);
            }
            frmHome.Instance.pnlControl.Controls["ucHo"].BringToFront();
            frmHome.Instance.buttonBack.Visible = true;
        }

        private void btLoai_Click(object sender, EventArgs e)
        {
            frmHome.Instance.tieuDe.Visible = false;
            if (!frmHome.Instance.pnlControl.Controls.ContainsKey("ucLoai"))
            {
                ucLoai uc = new ucLoai();
                uc.idUserLoai = id;
                uc.loaiLoai = loai;

                uc.Dock = DockStyle.Fill;
                frmHome.Instance.pnlControl.Controls.Add(uc);
            }
            frmHome.Instance.pnlControl.Controls["ucLoai"].BringToFront();
            frmHome.Instance.buttonBack.Visible = true;
        }

        private void btNganh_Click(object sender, EventArgs e)
        {
            frmHome.Instance.tieuDe.Visible = false;
            if (!frmHome.Instance.pnlControl.Controls.ContainsKey("ucNganh"))
            {
                ucNganh uc = new ucNganh();
                uc.idUserNganh = id;
                uc.loaiNganh = loai;
                
                uc.Dock = DockStyle.Fill;
                frmHome.Instance.pnlControl.Controls.Add(uc);
            }
            frmHome.Instance.pnlControl.Controls["ucNganh"].BringToFront();
            frmHome.Instance.buttonBack.Visible = true;
            //await Task.Delay(300);
        }

        private void ucChon_Load(object sender, EventArgs e)
        {
            if (loai == 0)
            {
                btSearch.Text = "CSDL động vật";
                btSearch.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "\\picture\\Gorilla-100.png");
                btNganh.Text = "Ngành động vật";
                btNganh.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "\\picture\\Gorilla-100.png");
                btLop.Text = "Lớp động vật";
                btLop.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "\\picture\\Gorilla-100.png");
                btBo.Text = "Bộ động vật";
                btBo.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "\\picture\\Gorilla-100.png");
                btHo.Text = "Họ động vật";
                btHo.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "\\picture\\Gorilla-100.png");
                btLoai.Text = "Loài động vật";
                btLoai.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "\\picture\\Gorilla-100.png");
            }
            else
            {
                btSearch.Text = "CSDL thực vật";
                btSearch.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "\\picture\\Oak Tree - 100.png");
                btNganh.Text = "Ngành thực vật";
                btNganh.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "\\picture\\Oak Tree - 100.png");
                btLop.Text = "Lớp thực vật";
                btLop.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "\\picture\\Oak Tree - 100.png");
                btBo.Text = "Bộ thực vật";
                btBo.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "\\picture\\Oak Tree - 100.png");
                btHo.Text = "Họ thực vật";
                btHo.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "\\picture\\Oak Tree - 100.png");
                btLoai.Text = "Loài thực vật";
                btLoai.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "\\picture\\Oak Tree - 100.png");
            }
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            frmHome.Instance.tieuDe.Visible = false;
            if (!frmHome.Instance.pnlControl.Controls.ContainsKey("ucSearch"))
            {
                ucSearch uc = new ucSearch();
                uc.Loai = loai;

                uc.Dock = DockStyle.Fill;
                frmHome.Instance.pnlControl.Controls.Add(uc);
            }
            frmHome.Instance.pnlControl.Controls["ucSearch"].BringToFront();
            frmHome.Instance.buttonBack.Visible = true;
        }
    }
}
