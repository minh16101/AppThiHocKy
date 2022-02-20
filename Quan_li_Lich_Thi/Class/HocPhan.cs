using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_li_Lich_Thi.Class
{
    public class HocPhan
    {
        public string MHP { get; set; }
        public string TenHP { get; set; }
        public bool TH { get; set; }

        static public HocPhan Get_MHP(string MHP)
        {
            List<HocPhan> list_hp = Get_list_HocPhan();
            foreach(HocPhan hp in list_hp)
            {
                if(hp.MHP == MHP)
                {
                    return hp;
                }
            }
            return null;
        }       // Lấy Học phần theo mã học phần

        static public List<LopHoc> Get_LopHoc(string MHP)
        {
            List<LopHoc> list_lh = Class.LopHoc.Get_list_LopHoc();
            List<LopHoc> list_lophoc = new List<LopHoc>();
            foreach(LopHoc lh in list_lh)
            {
                if(lh.MHP == MHP)
                {
                    list_lophoc.Add(lh);
                }
            }
            return list_lh;
        }   // Lấy Danh Sách học phần theo mã Học phần

        static public List<HocPhan> Get_list_HocPhan()
        {
            List<HocPhan> list_hp = new List<HocPhan>();
            string[] data = File.ReadAllData(File.path_hocphan);
            foreach(string s in data)
            {
                string[] arr = s.Split(',');
                if(arr.Length == 3)
                {
                    HocPhan hp = new HocPhan();
                    hp.MHP = arr[0];
                    hp.TenHP = arr[1];
                    if (arr[2] == "0")
                    {
                        hp.TH = false;
                    }
                    else
                    {
                        hp.TH = true;
                    }
                    list_hp.Add(hp);
                }
            }
            return list_hp;
        }   // Lấy danh sách học phần từ database
    }
}
