
namespace DongThucVat
{
    partial class ucGioiThieu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucGioiThieu));
            this.lbNoiDung = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbNoiDung
            // 
            this.lbNoiDung.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbNoiDung.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(21)))));
            this.lbNoiDung.Location = new System.Drawing.Point(108, 164);
            this.lbNoiDung.Name = "lbNoiDung";
            this.lbNoiDung.Size = new System.Drawing.Size(900, 300);
            this.lbNoiDung.TabIndex = 6;
            this.lbNoiDung.Text = resources.GetString("lbNoiDung.Text");
            // 
            // ucGioiThieu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.lbNoiDung);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(127)))), ((int)(((byte)(24)))));
            this.Name = "ucGioiThieu";
            this.Size = new System.Drawing.Size(1117, 628);
            this.Load += new System.EventHandler(this.ucGioiThieu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbNoiDung;
    }
}
