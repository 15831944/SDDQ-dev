using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityMode
{
    /// <summary>
    /// 水文
    /// </summary>
public struct Hydrology
    {

        public int starmileage;
        public int endmileage;
        /// <summary>5年一遇洪水位</summary>
        public double fiveyearflood;
        /// <summary>100年一遇洪水位</summary>
        public double centuryflood;
        /// <summary>通航水位</summary>
        public double? traffic;
        /// <summary>桅杆高</summary>
        public double? mast;
        /// <summary>冰面</summary>
        public double? icelevel;

    }
}
