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
using QuanLyDonVi.Model.View;

namespace QuanLyDonVi.GUI
{
    public partial class Uc_KetQuaCTD : DevExpress.XtraEditors.XtraUserControl
    {
        List<TieuDoan> list_TieuDoan = new List<TieuDoan>();
        List<DaiDoi> list_DaiDoi = new List<DaiDoi>();
        List<Lop> list_Lop = new List<Lop>();
        List<KQCTD> list_KQCTD = new List<KQCTD>();
        long id_rowchange;
        public Uc_KetQuaCTD()
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
            comboBox1.SelectedIndex = -1;

        }
        void LoadDataKQCTD()
        {
            long hocvienid = Convert.ToInt32(grvDSHocVien.GetFocusedRowCellValue("ID").ToString());
            int nam = Convert.ToInt16(comboBox1.Text);
            list_KQCTD.Clear();
            list_KQCTD.AddRange(new HocVienDAO().KetQuaCTD(hocvienid, nam));
            grcKetQua.DataSource = null;
            grcKetQua.DataSource = list_KQCTD;
        }
        private void btn_Sua_Click(object sender, EventArgs e)
        {
            if (Common.Acc_type == "Root" || Common.Acc_type == "Admin")
            {
                if (btn_Sua.Text == "Sửa")
                {
                    gridColumn6.OptionsColumn.ReadOnly = false;
                    btn_Sua.Text = "Lưu";
                    MessageBox.Show("Bạn có thể sửa điểm học viên trong bảng !", "Sửa thành tích", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btn_Huy_In.Text = "Hủy";
                }
                else
                {
                    btn_Sua.Text = "Sửa";
                    btn_Huy_In.Text = "In kết quả";
                    gridColumn6.OptionsColumn.ReadOnly = true;
                    HocVien_CongTacDang temp = new HocVien_CongTacDang();
                    temp.HocVienID = Convert.ToInt32(grvDSHocVien.GetFocusedRowCellValue("ID").ToString());
                    HocVienDAO dao = new HocVienDAO();
                    foreach (var item in list_KQCTD)
                    {
                        temp.CongTacDangID = item.MonCTDID;
                        if (item.ThanhTich < 0) { MessageBox.Show("Bạn không thể nhập điểm < 0 !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Hand); continue; }
                        temp.Diem = item.ThanhTich;
                        dao.EditCTD(temp);
                    }
                    MessageBox.Show("Cập nhật thành công !", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataKQCTD();
                }
            }
            else
            {
                MessageBox.Show("Bạn không có quyền thực hiện tác vụ này");
            }

        }

        private void btn_Huy_In_Click(object sender, EventArgs e)
        {
            if (Common.Acc_type == "Root" || Common.Acc_type == "Admin")
            {
                if (btn_Huy_In.Text == "Hủy")
                {
                    btn_Sua.Text = "Sửa";
                    btn_Huy_In.Text = "In kết quả";
                    gridColumn6.OptionsColumn.ReadOnly = true;
                    LoadDataKQCTD();
                }
                else
                {
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = "Excel |*.xls";
                    saveFileDialog1.Title = "Save an Excel File";
                    saveFileDialog1.ShowDialog();

                    string FileName = saveFileDialog1.FileName.ToString();
                    try
                    {
                        grcKetQua.ExportToXls(FileName);
                        MessageBox.Show("Xuất file excel thành công");
                    }
                    catch
                    {
                        MessageBox.Show("Vui lòng dóng file cần ghi lại để quá trình ghi thành công");
                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn không có quyền thực hiện tác vụ này");
            }

        }

        private void grvKetQua_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

            try
            {
                string kq = "";
                id_rowchange = Convert.ToInt32(grvKetQua.GetFocusedRowCellValue("MonCTDID").ToString());
                double ThanhTich = Convert.ToDouble(grvKetQua.GetFocusedRowCellDisplayText("ThanhTich").ToString());
                double Dat = Convert.ToDouble(grvKetQua.GetFocusedRowCellValue("Dat").ToString());
                double Kha = Convert.ToDouble(grvKetQua.GetFocusedRowCellValue("Kha").ToString());
                double Gioi = Convert.ToDouble(grvKetQua.GetFocusedRowCellValue("Gioi").ToString());

                if (ThanhTich < Dat)
                    kq = "Không đạt";
                else if (ThanhTich >= Dat && ThanhTich < Kha)
                    kq = "Đạt";
                else if (ThanhTich >= Kha && ThanhTich < Gioi)
                    kq = "Khá";
                else
                    kq = "Giỏi";

                if (e.Column.FieldName == "ThanhTich")
                {
                    grvKetQua.SetRowCellValue(e.RowHandle, "KetQua", kq);
                }

                var item = list_KQCTD.Find(x => x.MonCTDID == id_rowchange);
                item.ThanhTich = ThanhTich;
                item.KetQua = kq;
            }
            catch
            {

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                LoadDataKQCTD();
                gr_data.Enabled = true;
            }
            else gr_data.Enabled = false;
        }
    }
}
