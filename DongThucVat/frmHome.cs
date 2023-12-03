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

    public partial class frmHome : Form
    {
        static frmHome _obj;

        private string id;
        private string name;
        private string is_admin;

        public string idHome//Đọc, ghi biến nhận từ form trước
        {
            get { return id; }
            set { id = value; }
        }
        public string name_Home
        {
            get { return name; }
            set { name = value; }
        }
        public string is_admin_Home
        {
            get { return is_admin; }
            set { is_admin = value; }
        }

        public static frmHome Instance
        {
            get
            {
                if (_obj == null)
                {
                    _obj = new frmHome();
                }
                return _obj;
            }
        }

        public Panel pnlControl
        {
            get { return panelControl; }
            set { panelControl = value; }
        }

        public Button buttonBack
        {
            get { return btBack; }
            set { btBack = value; }
        }

        public frmHome()
        {
            InitializeComponent();
            timerTime.Start();
            //ucChon uc = new ucChon();
            //AddControlsToPanel(uc);
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
            using (Login fd = new Login())
            {
                fd.ShowDialog();
            }
        }

        private void AddControlsToPanel(Control c)
        {
            c.Dock = DockStyle.Fill;
            panelControl.Controls.Clear();
            panelControl.Controls.Add(c);
        }

        private void moveSidePanel(Control btn)
        {
            panelSide.Top = btn.Top;
            panelSide.Height = btn.Height;
        }

        private void timerTime_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            lbTime.Text = dt.ToString("HH:MM:ss");
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            moveSidePanel(btHome);
            //UC_Home uch = new UC_Home();
            //AddControlsToPanel(uch);
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnUsers);
            ucUser uc = new ucUser();
            //uc.idChon = id;
            //uc.loaiChon = 0;// Truyền vào thuộc tính của form tiếp theo
            AddControlsToPanel(uc);
            btBack.Visible = false;
        }

        private void btDongVat_Click(object sender, EventArgs e)
        {
            moveSidePanel(btDongVat);
            ucChon uc = new ucChon();
            uc.idChon = id;
            uc.loaiChon = 0;// Truyền vào thuộc tính của form tiếp theo
            AddControlsToPanel(uc);
            btBack.Visible = false;
        }

        private void frmHome_Load(object sender, EventArgs e)
        {
            lbFirstName.Text = name + ".";
            if (Boolean.Parse(is_admin) == true)
                lbRole.Text = "Admin.";
            if (Boolean.Parse(is_admin) == false)
                lbRole.Text = "Nhân viên.";
            
            
            btBack.Visible = false;
            _obj = this;

            //ucChon uc = new ucChon();
            //uc.Dock = DockStyle.Fill;
            //panelControl.Controls.Add(uc);
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            panelControl.Controls["ucChon"].BringToFront();
            btBack.Visible = false;
        }

        private void btThucVat_Click(object sender, EventArgs e)
        {
            moveSidePanel(btThucVat);
            ucChon uc = new ucChon();
            uc.idChon = id;
            uc.loaiChon = 1;// Truyền vào thuộc tính của form tiếp theo
            AddControlsToPanel(uc);
            btBack.Visible = false;
        }
    }
}
