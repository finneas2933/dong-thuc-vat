
namespace DongThucVat
{
    partial class ucUser
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btThem = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dob = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.is_admin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.last_signined_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.created_at = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updated_at = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.avatar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbGioiTinh = new System.Windows.Forms.ComboBox();
            this.btHuy = new System.Windows.Forms.Button();
            this.btXoa = new System.Windows.Forms.Button();
            this.btLuu = new System.Windows.Forms.Button();
            this.btSua = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtAdmin = new System.Windows.Forms.RadioButton();
            this.rbtNV = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbtOff = new System.Windows.Forms.RadioButton();
            this.rbtOn = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.dtpNgaySinh);
            this.panel1.Controls.Add(this.txtDiaChi);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.btThem);
            this.panel1.Controls.Add(this.dgv);
            this.panel1.Controls.Add(this.cbGioiTinh);
            this.panel1.Controls.Add(this.btHuy);
            this.panel1.Controls.Add(this.btXoa);
            this.panel1.Controls.Add(this.btLuu);
            this.panel1.Controls.Add(this.btSua);
            this.panel1.Controls.Add(this.txtPassword);
            this.panel1.Controls.Add(this.txtHoTen);
            this.panel1.Controls.Add(this.txtSDT);
            this.panel1.Controls.Add(this.txtEmail);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(985, 580);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(523, 80);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 21);
            this.label10.TabIndex = 81;
            this.label10.Text = "Ngày sinh:";
            // 
            // dtpNgaySinh
            // 
            this.dtpNgaySinh.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            this.dtpNgaySinh.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgaySinh.Location = new System.Drawing.Point(614, 74);
            this.dtpNgaySinh.Name = "dtpNgaySinh";
            this.dtpNgaySinh.Size = new System.Drawing.Size(285, 29);
            this.dtpNgaySinh.TabIndex = 80;
            this.dtpNgaySinh.Value = new System.DateTime(2023, 12, 3, 19, 16, 41, 0);
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDiaChi.Location = new System.Drawing.Point(152, 218);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(285, 29);
            this.txtDiaChi.TabIndex = 79;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(82, 221);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 21);
            this.label5.TabIndex = 78;
            this.label5.Text = "Địa chỉ:";
            // 
            // btThem
            // 
            this.btThem.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btThem.BackColor = System.Drawing.Color.Teal;
            this.btThem.FlatAppearance.BorderSize = 0;
            this.btThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btThem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btThem.ForeColor = System.Drawing.Color.White;
            this.btThem.Location = new System.Drawing.Point(419, 522);
            this.btThem.Name = "btThem";
            this.btThem.Size = new System.Drawing.Size(164, 38);
            this.btThem.TabIndex = 77;
            this.btThem.Text = "Thêm";
            this.btThem.UseVisualStyleBackColor = false;
            this.btThem.Click += new System.EventHandler(this.btThem_Click_1);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgv.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.name,
            this.email,
            this.phone,
            this.address,
            this.dob,
            this.gender,
            this.password,
            this.is_admin,
            this.last_signined_time,
            this.created_at,
            this.updated_at,
            this.status,
            this.avatar});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgv.Location = new System.Drawing.Point(152, 343);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowHeadersWidth = 51;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(749, 163);
            this.dgv.TabIndex = 73;
            this.dgv.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_CellMouseClick_1);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.HeaderText = "Họ tên";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 200;
            // 
            // email
            // 
            this.email.DataPropertyName = "email";
            this.email.HeaderText = "Email";
            this.email.Name = "email";
            this.email.ReadOnly = true;
            this.email.Width = 150;
            // 
            // phone
            // 
            this.phone.DataPropertyName = "phone";
            this.phone.HeaderText = "SĐT";
            this.phone.Name = "phone";
            this.phone.ReadOnly = true;
            this.phone.Width = 150;
            // 
            // address
            // 
            this.address.DataPropertyName = "address";
            this.address.HeaderText = "Địa chỉ";
            this.address.Name = "address";
            this.address.ReadOnly = true;
            this.address.Width = 150;
            // 
            // dob
            // 
            this.dob.DataPropertyName = "dob";
            this.dob.HeaderText = "Ngày sinh";
            this.dob.Name = "dob";
            this.dob.ReadOnly = true;
            this.dob.Width = 150;
            // 
            // gender
            // 
            this.gender.DataPropertyName = "gender";
            this.gender.HeaderText = "Giới tính";
            this.gender.Name = "gender";
            this.gender.ReadOnly = true;
            // 
            // password
            // 
            this.password.DataPropertyName = "password";
            this.password.HeaderText = "Mật khẩu";
            this.password.Name = "password";
            this.password.ReadOnly = true;
            this.password.Width = 125;
            // 
            // is_admin
            // 
            this.is_admin.DataPropertyName = "is_admin";
            this.is_admin.HeaderText = "Admin";
            this.is_admin.Name = "is_admin";
            this.is_admin.ReadOnly = true;
            // 
            // last_signined_time
            // 
            this.last_signined_time.DataPropertyName = "last_signined_time";
            this.last_signined_time.HeaderText = "Đăng nhập lần cuối";
            this.last_signined_time.Name = "last_signined_time";
            this.last_signined_time.ReadOnly = true;
            this.last_signined_time.Width = 150;
            // 
            // created_at
            // 
            this.created_at.DataPropertyName = "created_at";
            this.created_at.HeaderText = "Khởi tạo";
            this.created_at.Name = "created_at";
            this.created_at.ReadOnly = true;
            this.created_at.Width = 150;
            // 
            // updated_at
            // 
            this.updated_at.DataPropertyName = "updated_at";
            this.updated_at.HeaderText = "Cập nhật";
            this.updated_at.Name = "updated_at";
            this.updated_at.ReadOnly = true;
            this.updated_at.Width = 150;
            // 
            // status
            // 
            this.status.DataPropertyName = "status";
            this.status.HeaderText = "Trạng thái";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            // 
            // avatar
            // 
            this.avatar.DataPropertyName = "avatar";
            this.avatar.HeaderText = "";
            this.avatar.Name = "avatar";
            this.avatar.ReadOnly = true;
            this.avatar.Visible = false;
            // 
            // cbGioiTinh
            // 
            this.cbGioiTinh.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbGioiTinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGioiTinh.FormattingEnabled = true;
            this.cbGioiTinh.Items.AddRange(new object[] {
            "",
            "Nam",
            "Nữ",
            "Khác"});
            this.cbGioiTinh.Location = new System.Drawing.Point(614, 124);
            this.cbGioiTinh.Name = "cbGioiTinh";
            this.cbGioiTinh.Size = new System.Drawing.Size(285, 29);
            this.cbGioiTinh.TabIndex = 72;
            // 
            // btHuy
            // 
            this.btHuy.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btHuy.BackColor = System.Drawing.Color.OrangeRed;
            this.btHuy.FlatAppearance.BorderSize = 0;
            this.btHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btHuy.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btHuy.ForeColor = System.Drawing.Color.White;
            this.btHuy.Location = new System.Drawing.Point(567, 292);
            this.btHuy.Name = "btHuy";
            this.btHuy.Size = new System.Drawing.Size(164, 38);
            this.btHuy.TabIndex = 69;
            this.btHuy.Text = "Hủy";
            this.btHuy.UseVisualStyleBackColor = false;
            this.btHuy.Click += new System.EventHandler(this.btHuy_Click_1);
            // 
            // btXoa
            // 
            this.btXoa.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btXoa.BackColor = System.Drawing.Color.Red;
            this.btXoa.FlatAppearance.BorderSize = 0;
            this.btXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btXoa.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btXoa.ForeColor = System.Drawing.Color.White;
            this.btXoa.Location = new System.Drawing.Point(761, 522);
            this.btXoa.Name = "btXoa";
            this.btXoa.Size = new System.Drawing.Size(138, 38);
            this.btXoa.TabIndex = 68;
            this.btXoa.Text = "Xóa";
            this.btXoa.UseVisualStyleBackColor = false;
            this.btXoa.Click += new System.EventHandler(this.btXoa_Click_1);
            // 
            // btLuu
            // 
            this.btLuu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btLuu.BackColor = System.Drawing.Color.SeaGreen;
            this.btLuu.FlatAppearance.BorderSize = 0;
            this.btLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btLuu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLuu.ForeColor = System.Drawing.Color.White;
            this.btLuu.Location = new System.Drawing.Point(737, 292);
            this.btLuu.Name = "btLuu";
            this.btLuu.Size = new System.Drawing.Size(164, 38);
            this.btLuu.TabIndex = 71;
            this.btLuu.Text = "Lưu";
            this.btLuu.UseVisualStyleBackColor = false;
            this.btLuu.Click += new System.EventHandler(this.btLuu_Click_1);
            // 
            // btSua
            // 
            this.btSua.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btSua.BackColor = System.Drawing.Color.RoyalBlue;
            this.btSua.FlatAppearance.BorderSize = 0;
            this.btSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSua.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSua.ForeColor = System.Drawing.Color.White;
            this.btSua.Location = new System.Drawing.Point(590, 522);
            this.btSua.Name = "btSua";
            this.btSua.Size = new System.Drawing.Size(164, 38);
            this.btSua.TabIndex = 70;
            this.btSua.Text = "Sửa";
            this.btSua.UseVisualStyleBackColor = false;
            this.btSua.Click += new System.EventHandler(this.btSua_Click_1);
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPassword.Location = new System.Drawing.Point(152, 263);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(285, 29);
            this.txtPassword.TabIndex = 67;
            // 
            // txtHoTen
            // 
            this.txtHoTen.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtHoTen.Location = new System.Drawing.Point(150, 75);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(285, 29);
            this.txtHoTen.TabIndex = 64;
            // 
            // txtSDT
            // 
            this.txtSDT.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtSDT.Location = new System.Drawing.Point(150, 169);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(285, 29);
            this.txtSDT.TabIndex = 66;
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtEmail.Location = new System.Drawing.Point(150, 122);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(285, 29);
            this.txtEmail.TabIndex = 65;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(533, 127);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 21);
            this.label8.TabIndex = 60;
            this.label8.Text = "Giới tính:";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(101, 172);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 21);
            this.label6.TabIndex = 59;
            this.label6.Text = "SĐT:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(65, 266);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 21);
            this.label3.TabIndex = 58;
            this.label3.Text = "Mật khẩu:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(92, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 21);
            this.label4.TabIndex = 57;
            this.label4.Text = "Email:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(420, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 30);
            this.label2.TabIndex = 63;
            this.label2.Text = "QUẢN LÝ USER";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(80, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 21);
            this.label1.TabIndex = 56;
            this.label1.Text = "Họ tên:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.rbtOff);
            this.groupBox1.Controls.Add(this.rbtOn);
            this.groupBox1.Location = new System.Drawing.Point(518, 169);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(383, 44);
            this.groupBox1.TabIndex = 82;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Trạng thái:";
            // 
            // rbtAdmin
            // 
            this.rbtAdmin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbtAdmin.AutoSize = true;
            this.rbtAdmin.Location = new System.Drawing.Point(118, 13);
            this.rbtAdmin.Name = "rbtAdmin";
            this.rbtAdmin.Size = new System.Drawing.Size(76, 25);
            this.rbtAdmin.TabIndex = 78;
            this.rbtAdmin.TabStop = true;
            this.rbtAdmin.Text = "Admin";
            this.rbtAdmin.UseVisualStyleBackColor = true;
            // 
            // rbtNV
            // 
            this.rbtNV.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbtNV.Location = new System.Drawing.Point(237, 13);
            this.rbtNV.Name = "rbtNV";
            this.rbtNV.Size = new System.Drawing.Size(125, 25);
            this.rbtNV.TabIndex = 77;
            this.rbtNV.TabStop = true;
            this.rbtNV.Text = "Nhân viên";
            this.rbtNV.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox2.Controls.Add(this.rbtNV);
            this.groupBox2.Controls.Add(this.rbtAdmin);
            this.groupBox2.Location = new System.Drawing.Point(518, 231);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(383, 44);
            this.groupBox2.TabIndex = 83;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Quyền:";
            // 
            // rbtOff
            // 
            this.rbtOff.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbtOff.AutoSize = true;
            this.rbtOff.Location = new System.Drawing.Point(237, 13);
            this.rbtOff.Name = "rbtOff";
            this.rbtOff.Size = new System.Drawing.Size(52, 25);
            this.rbtOff.TabIndex = 75;
            this.rbtOff.TabStop = true;
            this.rbtOff.Text = "Off";
            this.rbtOff.UseVisualStyleBackColor = true;
            // 
            // rbtOn
            // 
            this.rbtOn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbtOn.AutoSize = true;
            this.rbtOn.Location = new System.Drawing.Point(118, 13);
            this.rbtOn.Name = "rbtOn";
            this.rbtOn.Size = new System.Drawing.Size(49, 25);
            this.rbtOn.TabIndex = 76;
            this.rbtOn.TabStop = true;
            this.rbtOn.Text = "On";
            this.rbtOn.UseVisualStyleBackColor = true;
            // 
            // ucUser
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(127)))), ((int)(((byte)(24)))));
            this.Name = "ucUser";
            this.Size = new System.Drawing.Size(985, 580);
            this.Load += new System.EventHandler(this.ucUser_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btThem;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.ComboBox cbGioiTinh;
        private System.Windows.Forms.Button btHuy;
        private System.Windows.Forms.Button btXoa;
        private System.Windows.Forms.Button btLuu;
        private System.Windows.Forms.Button btSua;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn email;
        private System.Windows.Forms.DataGridViewTextBoxColumn phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn address;
        private System.Windows.Forms.DataGridViewTextBoxColumn dob;
        private System.Windows.Forms.DataGridViewTextBoxColumn gender;
        private System.Windows.Forms.DataGridViewTextBoxColumn password;
        private System.Windows.Forms.DataGridViewTextBoxColumn is_admin;
        private System.Windows.Forms.DataGridViewTextBoxColumn last_signined_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn created_at;
        private System.Windows.Forms.DataGridViewTextBoxColumn updated_at;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn avatar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbtNV;
        private System.Windows.Forms.RadioButton rbtAdmin;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtOff;
        private System.Windows.Forms.RadioButton rbtOn;
    }
}
