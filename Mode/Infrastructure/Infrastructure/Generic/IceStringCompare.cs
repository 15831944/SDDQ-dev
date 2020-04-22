
using System;
using System.Collections.Generic;

namespace Infrastructure.Generic
{  
    public class IceStringCompare : IComparer<string>
    {
        public  int Compare(string x, string y)
        {
            if (x.EndsWith("mm") & y.EndsWith("mm"))
            {
                return double.Parse(x.TrimEnd('m')).CompareTo(double.Parse(y.TrimEnd('m')));
            }
            else
            {
                throw new Exception("IceString错误,正确格式如5mm");
            }
        }
    }
}
