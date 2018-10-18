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
    public partial class Uc_MonTheLuc : DevExpress.XtraEditors.XtraUserControl
    {
        BindingSource list = new BindingSource();
        public Uc_MonTheLuc()
        {
            InitializeComponent();
            LoadMonTheLuc();
            dgrMonTheLuc.DataSource = list;
            AddMonTheLucBinding();
            LockControl();
        }

        #region chuc nang
        private void LoadMonTheLuc()
        {
            list.DataSource = new MonTheLucDAO().GetAll();
        }
        private void AddMonTheLucBinding()
        {
            txbID.DataBindings.Add("Text", dgrMonTheLuc.DataSource, "ID", true, DataSourceUpdateMode.Never);
            txbTen.DataBindings.Add("Text", dgrMonTheLuc.DataSource, "Ten", true, DataSourceUpdateMode.Never);
            txbDonViTinh.DataBindings.Add("Text", dgrMonTheLuc.DataSource, "DonViTinh", true, DataSourceUpdateMode.Never);
            txbDat.DataBindings.Add("Text", dgrMonTheLuc.DataSource, "Dat", true, DataSourceUpdateMode.Never);
            txbKha.DataBindings.Add("Text", dgrMonTheLuc.DataSource, "Kha", true, DataSourceUpdateMode.Never);
            txbGioi.DataBindings.Add("Text", dgrMonTheLuc.DataSource, "Gioi", true, DataSourceUpdateMode.Never);

        }
        private void LockControl()
        {
            txbID.Enabled = false;
            txbTen.Enabled = false;
            txbDonViTinh.Enabled = false;
            txbDat.Enabled = false;
            txbKha.Enabled = false;
            txbGioi.Enabled = false;
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
            txbDonViTinh.Enabled = true;
            txbDat.Enabled = true;
            txbKha.Enabled = true;
            txbGioi.Enabled = true;
        }
        private void Empty()
        {
            //txbID.Clear();

            txbID.Text = "";
            txbTen.Text = "";
            txbDonViTinh.Text = "";
            txbDat.Text = "";
            txbKha.Text = "";
            txbGioi.Text = "";
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
                    MonTheLuc item = new MonTheLuc();

                    item.Ten = txbTen.Text;
                    item.DonViTinh = txbDonViTinh.Text;
                    item.Dat = Convert.ToDouble(txbDat.Text);
                    item.Kha = Convert.ToDouble(txbKha.Text);
                    item.Gioi = Convert.ToDouble(txbGioi.Text);

                    if (new MonTheLucDAO().Add(item))
                    {
                        LoadMonTheLuc();
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
                    MonTheLuc item = new MonTheLuc();

                    item.ID = Convert.ToInt32(txbID.Text);
                    item.Ten = txbTen.Text;
                    item.DonViTinh = txbDonViTinh.Text;
                    item.Dat = Convert.ToDouble(txbDat.Text);
                    item.Kha = Convert.ToDouble(txbKha.Text);
                    item.Gioi = Convert.ToDouble(txbGioi.Text);

                    if (new MonTheLucDAO().Edit(item))
                    {
                        LoadMonTheLuc();
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
                    LoadMonTheLuc();
                    LockControl();
                }
                else
                {

                    if (MessageBox.Show("Bạn có chắc chắn muốn xóa ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        long id = Convert.ToInt32(txbID.Text);

                        if (new MonTheLucDAO().Remove(id))
                        {
                            LoadMonTheLuc();
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
