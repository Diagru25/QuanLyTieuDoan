namespace QuanLyDonVi.GUI
{
    partial class Uc_DoiMatKhau
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btn_DoiMK = new System.Windows.Forms.Button();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.txt_MKMoi1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_MkMoi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_MKCu = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnThoat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnThoat);
            this.panelControl1.Controls.Add(this.btn_DoiMK);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 430);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(867, 100);
            this.panelControl1.TabIndex = 0;
            // 
            // btn_DoiMK
            // 
            this.btn_DoiMK.Location = new System.Drawing.Point(194, 33);
            this.btn_DoiMK.Name = "btn_DoiMK";
            this.btn_DoiMK.Size = new System.Drawing.Size(156, 40);
            this.btn_DoiMK.TabIndex = 34;
            this.btn_DoiMK.Text = "Đổi mật khẩu";
            this.btn_DoiMK.UseVisualStyleBackColor = true;
            this.btn_DoiMK.Click += new System.EventHandler(this.btn_DoiMK_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.txt_MKMoi1);
            this.panelControl2.Controls.Add(this.label3);
            this.panelControl2.Controls.Add(this.txt_MkMoi);
            this.panelControl2.Controls.Add(this.label1);
            this.panelControl2.Controls.Add(this.txt_MKCu);
            this.panelControl2.Controls.Add(this.label2);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(867, 430);
            this.panelControl2.TabIndex = 0;
            // 
            // txt_MKMoi1
            // 
            this.txt_MKMoi1.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txt_MKMoi1.Location = new System.Drawing.Point(368, 243);
            this.txt_MKMoi1.Name = "txt_MKMoi1";
            this.txt_MKMoi1.Size = new System.Drawing.Size(225, 25);
            this.txt_MKMoi1.TabIndex = 36;
            this.txt_MKMoi1.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label3.Location = new System.Drawing.Point(191, 246);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 18);
            this.label3.TabIndex = 35;
            this.label3.Text = "Xác nhận mật khẩu mới";
            // 
            // txt_MkMoi
            // 
            this.txt_MkMoi.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txt_MkMoi.Location = new System.Drawing.Point(368, 183);
            this.txt_MkMoi.Name = "txt_MkMoi";
            this.txt_MkMoi.Size = new System.Drawing.Size(225, 25);
            this.txt_MkMoi.TabIndex = 34;
            this.txt_MkMoi.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label1.Location = new System.Drawing.Point(191, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 18);
            this.label1.TabIndex = 33;
            this.label1.Text = "Mật khẩu hiện tại";
            // 
            // txt_MKCu
            // 
            this.txt_MKCu.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txt_MKCu.Location = new System.Drawing.Point(368, 123);
            this.txt_MKCu.Name = "txt_MKCu";
            this.txt_MKCu.Size = new System.Drawing.Size(225, 25);
            this.txt_MKCu.TabIndex = 32;
            this.txt_MKCu.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label2.Location = new System.Drawing.Point(191, 183);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 18);
            this.label2.TabIndex = 31;
            this.label2.Text = "Mật khẩu mới";
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(532, 33);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(156, 40);
            this.btnThoat.TabIndex = 35;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // Uc_DoiMatKhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "Uc_DoiMatKhau";
            this.Size = new System.Drawing.Size(867, 530);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.TextBox txt_MKMoi1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_MkMoi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_MKCu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_DoiMK;
        private System.Windows.Forms.Button btnThoat;
    }
}
