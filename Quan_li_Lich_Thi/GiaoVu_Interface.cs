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
    public partial class GiaoVu_Interface : Form
    {
        public GiaoVu_Interface()
        {
            InitializeComponent();
        }
        Button btn_choose = new Button();
        private void GiaoVu_Load(object sender, EventArgs e)
        {
        }
        User_Control.UserControlGiaoVuLopHoc uc_lophoc = new User_Control.UserControlGiaoVuLopHoc();
        User_Control.UserControlGiaoVuLopThi uc_lopthi = new User_Control.UserControlGiaoVuLopThi();
        User_Control.UserControl_In uc_In = new User_Control.UserControl_In();
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
   
        }

        private void btn_LopHoc_Click(object sender, EventArgs e)
        {
            btn_choose = btn_LopHoc;
            Clear_Color_Button();
            if (btn_choose == btn_LopHoc)
            {
                panel_btn_Lop_Hoc.BackColor = Color.Blue;
            }
            if (!panel_Contain.Controls.Contains(uc_lophoc))
            {
                panel_Contain.Controls.Clear();
                panel_Contain.Controls.Add(uc_lophoc);
            }
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_Lop_Thi_Click(object sender, EventArgs e)
        {
            
            btn_choose = btn_Lop_Thi;
            Clear_Color_Button();
            if (btn_choose == btn_Lop_Thi)
            {
                panel_btn_Lop_Thi.BackColor = Color.Blue;
            }
            if (!panel_Contain.Controls.Contains(uc_lopthi))
            {
                panel_Contain.Controls.Clear();
                panel_Contain.Controls.Add(uc_lopthi);
            }
        }
        void Clear_Color_Button()
        {
            panel_btn_Lop_Hoc.BackColor = Color.White;
            panel_btn_Lop_Thi.BackColor = Color.White;
            panel_btn_In.BackColor = Color.White;
        }

        private void button2_Click(object sender, EventArgs e)
        { 
            btn_choose = btn_In;
            Clear_Color_Button();
            if (btn_choose == btn_In)
            {
                panel_btn_In.BackColor = Color.Blue;
            }
            if (!panel_Contain.Controls.Contains(uc_In))
            {
                panel_Contain.Controls.Clear();
                panel_Contain.Controls.Add(uc_In);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
