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
    public partial class Uc_MonHoc : DevExpress.XtraEditors.XtraUserControl
    {
        BindingSource list = new BindingSource();
        public Uc_MonHoc()
        {
            InitializeComponent();
            LoadMonHoc();
            dgrMonHoc.DataSource = list;
            AddMonHocBinding();
            LockControl();
        }

        #region chuc nang
        private void LoadMonHoc()
        {
            list.DataSource = new MonHocDAO().GetAll();
        }
        private void AddMonHocBinding()
        {
            txbID.DataBindings.Add("Text", dgrMonHoc.DataSource, "ID", true, DataSourceUpdateMode.Never);
            txbTen.DataBindings.Add("Text", dgrMonHoc.DataSource, "Ten", true, DataSourceUpdateMode.Never);
            txbSoTin.DataBindings.Add("Text", dgrMonHoc.DataSource, "SoTin", true, DataSourceUpdateMode.Never);
            cboHocKy.DataBindings.Add("Text", dgrMonHoc.DataSource, "KyHoc", true, DataSourceUpdateMode.Never);
        }
        private void LockControl()
        {
            txbID.Enabled = false;
            txbTen.Enabled = false;
            txbSoTin.Enabled = false;
            cboHocKy.Enabled = false;
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
            txbSoTin.Enabled = true;
            cboHocKy.Enabled = true;
        }
        private void Empty()
        {
            //txbID.Clear();

            txbID.Text = "";
            txbTen.Text = "";
            txbSoTin.Text = "";
        }
        #endregion

        #region su kien
        private void btn_Them_Click(object sender, EventArgs e)
        {
            if (Common.Acc_type == "Root" || Common.Acc_type == "Admin")
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
                    MonHoc item = new MonHoc();

                    item.Ten = txbTen.Text;
                    item.KyHoc = Convert.ToInt32(cboHocKy.Text);
                    item.SoTin = Convert.ToInt32(txbSoTin.Text);

                    if (new MonHocDAO().Add(item))
                    {
                        LoadMonHoc();
                        MessageBox.Show("Thêm thành công");
                    }
                    else
                    {
                        MessageBox.Show("Không thành công");
                    }
                    LockControl();
                }
            }
            else
            {
                MessageBox.Show("Bạn không có quyền thực hiện tác vụ này");
            }

        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            if (Common.Acc_type == "Root" || Common.Acc_type == "Admin")
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
                    MonHoc item = new MonHoc();

                    item.ID = Convert.ToInt32(txbID.Text);
                    item.Ten = txbTen.Text;
                    item.KyHoc = Convert.ToInt32(cboHocKy.Text);
                    item.SoTin = Convert.ToInt32(txbSoTin.Text);

                    if (new MonHocDAO().Edit(item))
                    {
                        LoadMonHoc();
                        MessageBox.Show("Sửa thành công");
                    }
                    else
                    {
                        MessageBox.Show("Không thành công");
                    }
                    LockControl();
                }
            }
            else
            {
                MessageBox.Show("Bạn không có quyền thực hiện tác vụ này");
            }

        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (Common.Acc_type == "Root" || Common.Acc_type == "Admin")
            {
                if (btn_Xoa.Text == "Hủy")
                {
                    LoadMonHoc();
                    LockControl();
                }
                else
                {

                    if (MessageBox.Show("Bạn có chắc chắn muốn xóa ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        long id = Convert.ToInt32(txbID.Text);

                        if (new MonHocDAO().Remove(id))
                        {
                            LoadMonHoc();
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
            else
            {
                MessageBox.Show("Bạn không có quyền thực hiện tác vụ này");
            }

        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
        #endregion
    }
}
