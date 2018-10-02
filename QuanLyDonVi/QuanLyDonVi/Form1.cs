using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanLyDonVi.GUI;
using QuanLyDonVi.Model.EF;

namespace QuanLyDonVi
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        Account acc = new Account();
        public Form1()
        {
            InitializeComponent();
        }
        public Form1(Account _acc)
        {
            InitializeComponent();
            acc = _acc;
        }
        void LoadUc(Control ctrl)
        {
            panelmain.Controls.Clear();
            panelmain.Controls.Add(ctrl);
            ctrl.Dock = DockStyle.Fill;
            ctrl.BringToFront();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadUc(new Uc_DSHocVien());
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadUc(new Uc_KetQuaHocTap());
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadUc(new Uc_KetQuaTheLuc());
        }

        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadUc(new Uc_KetQuaCTD());
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadUc(new Uc_TieuDoan());
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadUc(new Uc_DaiDoi());
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadUc(new Uc_Lop());
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadUc(new Uc_MonHoc());
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadUc(new Uc_MonTheLuc());
        }

        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadUc(new Uc_MonCTD());
        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadUc(new Uc_DoiMatKhau(acc));
        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadUc(new Uc_QLTaiKhoan(acc));
        }
    }
}
