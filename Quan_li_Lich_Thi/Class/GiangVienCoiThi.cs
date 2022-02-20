using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_li_Lich_Thi.Class
{
    public class GiangVienCoiThi
    {
        public int MLT { get; set; }
        public int MSGV { get; set; }

        public GiangVien GET_GiangVien()
        {
            List<GiangVien> list_gv = GiangVien.Get_list_GiangVien();
            foreach(GiangVien gv in list_gv)
            {
                if(gv.MSGV == this.MSGV)
                {
                    return gv;
                }
            }
            return null;
        }   // Trả về Giảng Viên

        public LopThi GET_LopThi()
        {
            List<LopThi> list_lt = LopThi.Get_list_LopThi();
            foreach(LopThi lt in list_lt)
            {
                if(lt.MLT == this.MLT)
                {
                    return lt;
                }
            }
            return null;
        }   // Trả về Lớp Thi

        static public bool Them(GiangVienCoiThi giangviencoithi)
        {
            List<GiangVienCoiThi> list_gvct = Get_list_GiangVienCoiThi();
            foreach(GiangVienCoiThi gvct in list_gvct)
            {
                if(gvct.MLT == giangviencoithi.MLT && gvct.MSGV == giangviencoithi.MSGV)
                {
                    return false;
                }
            }
            string str = giangviencoithi.MLT.ToString() + "," + giangviencoithi.MSGV.ToString();
            File.Add_Row(File.path_giangviencoithi,str);
            return true;
        }   // Thêm giảng viên coi thi

        static public bool Xoa_Theo_MLT(string MLT)
        {
            List<GiangVienCoiThi> list_gvct = Get_list_GiangVienCoiThi();
            foreach (GiangVienCoiThi gvct in list_gvct)
            {
                if (gvct.MLT.ToString() == MLT)
                {
                    string str = gvct.MLT.ToString() + "," + gvct.MSGV.ToString();
                    File.Delete_Row(File.path_giangviencoithi, str);
                    return true;
                }
            }
            return false;
        }   // Xóa Giảng Viên Coi Thi theo Mã Lớp Thi
        static public bool Xoa_Theo_MSGV(string MSGV)
        {
            List<GiangVienCoiThi> list_gvct = Get_list_GiangVienCoiThi();
            foreach (GiangVienCoiThi gvct in list_gvct)
            {
                if (gvct.MSGV.ToString() == MSGV)
                {
                    string str = gvct.MLT.ToString() + "," + gvct.MSGV.ToString();
                    File.Delete_Row(File.path_giangviencoithi, str);
                    return true;
                }
            }
            return false;
        }   // Xóa Giảng Viên Coi Thi theo Mã Số Giảng Viên
        static public bool Xoa(GiangVienCoiThi giangviencoithi)
        {
            List<GiangVienCoiThi> list_gvct = Get_list_GiangVienCoiThi();
            foreach (GiangVienCoiThi gvct in list_gvct)
            {
                if (gvct.MLT == giangviencoithi.MLT && gvct.MSGV == giangviencoithi.MSGV)
                {
                    string str = giangviencoithi.MLT.ToString() + "," + giangviencoithi.MSGV.ToString();
                    File.Delete_Row(File.path_giangviencoithi, str);
                    return true;
                }
            }
            return false;
        }   // Xóa 1 đối tượng Giảng Viên Coi Thi
        static public List<GiangVienCoiThi> Get_list_GiangVienCoiThi()
        {
            List<GiangVienCoiThi> list_gvct = new List<GiangVienCoiThi>();
            string[] data = File.ReadAllData(File.path_giangviencoithi);
            foreach(string s in data)
            {
                string[] arr = s.Split(',');
                if(arr.Length == 2)
                {
                    GiangVienCoiThi gvct = new GiangVienCoiThi();
                    gvct.MLT = Convert.ToInt32(arr[0]);
                    gvct.MSGV = Convert.ToInt32(arr[1]);
                    list_gvct.Add(gvct);
                }
            }
            return list_gvct;
        }   // Lấy danh sách Giảng Viên Coi Thi
    }
}
