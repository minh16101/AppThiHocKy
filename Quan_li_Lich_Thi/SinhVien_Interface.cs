using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroSet_UI.Forms;
namespace Quan_li_Lich_Thi
{
    public partial class SinhVien_Interface : MetroSetForm
    {
        public SinhVien_Interface()
        {
            InitializeComponent();
        }
        int MSSV = 2112200844;
        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button1_MouseHover(object sender, EventArgs e)
        { 
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
        }

        private void SinhVien_Load(object sender, EventArgs e)
        {
            Reset();
        }
        
        private void metroSetButton1_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_RESET_Click(object sender, EventArgs e)
        {
            Reset();
        }


        public void Reset()
        {
            dataGridView_LichThi.Rows.Clear();
            dataGridView_LichThi.Rows.Add("Mã Lớp Thi", "Mã Lớp Học", "Địa Điểm", "Thời Gian", "Hình Thức Thi", "Kiểu Thi");
            dataGridView_LichThi.Rows[0].DefaultCellStyle.BackColor = Color.Blue;
            dataGridView_LichThi.Rows[0].DefaultCellStyle.ForeColor = Color.White;
            List<Class.LopThi> list_lt = Class.SinhVien.GET_list_LopThi(MSSV);
            if (list_lt.Count != 0)
            {
                foreach (Class.LopThi lt in list_lt)
                {
                    dataGridView_LichThi.Rows.Add(lt.MLT.ToString(), lt.MLH.ToString(), lt.DDT, lt.TGT, lt.Get_HTT(), lt.Get_KT());
                }
            }
        }
        private void metroSetControlBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
