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
        }

        private void ucChon_Load(object sender, EventArgs e)
        {
            if (loai == 0)
            {
                btNganh.Text = "Ngành động vật";
                btLop.Text = "Lớp động vật";
                btBo.Text = "Bộ động vật";
                btHo.Text = "Họ động vật";
                btLoai.Text = "Loài động vật";
            }
            else
            {
                btNganh.Text = "Ngành thực vật";
                btLop.Text = "Lớp thực vật";
                btBo.Text = "Bộ thực vật";
                btHo.Text = "Họ thực vật";
                btLoai.Text = "Loài thực vật";
            }
        }
    }
}
