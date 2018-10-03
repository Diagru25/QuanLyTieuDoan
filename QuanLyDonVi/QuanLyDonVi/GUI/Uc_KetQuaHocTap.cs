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
using QuanLyDonVi.Model.View;

namespace QuanLyDonVi.GUI
{
    public partial class Uc_KetQuaHocTap : DevExpress.XtraEditors.XtraUserControl
    {
        List<TieuDoan> list_TieuDoan = new List<TieuDoan>();
        List<DaiDoi> list_DaiDoi = new List<DaiDoi>();
        List<Lop> list_Lop = new List<Lop>();
        List<DiemView> list_Diem = new List<DiemView>();
        long id_rowchange;
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

        void LoadDataDiem()
        {
            long hocvienid = Convert.ToInt32(grvDSHocVien.GetFocusedRowCellValue("ID").ToString());
            int hocky = Convert.ToInt16(comboBox1.Text);
            list_Diem.Clear();
            list_Diem.AddRange(new HocVienDAO().KetQuaHocTap(hocvienid, hocky));
            grcKetQua.DataSource = null;
            grcKetQua.DataSource = list_Diem;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                gr_data.Enabled = true;
                LoadDataDiem();
            }
            catch
            {

            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            if(btn_Sua.Text == "Sửa")
            {
                gridColumn5.OptionsColumn.ReadOnly = false;
                btn_Sua.Text = "Lưu";
                MessageBox.Show("Bạn có thể sửa điểm học viên trong bảng !", "Sửa điểm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btn_Huy_In.Text = "Hủy";
            }
            else
            {
                btn_Sua.Text = "Sửa";
                btn_Huy_In.Text = "In kết quả";
                gridColumn5.OptionsColumn.ReadOnly = true;
                HocVien_MonHoc temp = new HocVien_MonHoc();
                temp.HocVienID = Convert.ToInt32(grvDSHocVien.GetFocusedRowCellValue("ID").ToString());
                HocVienDAO dao = new HocVienDAO();
                foreach(var item in list_Diem)
                {
                    temp.MonHocID = item.MonHocID;
                    if (item.KetQua < 0 || item.KetQua > 10) { MessageBox.Show("Bạn không thể nhập điểm < 0 hoặc > 10 !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Hand); continue; }
                    temp.Diem = item.KetQua;
                    dao.EditDiem(temp);
                }
                MessageBox.Show("Cập nhật thành công !", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataDiem();
            }

        }

        private void grvKetQua_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            id_rowchange = Convert.ToInt32(grvKetQua.GetFocusedRowCellValue("MonHocID").ToString());
            float Diem = Convert.ToSingle(grvKetQua.GetFocusedRowCellDisplayText("KetQua").ToString());
            list_Diem.Find(x => x.MonHocID == id_rowchange).KetQua = Diem;
        }

        private void btn_Huy_In_Click(object sender, EventArgs e)
        {
            if(btn_Huy_In.Text == "Hủy")
            {
                btn_Sua.Text = "Sửa";
                btn_Huy_In.Text = "In kết quả";
                gridColumn5.OptionsColumn.ReadOnly = true;
                LoadDataDiem();
            }
            else
            {

            }
        }
    }
}
