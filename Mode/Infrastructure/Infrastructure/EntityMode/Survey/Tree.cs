using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityMode
{
  public struct  Tree
    {
        /// <summary>
        /// 总里程
        /// </summary>
        public int starmileage;       
        public int endmileage;
        /// <summary>树种，树高</summary>
        public Dictionary<string,double> descrip;


    }
}
