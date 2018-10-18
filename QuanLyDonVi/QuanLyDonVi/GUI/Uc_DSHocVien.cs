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
    public partial class Uc_DSHocVien : DevExpress.XtraEditors.XtraUserControl
    {
        List<TieuDoan> list_TieuDoan = new List<TieuDoan>();
        List<DaiDoi> list_DaiDoi = new List<DaiDoi>();
        List<Lop> list_Lop = new List<Lop>();
        public Uc_DSHocVien()
        {
            InitializeComponent();
            list_TieuDoan.Add(new TieuDoan() { ID = 0, Ten = "Tất cả" });
            LoadData();
        }
        void LoadData()
        {
            list_TieuDoan.AddRange(new TieuDoanDAO().GetAll());
            cb_TieuDoan.DataSource = list_TieuDoan;
            cb_TieuDoan.DisplayMember = "Ten";
            cb_TieuDoan.ValueMember = "ID";

            grcHocVien.DataSource = new HocVienDAO().GetDonVi();
        }

        private void cb_TieuDoan_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                long value = Convert.ToInt32(cb_TieuDoan.SelectedValue.ToString());
                if (value.Equals(0))
                {
                    cb_DaiDoi.DataSource = null;
                    cb_Lop.DataSource = null;
                    grcHocVien.DataSource = new HocVienDAO().GetDonVi();
                }
                else
                {
                    list_DaiDoi = new List<DaiDoi>();
                    list_DaiDoi.Add(new DaiDoi() { ID = 0, Ten = "Tất cả" });
                    list_DaiDoi.AddRange(new DaiDoiDAO().GetAll().Where(x => x.TieuDoanID == value).ToList());
                    cb_DaiDoi.DataSource = list_DaiDoi;
                    cb_DaiDoi.DisplayMember = "Ten";
                    cb_DaiDoi.ValueMember = "ID";
                    cb_Lop.DataSource = null;
                    grcHocVien.DataSource = new HocVienDAO().GetDonVi().Where(x => x.TieuDoan_ID == value).ToList();
                }
            }
            catch
            {

            }
        }
        private void cb_DaiDoi_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                long value = Convert.ToInt32(cb_DaiDoi.SelectedValue.ToString());
                if (value.Equals(0))
                {
                    cb_Lop.DataSource = null;
                    grcHocVien.DataSource = new HocVienDAO().GetDonVi().Where(x => x.TieuDoan_ID == Convert.ToInt32(cb_TieuDoan.SelectedValue.ToString())).ToList();
                }
                else
                {
                    list_Lop = new List<Lop>();
                    list_Lop.Add(new Lop() { ID = 0, Ten = "Tất cả" });
                    list_Lop.AddRange(new LopDAO().GetAll().Where(x => x.DaiDoiID == value).ToList());
                    cb_Lop.DataSource = list_Lop;
                    cb_Lop.DisplayMember = "Ten";
                    cb_Lop.ValueMember = "ID";
                    grcHocVien.DataSource = new HocVienDAO().GetDonVi().Where(x => x.DaiDoi_ID == value).ToList();
                }
            }
            catch
            {

            }

        }
        private void cb_Lop_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                long value = Convert.ToInt32(cb_Lop.SelectedValue.ToString());
                if (value.Equals(0))
                {
                    cb_Lop.DataSource = null;
                    grcHocVien.DataSource = new HocVienDAO().GetDonVi().Where(x => x.DaiDoi_ID == Convert.ToInt32(cb_DaiDoi.SelectedValue.ToString()));
                }
                else
                {
                    grcHocVien.DataSource = new HocVienDAO().GetDonVi().Where(x => x.Lop_ID == value);
                }
            }
            catch
            {

            }

        }
        void ReloadTable()
        {
            cb_TieuDoan.SelectedValue = 0;
            grcHocVien.DataSource = new HocVienDAO().GetDonVi();
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            if (Common.Acc_type == "Root" || Common.Acc_type == "Admin")
            {
                FrLyLich f = new FrLyLich();
                f.ShowDialog();
                ReloadTable();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền thực hiện tác vụ này");
            }

        }

        private void btn_ChiTiet_Click(object sender, EventArgs e)
        {
            FrLyLich f = new FrLyLich(Convert.ToInt32(grvHocVien.GetFocusedRowCellValue("ID").ToString()));
            f.ShowDialog();
            ReloadTable();
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (Common.Acc_type == "Root" || Common.Acc_type == "Admin")
            {
                long id = Convert.ToInt32(grvHocVien.GetFocusedRowCellValue("ID").ToString());
                if (MessageBox.Show("Bạn muốn xóa học viên " + grvHocVien.GetFocusedRowCellValue("Ten").ToString() + " khỏi CSDL?", "Xóa học viên", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var res = new HocVienDAO().Delete(id);
                    if (res)
                    {
                        MessageBox.Show("Xóa thành công !", "Xóa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ReloadTable();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi xảy ra ! Vui lòng thử lại !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        ReloadTable();
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn không có quyền thực hiện tác vụ này");
            }

        }

        private void grvHocVien_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            btn_ChiTiet.Enabled = true;
            btn_Xoa.Enabled = true;
        }
    }
}
