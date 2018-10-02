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
using QuanLyDonVi.DAO;
using QuanLyDonVi.Model.EF;

namespace QuanLyDonVi.GUI
{
    public partial class Uc_QLTaiKhoan : DevExpress.XtraEditors.XtraUserControl
    {
        BindingSource list = new BindingSource();
        public Uc_QLTaiKhoan()
        {
            InitializeComponent();
            LoadAccount();
            dgrAccount.DataSource = list;
            Binding();
        }

        private void LoadAccount()
        {
            list.DataSource = new AccountDAO().GetAll();
        }

        private void Binding()
        {
            txbUsername.DataBindings.Add("Text", dgrAccount.DataSource, "Username", true, DataSourceUpdateMode.Never);
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            if(btn_Them.Text == "Thêm tài khoản")
            {
                btn_Them.Text = "Lưu";
                btnXoa.Text = "Hủy";
                pnlPass.Visible = true;
                txbUsername.ReadOnly = false;
                txbUsername.Clear();
            }
            else
            {
                if(txbPass.Text == txbRePass.Text)
                {
                    Account item = new Account();
                    item.Username = txbUsername.Text;
                    item.Password = txbPass.Text; 
                    if (new AccountDAO().Add(item))
                    {
                        LoadAccount();
                        MessageBox.Show("Thêm thành công");
                    }
                    else
                    {
                        MessageBox.Show("Không thành công");
                    }

                    pnlPass.Visible = false;
                    txbUsername.ReadOnly = true;
                    btn_Them.Text = "Thêm tài khoản";
                    btnXoa.Text = "Xóa tài khoản";
                }
                else
                {
                    MessageBox.Show("Xác nhận mật khẩu không chính xác");
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(btnXoa.Text == "Hủy")
            {
                pnlPass.Visible = false;
                txbUsername.ReadOnly = true;
                btn_Them.Text = "Thêm tài khoản";
                btnXoa.Text = "Xóa tài khoản";
            }
            else
            {
                if (MessageBox.Show("Bạn có muốn xóa không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if(new AccountDAO().Remove(txbUsername.Text))
                    {
                        LoadAccount();
                    }
                }
            }
        }
    }
}
