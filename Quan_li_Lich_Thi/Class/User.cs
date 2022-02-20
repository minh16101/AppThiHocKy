using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Quan_li_Lich_Thi.Class
{
    public enum User_Type
    {
        SINHVIEN,GIANGVIEN,GIAOVU
    }
    public class User
    {
        public string tai_khoan { get; set; }
        public string mat_khau { get; set; }
        public User_Type type { get; set; }
        public int Ma_So { get; set; }
      
        
        static public  List<User> Get_User()
        {
            List<User> list_user = new List<User>();
            string[] arr_user = File.ReadAllData(File.path_user);
            foreach(string s in arr_user)
            {
                string[] arr = s.Split(',');
                if(arr.Length == 4)
                {
                    User user = new User();
                    user.tai_khoan = arr[0];
                    user.mat_khau = arr[1];
                    int type = Convert.ToInt32(arr[2]);
                    if (type == 0)
                    {
                        user.type = User_Type.SINHVIEN;
                    }
                    else if(type==1)
                    {
                        user.type = User_Type.GIANGVIEN;
                    }
                    else
                    {
                        user.type = User_Type.GIAOVU;
                    }
                    user.Ma_So = Convert.ToInt32(arr[3]);
                    list_user.Add(user);
                }
            }
            return list_user;
        }
    }
}
