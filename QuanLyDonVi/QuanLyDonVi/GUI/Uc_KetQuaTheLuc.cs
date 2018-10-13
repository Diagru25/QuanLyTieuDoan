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
    public partial class Uc_KetQuaTheLuc : DevExpress.XtraEditors.XtraUserControl
    {
        List<TieuDoan> list_TieuDoan = new List<TieuDoan>();
        List<DaiDoi> list_DaiDoi = new List<DaiDoi>();
        List<Lop> list_Lop = new List<Lop>();
        List<KQTheLuc> list_KQTL = new List<KQTheLuc>();
        long id_rowchange;
        public Uc_KetQuaTheLuc()
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
            LoadDataKQTheLuc();
            gr_data.Enabled = true;
        }
        void LoadDataKQTheLuc()
        {
            long hocvienid = Convert.ToInt32(grvDSHocVien.GetFocusedRowCellValue("ID").ToString());
            list_KQTL.Clear();
            list_KQTL.AddRange(new HocVienDAO().KetQuaTheLuc(hocvienid));
            grcKetQua.DataSource = null;
            grcKetQua.DataSource = list_KQTL;
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            grvKetQua.SetRowCellValue(0, "KetQua", "ABC");
            if (btn_Sua.Text == "Sửa")
            {
                gridColumn6.OptionsColumn.ReadOnly = false;
                btn_Sua.Text = "Lưu";
                MessageBox.Show("Bạn có thể sửa thành tích học viên trong bảng !", "Sửa thành tích", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btn_Huy_In.Text = "Hủy";
            }
            else
            {
                btn_Sua.Text = "Sửa";
                btn_Huy_In.Text = "In kết quả";
                gridColumn6.OptionsColumn.ReadOnly = true;
                HocVien_TheLuc temp = new HocVien_TheLuc();
                temp.HocVienID = Convert.ToInt32(grvDSHocVien.GetFocusedRowCellValue("ID").ToString());
                HocVienDAO dao = new HocVienDAO();
                foreach (var item in list_KQTL)
                {
                    temp.MonTheLucID = item.MonTheLucID;
                    if (item.ThanhTich < 0) { MessageBox.Show("Bạn không thể nhập thành tích < 0 !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Hand); continue; }
                    temp.KetQua = item.ThanhTich;
                    dao.EditTheLuc(temp);
                }
                MessageBox.Show("Cập nhật thành công !", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataKQTheLuc();
            }
        }

        private void btn_Huy_In_Click(object sender, EventArgs e)
        {
            if (btn_Huy_In.Text == "Hủy")
            {
                btn_Sua.Text = "Sửa";
                btn_Huy_In.Text = "In kết quả";
                gridColumn6.OptionsColumn.ReadOnly = true;
                LoadDataKQTheLuc();
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

        private void grvKetQua_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                string kq = "";
                id_rowchange = Convert.ToInt32(grvKetQua.GetFocusedRowCellValue("MonTheLucID").ToString());
                double ThanhTich = Convert.ToDouble(grvKetQua.GetFocusedRowCellDisplayText("ThanhTich").ToString());
                double Dat = Convert.ToDouble(grvKetQua.GetFocusedRowCellValue("Dat").ToString());
                double Kha = Convert.ToDouble(grvKetQua.GetFocusedRowCellValue("Kha").ToString());
                double Gioi = Convert.ToDouble(grvKetQua.GetFocusedRowCellValue("Gioi").ToString());

                if(Dat < Kha && Kha < Gioi)
                {
                    if (ThanhTich < Dat)
                        kq = "Không đạt";
                    else if (ThanhTich >= Dat && ThanhTich < Kha)
                        kq = "Đạt";
                    else if (ThanhTich >= Kha && ThanhTich < Gioi)
                        kq = "Khá";
                    else
                        kq = "Giỏi";
                }
                else // Dat > Kha > gioi
                {
                    if (ThanhTich > Dat)
                        kq = "Không đạt";
                    else if (ThanhTich <= Dat && ThanhTich > Kha)
                        kq = "Đạt";
                    else if (ThanhTich <= Kha && ThanhTich > Gioi)
                        kq = "Khá";
                    else
                        kq = "Giỏi";
                }

                if (e.Column.FieldName == "ThanhTich")
                {
                    grvKetQua.SetRowCellValue(e.RowHandle, "KetQua", kq);
                }

                var item = list_KQTL.Find(x => x.MonTheLucID == id_rowchange);
                item.ThanhTich = ThanhTich;
                item.KetQua = kq;
            }
            catch
            {

            }
        }
    }
}
