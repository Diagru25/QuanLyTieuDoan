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
    public partial class Uc_MonCTD : DevExpress.XtraEditors.XtraUserControl
    {
        BindingSource list = new BindingSource();
        public Uc_MonCTD()
        {
            InitializeComponent();
            LoadCongTacDang();
            dgrCongTacDang.DataSource = list;
            AddCongTacDangBinding();
            LockControl();
        }

        #region chuc nang
        private void LoadCongTacDang()
        {
            list.DataSource = new CongTacDangDAO().GetAll();
        }
        private void AddCongTacDangBinding()
        {
            txbID.DataBindings.Add("Text", dgrCongTacDang.DataSource, "ID", true, DataSourceUpdateMode.Never);
            txbTen.DataBindings.Add("Text", dgrCongTacDang.DataSource, "Ten", true, DataSourceUpdateMode.Never);
            txbDat.DataBindings.Add("Text", dgrCongTacDang.DataSource, "Dat", true, DataSourceUpdateMode.Never);
            txbKha.DataBindings.Add("Text", dgrCongTacDang.DataSource, "Kha", true, DataSourceUpdateMode.Never);
            txbGioi.DataBindings.Add("Text", dgrCongTacDang.DataSource, "Gioi", true, DataSourceUpdateMode.Never);

        }
        private void LockControl()
        {
            txbID.Enabled = false;
            txbTen.Enabled = false;
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
            txbDat.Enabled = true;
            txbKha.Enabled = true;
            txbGioi.Enabled = true;
        }
        private void Empty()
        {
            //txbID.Clear();

            txbID.Text = "";
            txbTen.Text = "";
            txbDat.Text = "";
            txbKha.Text = "";
            txbGioi.Text = "";
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
                CongTacDang item = new CongTacDang();

                item.Ten = txbTen.Text;
                item.Dat = Convert.ToDouble(txbDat.Text);
                item.Kha = Convert.ToDouble(txbKha.Text);
                item.Gioi = Convert.ToDouble(txbGioi.Text);

                if (new CongTacDangDAO().Add(item))
                {
                    LoadCongTacDang();
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
                CongTacDang item = new CongTacDang();

                item.ID = Convert.ToInt32(txbID.Text);
                item.Ten = txbTen.Text;
                item.Dat = Convert.ToDouble(txbDat.Text);
                item.Kha = Convert.ToDouble(txbKha.Text);
                item.Gioi = Convert.ToDouble(txbGioi.Text);

                if (new CongTacDangDAO().Edit(item))
                {
                    LoadCongTacDang();
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
                LoadCongTacDang();
                LockControl();
            }
            else
            {

                if (MessageBox.Show("Bạn có chắc chắn muốn xóa ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    long id = Convert.ToInt32(txbID.Text);

                    if (new CongTacDangDAO().Remove(id))
                    {
                        LoadCongTacDang();
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
