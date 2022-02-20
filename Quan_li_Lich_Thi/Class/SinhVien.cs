using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Quan_li_Lich_Thi.Class
{
    public class SinhVien
    {
        public int MSSV { get; set; }
        public string TenSV { get; set; }


        static public SinhVien GET_SV(int MSSV)
        {
            List<SinhVien> list_sv = Get_list_SinhVien();
            foreach (SinhVien sv in list_sv)
            {
                if (sv.MSSV == MSSV)
                {
                    return sv;
                }
            }
            return null;
        }   // Get Sinh Viên theo mã sinh viên

        static public List<LopHoc> GET_list_LopHoc(int MSSV)
        {
            List<LopHoc> list_lh = new List<LopHoc>();
            List<SinhVienLop> list_svlop = SinhVienLop.Get_list_SinhVienLop();
            foreach(SinhVienLop svl in list_svlop)
            {
                if(svl.MSSV == MSSV)
                {
                    List<LopHoc> list_lophoc = LopHoc.Get_list_LopHoc();
                    foreach(LopHoc lh in list_lophoc)
                    {
                        if(lh.MLH == svl.MLH)
                        {
                            list_lh.Add(lh);
                        }
                    }
                }
            }
            return list_lh;
        }   // Get danh sách lớp học mà sinh viên theo học
        static public List<LopThi> GET_list_LopThi(int MSSV)
        {
            List<LopThi> list_lt = new List<LopThi>();
            List<LopHoc> list_lh = Class.SinhVien.GET_list_LopHoc(MSSV);
            if (list_lh != null)
            {
                foreach (LopHoc lh in list_lh)
                {
                    LopThi lt = Class.LopHoc.Get_LopThi(lh.MLH);
                    if (lt != null)
                    {
                        list_lt.Add(lt);
                    }
                }
            }
            return list_lt;
        }   // Get danh sách lớp thi mà sinh viên thi

        static public List<SinhVien> Get_list_SinhVien()
        {
            List<SinhVien> list_sv = new List<SinhVien>();
            string[] arr_str = File.ReadAllData(File.path_sinhvien);
            foreach (string s in arr_str)
            {
                string[] arr = s.Split(',');
                if (arr.Length == 2)
                {
                    SinhVien sv = new SinhVien();
                    sv.MSSV = Convert.ToInt32(arr[0]);
                    sv.TenSV = arr[1];
                    list_sv.Add(sv);
                }
            }
            return list_sv;
        }   // Lấy danh sách sinh viên từ database
    }
}
