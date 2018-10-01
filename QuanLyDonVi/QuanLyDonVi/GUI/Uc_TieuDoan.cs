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
    public partial class Uc_TieuDoan : DevExpress.XtraEditors.XtraUserControl
    {
        BindingSource list = new BindingSource();

        public Uc_TieuDoan()
        {
            InitializeComponent();
            LoadTieuDoan();
            dgrTieuDoan.DataSource = list;
            AddTieuDoanBinding();
            LockControl();
        }


        #region chuc nang
        private void LoadTieuDoan()
        {
            list.DataSource = new TieuDoanDAO().GetAll();
        }
        private void AddTieuDoanBinding()
        {
            txbID.DataBindings.Add("Text", dgrTieuDoan.DataSource, "ID", true, DataSourceUpdateMode.Never);
            txbTen.DataBindings.Add("Text", dgrTieuDoan.DataSource, "Ten", true, DataSourceUpdateMode.Never);
            txbGhiChu.DataBindings.Add("Text", dgrTieuDoan.DataSource, "GhiChu", true, DataSourceUpdateMode.Never);
        }
        private void LockControl()
        {
            txbID.Enabled = false;
            txbTen.Enabled = false;
            txbGhiChu.Enabled = false;
            btn_Them.Enabled = true;
            btn_Sua.Enabled = true;
            btn_Xoa.Enabled = true;
            btn_Them.Text = "Thêm";
            btn_Sua.Text = "Sửa";
            btn_Xoa.Text = "Xóa";
        }
        private void UnLockControl()
        {
            txbID.Enabled = true;
            txbTen.Enabled = true;
            txbGhiChu.Enabled = true;
        }
        private void Empty()
        {
            //txbID.Clear();

            txbID.Text = "";
            txbTen.Text = "";
            txbGhiChu.Text = "";
        }
        #endregion

        #region su kien
        private void btn_Them_Click(object sender, EventArgs e)
        {
            if (btn_Them.Text == "Thêm")
            {
                btn_Sua.Enabled = false;
                btn_Them.Text = "Lưu";
                btn_Xoa.Text = "Hủy";
                UnLockControl();
                Empty();
            }
            else
            {
                TieuDoan item = new TieuDoan();

                item.Ten = txbTen.Text;
                item.GhiChu = txbGhiChu.Text;

                if(new TieuDoanDAO().Add(item))
                {
                    LoadTieuDoan();
                    MessageBox.Show("Thêm thành công");
                }
                else
                {
                    MessageBox.Show("Không thành công");
                }
                LockControl();
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            if (btn_Sua.Text == "Sửa")
            {
                btn_Them.Enabled = false;
                btn_Sua.Text = "Lưu";
                btn_Xoa.Text = "Hủy";
                UnLockControl();
            }
            else
            {
                TieuDoan item = new TieuDoan();

                item.ID = Convert.ToInt32(txbID.Text);
                item.Ten = txbTen.Text;
                item.GhiChu = txbGhiChu.Text;

                if (new TieuDoanDAO().Edit(item))
                {
                    LoadTieuDoan();
                    MessageBox.Show("Sửa thành công");
                }
                else
                {
                    MessageBox.Show("Không thành công");
                }
                LockControl();
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (btn_Xoa.Text == "Hủy")
            {
                LoadTieuDoan();
                LockControl();
            }
            else
            {

                if(MessageBox.Show("Bạn có chắc chắn muốn xóa ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    long id = Convert.ToInt32(txbID.Text);

                    if (new TieuDoanDAO().Remove(id))
                    {
                        LoadTieuDoan();
                        MessageBox.Show("Xóa thành công");
                    }
                    else
                    {
                        MessageBox.Show("Không thành công");
                    }
                    LockControl();
                }              
            }
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        #endregion
    }
}
