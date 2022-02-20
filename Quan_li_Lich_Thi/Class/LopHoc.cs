using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_li_Lich_Thi.Class
{
    public class LopHoc
    {
        public int MLH { get; set; }
        public string TenLH { get; set; }
        public int MSGV { get; set; }
        public string MHP { get; set; }

        public override string ToString()
        {
            return this.MLH.ToString() + "," + this.TenLH + "," + this.MSGV.ToString() + "," + this.MHP;
        }   // Lấy theo string

        static public List<SinhVien> Get_list_SinhVien(int MLH)
        {
            List<SinhVien> list_svml = new List<SinhVien>();
            List<SinhVien> list_sv = SinhVien.Get_list_SinhVien();
            List<SinhVienLop> list_svlop = SinhVienLop.Get_list_SinhVienLop();
            foreach(SinhVien sv in list_sv)
            {
                foreach(SinhVienLop svlop in list_svlop)
                {
                    if(svlop.MLH == MLH && sv.MSSV == svlop.MSSV)
                    {
                        if (list_svml.Contains(sv) == false)
                        {
                            list_svml.Add(sv);
                        }
                    }
                }
            }
            return list_svml;
        }   // Lấy danh sách sinh viên trong lớp học

        static public LopHoc GET_LopHoc(int MLH)
        {
            List<LopHoc> list_lh = Get_list_LopHoc();
            foreach (LopHoc lh in list_lh)
            {
                if (lh.MLH == MLH)
                {
                    return lh;
                }
            }
            return null;
        }   // Trả về lớp học theo Mã Lớp học

        static public bool Them(LopHoc lophoc)
        {
            List<LopHoc> list_lh = Get_list_LopHoc();
            foreach (LopHoc lh in list_lh)
            {
                if (lh.MLH == lophoc.MLH)
                {
                    return false;
                }
            }
            string str = lophoc.MLH.ToString() + "," + lophoc.TenLH + "," + lophoc.MSGV.ToString() + "," + lophoc.MHP;
            File.Add_Row(File.path_lophoc, str);
            return true;
            }   // Thêm lớp học

        static public bool Sua(LopHoc lophoc)
        {
            if (Xoa(lophoc.MLH) == true)
            {
                if(Them(lophoc) == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }   // Sửa lướp học
        static public bool Xoa(int MLH)
        {
            List<LopHoc> list_lh = Get_list_LopHoc();
            foreach(LopHoc lh in list_lh)
            {
                if(lh.MLH == MLH)
                {
                    string str = lh.MLH.ToString() + "," + lh.TenLH + "," + lh.MSGV.ToString() + "," + lh.MHP;
                    File.Delete_Row(File.path_lophoc, str);
                    return true;
                }
            }
            return false;
        }   // Xóa lớp học theo Mã lớp học

        static public LopThi Get_LopThi(int MLH)
        {
            LopThi lopthi = new LopThi();
            List<LopThi> list_lt = Class.LopThi.Get_list_LopThi();
            foreach(LopThi lt in list_lt)
            {
                if(lt.MLH == MLH)
                {
                    lopthi = lt;
                }
            }
            return lopthi;
        }

        static public List<LopHoc> Get_list_LopHoc()
        {
            List<LopHoc> list_lh = new List<LopHoc>();
            string[] array_data = File.ReadAllData(File.path_lophoc);
            foreach(string s in array_data)
            {
                string[] s_data = s.Split(',');
                if(s_data.Length == 4)
                {
                    LopHoc lh = new LopHoc();
                    lh.MLH = Convert.ToInt32(s_data[0]);
                    lh.TenLH = s_data[1];
                    lh.MSGV = Convert.ToInt32(s_data[2]);
                    lh.MHP = s_data[3];
                    list_lh.Add(lh);
                }
            }
            return list_lh;
        }   // Lấy danh sách lớp học từ database
    }
}
