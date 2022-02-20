using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DGVPrinterHelper;

namespace Quan_li_Lich_Thi.User_Control
{
    public partial class UserControl_In : UserControl
    {
        public UserControl_In()
        {
            InitializeComponent();
        }

        private void metroSetButton1_Click(object sender, EventArgs e)
        {
            DataGridView data_gri = new DataGridView();
            data_gri.Columns.Add("columns_MLT","Mã Lớp Thi");
            data_gri.Columns.Add("columns_MLH","Mã Lớp Học");
            data_gri.Columns.Add("columns_DDT","Địa điểm Thi");
            data_gri.Columns.Add("columns_TGT","Thời gian thi");
            data_gri.Columns.Add("columns_HTT","Hình Thức Thi");
            data_gri.Columns.Add("columns_KT","Kiểu Thi");
            List<Class.LopThi> list_lt = Class.LopThi.Get_list_LopThi();
            foreach (Class.LopThi lt in list_lt)
            {
                data_gri.Rows.Add(lt.MLT.ToString(), lt.MLH.ToString(), lt.DDT.ToString(), lt.TGT.ToString(), lt.Get_HTT(), lt.Get_KT());
            }
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "DANH SÁCH THI";
            printer.SubTitle = "";
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "Đại học Bách Khoa Hà Nội";
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(data_gri);
        }

        private void UserControl_In_Load(object sender, EventArgs e)
        {
            Reset();
        }
        public void Reset()
        {
            dataGridView_InLopThi.Rows.Clear();
            List<Class.LopThi> list_lt = Class.LopThi.Get_list_LopThi();
            dataGridView_InLopThi.Rows.Add("Mã Lớp Thi", "Mã Lớp Học", "Địa Điểm", "Thời Gian", "Hình Thức Thi", "Kiểu Thi");
            dataGridView_InLopThi.Rows[0].DefaultCellStyle.BackColor = Color.Blue;
            dataGridView_InLopThi.Rows[0].DefaultCellStyle.ForeColor = Color.White;
            foreach (Class.LopThi lt in list_lt)
            {
                dataGridView_InLopThi.Rows.Add(lt.MLT.ToString(), lt.MLH.ToString(), lt.DDT.ToString(), lt.TGT.ToString(), lt.Get_HTT(), lt.Get_KT());
            }
        }

        private void dataGridView_InLopThi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
