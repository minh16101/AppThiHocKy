using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Quan_li_Lich_Thi
{
    public partial class DangNhap_Interface : Form
    {
        public DangNhap_Interface()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, Color.Black);
            label_TaiKhoan.BackColor = Color.FromArgb(0, Color.Black);
            label_MatKhau.BackColor = Color.FromArgb(0, Color.Black);
            label_DangNhap.BackColor = Color.FromArgb(0, Color.Black);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
  
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
          
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txt_MatKhau.Text) || String.IsNullOrEmpty(txt_TaiKhoan.Text))
            {
                MessageBox.Show("Điền thông tin đầy đủ!","Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            List<Class.User> list_user = Class.User.Get_User();
            foreach(Class.User user in list_user)
            {
                if(user.tai_khoan==txt_TaiKhoan.Text&&user.mat_khau == txt_MatKhau.Text&&user.type == Class.User_Type.GIAOVU)
                {
                    GiaoVu_Interface gv = new GiaoVu_Interface();
                    gv.Show();
                }else if(user.tai_khoan == txt_TaiKhoan.Text && user.mat_khau == txt_MatKhau.Text && user.type == Class.User_Type.GIANGVIEN)
                {
                    GiangVien gv = new GiangVien();
                    gv.tai_khoan = txt_TaiKhoan.Text;
                    gv.Ma_So_Giang_Vien = user.Ma_So.ToString();
                    gv.ShowDialog();
                }
            }
        }

        private void btnDangNhap_MouseMove(object sender, MouseEventArgs e)
        {
            
        }
    }
}
