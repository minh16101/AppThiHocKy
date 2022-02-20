using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Quan_li_Lich_Thi.Class
{
    class SinhVienLop
    {
        public int MSSV { get; set; }
        public int MLH { get; set; }

        static public bool Them(SinhVienLop sinhvienlop)
        {
            List<SinhVienLop> list_svlop = Get_list_SinhVienLop();
            foreach(SinhVienLop svlop in list_svlop)
            {
                if(svlop.MSSV == sinhvienlop.MSSV && svlop.MLH == sinhvienlop.MLH)
                {
                    return false;
                }
            }
            string str = sinhvienlop.MSSV.ToString() + "," + sinhvienlop.MLH.ToString();
            File.Add_Row(File.path_sinhvienlop, str);
            return true;
        }   // Thêm sinh viên vào lớp
        static public bool Xoa(SinhVienLop sinhvienlop)
        {
            List<SinhVienLop> list_svlop = Get_list_SinhVienLop();
            foreach(SinhVienLop svlop in list_svlop)
            {
                if(svlop.MSSV == sinhvienlop.MSSV && svlop.MLH == sinhvienlop.MLH)
                {
                    string s = svlop.MSSV + "," + svlop.MLH;
                    File.Delete_Row(File.path_sinhvienlop, s);
                    return true;
                }
            }
            return false;
        }   // Xóa sinh viên trong 1 lớp 
        static public bool Xoa(int MLH)
        {
            List<SinhVienLop> list_svlop = Get_list_SinhVienLop();
            foreach (SinhVienLop svlop in list_svlop)
            {
                if ( svlop.MLH == MLH)
                {
                    string s = svlop.MSSV + "," + svlop.MLH;
                    File.Delete_Row(File.path_sinhvienlop, s);
                    return true;
                }
            }
            return false;
        }   // Xóa toàn bộ sinh viên trong lớp học theo mã lớp học
        static public List<SinhVienLop> Get_list_SinhVienLop()
        {
            List<SinhVienLop> list_svlop = new List<SinhVienLop>();

            string[] arr_user = File.ReadAllData(File.path_sinhvienlop);
            foreach (string s in arr_user)
            {
                string[] arr = s.Split(',');
                if (arr.Length == 2)
                {
                    SinhVienLop svlop = new SinhVienLop();
                    svlop.MLH = Convert.ToInt32(arr[1]);
                    svlop.MSSV = Convert.ToInt32(arr[0]);
                    list_svlop.Add(svlop);
                }
            }
            return list_svlop;
        }   // Lấy toàn bộ danh sách sinh viên các lớp học
    }
}
