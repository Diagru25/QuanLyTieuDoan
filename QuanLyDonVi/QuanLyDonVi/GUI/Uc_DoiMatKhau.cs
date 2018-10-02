using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QuanLyDonVi.Model.EF;
using QuanLyDonVi.DAO;

namespace QuanLyDonVi.GUI
{
    public partial class Uc_DoiMatKhau : DevExpress.XtraEditors.XtraUserControl
    {
        Account acc = new Account();

        public Uc_DoiMatKhau()
        {
            InitializeComponent();
        }

        public Uc_DoiMatKhau(Account _acc)
        {
            InitializeComponent();
            acc = _acc;
        }

        private void btn_DoiMK_Click(object sender, EventArgs e)
        {
            string mk_moi = txt_MkMoi.Text;
            string mk_moi1 = txt_MKMoi1.Text;
            if (mk_moi == mk_moi1)
            {
                if (new AccountDAO().Edit(acc.Username, mk_moi))
                {
                    MessageBox.Show("Đổi mật khẩu thành công");
                }
                else
                    MessageBox.Show("Không thành công");
            }
            else
                MessageBox.Show("Xác nhận mật khẩu không chính xác");
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
