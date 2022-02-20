using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_li_Lich_Thi.User_Control
{
    public partial class UserControlGiaoVuLopThi : UserControl
    {
        public static User_Control.UserControlGiaoVuLopThi uc_lopthi;
        public UserControlGiaoVuLopThi()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
          
        }

        private void listView_LopThi_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void xóaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            treeView_GiangVien.Nodes.Remove(treeView_GiangVien.SelectedNode);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void thêmToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Forms.add_GiangVienCoiThi add_gv = new Forms.add_GiangVienCoiThi();
            add_gv.Show();
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Xác nhận thay đổi thông tin lớp thi: " + txt_MaLopThi.Text, "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                if (String.IsNullOrEmpty(txt_DiaDiemThi.Text) == false
                && String.IsNullOrEmpty(txt_MaLopThi.Text) == false
                && String.IsNullOrEmpty(cb_HinhThucThi.Text) == false
                && String.IsNullOrEmpty(cb_Kieu_Thi.Text) == false
                && String.IsNullOrEmpty(cb_HinhThucThi.Text) == false
                && treeView_GiangVien.Nodes.Count != 0
                )
                {
                    if (Class.Handle_String.IsNumber(txt_MaLopThi.Text) == true)
                    {
                        if (Class.LopThi.Is_Exist(Convert.ToInt32(txt_MaLopThi.Text)) == true)
                        {
                            Class.LopThi lt = Get_data();
                            ListViewItem item_select = Class.list_view_method.ListView_GET_LOPTHI_EXIST(listView_LopThi, lt.MLT.ToString());
                            if (item_select != null)
                            {
                                Class.list_view_method.ListView_LOPTHI(Class.METHOD.REPAIR, listView_LopThi, lt);
                                Class.LopThi.Sua(lt);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Mã lớp không tồn tại!", "CẢNH BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mã lớp không hợp lệ!", "CẢNH BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Điền đầy đủ thông tin!", "CẢNH BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void dateTime_Day_Month_Year_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void UserControlGiaoVuLopThi_Load(object sender, EventArgs e)
        {
            Reset();
        }

        public void Reset()
        {
            txt_DiaDiemThi.Text = "";
            txt_MaLopThi.Text = "";
            txt_SoGiangVienCoiThi.Text = "";
            cb_HinhThucThi.Text = "";
            cb_Kieu_Thi.Text = "";
            cb_MaLopHoc.Text = "";
            treeView_GiangVien.Nodes.Clear();
            treeView_SinhVien.Nodes.Clear();
            listView_LopThi.Items.Clear();
            List<Class.LopThi> list_lt = Class.LopThi.Get_list_LopThi();
            foreach(Class.LopThi item in list_lt)
            {
                Class.list_view_method.ListView_LOPTHI(Class.METHOD.ADD, listView_LopThi,item);
            }
            List<Class.LopHoc> list_lh = Class.LopHoc.Get_list_LopHoc();
            foreach(Class.LopHoc item in list_lh)
            {
                cb_MaLopHoc.Items.Add(item.MLH);
            }
        }
        public void Show_Data(Class.LopThi lt)
        {
            txt_MaLopThi.Text = lt.MLT.ToString();
            cb_MaLopHoc.Text = lt.MLH.ToString();
            cb_Kieu_Thi.Text = lt.Get_KT();
            cb_HinhThucThi.Text = lt.Get_HTT();
            txt_SoGiangVienCoiThi.Text = lt.SoGV.ToString();
            txt_DiaDiemThi.Text = lt.DDT;
            Dictionary<Class.Time[], Class.DateTime> dic_TGT = Class.LopThi.Convert_TGT(lt.TGT);
            foreach (KeyValuePair<Class.Time[], Class.DateTime> item in dic_TGT)
            {
                dateTime_Start.Value = DateTime.Today.AddHours(item.Key[0].gio).AddMinutes(item.Key[0].phut);
                dateTime_End.Value = DateTime.Today.AddHours(item.Key[1].gio).AddMinutes(item.Key[1].phut);
                dateTime_Day_Month_Year.Value = DateTime.Today.AddYears(item.Value.nam).AddMonths(item.Value.thang).AddDays(item.Value.ngay);
            }
        }

        public Class.LopThi Get_data()
        {
            Class.LopThi lt = new Class.LopThi();
            lt.MLT = Convert.ToInt32(txt_MaLopThi.Text);
            lt.MLH = Convert.ToInt32(cb_MaLopHoc.Text);
            lt.HTT = cb_HinhThucThi.Text == "Online" ? Class.Hinh_Thu_Thi.Online : Class.Hinh_Thu_Thi.Offline;
            lt.KT = cb_Kieu_Thi.Text == "Giữa Kì" ? Class.Kieu_Thi.Giua_Ki : Class.Kieu_Thi.Cuoi_Ki;
            lt.DDT = txt_DiaDiemThi.Text;
            Class.Time time_start = new Class.Time();
            Class.Time time_end = new Class.Time();
            time_start.gio = Convert.ToInt32(dateTime_Start.Value.Hour.ToString());
            time_start.phut = Convert.ToInt32(dateTime_Start.Value.Minute.ToString());
            time_end.gio = Convert.ToInt32(dateTime_End.Value.Hour.ToString());
            time_end.phut = Convert.ToInt32(dateTime_End.Value.Minute.ToString());
            Class.DateTime date_time = new Class.DateTime(Convert.ToInt32(dateTime_Day_Month_Year.Value.Day.ToString()), Convert.ToInt32(dateTime_Day_Month_Year.Value.Month.ToString()), Convert.ToInt32(dateTime_Day_Month_Year.Value.Year.ToString()));
            lt.TGT = Class.LopThi.Convert_TGT(time_start,time_end, date_time);
            lt.SoGV = treeView_GiangVien.Nodes.Count;
            return lt;
        }
        private void btn_Them_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Có muốn thêm lớp thi mã: " + txt_MaLopThi.Text, "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                if (String.IsNullOrEmpty(txt_DiaDiemThi.Text) == false
            && String.IsNullOrEmpty(txt_MaLopThi.Text) == false
            && String.IsNullOrEmpty(cb_HinhThucThi.Text) == false
            && String.IsNullOrEmpty(cb_Kieu_Thi.Text) == false
            && String.IsNullOrEmpty(cb_HinhThucThi.Text) == false
            && treeView_GiangVien.Nodes.Count != 0
            )
                {
                    if (Class.Handle_String.IsNumber(txt_MaLopThi.Text) == true)
                    {
                        if (Class.LopThi.Is_Exist(Convert.ToInt32(txt_MaLopThi.Text)) == false)
                        {
                            Class.LopThi lt = Get_data();
                            List<Class.GiangVien> list_gv = Class.tree_node_method.Get_GiangVien_In_TreeView(treeView_GiangVien);
                            foreach (Class.GiangVien gv in list_gv)
                            {
                                Class.GiangVienCoiThi gvct = new Class.GiangVienCoiThi();
                                gvct.MLT = lt.MLT;
                                gvct.MSGV = gv.MSGV;
                                Class.GiangVienCoiThi.Them(gvct);
                            }
                            if (Class.list_view_method.ListView_LOPTHI(Class.METHOD.ADD, listView_LopThi, lt) == true)
                            {
                                Class.LopThi.Them(lt);
                                MessageBox.Show("Thêm thành công!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Lỗi!", "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Mã lớp tồn tại!", "CẢNH BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mã lớp không hợp lệ!", "CẢNH BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show("Điền đầy đủ thông tin!", "CẢNH BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Có muốn xóa lớp thi mã: " + txt_MaLopThi.Text, "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.OK)
            {
                if(listView_LopThi.SelectedItems.Count == 1)
                {
                    Class.LopThi lt = Class.list_view_method.ListView_GET_LOPTHI_SELECTED(listView_LopThi);
                    if(Class.list_view_method.ListView_LOPTHI(Class.METHOD.DELETE, listView_LopThi, lt) == true)
                    {
                        Class.LopThi.Xoa(lt.MLT.ToString());
                        Class.GiangVienCoiThi.Xoa_Theo_MLT(lt.MLT.ToString());
                        Reset();
                    }
                    else
                    {
                        MessageBox.Show("Lỗi!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Chưa chọn lớp thi để xóa!", "CẢNH BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(treeView_GiangVien.SelectedNode.Nodes.Count != 0)
            {
                DialogResult result = MessageBox.Show("Xác nhận xóa giảng viên coi thi: " + treeView_GiangVien.SelectedNode.Nodes[0].Text + "-" + treeView_GiangVien.SelectedNode.Text, "QUESTION?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if(result == DialogResult.OK)
                {
                    treeView_GiangVien.Nodes.Remove(treeView_GiangVien.SelectedNode);
                    Class.GiangVienCoiThi gvct = new Class.GiangVienCoiThi();
                    gvct.MSGV = Convert.ToInt32(treeView_GiangVien.SelectedNode.Text);
                    gvct.MLT = Convert.ToInt32(txt_MaLopThi.Text);
                    Class.GiangVienCoiThi.Xoa(gvct);
                }
            }
        }

        private void thêmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Class.GiangVien> list_gv = new List<Class.GiangVien>();
            foreach (TreeNode x in treeView_GiangVien.Nodes)
            {
                if (x.Nodes.Count != 0)
                {
                    Class.GiangVien gv = new Class.GiangVien();
                    gv.MSGV = Convert.ToInt32(x.Text);
                    gv.TenGV = x.Nodes[0].Text;
                    gv.Khoa = x.Nodes[1].Text;
                    list_gv.Add(gv);
                }
            }
            Forms.add_GiangVienCoiThi wf_sv = new Forms.add_GiangVienCoiThi();
            wf_sv.Receive_data(list_gv);
            wf_sv.ThayDoiGiangVienCoiThiEvent += Wf_sv_ThayDoiGiangVienCoiThiEvent;
            wf_sv.ShowDialog();
        }

        private void Wf_sv_ThayDoiGiangVienCoiThiEvent(List<Class.GiangVien> list_gv)
        {
            foreach(Class.GiangVien gv in list_gv)
            {
                Class.tree_node_method.tree_node_Giang_Vien(Class.METHOD_TREENODE.ADD, treeView_GiangVien, gv);
            }
            txt_SoGiangVienCoiThi.Text = treeView_GiangVien.Nodes.Count.ToString();
        }

        private void listView_LopThi_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (listView_LopThi.SelectedItems.Count == 1&&listView_LopThi.Items.Count!=0)
            {
                treeView_SinhVien.Nodes.Clear();
                treeView_GiangVien.Nodes.Clear();
                Show_Data(Class.LopThi.GET_MLT(Convert.ToInt32(listView_LopThi.SelectedItems[0].Text)));
                Class.LopHoc lophoc = Class.LopHoc.GET_LopHoc(Convert.ToInt32(listView_LopThi.SelectedItems[0].SubItems[1].Text));
                List<Class.SinhVien> list_sv = Class.LopHoc.Get_list_SinhVien(lophoc.MLH);
                foreach (Class.SinhVien sv in list_sv)
                {
                    Class.tree_node_method.tree_node_Sinh_Vien(Class.METHOD_TREENODE.ADD, treeView_SinhVien, sv);
                }
                List<Class.GiangVien> list_gv = Class.LopThi.GET_GVCT(Convert.ToInt32(listView_LopThi.SelectedItems[0].Text));
                foreach (Class.GiangVien gv in list_gv)
                {
                    Class.tree_node_method.tree_node_Giang_Vien(Class.METHOD_TREENODE.ADD, treeView_GiangVien, gv);
                }
            }
        }

        private void treeView_GiangVien_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void cb_MaLopHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(cb_MaLopHoc.Text) == false)
            {
                treeView_SinhVien.Nodes.Clear();
                List<Class.SinhVien> list_sv = Class.LopHoc.Get_list_SinhVien(Convert.ToInt32(cb_MaLopHoc.Text));
                foreach(Class.SinhVien sv in list_sv)
                {
                    Class.tree_node_method.tree_node_Sinh_Vien(Class.METHOD_TREENODE.ADD, treeView_SinhVien, sv);
                }
            }
        }
    }
}
