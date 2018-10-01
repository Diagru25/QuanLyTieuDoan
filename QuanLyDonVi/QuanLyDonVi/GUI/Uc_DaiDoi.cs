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
    public partial class Uc_DaiDoi : DevExpress.XtraEditors.XtraUserControl
    {
        BindingSource list = new BindingSource();
        public Uc_DaiDoi()
        {
            InitializeComponent();
            LoadDaiDoi();
            LoadcboTieuDoan();
            dgrDaiDoi.DataSource = list;
            AddDaiDoiBinding();
            LockControl();

        }

        #region chuc nang
        private void LoadDaiDoi()
        {
            list.DataSource = new DaiDoiDAO().GetAll();
        }
        private void LoadcboTieuDoan()
        {
            cboTieuDoan.DataSource = new TieuDoanDAO().GetAll();
            cboTieuDoan.DisplayMember = "Ten";
            cboTieuDoan.ValueMember = "ID";
        }
        private void AddDaiDoiBinding()
        {
            txbID.DataBindings.Add("Text", dgrDaiDoi.DataSource, "ID", true, DataSourceUpdateMode.Never);
            txbTen.DataBindings.Add("Text", dgrDaiDoi.DataSource, "Ten", true, DataSourceUpdateMode.Never);
            txbGhiChu.DataBindings.Add("Text", dgrDaiDoi.DataSource, "GhiChu", true, DataSourceUpdateMode.Never);
            cboTieuDoan.DataBindings.Add("SelectedValue", dgrDaiDoi.DataSource, "TieuDoanID", true, DataSourceUpdateMode.Never);
        }
        private void LockControl()
        {
            txbID.Enabled = false;
            txbTen.Enabled = false;
            txbGhiChu.Enabled = false;
            cboTieuDoan.Enabled = false;
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
            cboTieuDoan.Enabled = true;
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
                DaiDoi item = new DaiDoi();

                item.Ten = txbTen.Text;
                item.GhiChu = txbGhiChu.Text;
                item.TieuDoanID = Convert.ToInt32(cboTieuDoan.SelectedValue);

                if (new DaiDoiDAO().Add(item))
                {
                    LoadDaiDoi();
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
                DaiDoi item = new DaiDoi();

                item.ID = Convert.ToInt32(txbID.Text);
                item.Ten = txbTen.Text;
                item.GhiChu = txbGhiChu.Text;
                item.TieuDoanID = Convert.ToInt32(cboTieuDoan.SelectedValue);

                if (new DaiDoiDAO().Edit(item))
                {
                    LoadDaiDoi();
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
                LoadDaiDoi();
                LockControl();
            }
            else
            {

                if (MessageBox.Show("Bạn có chắc chắn muốn xóa ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    long id = Convert.ToInt32(txbID.Text);

                    if (new DaiDoiDAO().Remove(id))
                    {
                        LoadDaiDoi();
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
