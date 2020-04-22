

using Infrastructure.Generic;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Infrastructure.EntityMode
{
  public abstract  class AbstractEntityIce
    {        
        /// <summary> 冰重量 </summary>
        public Dictionary<string, double> IceWeightList { get; set; }

        /// <summary>
        /// 覆冰重量kg 
        /// </summary>
        /// <param name="IceThickness">冰厚如5mm</param>
        /// <returns></returns>
        public double IceWeight(string IceThickness)
        {
            string s1 = null;
            var IceStringCompare = new IceStringCompare();
            foreach (var item in IceWeightList)
            {
                if (IceStringCompare.Compare(IceThickness, item.Key) == 0)
                    return item.Value;
                else if (IceStringCompare.Compare(IceThickness, item.Key) < 0)
                {
                    if (s1 == null) s1 = item.Key;
                    else if (IceStringCompare.Compare(s1, item.Key) > 0)
                        s1 = item.Key;
                }
            }
            if (s1 != null) return IceWeightList[s1];
            throw new Exception("覆冰厚度超出给定区域");
        }
    }
}
