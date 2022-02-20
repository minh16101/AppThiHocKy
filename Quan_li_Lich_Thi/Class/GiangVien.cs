using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_li_Lich_Thi.Class
{
    public class GiangVien
    {
        public int MSGV { get; set; }
        public string TenGV { get; set; }
        public string Khoa { get; set; }
        
       

        static public List<GiangVien> Get_list_GiangVien()
        {
            List<GiangVien> list_gv = new List<GiangVien>();
            string[] data = File.ReadAllData(File.path_giangvien);
            foreach(string s in data)
            {
                string[] arr = s.Split(',');
                if(arr.Length == 3)
                {
                    GiangVien gv = new GiangVien();
                    gv.MSGV = Convert.ToInt32(arr[0]);
                    gv.TenGV = arr[1];
                    gv.Khoa = arr[2];
                    list_gv.Add(gv);
                }
            }
            return list_gv;
        }   // Lấy danh sách giảng viên từ database

        static public List<LopHoc> Get_List_LopHoc(int MSGV)
        {
            List<LopHoc> list_lh = LopHoc.Get_list_LopHoc();
            List<LopHoc> list_lophoc = new List<LopHoc>();
            foreach (LopHoc lt in list_lh)
            {
                if (lt.MSGV == MSGV)
                {
                    list_lophoc.Add(lt);
                }
            }
            return list_lophoc;
        }   // Lấy danh sách lớp học giảng dạy theo mã số giảng viên

        static public List<LopThi> Get_List_LopThi(int MSGV)
        {
            List<LopThi> list_lt = Class.LopThi.Get_list_LopThi();
            List<LopThi> list_lopthi = new List<LopThi>();
            List<LopHoc> list_lh = Get_List_LopHoc(MSGV);
            foreach (LopHoc lh in list_lh)
            {
                foreach (LopThi lt in list_lt)
                {
                    if (lt.MLH == lh.MLH)
                    {
                        list_lopthi.Add(lt);
                    }
                }
            }
            return list_lopthi;
        }   // Lấy Danh sách Lớp Thi theo Mã Sô Giảng Viên

        static public GiangVien Get_GV(int MSGV)
        {
            List<GiangVien> list_gv = Class.GiangVien.Get_list_GiangVien();
            foreach(GiangVien gv in list_gv)
            {
                if(gv.MSGV == MSGV)
                {
                    return gv;
                }
            }
            return null;
        }   // Lấy Giảng Viên theo Mã Số Giảng Viên
    }
}
