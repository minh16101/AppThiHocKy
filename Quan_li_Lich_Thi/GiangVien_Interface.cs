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
    public partial class GiangVien_Interface : MetroSetForm
    {
        public GiangVien_Interface()
        {
            InitializeComponent();
        }
        public string tai_khoan = "123";
        public int Ma_So_Giang_Vien = 8;
        private void GiangVienInterface_Load(object sender, EventArgs e)
        {
            Reset_Danh_Sach_Lop_Thi_GV();
            Show_Lich_Thi();
            Reset_Danh_Sach_Sinh_Vien();
        }

        private void metroSetControlBox1_Click(object sender, EventArgs e)
        {

        }

        private void btn_ChinhSua_Click(object sender, EventArgs e)
        {
            if (listView_LopThi.SelectedItems.Count == 1)
            {
                List<Class.LopThi> list_lt = Class.LopThi.Get_list_LopThi();
                foreach (Class.LopThi lt in list_lt)
                {
                    if (lt.MLT.ToString() == txt_MaLopThi.Text)
                    {
                        Class.Time time_start = new Class.Time(dateTime_Start.Value.ToString(), ':');
                        Class.Time time_end = new Class.Time(dateTime_End.Value.ToString(), ':');
                        Class.DateTime date_time = new Class.DateTime(dateTime_Day_Month_Year.Value.ToString(), '/');
                        string time = time_start.ToString() + "-" + time_end.ToString() + " " + date_time.ToString();
                        Class.Hinh_Thu_Thi hinh_thuc_thi = cb_HinhThucThi.SelectedItem.ToString() == "Online" ? Class.Hinh_Thu_Thi.Online : Class.Hinh_Thu_Thi.Offline;
                        lt.TGT = time;
                        lt.HTT = hinh_thuc_thi;
                        if (Class.LopThi.Xoa(lt.MLT.ToString()) == true)
                        {
                            if (Class.LopThi.Them(lt) == true)
                            {
                                if (Class.list_view_method.ListView_LOPTHI(Class.METHOD.REPAIR, listView_LopThi, lt) == true)
                                {
                                    MessageBox.Show("Thay đổi thông tin lớp mã: " + lt.MLT, "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Chưa chọn lớp thi để chỉnh sửa!", "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            Reset_Danh_Sach_Lop_Thi_GV();
        }

        //---------------------------------------------------------------------------------------------------------//
        public void Reset_Danh_Sach_Lop_Thi_GV()
        {
            List<Class.LopThi> list_lt = Class.GiangVien.Get_List_LopThi(Ma_So_Giang_Vien);
            //   List<Class.LopThi> list_lopthi = Class.LopThi.Get_list_LopThi();
            listView_LopThi.Items.Clear();
            foreach (Class.LopThi lt in list_lt)
            {
                Class.list_view_method.ListView_LOPTHI(Class.METHOD.ADD, listView_LopThi, lt);
            }

        }

        public void Clear_Data_Danh_Sach_Lop_Thi_GV()
        {
            txt_DiaDiemThi.Text = "";
            txt_KieuThi.Text = "";
            txt_MaLopHoc.Text = "";
            txt_MaLopThi.Text = "";
            txt_SoGiangVienCoiThi.Text = "";
            cb_HinhThucThi.Text = "";
        }

        public void Show_Data_Lop_Thi(Class.LopThi lt)
        {
            txt_MaLopThi.Text = lt.MLT.ToString();
            txt_MaLopHoc.Text = lt.MLH.ToString();
            txt_KieuThi.Text = lt.Get_KT();
            cb_HinhThucThi.Text = lt.Get_HTT();
            txt_SoGiangVienCoiThi.Text = lt.SoGV.ToString();
            txt_DiaDiemThi.Text = lt.DDT;
            Dictionary<Class.Time[], Class.DateTime> dic_TGT = Class.LopThi.Convert_TGT(lt.TGT);
            foreach (KeyValuePair<Class.Time[], Class.DateTime> item in dic_TGT)
            {
                dateTime_Start.Value.AddHours(item.Key[0].gio);
                dateTime_Start.Value.AddMinutes(item.Key[0].phut);
                dateTime_End.Value.AddHours(item.Key[1].gio);
                dateTime_End.Value.AddMinutes(item.Key[1].phut);
                dateTime_Day_Month_Year.Value.AddDays(item.Value.ngay);
                dateTime_Day_Month_Year.Value.AddMonths(item.Value.thang);
                dateTime_Day_Month_Year.Value.AddYears(item.Value.nam);
            }
        }

        public void Show_Lich_Thi()
        {
            dataGridView_LopThi.Rows.Clear();
            dataGridView_LopThi.Rows.Add("Mã Lớp Thi", "Mã Lớp Học", "Địa Điểm", "Thời Gian", "Hình Thức Thi", "Kiểu Thi");
            dataGridView_LopThi.Rows[0].DefaultCellStyle.BackColor = Color.Blue;
            dataGridView_LopThi.Rows[0].DefaultCellStyle.ForeColor = Color.White;
            List<Class.LopThi> list_lt = Class.GiangVien.Get_List_LopThi(Ma_So_Giang_Vien);
            foreach (Class.LopThi lt in list_lt)
            {
                dataGridView_LopThi.Rows.Add(lt.MLT.ToString(), lt.MLH.ToString(), lt.DDT, lt.TGT, lt.Get_HTT(), lt.Get_KT());
            }
        }

        public void Show_Danh_Sach_Sinh_Vien(List<Class.SinhVien> list_sv)
        {
            Reset_Danh_Sach_Sinh_Vien();
            if(list_sv.Count != 0)
            {
                foreach (Class.SinhVien sv in list_sv)
                {
                    dataGridView_DanhSachSinhVien.Rows.Add(sv.MSSV.ToString(), sv.TenSV);
                }
            }
        }

        public void Reset_Danh_Sach_Sinh_Vien()
        {
            dataGridView_DanhSachSinhVien.Rows.Clear();
            dataGridView_DanhSachSinhVien.Rows.Add("Mã số Sinh Viên", "Tên Sinh Viên");
            dataGridView_DanhSachSinhVien.Rows[0].DefaultCellStyle.BackColor = Color.Blue;
            dataGridView_DanhSachSinhVien.Rows[0].DefaultCellStyle.ForeColor = Color.White;
        }

        private void listView_LopThi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView_LopThi.SelectedItems.Count == 1)
            {
                Clear_Data_Danh_Sach_Lop_Thi_GV();
                List<Class.LopThi> list_lt = Class.LopThi.Get_list_LopThi();
                foreach (Class.LopThi lt in list_lt)
                {
                    if (lt.MLT.ToString() == listView_LopThi.SelectedItems[0].Text)
                    {
                        Show_Data_Lop_Thi(lt);
                    }
                }
            }
        }

        private void inDanhSáchSinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView_LopThi.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                string ma_lop_thi = dataGridView_LopThi.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                List<Class.SinhVien> list_sv = Class.LopHoc.Get_list_SinhVien(Class.LopThi.GET_MLT(Convert.ToInt32(ma_lop_thi)).MLH);
                Show_Danh_Sach_Sinh_Vien(list_sv);
                
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView_DanhSachSinhVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Show_Lich_Thi();
        }
    }
}
