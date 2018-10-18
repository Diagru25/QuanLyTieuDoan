using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QuanLyDonVi.DAO;
using QuanLyDonVi.Model.EF;

namespace QuanLyDonVi.GUI
{
    public partial class FrLyLich : System.Windows.Forms.Form
    {
        HocVien hv = null;
        long id = 0;
        public FrLyLich()
        {
            InitializeComponent();
            cb_Lop.DataSource = new LopDAO().GetAll();
            cb_Lop.DisplayMember = "Ten";
            cb_Lop.ValueMember = "ID";

            this.Text = "Thêm học viên";
            btn_Luu.Text = "Thêm học viên";
            lbMaHV.Text = "";
            hv = new HocVien();
        }
        public FrLyLich(long _id)
        {
            InitializeComponent();
            cb_Lop.DataSource = new LopDAO().GetAll();
            cb_Lop.DisplayMember = "Ten";
            cb_Lop.ValueMember = "ID";
            id = _id;

            this.Text = "Xem chi tiết và chỉnh sửa thông tin học viên";
            hv = new HocVienDAO().GetAll().SingleOrDefault(x => x.ID == id);
            lbMaHV.Text = "Mã học viên : " + hv.ID;
            txt_HoTen.Text = hv.Ten;
            dt_NgaySinh.Value = (DateTime)hv.NgaySinh;
            txt_QueQuan.Text = hv.QueQuan;
            txt_NoiSinh.Text = hv.NoiSinh;
            txt_NoiO.Text = hv.DiaChi;
            txt_CapBac.Text = hv.CapBac;
            txt_ChucVu.Text = hv.ChucVu;
            if ((bool)hv.GioiTinh)
            {
                rb_Nam.Checked = true;
                rb_Nu.Checked = false;
            }
            else
            {
                rb_Nam.Checked = false;
                rb_Nu.Checked = true;
            }
            dt_Doan.Value = (DateTime)hv.NgayVaoDoan;
            dt_Dang.Value = (DateTime)hv.NgayVaoDang;
            cb_Lop.SelectedValue = hv.LopID;
            if ((bool)hv.LopTruong) cbox_LopTruong.Checked = true;

        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (Common.Acc_type == "Root" || Common.Acc_type == "Admin")
            {
                if (txt_HoTen.Text == "")
                {
                    MessageBox.Show("Nhập họ và tên", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txt_QueQuan.Text == "")
                {
                    MessageBox.Show("Nhập quê quán", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txt_NoiSinh.Text == "")
                {
                    MessageBox.Show("Nhập nơi sinh", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txt_NoiO.Text == "")
                {
                    MessageBox.Show("Nhập chỗ ở hiện nay", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txt_CapBac.Text == "")
                {
                    MessageBox.Show("Nhập cấp bậc", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txt_ChucVu.Text == "")
                {
                    MessageBox.Show("Nhập chức vụ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                hv.Ten = txt_HoTen.Text;
                hv.NgaySinh = dt_NgaySinh.Value;
                hv.QueQuan = txt_QueQuan.Text;
                hv.NoiSinh = txt_NoiSinh.Text;
                hv.DiaChi = txt_NoiO.Text;
                hv.CapBac = txt_CapBac.Text;
                hv.ChucVu = txt_ChucVu.Text;
                hv.GioiTinh = rb_Nam.Checked ? true : false;
                hv.NgayVaoDoan = dt_Doan.Value;
                hv.NgayVaoDang = dt_Dang.Value;
                hv.LopID = Convert.ToInt32(cb_Lop.SelectedValue.ToString());
                hv.LopTruong = cbox_LopTruong.Checked ? true : false;
                if (id.Equals(0))
                {

                    var result = new HocVienDAO().Insert(hv);
                    if (result)
                    {
                        MessageBox.Show("Thêm thành công !", "Thêm học viên", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi xảy ra ! Vui lòng thử lại !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                else
                {
                    var result = new HocVienDAO().Edit(hv);
                    if (result)
                    {
                        MessageBox.Show("Sửa thành công !", "Sửa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi xảy ra ! Vui lòng thử lại !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
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
            this.Close();
        }
    }
}