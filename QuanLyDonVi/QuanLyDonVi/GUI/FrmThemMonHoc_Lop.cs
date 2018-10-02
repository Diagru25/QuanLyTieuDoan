using QuanLyDonVi.DAO;
using QuanLyDonVi.Model.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDonVi.GUI
{
    public partial class FrmThemMonHoc_Lop : Form
    {
        long id = 0;
        //List<MonHoc> li1 = null;
        List <MonHoc> li1 = new MonHocDAO().GetAll();
        List <MonHoc> li2 = null;
        
        public FrmThemMonHoc_Lop()
        {
            InitializeComponent();
            LoadDataSource();
        }

        public FrmThemMonHoc_Lop(long Lop_id)
        {
            InitializeComponent();
            id = Lop_id;
            //li1 = new MonHocDAO().GetMonByLopID_No(id);
            li2 = new MonHocDAO().GetMonByLopID(id);
            LoadDataSource();
        }

        private void LoadDataSource()
        {
            lib_DSMon.DataSource = null;
            lib_DSMonThem.DataSource = null;

            lib_DSMon.DataSource = li1;
            lib_DSMon.ValueMember = "ID";
            lib_DSMon.DisplayMember = "Ten";

            lib_DSMonThem.DataSource = li2;
            lib_DSMonThem.ValueMember = "ID";
            lib_DSMonThem.DisplayMember = "Ten";
        }

        // button >>>
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (MonHoc item in lib_DSMon.SelectedItems)
            {
                if(li2.Where(x=>x.ID == item.ID).SingleOrDefault() == null)
                {
                    li2.Add(item);
                    li1.Remove(item);
                }
                
            }

            LoadDataSource();
        }


        // button <<<
        private void button2_Click(object sender, EventArgs e)
        {
            foreach (MonHoc item in lib_DSMonThem.SelectedItems)
            {
                if (li1.Where(x => x.ID == item.ID).SingleOrDefault() == null)
                {
                    li1.Add(item);
                    li2.Remove(item);
                }

            }

            LoadDataSource();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            Lop_MonHoc _item = new Lop_MonHoc();
            foreach (MonHoc item in li2)
            {
                _item.LopID = id;
                _item.MonHocID = item.ID;
                if(new MonHocDAO().Add_Lop_MonHoc(_item))
                {
                    MessageBox.Show("Lưu thành công");
                }
                else
                {
                    MessageBox.Show("Xảy ra lỗi");
                }
            }
        }
    }
}
