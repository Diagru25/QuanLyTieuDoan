using QuanLyDonVi.DAO;
using QuanLyDonVi.Model.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDonVi
{
    public partial class FrmDangNhap : Form
    {
        public FrmDangNhap()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Account acc = new Account();
            acc = new AccountDAO().Is_login(txbUsername.Text, txbPass.Text);
            if (acc != null)
            {
                Common.Acc_type = acc.Type;
                Form1 frm = new Form1(acc);
                this.Hide();
                frm.ShowDialog();
                txbUsername.Text = "";
                txbPass.Text = "";
                this.Show();
                
            }
            else
            {
                MessageBox.Show("Tài khoản, mật khẩu không chính xác");
            }
        }
    }
}
