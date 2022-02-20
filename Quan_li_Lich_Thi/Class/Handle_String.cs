using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_li_Lich_Thi.Class
{
    public class Handle_String
    {
        static public bool IsNumber(string s)
        {
            foreach(char c in s)
            {
                if((int)c<48 || (int)c > 57)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
