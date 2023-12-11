
namespace DongThucVat
{
    partial class ucHome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucHome));
            this.lbNoiDung1 = new System.Windows.Forms.Label();
            this.lbNoiDung2 = new System.Windows.Forms.Label();
            this.lbNoiDung3 = new System.Windows.Forms.Label();
            this.lbTieuDe = new System.Windows.Forms.Label();
            this.pbHome = new System.Windows.Forms.PictureBox();
            this.lbNoiDung4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbHome)).BeginInit();
            this.SuspendLayout();
            // 
            // lbNoiDung1
            // 
            this.lbNoiDung1.Location = new System.Drawing.Point(100, 63);
            this.lbNoiDung1.Name = "lbNoiDung1";
            this.lbNoiDung1.Size = new System.Drawing.Size(900, 300);
            this.lbNoiDung1.TabIndex = 0;
            this.lbNoiDung1.Text = resources.GetString("lbNoiDung1.Text");
            // 
            // lbNoiDung2
            // 
            this.lbNoiDung2.Location = new System.Drawing.Point(100, 372);
            this.lbNoiDung2.Name = "lbNoiDung2";
            this.lbNoiDung2.Size = new System.Drawing.Size(900, 300);
            this.lbNoiDung2.TabIndex = 1;
            this.lbNoiDung2.Text = resources.GetString("lbNoiDung2.Text");
            // 
            // lbNoiDung3
            // 
            this.lbNoiDung3.Location = new System.Drawing.Point(100, 681);
            this.lbNoiDung3.Name = "lbNoiDung3";
            this.lbNoiDung3.Size = new System.Drawing.Size(900, 300);
            this.lbNoiDung3.TabIndex = 2;
            this.lbNoiDung3.Text = resources.GetString("lbNoiDung3.Text");
            // 
            // lbTieuDe
            // 
            this.lbTieuDe.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTieuDe.Location = new System.Drawing.Point(0, 18);
            this.lbTieuDe.Name = "lbTieuDe";
            this.lbTieuDe.Size = new System.Drawing.Size(1754, 32);
            this.lbTieuDe.TabIndex = 3;
            this.lbTieuDe.Text = "GIỚI THIỆU VỀ BẮC HƯỚNG HÓA";
            this.lbTieuDe.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pbHome
            // 
            this.pbHome.Location = new System.Drawing.Point(1045, 63);
            this.pbHome.Name = "pbHome";
            this.pbHome.Size = new System.Drawing.Size(600, 600);
            this.pbHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbHome.TabIndex = 4;
            this.pbHome.TabStop = false;
            // 
            // lbNoiDung4
            // 
            this.lbNoiDung4.Location = new System.Drawing.Point(1045, 681);
            this.lbNoiDung4.Name = "lbNoiDung4";
            this.lbNoiDung4.Size = new System.Drawing.Size(600, 300);
            this.lbNoiDung4.TabIndex = 5;
            this.lbNoiDung4.Text = resources.GetString("lbNoiDung4.Text");
            // 
            // ucHome
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.lbNoiDung4);
            this.Controls.Add(this.pbHome);
            this.Controls.Add(this.lbTieuDe);
            this.Controls.Add(this.lbNoiDung3);
            this.Controls.Add(this.lbNoiDung2);
            this.Controls.Add(this.lbNoiDung1);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(127)))), ((int)(((byte)(24)))));
            this.Name = "ucHome";
            this.Size = new System.Drawing.Size(1757, 988);
            this.Load += new System.EventHandler(this.ucHome_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbHome)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbNoiDung1;
        private System.Windows.Forms.Label lbNoiDung2;
        private System.Windows.Forms.Label lbNoiDung3;
        private System.Windows.Forms.Label lbTieuDe;
        private System.Windows.Forms.PictureBox pbHome;
        private System.Windows.Forms.Label lbNoiDung4;
    }
}
