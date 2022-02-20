using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Quan_li_Lich_Thi.Class
{
    public class File
    {
        public static string path_user = @"C:\Users\admin\OneDrive\Desktop\database ảo\User.txt";
        public static string path_sinhvien = @"C:\Users\admin\OneDrive\Desktop\database ảo\SinhVien.txt";
        public static string path_giangvien = @"C:\Users\admin\OneDrive\Desktop\database ảo\GiangVien.txt";
        public static string path_lophoc = @"C:\Users\admin\OneDrive\Desktop\database ảo\LopHoc.txt";
        public static string path_lopthi = @"C:\Users\admin\OneDrive\Desktop\database ảo\lopthi.txt";
        public static string path_hocphan = @"C:\Users\admin\OneDrive\Desktop\database ảo\HocPhan.txt";
        public static string path_giangviencoithi = @"C:\Users\admin\OneDrive\Desktop\database ảo\GiangVienCoiThi.txt";
        public static string path_sinhvienlop = @"C:\Users\admin\OneDrive\Desktop\database ảo\SinhVienLop.txt";
        static public string[] ReadAllData(string path)
        {
            System.IO.FileStream fs = new System.IO.FileStream(path, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.None);
            StreamReader sr = new StreamReader(fs);
            string data = sr.ReadToEnd();
            sr.Close();
            fs.Close();
            return data.Split('\n');

        }
        static public void Clear_File(string path)
        {
            System.IO.File.WriteAllText(path,"");
        }
        static public void WriteData(string path, string data)
        {
            System.IO.FileStream fs = new System.IO.FileStream(path, System.IO.FileMode.Append, System.IO.FileAccess.Write, System.IO.FileShare.None);
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(data);
            sw.Close();
            fs.Close();
        }

        static public void WriteLineData(string path,string data)
        {
            System.IO.FileStream fs = new System.IO.FileStream(path, System.IO.FileMode.Append, System.IO.FileAccess.Write, System.IO.FileShare.None);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(data);
            sw.Close();
            fs.Close();
        }

        static public void Delete_Row(string path, string delete_row)
        {
            string[] data = ReadAllData(path);
            Clear_File(path);
            foreach(string s in data)
            {
                if (s != delete_row)
                {
                    WriteLineData(path, s);
                }
            }
        }

        static public bool Delete_By_MaSo(string path,string Ma_So)
        {
            bool result = false;
            string[] data = ReadAllData(path);
            foreach(string s in data)
            {
                string[] arr_data = s.Split(',');
                if(arr_data[0] != Ma_So)
                {
                    WriteLineData(path, s);
                }
                else
                {
                    result = true;
                }
            }
            return result;
        }

        static public bool Add_Row(string path, string row_add)
        {
            if (Row_Exist(path, row_add) == false)
            {
                WriteLineData(path, row_add);
                return true;
            }
            else
            {
                return false;
            }
        }

        static public bool Row_Exist(string path, string row) {
            string[] data = ReadAllData(path);
            foreach(string s in data)
            {
                if(s == row)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
