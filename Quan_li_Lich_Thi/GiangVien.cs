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
    public partial class GiangVien : Form
    {
        public GiangVien()
        {
            InitializeComponent();
        }
        public string tai_khoan = "";
        public string Ma_So_Giang_Vien = "";
        private void btn_LopHoc_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void GiangVien_Load(object sender, EventArgs e)
        {
            
        }

        private void btn_DangXuat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public  void Reset()
        {
            label_TenTaiKhoan.Text = tai_khoan;
            List<Class.GiangVien> list_gv = Class.GiangVien.Get_list_GiangVien();
            foreach(Class.GiangVien gv in list_gv)
            {
                if(gv.MSGV == Convert.ToInt32(Ma_So_Giang_Vien))
                {
                    List<Class.LopThi> list_lt = Class.LopThi.Get_list_LopThi();
                    foreach(Class.LopThi lt in list_lt)
                    {
                        if (Class.LopThi.GET_LopHoc(lt.MLH).MSGV == gv.MSGV)
                        {
                            ListViewItem item = new ListViewItem(lt.MLH.ToString());
                            item.SubItems.Add(lt.MLH.ToString());
                            item.SubItems.Add(lt.SoGV.ToString());
                            item.SubItems.Add(lt.TGT.ToString());
                            item.SubItems.Add(lt.DDT.ToString());
                            item.SubItems.Add(lt.HTT.ToString());
                            item.SubItems.Add(lt.KT.ToString());
                            listView_LopThi.Items.Add(item);
                        }
                    }
                }
            }
        }

        public void Clear_Data()
        {
            txt_DiaDiemThi.Text = "";
            txt_KieuThi.Text = "";
            txt_MaLopHoc.Text = "";
            txt_MaLopThi.Text = "";
            txt_SoGiangVienCoiThi.Text = "";
            cb_HinhThucThi.Text = "";
            treeView_SinhVien.Nodes.Clear();
        }

        public void Show_Data(Class.LopThi lt)
        {
            txt_MaLopThi.Text = lt.MLT.ToString();
            txt_MaLopHoc.Text = lt.MLH.ToString();
            txt_KieuThi.Text = lt.Get_KT();
            cb_HinhThucThi.Text = lt.Get_HTT();
            txt_SoGiangVienCoiThi.Text = lt.SoGV.ToString();
            txt_DiaDiemThi.Text = lt.DDT;
            Dictionary<Class.Time[], Class.DateTime> dic_TGT = Class.LopThi.Convert_TGT(lt.TGT);
            foreach(KeyValuePair<Class.Time[],Class.DateTime> item in dic_TGT)
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
        private void listView_LopThi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView_LopThi.SelectedItems.Count == 1)
            {
                Clear_Data();
                List<Class.LopThi> list_lt = Class.LopThi.Get_list_LopThi();
                foreach(Class.LopThi lt in list_lt)
                {
                    if(lt.MLT.ToString() == listView_LopThi.SelectedItems[0].Text)
                    {
                        List<Class.SinhVien> list_sv = Class.LopHoc.Get_list_SinhVien(Class.LopThi.GET_LopHoc(lt.MLT).MLH);
                        foreach(Class.SinhVien sv in list_sv)
                        {
                            TreeNode item = new TreeNode();
                            item.Text = sv.MSSV.ToString();
                            item.Nodes.Add(sv.TenSV);
                            treeView_SinhVien.Nodes.Add(item);
                        }
                        Show_Data(lt);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btn_ChinhSua_Click(object sender, EventArgs e)
        {
            if(listView_LopThi.SelectedItems.Count == 1)
            {
                List<Class.LopThi> list_lt = Class.LopThi.Get_list_LopThi();
                foreach(Class.LopThi lt in list_lt)
                {
                    if(lt.MLT.ToString() == txt_MaLopThi.Text)
                    {
                        Class.Time time_start = new Class.Time(dateTime_Start.Value.ToString(), ':');
                        Class.Time time_end = new Class.Time(dateTime_End.Value.ToString(), ':');
                        Class.DateTime date_time = new Class.DateTime(dateTime_Day_Month_Year.Value.ToString(), '/');
                        string time = time_start.ToString() + "-" + time_end.ToString() + " " + date_time.ToString();
                        Class.Hinh_Thu_Thi hinh_thuc_thi = cb_HinhThucThi.SelectedItem.ToString() == "Online" ? Class.Hinh_Thu_Thi.Online:Class.Hinh_Thu_Thi.Offline;
                        lt.TGT = time;
                        lt.HTT = hinh_thuc_thi;
                        if (Class.LopThi.Xoa(lt.MLT.ToString()) == true)
                        {
                            if (Class.LopThi.Them(lt) == true)
                            {
                                if(Class.list_view_method.ListView_LOPTHI(Class.METHOD.REPAIR, listView_LopThi, lt) == true)
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

        private void btn_Print_Click(object sender, EventArgs e)
        {

        }
    }
}
