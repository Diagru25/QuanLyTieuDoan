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
    public partial class Uc_Lop : DevExpress.XtraEditors.XtraUserControl
    {
        BindingSource list = new BindingSource();
        public Uc_Lop()
        {
            InitializeComponent();
            LoadLop();
            LoadcboTieuDoan();
            LoadcboDaiDoi();
            dgrLop.DataSource = list;
            AddLopBinding();
            LockControl();
        }

        #region chuc nang
        private void LoadLop()
        {
            list.DataSource = new LopDAO().GetAll();
        }
        private void LoadcboTieuDoan()
        {
            cboTieuDoan.DataSource = new TieuDoanDAO().GetAll();
            cboTieuDoan.DisplayMember = "Ten";
            cboTieuDoan.ValueMember = "ID";
        }
        private void LoadcboDaiDoi(long id = 0)
        {
            if (id == 0)
                cboDaiDoi.DataSource = new DaiDoiDAO().GetAll();
            else
                cboDaiDoi.DataSource = new DaiDoiDAO().GetAllByTieuDoanID(id);

            cboDaiDoi.DisplayMember = "Ten";
            cboDaiDoi.ValueMember = "ID";
        }
        private void AddLopBinding()
        {
            txbID.DataBindings.Add("Text", dgrLop.DataSource, "ID", true, DataSourceUpdateMode.Never);
            txbTen.DataBindings.Add("Text", dgrLop.DataSource, "Ten", true, DataSourceUpdateMode.Never);
            txbGhiChu.DataBindings.Add("Text", dgrLop.DataSource, "GhiChu", true, DataSourceUpdateMode.Never);
            //cboTieuDoan.DataBindings.Add("SelectedValue", dgrLop.DataSource, "TieuDoanID", true, DataSourceUpdateMode.Never);
            cboDaiDoi.DataBindings.Add("SelectedValue", dgrLop.DataSource, "DaiDoiID", true, DataSourceUpdateMode.Never);
        }
        private void LockControl()
        {
            txbID.Enabled = false;
            txbTen.Enabled = false;
            txbGhiChu.Enabled = false;
            cboTieuDoan.Enabled = false;
            cboDaiDoi.Enabled = false;
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
            cboDaiDoi.Enabled = true;
        }
        private void Empty()
        {
            //txbID.Clear();

            txbID.Text = "";
            txbTen.Text = "";
            txbGhiChu.Text = "";
        }
        #endregion

        #region
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
                Lop item = new Lop();

                item.Ten = txbTen.Text;
                item.GhiChu = txbGhiChu.Text;
                item.DaiDoiID = Convert.ToInt32(cboDaiDoi.SelectedValue);

                if (new LopDAO().Add(item))
                {
                    LoadLop();
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
                Lop item = new Lop();

                item.ID = Convert.ToInt32(txbID.Text);
                item.Ten = txbTen.Text;
                item.GhiChu = txbGhiChu.Text;
                item.DaiDoiID = Convert.ToInt32(cboDaiDoi.SelectedValue);

                if (new LopDAO().Edit(item))
                {
                    LoadLop();
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
                LoadLop();
                LockControl();
            }
            else
            {

                if (MessageBox.Show("Bạn có chắc chắn muốn xóa ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    long id = Convert.ToInt32(txbID.Text);

                    if (new LopDAO().Remove(id))
                    {
                        LoadLop();
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

        private void cboTieuDoan_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboTieuDoan.Enabled == true)
                {
                    LoadcboDaiDoi(Convert.ToInt32(cboTieuDoan.SelectedValue));
                }
            }
            catch
            {

            }
        }

        private void cboDaiDoi_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboTieuDoan.Enabled == false /* cboDaiDoi.Enable == false */)
                {
                    cboTieuDoan.SelectedValue = new DaiDoiDAO().GetTieuDoanIDByDaiDoiID(Convert.ToInt32(cboDaiDoi.SelectedValue));
                }
            }
            catch
            {

            }
        }
        #endregion
    }
}
