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
    public partial class add_GiangVienCoiThi : Form
    {
        public delegate void ThayDoiGiangVienCoiThi(List<Class.GiangVien> list_gv);
        public event ThayDoiGiangVienCoiThi ThayDoiGiangVienCoiThiEvent;
        public add_GiangVienCoiThi()
        {
            InitializeComponent();
            btn_Luu.Click += Btn_Luu_Click;
        }

        private void Btn_Luu_Click(object sender, EventArgs e)
        {
            List<Class.GiangVien> list_gv = new List<Class.GiangVien>();
            foreach (ListViewItem item in listView_GiangVien.Items)
            {
                Class.GiangVien gv = new Class.GiangVien();
                gv.MSGV = Convert.ToInt32(item.SubItems[0].Text);
                gv.TenGV = item.SubItems[1].Text;
                gv.Khoa = item.SubItems[2].Text;
                list_gv.Add(gv);
            }
            ThayDoiGiangVienCoiThiEvent(list_gv);
            this.Close();

        }

        private void ThemGiangVienCoiThi_Load(object sender, EventArgs e)
        {
            List<Class.GiangVien> list_gv = Class.GiangVien.Get_list_GiangVien();
            foreach (Class.GiangVien gv in list_gv)
            {
                cb_MaSoGiangVien.Items.Add(gv.MSGV.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {

        }

        //------------------------------------Function----------------------------------------------------------// 
        public void Receive_data(List<Class.GiangVien> list_gv)
        {
            foreach (Class.GiangVien gv in list_gv)
            {
                Class.list_view_method.ListView_GIANGVIEN(Class.METHOD.ADD, listView_GiangVien, gv);
            }
        }

        public void Reset()
        {
            cb_MaSoGiangVien.Text = "";
            txt_Khoa.Text = "";
            txt_TenGV.Text = "";
        }

        //------------------------------------Function----------------------------------------------------------//
        private void cb_MaSoGiangVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Class.GiangVien> list_gv = Class.GiangVien.Get_list_GiangVien();
            foreach (Class.GiangVien gv in list_gv)
            {
                if (gv.MSGV.ToString() == cb_MaSoGiangVien.Text)
                {
                    txt_Khoa.Text = gv.Khoa;
                    txt_TenGV.Text = gv.TenGV;
                }
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(cb_MaSoGiangVien.Text) == false && String.IsNullOrEmpty(txt_TenGV.Text) == false && String.IsNullOrEmpty(txt_Khoa.Text)==false)
            {
                Class.GiangVien gv = new Class.GiangVien();
                gv.MSGV = Convert.ToInt32(cb_MaSoGiangVien.Text);
                gv.TenGV = txt_TenGV.Text;
                gv.Khoa = txt_Khoa.Text;
                Class.list_view_method.ListView_GIANGVIEN(Class.METHOD.ADD, listView_GiangVien, gv);
            }
            else
            {
                MessageBox.Show("Điền đầy đủ thông tin!", "CẢNH BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(cb_MaSoGiangVien.Text) == false && String.IsNullOrEmpty(txt_TenGV.Text) == false && String.IsNullOrEmpty(txt_Khoa.Text))
            {
                Class.GiangVien gv = new Class.GiangVien();
                gv.MSGV = Convert.ToInt32(cb_MaSoGiangVien.Text);
                gv.TenGV = txt_TenGV.Text;
                gv.Khoa = txt_Khoa.Text;
                Class.list_view_method.ListView_GIANGVIEN(Class.METHOD.DELETE, listView_GiangVien, gv);
            }
        }

        private void listView_GiangVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listView_GiangVien.SelectedItems.Count == 1)
            {
                cb_MaSoGiangVien.Text = listView_GiangVien.SelectedItems[0].Text;
                txt_TenGV.Text = listView_GiangVien.SelectedItems[0].SubItems[1].Text;
                txt_Khoa.Text = listView_GiangVien.SelectedItems[0].SubItems[2].Text;
            }
        }
    }
}
