namespace QuanLyDonVi.GUI
{
    partial class Uc_QLTaiKhoan
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
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.dgrAccount = new DevExpress.XtraGrid.GridControl();
            this.grvAccount = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.cboQuyen = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlPass = new System.Windows.Forms.Panel();
            this.txbPass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbRePass = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btn_Them = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txbUsername = new System.Windows.Forms.TextBox();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            this.pnlPass.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.groupControl1);
            this.panelControl2.Controls.Add(this.panelControl3);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(867, 530);
            this.panelControl2.TabIndex = 0;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.dgrAccount);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(2, 2);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(416, 526);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "Danh sách tài khoản";
            // 
            // dgrAccount
            // 
            this.dgrAccount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrAccount.Location = new System.Drawing.Point(2, 20);
            this.dgrAccount.MainView = this.grvAccount;
            this.dgrAccount.Name = "dgrAccount";
            this.dgrAccount.Size = new System.Drawing.Size(412, 504);
            this.dgrAccount.TabIndex = 0;
            this.dgrAccount.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvAccount});
            // 
            // grvAccount
            // 
            this.grvAccount.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.grvAccount.GridControl = this.dgrAccount;
            this.grvAccount.Name = "grvAccount";
            this.grvAccount.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.grvAccount.OptionsView.ShowGroupPanel = false;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.cboQuyen);
            this.panelControl3.Controls.Add(this.label4);
            this.panelControl3.Controls.Add(this.pnlPass);
            this.panelControl3.Controls.Add(this.panel1);
            this.panelControl3.Controls.Add(this.label1);
            this.panelControl3.Controls.Add(this.txbUsername);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl3.Location = new System.Drawing.Point(418, 2);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(447, 526);
            this.panelControl3.TabIndex = 0;
            // 
            // cboQuyen
            // 
            this.cboQuyen.Font = new System.Drawing.Font("Tahoma", 11F);
            this.cboQuyen.FormattingEnabled = true;
            this.cboQuyen.Items.AddRange(new object[] {
            "User",
            "Admin",
            "Root"});
            this.cboQuyen.Location = new System.Drawing.Point(198, 134);
            this.cboQuyen.Name = "cboQuyen";
            this.cboQuyen.Size = new System.Drawing.Size(225, 26);
            this.cboQuyen.TabIndex = 46;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label4.Location = new System.Drawing.Point(21, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 18);
            this.label4.TabIndex = 45;
            this.label4.Text = "Quyền";
            // 
            // pnlPass
            // 
            this.pnlPass.Controls.Add(this.txbPass);
            this.pnlPass.Controls.Add(this.label2);
            this.pnlPass.Controls.Add(this.txbRePass);
            this.pnlPass.Controls.Add(this.label3);
            this.pnlPass.Location = new System.Drawing.Point(6, 195);
            this.pnlPass.Name = "pnlPass";
            this.pnlPass.Size = new System.Drawing.Size(436, 117);
            this.pnlPass.TabIndex = 44;
            this.pnlPass.Visible = false;
            // 
            // txbPass
            // 
            this.txbPass.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txbPass.Location = new System.Drawing.Point(192, 13);
            this.txbPass.Name = "txbPass";
            this.txbPass.Size = new System.Drawing.Size(225, 25);
            this.txbPass.TabIndex = 40;
            this.txbPass.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label2.Location = new System.Drawing.Point(15, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 18);
            this.label2.TabIndex = 37;
            this.label2.Text = "Mật khẩu";
            // 
            // txbRePass
            // 
            this.txbRePass.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txbRePass.Location = new System.Drawing.Point(192, 73);
            this.txbRePass.Name = "txbRePass";
            this.txbRePass.Size = new System.Drawing.Size(225, 25);
            this.txbRePass.TabIndex = 42;
            this.txbRePass.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label3.Location = new System.Drawing.Point(15, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 18);
            this.label3.TabIndex = 41;
            this.label3.Text = "Xác nhận mật khẩu";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnXoa);
            this.panel1.Controls.Add(this.btn_Them);
            this.panel1.Location = new System.Drawing.Point(0, 431);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(447, 95);
            this.panel1.TabIndex = 43;
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(246, 27);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(156, 40);
            this.btnXoa.TabIndex = 46;
            this.btnXoa.Text = "Xóa tài khoản";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btn_Them
            // 
            this.btn_Them.Location = new System.Drawing.Point(44, 27);
            this.btn_Them.Name = "btn_Them";
            this.btn_Them.Size = new System.Drawing.Size(156, 40);
            this.btn_Them.TabIndex = 45;
            this.btn_Them.Text = "Thêm tài khoản";
            this.btn_Them.UseVisualStyleBackColor = true;
            this.btn_Them.Click += new System.EventHandler(this.btn_Them_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label1.Location = new System.Drawing.Point(21, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 18);
            this.label1.TabIndex = 39;
            this.label1.Text = "Tên đăng nhập";
            // 
            // txbUsername
            // 
            this.txbUsername.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txbUsername.Location = new System.Drawing.Point(198, 76);
            this.txbUsername.Name = "txbUsername";
            this.txbUsername.ReadOnly = true;
            this.txbUsername.Size = new System.Drawing.Size(225, 25);
            this.txbUsername.TabIndex = 38;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Tài khoản";
            this.gridColumn1.FieldName = "Username";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Quyền";
            this.gridColumn2.FieldName = "Type";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // Uc_QLTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl2);
            this.Name = "Uc_QLTaiKhoan";
            this.Size = new System.Drawing.Size(867, 530);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            this.pnlPass.ResumeLayout(false);
            this.pnlPass.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private System.Windows.Forms.TextBox txbRePass;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbPass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbUsername;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraGrid.GridControl dgrAccount;
        private DevExpress.XtraGrid.Views.Grid.GridView grvAccount;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btn_Them;
        private System.Windows.Forms.Panel pnlPass;
        private System.Windows.Forms.ComboBox cboQuyen;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
    }
}
