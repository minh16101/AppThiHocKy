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
    public partial class UserControlGiaoVuLopHoc : UserControl
    {
        public UserControlGiaoVuLopHoc()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
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
            if (listView_LopHoc.SelectedItems.Count == 1)
            {
                if (String.IsNullOrEmpty(txt_MaLop.Text) == false && String.IsNullOrEmpty(txt_TenLop.Text) == false && String.IsNullOrEmpty(cb_GiaoVienGiangDay.Text) == false && String.IsNullOrEmpty(cb_MaHocPhan.Text) == false&&treeView_SinhVien.Nodes.Count!=0)
                {
                    DialogResult result = MessageBox.Show("Xác nhận sửa lớp học với mã lớp: " + txt_MaLop.Text, "THÔNG BÁO", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.OK)
                    {
                        Class.LopHoc lh = new Class.LopHoc();
                        lh.MLH = Convert.ToInt32(txt_MaLop.Text);
                        lh.TenLH = txt_TenLop.Text;
                        lh.MSGV = Convert.ToInt32(cb_GiaoVienGiangDay.Text.Split('-')[0]);
                        lh.MHP = cb_MaHocPhan.Text.Split('-')[0];
                        if (Class.list_view_method.ListView_LOPHOC(Class.METHOD.REPAIR, listView_LopHoc, lh) == true)
                        {
                            Class.LopHoc.Xoa(lh.MLH);
                            Class.SinhVienLop.Xoa(lh.MLH);
                            Class.LopHoc.Them(lh);
                            foreach (TreeNode item in treeView_SinhVien.Nodes)
                            {
                                Class.SinhVienLop svl = new Class.SinhVienLop();
                                svl.MLH = lh.MLH;
                                svl.MSSV = Convert.ToInt32(item.Text);
                                Class.SinhVienLop.Them(svl);
                            }
                            MessageBox.Show("Sửa thành công!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Sửa không thành công!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Thông tin còn trống!", "CẢNH BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Chọn lớp học để thay đổi!", "CẢNH BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (listView_LopHoc.SelectedItems.Count == 1)
            {
                if (String.IsNullOrEmpty(txt_MaLop.Text) == false && String.IsNullOrEmpty(txt_TenLop.Text) == false && String.IsNullOrEmpty(cb_GiaoVienGiangDay.Text) == false && String.IsNullOrEmpty(cb_MaHocPhan.Text) == false)
                {
                    DialogResult result = MessageBox.Show("Xác nhận xóa lớp học với mã lớp: " + txt_MaLop.Text, "THÔNG BÁO", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if(result == DialogResult.OK)
                    {
                        Class.LopHoc lh = new Class.LopHoc();
                        lh.MLH = Convert.ToInt32(txt_MaLop.Text);
                        lh.TenLH = txt_TenLop.Text;
                        lh.MSGV = Convert.ToInt32(cb_GiaoVienGiangDay.Text.Split('-')[0]);
                        lh.MHP = cb_GiaoVienGiangDay.Text.Split('-')[0]; 
                        if (Class.list_view_method.ListView_LOPHOC(Class.METHOD.DELETE, listView_LopHoc, lh) == true)
                        {
                            Class.LopHoc.Xoa(lh.MLH);
                            Class.SinhVienLop.Xoa(lh.MLH);
                            MessageBox.Show("Xóa thành công!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Xóa không thành công!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txt_MaLop.Text)==false && String.IsNullOrEmpty(txt_TenLop.Text) == false && String.IsNullOrEmpty(cb_GiaoVienGiangDay.Text) == false && String.IsNullOrEmpty(cb_MaHocPhan.Text) == false && treeView_SinhVien.Nodes.Count!=0)
            {
                Class.LopHoc lh = new Class.LopHoc();
                lh.MLH = Convert.ToInt32(txt_MaLop.Text);
                lh.TenLH = txt_TenLop.Text;
                string[] arr_gv = cb_GiaoVienGiangDay.Text.Split('-');
                string[] arr_hp = cb_MaHocPhan.Text.Split('-');
                lh.MSGV = Convert.ToInt32(arr_gv[0]);
                lh.MHP = arr_hp[0];
                if(Class.list_view_method.ListView_LOPHOC(Class.METHOD.ADD, listView_LopHoc, lh) == true)
                {
                    if (Class.LopHoc.Them(lh) == true) { 
                        foreach(TreeNode item in treeView_SinhVien.Nodes) {
                            Class.SinhVienLop svlop = new Class.SinhVienLop();
                            svlop.MSSV = Convert.ToInt32(item.Text);
                            svlop.MLH = Convert.ToInt32(txt_MaLop.Text);
                            Class.SinhVienLop.Them(svlop);
                        }
                        MessageBox.Show("Thêm lớp học thành công!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Lớp đã tồn tại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if(treeView_SinhVien.Nodes.Count == 0)
                {
                    MessageBox.Show("Chưa thêm danh sách sinh viên!", "Cảnh báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Thông tin trống", "Cảnh báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
               
            }
        }

        private void thêmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Class.SinhVien> list_sv = new List<Class.SinhVien>();
            foreach (TreeNode x in treeView_SinhVien.Nodes)
            {
                if (x.Nodes.Count != 0)
                {
                    Class.SinhVien sv = new Class.SinhVien();
                    sv.MSSV = Convert.ToInt32(x.Text);
                    sv.TenSV = x.Nodes[0].Text;
                    list_sv.Add(sv);
                }
            }
            Forms.add_SinhVien wf_sv = new Forms.add_SinhVien();
            wf_sv.Receive_data(list_sv);
            wf_sv.ThayDoiThongTinSinhVienEvent += Wf_sv_ThayDoiThongTinSinhVienEvent;
            wf_sv.ShowDialog();

        }

        private void Wf_sv_ThayDoiThongTinSinhVienEvent(List<Class.SinhVien> list_sv)
        {
            treeView_SinhVien.Nodes.Clear();
            foreach(Class.SinhVien sv in list_sv)
            {
                TreeNode item = new TreeNode();
                item.Text = sv.MSSV.ToString();
                item.Nodes.Add(sv.TenSV);
                treeView_SinhVien.Nodes.Add(item);
            }
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {

        }

        private void treeView_SinhVien_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void btn_reset_Click_1(object sender, EventArgs e)
        {
            Reset();
        }

        private void UserControlGiaoVuLopHoc_Load(object sender, EventArgs e)
        {
            Reset();
        }

        private void listView_LopHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView_LopHoc.SelectedItems.Count == 1)
            {
                int ma_lop = Convert.ToInt32(listView_LopHoc.SelectedItems[0].Text);
                List<Class.SinhVien> list_svml = Class.LopHoc.Get_list_SinhVien(ma_lop);
                if (list_svml.Count != 0)
                {
                    treeView_SinhVien.Nodes.Clear();
                    foreach (Class.SinhVien sv in list_svml)
                    {
                        TreeNode item = new TreeNode();
                        item.Text = sv.MSSV.ToString();
                        item.Nodes.Add(sv.TenSV);
                        treeView_SinhVien.Nodes.Add(item);
                    }
                }
                else
                {
                    MessageBox.Show("Lớp trống", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                txt_MaLop.Text = listView_LopHoc.SelectedItems[0].SubItems[0].Text;
                txt_TenLop.Text = listView_LopHoc.SelectedItems[0].SubItems[1].Text;
                List<Class.GiangVien> list_gv = Class.GiangVien.Get_list_GiangVien();
                foreach (Class.GiangVien gv in list_gv)
                {
                    if (gv.MSGV.ToString() == listView_LopHoc.SelectedItems[0].SubItems[2].Text)
                    {
                        cb_GiaoVienGiangDay.Text = gv.MSGV.ToString() + '-' + gv.TenGV + '-' + gv.Khoa;
                    }
                }
                cb_MaHocPhan.Text = listView_LopHoc.SelectedItems[0].SubItems[3].Text;
                
            }
        }

        //------------------------------------------------------------------------------------------------------------//
        public void Reset()
        {
            listView_LopHoc.Items.Clear();
            treeView_SinhVien.Nodes.Clear();
            txt_MaLop.Text = "";
            txt_TenLop.Text = "";
            cb_GiaoVienGiangDay.Text = "";
            cb_GiaoVienGiangDay.Items.Clear();
            cb_MaHocPhan.Items.Clear();
            cb_MaHocPhan.Text = "";
            List<Class.GiangVien> list_gv = Class.GiangVien.Get_list_GiangVien();
            foreach (Class.GiangVien gv in list_gv)
            {
                cb_GiaoVienGiangDay.Items.Add(gv.MSGV.ToString() + "-" + gv.TenGV);
            }
            List<Class.HocPhan> list_hp = Class.HocPhan.Get_list_HocPhan();
            foreach (Class.HocPhan hp in list_hp)
            {
                cb_MaHocPhan.Items.Add(hp.MHP + "-" + hp.TenHP +"-"+ (hp.TH == true ? "Có thực hành" : "Không có thực hành"));
            }
            List<Class.LopHoc> list_lh = Class.LopHoc.Get_list_LopHoc();
            foreach (Class.LopHoc lh in list_lh)
            {
                ListViewItem item = new ListViewItem(lh.MLH.ToString());
                item.SubItems.Add(lh.TenLH);
                item.SubItems.Add(lh.MSGV.ToString());
                item.SubItems.Add(lh.MHP);
                listView_LopHoc.Items.Add(item);
            }
        }
    }
}
