using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_li_Lich_Thi.Forms
{
    public partial class add_SinhVien : Form
    {
        public delegate void ThayDoiThongTinSinhVien(List<Class.SinhVien> list_sv);
        public event ThayDoiThongTinSinhVien ThayDoiThongTinSinhVienEvent;

        public add_SinhVien()
        {
            InitializeComponent();
            btn_Luu.Click += Btn_Luu_Click;
        }

        private void Btn_Luu_Click(object sender, EventArgs e)
        {
            List<Class.SinhVien> list_sv = new List<Class.SinhVien>();

            foreach(ListViewItem x in listView_SinhVien.Items)
            {
                Class.SinhVien sv = new Class.SinhVien();
                sv.MSSV = Convert.ToInt32(x.SubItems[0].Text);
                sv.TenSV = x.SubItems[1].Text;
                list_sv.Add(sv);
            }
            ThayDoiThongTinSinhVienEvent(list_sv);
            this.Close();
        }

        public void Receive_data(List<Class.SinhVien> list_sv)
        {
            foreach(Class.SinhVien sv in list_sv)
            {
                ListViewItem item = new ListViewItem();
                item.Text = sv.MSSV.ToString();
                item.SubItems.Add(sv.TenSV);
                listView_SinhVien.Items.Add(item);
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {

        }

        private void add_SinhVien_Load(object sender, EventArgs e)
        {
            List<Class.SinhVien> list_sv = Class.SinhVien.Get_list_SinhVien();
            foreach(Class.SinhVien sv in list_sv)
            {
                cb_MaSoSinhVien.Items.Add(sv.MSSV.ToString());
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if(listView_SinhVien.SelectedItems.Count == 1)
            {
                listView_SinhVien.Items.Remove(listView_SinhVien.SelectedItems[0]);
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(cb_MaSoSinhVien.Text)!=true && String.IsNullOrEmpty(txt_TenSV.Text) != true)
            {
                
                ListViewItem item = new ListViewItem();
                item.Text = cb_MaSoSinhVien.Text;
                item.SubItems.Add(txt_TenSV.Text);
                if (Class.list_view_method.ListView_GET_SINHVIEN_EXIST(listView_SinhVien,cb_MaSoSinhVien.Text)==false){
                    listView_SinhVien.Items.Add(item);
                }
                else
                {
                    MessageBox.Show("Mã Sinh Viên trùng!");
                }
            }
            else
            {
                if(String.IsNullOrEmpty(cb_MaSoSinhVien.Text) == true && String.IsNullOrEmpty(txt_TenSV.Text) != true)
                {
                    MessageBox.Show("Mã Sinh Viên trống", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if(String.IsNullOrEmpty(cb_MaSoSinhVien.Text) != true && String.IsNullOrEmpty(txt_TenSV.Text) == true)
                {
                    MessageBox.Show("Tên Sinh Viên Trống", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Thông tin trống", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void txt_MSSV_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView_SinhVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView_SinhVien.SelectedItems.Count==1)
            {
                cb_MaSoSinhVien.Text = listView_SinhVien.SelectedItems[0].Text;
                txt_TenSV.Text = listView_SinhVien.SelectedItems[0].SubItems[1].Text;
            }
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            List<Class.SinhVien> list_sv = Class.SinhVien.Get_list_SinhVien();
            foreach(Class.SinhVien sv in list_sv)
            {
                cb_MaSoSinhVien.Items.Add(sv.MSSV.ToString());
            }
        }

        private void cb_MaSoSinhVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Class.SinhVien> list_sv = Class.SinhVien.Get_list_SinhVien();
            foreach (Class.SinhVien sv in list_sv)
            {
                if(cb_MaSoSinhVien.Text == sv.MSSV.ToString())
                {
                    txt_TenSV.Text = sv.TenSV;
                }
            }
        }

        private void cb_MaSoSinhVien_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
