namespace QuanLyDonVi.GUI
{
    partial class Uc_KetQuaHocTap
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.grcDSHocVien = new DevExpress.XtraGrid.GridControl();
            this.grvDSHocVien = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.cb_Lop = new System.Windows.Forms.ComboBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cb_DaiDoi = new System.Windows.Forms.ComboBox();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cb_TieuDoan = new System.Windows.Forms.ComboBox();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.gr_data = new DevExpress.XtraEditors.GroupControl();
            this.grcKetQua = new DevExpress.XtraGrid.GridControl();
            this.grvKetQua = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pn_action = new DevExpress.XtraEditors.PanelControl();
            this.btn_Luu = new System.Windows.Forms.Button();
            this.btn_Sua = new System.Windows.Forms.Button();
            this.btn_In = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcDSHocVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDSHocVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gr_data)).BeginInit();
            this.gr_data.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcKetQua)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKetQua)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pn_action)).BeginInit();
            this.pn_action.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.groupControl1);
            this.panelControl1.Controls.Add(this.panelControl3);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl1.Location = new System.Drawing.Point(636, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(231, 530);
            this.panelControl1.TabIndex = 0;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.grcDSHocVien);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(2, 168);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(227, 360);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "Danh sách học viên";
            // 
            // grcDSHocVien
            // 
            this.grcDSHocVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcDSHocVien.Location = new System.Drawing.Point(2, 20);
            this.grcDSHocVien.MainView = this.grvDSHocVien;
            this.grcDSHocVien.Name = "grcDSHocVien";
            this.grcDSHocVien.Size = new System.Drawing.Size(223, 338);
            this.grcDSHocVien.TabIndex = 0;
            this.grcDSHocVien.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDSHocVien});
            // 
            // grvDSHocVien
            // 
            this.grvDSHocVien.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.grvDSHocVien.GridControl = this.grcDSHocVien;
            this.grvDSHocVien.Name = "grvDSHocVien";
            this.grvDSHocVien.OptionsBehavior.Editable = false;
            this.grvDSHocVien.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.grvDSHocVien.OptionsView.ShowGroupPanel = false;
            this.grvDSHocVien.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.grvDSHocVien_RowCellClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "ID";
            this.gridColumn1.FieldName = "ID";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 48;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Họ và tên";
            this.gridColumn2.FieldName = "Ten";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 157;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.cb_Lop);
            this.panelControl3.Controls.Add(this.labelControl1);
            this.panelControl3.Controls.Add(this.cb_DaiDoi);
            this.panelControl3.Controls.Add(this.labelControl2);
            this.panelControl3.Controls.Add(this.cb_TieuDoan);
            this.panelControl3.Controls.Add(this.labelControl3);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl3.Location = new System.Drawing.Point(2, 2);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(227, 166);
            this.panelControl3.TabIndex = 0;
            // 
            // cb_Lop
            // 
            this.cb_Lop.Font = new System.Drawing.Font("Tahoma", 11F);
            this.cb_Lop.FormattingEnabled = true;
            this.cb_Lop.Location = new System.Drawing.Point(80, 118);
            this.cb_Lop.Name = "cb_Lop";
            this.cb_Lop.Size = new System.Drawing.Size(136, 26);
            this.cb_Lop.TabIndex = 19;
            this.cb_Lop.SelectedValueChanged += new System.EventHandler(this.cb_Lop_SelectedValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Location = new System.Drawing.Point(10, 124);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(31, 14);
            this.labelControl1.TabIndex = 18;
            this.labelControl1.Text = "Lớp :";
            // 
            // cb_DaiDoi
            // 
            this.cb_DaiDoi.Font = new System.Drawing.Font("Tahoma", 11F);
            this.cb_DaiDoi.FormattingEnabled = true;
            this.cb_DaiDoi.Location = new System.Drawing.Point(80, 68);
            this.cb_DaiDoi.Name = "cb_DaiDoi";
            this.cb_DaiDoi.Size = new System.Drawing.Size(136, 26);
            this.cb_DaiDoi.TabIndex = 17;
            this.cb_DaiDoi.SelectedValueChanged += new System.EventHandler(this.cb_DaiDoi_SelectedValueChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Location = new System.Drawing.Point(10, 74);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(46, 14);
            this.labelControl2.TabIndex = 16;
            this.labelControl2.Text = "Đại đội:";
            // 
            // cb_TieuDoan
            // 
            this.cb_TieuDoan.Font = new System.Drawing.Font("Tahoma", 11F);
            this.cb_TieuDoan.FormattingEnabled = true;
            this.cb_TieuDoan.Location = new System.Drawing.Point(80, 22);
            this.cb_TieuDoan.Name = "cb_TieuDoan";
            this.cb_TieuDoan.Size = new System.Drawing.Size(136, 26);
            this.cb_TieuDoan.TabIndex = 15;
            this.cb_TieuDoan.SelectedValueChanged += new System.EventHandler(this.cb_TieuDoan_SelectedValueChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Location = new System.Drawing.Point(10, 28);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(64, 14);
            this.labelControl3.TabIndex = 14;
            this.labelControl3.Text = "Tiểu đoàn:";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.gr_data);
            this.panelControl2.Controls.Add(this.pn_action);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(636, 530);
            this.panelControl2.TabIndex = 1;
            // 
            // gr_data
            // 
            this.gr_data.Controls.Add(this.grcKetQua);
            this.gr_data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gr_data.Enabled = false;
            this.gr_data.Location = new System.Drawing.Point(2, 124);
            this.gr_data.Name = "gr_data";
            this.gr_data.Size = new System.Drawing.Size(632, 404);
            this.gr_data.TabIndex = 3;
            this.gr_data.Text = "Kết quả";
            // 
            // grcKetQua
            // 
            this.grcKetQua.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcKetQua.Font = new System.Drawing.Font("Tahoma", 11F);
            this.grcKetQua.Location = new System.Drawing.Point(2, 20);
            this.grcKetQua.MainView = this.grvKetQua;
            this.grcKetQua.Name = "grcKetQua";
            this.grcKetQua.Size = new System.Drawing.Size(628, 382);
            this.grcKetQua.TabIndex = 2;
            this.grcKetQua.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvKetQua});
            // 
            // grvKetQua
            // 
            this.grvKetQua.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.grvKetQua.Appearance.HeaderPanel.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.grvKetQua.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvKetQua.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 11F);
            this.grvKetQua.Appearance.Row.Options.UseFont = true;
            this.grvKetQua.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn4,
            this.gridColumn6,
            this.gridColumn5});
            this.grvKetQua.GridControl = this.grcKetQua;
            this.grvKetQua.Name = "grvKetQua";
            this.grvKetQua.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.grvKetQua.OptionsFind.AlwaysVisible = true;
            this.grvKetQua.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Môn học";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 0;
            this.gridColumn4.Width = 297;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Số TC";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.ReadOnly = true;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 1;
            this.gridColumn6.Width = 89;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Điểm Tổng kết";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 2;
            this.gridColumn5.Width = 139;
            // 
            // pn_action
            // 
            this.pn_action.Controls.Add(this.btn_Luu);
            this.pn_action.Controls.Add(this.btn_Sua);
            this.pn_action.Controls.Add(this.btn_In);
            this.pn_action.Controls.Add(this.comboBox1);
            this.pn_action.Controls.Add(this.labelControl4);
            this.pn_action.Dock = System.Windows.Forms.DockStyle.Top;
            this.pn_action.Enabled = false;
            this.pn_action.Location = new System.Drawing.Point(2, 2);
            this.pn_action.Name = "pn_action";
            this.pn_action.Size = new System.Drawing.Size(632, 122);
            this.pn_action.TabIndex = 2;
            // 
            // btn_Luu
            // 
            this.btn_Luu.Location = new System.Drawing.Point(409, 74);
            this.btn_Luu.Name = "btn_Luu";
            this.btn_Luu.Size = new System.Drawing.Size(142, 29);
            this.btn_Luu.TabIndex = 20;
            this.btn_Luu.Text = "Lưu";
            this.btn_Luu.UseVisualStyleBackColor = true;
            // 
            // btn_Sua
            // 
            this.btn_Sua.Location = new System.Drawing.Point(141, 74);
            this.btn_Sua.Name = "btn_Sua";
            this.btn_Sua.Size = new System.Drawing.Size(142, 29);
            this.btn_Sua.TabIndex = 19;
            this.btn_Sua.Text = "Sửa";
            this.btn_Sua.UseVisualStyleBackColor = true;
            // 
            // btn_In
            // 
            this.btn_In.Location = new System.Drawing.Point(409, 27);
            this.btn_In.Name = "btn_In";
            this.btn_In.Size = new System.Drawing.Size(142, 29);
            this.btn_In.TabIndex = 18;
            this.btn_In.Text = "In kết quả";
            this.btn_In.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Tahoma", 11F);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.comboBox1.Location = new System.Drawing.Point(141, 28);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(142, 26);
            this.comboBox1.TabIndex = 17;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl4.Location = new System.Drawing.Point(70, 34);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(41, 14);
            this.labelControl4.TabIndex = 16;
            this.labelControl4.Text = "Học kỳ";
            // 
            // Uc_KetQuaHocTap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "Uc_KetQuaHocTap";
            this.Size = new System.Drawing.Size(867, 530);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcDSHocVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDSHocVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gr_data)).EndInit();
            this.gr_data.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcKetQua)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKetQua)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pn_action)).EndInit();
            this.pn_action.ResumeLayout(false);
            this.pn_action.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private System.Windows.Forms.ComboBox cb_Lop;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.ComboBox cb_DaiDoi;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.ComboBox cb_TieuDoan;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraGrid.GridControl grcDSHocVien;
        private DevExpress.XtraGrid.Views.Grid.GridView grvDSHocVien;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.GroupControl gr_data;
        private DevExpress.XtraGrid.GridControl grcKetQua;
        private DevExpress.XtraGrid.Views.Grid.GridView grvKetQua;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.PanelControl pn_action;
        private System.Windows.Forms.Button btn_In;
        private System.Windows.Forms.ComboBox comboBox1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private System.Windows.Forms.Button btn_Luu;
        private System.Windows.Forms.Button btn_Sua;
    }
}
