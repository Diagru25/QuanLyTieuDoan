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
    public partial class Uc_KetQuaHocTap : DevExpress.XtraEditors.XtraUserControl
    {
        List<TieuDoan> list_TieuDoan = new List<TieuDoan>();
        List<DaiDoi> list_DaiDoi = new List<DaiDoi>();
        List<Lop> list_Lop = new List<Lop>();
        public Uc_KetQuaHocTap()
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

            grcDSHocVien.DataSource = new HocVienDAO().GetDonVi();
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
                    grcDSHocVien.DataSource = new HocVienDAO().GetDonVi();
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
                    grcDSHocVien.DataSource = new HocVienDAO().GetDonVi().Where(x => x.TieuDoan_ID == value).ToList();
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
                    grcDSHocVien.DataSource = new HocVienDAO().GetDonVi().Where(x => x.TieuDoan_ID == Convert.ToInt32(cb_TieuDoan.SelectedValue.ToString())).ToList();
                }
                else
                {
                    list_Lop = new List<Lop>();
                    list_Lop.Add(new Lop() { ID = 0, Ten = "Tất cả" });
                    list_Lop.AddRange(new LopDAO().GetAll().Where(x => x.DaiDoiID == value).ToList());
                    cb_Lop.DataSource = list_Lop;
                    cb_Lop.DisplayMember = "Ten";
                    cb_Lop.ValueMember = "ID";
                    grcDSHocVien.DataSource = new HocVienDAO().GetDonVi().Where(x => x.DaiDoi_ID == value).ToList();
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
                    grcDSHocVien.DataSource = new HocVienDAO().GetDonVi().Where(x => x.DaiDoi_ID == Convert.ToInt32(cb_DaiDoi.SelectedValue.ToString()));
                }
                else
                {
                    grcDSHocVien.DataSource = new HocVienDAO().GetDonVi().Where(x => x.Lop_ID == value);
                }
            }
            catch
            {

            }

        }

        private void grvDSHocVien_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            pn_action.Enabled = true;
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {

            }
            catch
            {

            }
        }
    }
}
