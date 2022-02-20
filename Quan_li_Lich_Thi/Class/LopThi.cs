using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_li_Lich_Thi.Class
{
    public enum Hinh_Thu_Thi
    {
        Online, Offline  // 0 = Online, 1 = Offline
    };
    public enum Kieu_Thi
    {
        Giua_Ki, Cuoi_Ki // 0 = GiuaKi, 1 = Cuoi_Ki
    };
    public class Time
    {
        public int gio { get; set; }
        public int phut{ get; set; }

        public Time(string time)
        {
            string[] arr = time.Split('h');
            if(arr.Length == 2)
            {
                gio = Convert.ToInt32(arr[0]);
                phut = Convert.ToInt32(arr[1]);
            }
        }
        public Time(string time, char split_char)
        {
            string[] arr = time.Split(split_char);
            if (arr.Length == 2)
            {
                gio = Convert.ToInt32(arr[0]);
                phut = Convert.ToInt32(arr[1]);
            }
        }
        public Time()
        {
            gio = 0;
            phut = 0;
        }
        public override string ToString()
        {
            return gio.ToString() + "h" + phut.ToString();
        }
    }
    public class DateTime
    {
        public int ngay { get; set; }
        public int thang { get; set; }
        public int nam { get; set; }

        public DateTime(int ngay, int thang, int nam)
        {
            this.ngay = ngay;
            this.thang = thang;
            this.nam = nam;
        }

        public DateTime()
        {
            this.ngay = 0;
            this.thang = 0;
            this.nam = 0;
        }
        public DateTime(string datetime){
            string[] arr = datetime.Split('/');
            if(arr.Length == 3)
            {
                ngay = Convert.ToInt32(arr[0]);
                thang = Convert.ToInt32(arr[1]);
                nam = Convert.ToInt32(arr[2]);
            }
        }
        public DateTime(string datetime,char split_char)
        {
            string[] arr = datetime.Split(split_char);
            if (arr.Length == 3)
            {
                ngay = Convert.ToInt32(arr[0]);
                thang = Convert.ToInt32(arr[1]);
                nam = Convert.ToInt32(arr[2]);
            }
        }
        public override string ToString()
        {
            return ngay.ToString() + '/' + thang.ToString() + '/' + nam.ToString();
        }

        
    }

    public class DiaDiem
    {
        string khu;
        int tang;
        int phong;

        public override string ToString()
        {
            if (tang >= 10)
            {
                return null;
            }
            else
            {
                if (phong >= 10)
                {
                    return khu + "-" + tang.ToString() + phong.ToString();
                }
                else
                {
                    return khu + "-" + tang.ToString() + "0" + phong.ToString();
                }
            }
        }

        static public DiaDiem Convert_DiaDiem(string s_diadiem)
        {
            DiaDiem dd_diadiem = new DiaDiem();
            string[] arr = s_diadiem.Split('-');
            dd_diadiem.khu = arr[0];
            dd_diadiem.tang = Convert.ToInt32(arr[1].ToCharArray()[0]);
            char[] string_cp = new char[3];
            arr[1].CopyTo(1, string_cp, 0, 2);
            dd_diadiem.phong = Convert.ToInt32(string_cp);
            return dd_diadiem;
        }
    }

    public class LopThi
    {
        public int MLT { get; set; }
        public int MLH { get; set; }
        public int SoGV { get; set; }
        public string TGT { get; set; } // Ex: 6h30-9h30 22/12/2021
        public string DDT { get; set; } // Ex: D3-5 209     => Khu D3-5 tầng 2 phòng 9

        public Hinh_Thu_Thi HTT { get; set; }

        public Kieu_Thi KT { get; set; }

        public string Get_KT()
        {
            if(KT == Kieu_Thi.Cuoi_Ki)
            {
                return "Cuối Kì";
            }
            else
            {
                return "Giữa Kì";
            }
        }       // ToString() Kiểu thi

        public string Get_HTT()
        {
            if( HTT == Hinh_Thu_Thi.Online)
            {
                return "Online";
            }
            else
            {
                return "Offline";
            }
        }       // ToString() hình thức thi


        static public List<GiangVien> GET_GVCT(int MLT)
        {
            List<GiangVien> list_gv = new List<GiangVien>();
            List<GiangVienCoiThi> list_gvct = Class.GiangVienCoiThi.Get_list_GiangVienCoiThi();
            foreach(GiangVienCoiThi gvct in list_gvct)
            {
                if(gvct.MLT == MLT)
                {
                    list_gv.Add(Class.GiangVien.Get_GV(gvct.MSGV));
                }
            }
            return list_gv;
        }   // Lây danh sách giảng viên coi thi
        static public LopHoc GET_LopHoc(int MLH)
        {
            List<LopHoc> list_lh = LopHoc.Get_list_LopHoc();
            foreach(LopHoc item in list_lh)
            {
                if(item.MLH == MLH)
                {
                    return item;
                }
            }
            return null;
        }       // Lấy Lớp học đi kèm với lớp thi
        

        // Phuong thuc static
        static public LopThi GET_MLT(int MLT)
        {
            List<LopThi> list_LopThi = Get_list_LopThi();
            foreach(LopThi lt in list_LopThi)
            {
                if(lt.MLT == MLT)
                {
                    return lt;
                }
            }
            return null;
        }     // Tìm kiếm Lớp Thi theo mã lớp

        static public bool Is_Exist(int MLT)
        {
            List<LopThi> list_lt = Get_list_LopThi();
            foreach(LopThi lt in list_lt)
            {
                if(lt.MLT == MLT)
                {
                    return true;
                }
            }
            return false;
        }      // Kiểm tra lớp thi có tồn tại

        static public string Convert_TGT(Time time_start,Time time_end,DateTime datetime)
        {
            string TGT = time_start.ToString() + "-" + time_end.ToString() + " " + datetime.ToString();
            return TGT;
        } // Chuyển đổi thời gian thi phù hợp với format

        static public Dictionary<Time[], DateTime> Convert_TGT(string TGT)
        {
            Dictionary<Time[], DateTime> dic_TGT = new Dictionary<Time[], DateTime>();
            Time[] time = new Time[2];
            string[] arr = TGT.Split(' ');
            string[] arr_time = arr[0].Split('-');
            Time time_start = new Time(arr_time[0]);
            Time time_end = new Time(arr_time[1]);
            time[0] = time_start;
            time[1] = time_end;
            DateTime date_time = new DateTime(arr[1]);
            dic_TGT.Add(time, date_time);
            return dic_TGT;
        }   // Chuyển đổi từ format (kiểu string) sang time_start, time_end. datetime
        
        static public bool Them(LopThi lopthi)
        {
            List<LopThi> list_lopthi = Get_list_LopThi();
            foreach (LopThi lt in list_lopthi)
            {
                if (lt.MLT == lopthi.MLT)
                {
                    return false;
                }
            }
            string str = lopthi.MLT.ToString() + "," + lopthi.MLH.ToString() + "," + lopthi.SoGV.ToString() + "," + lopthi.TGT.ToString() + "," + lopthi.DDT.ToString() + "," + lopthi.HTT.ToString() + "," + lopthi.KT.ToString();
            File.Add_Row(File.path_lopthi, str);
            return true;
        }   // Thêm lớp thi vào database
       
        static public bool Sua(LopThi lopthi)
        {
            if (File.Delete_By_MaSo(File.path_lopthi,lopthi.MLT.ToString()) == true)
            {
                if(Them(lopthi) == true)
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
        }   // Sửa thông tin lớp thi và lưu vào database
        static public bool Xoa(string MLT)
        {
            if (File.Delete_By_MaSo(File.path_lopthi, MLT) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }       // Xóa lớp thi theo mã lớp 

        static public List<LopThi> Get_list_LopThi()
        {
            List<LopThi> list_lopthi = new List<LopThi>();
            string[] arr_lopthi = File.ReadAllData(File.path_lopthi);
            foreach (string s in arr_lopthi)
            {
                string[] arr = s.Split(',');
                if (arr.Length == 7)
                {
                    LopThi lopthi = new LopThi();
                    lopthi.MLT = Convert.ToInt32(arr[0]);
                    lopthi.MLH = Convert.ToInt32(arr[1]);
                    lopthi.SoGV = Convert.ToInt32(arr[2]);
                    lopthi.TGT = arr[3];
                    lopthi.DDT = arr[4];
                    if (arr[5] == "0")
                    {
                        lopthi.HTT = Hinh_Thu_Thi.Online;
                    }
                    else
                    {
                        lopthi.HTT = Hinh_Thu_Thi.Offline;
                    }
                    if (arr[6] == "0")
                    {
                        lopthi.KT = Kieu_Thi.Giua_Ki;
                    }
                    else
                    {
                        lopthi.KT = Kieu_Thi.Cuoi_Ki;
                    }
                    list_lopthi.Add(lopthi);
                }    
            }
            return list_lopthi;
        }   // Lấy danh sách các lơp thi từ database

    }
}
