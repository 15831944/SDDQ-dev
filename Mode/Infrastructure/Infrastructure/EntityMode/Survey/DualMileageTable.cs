using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityMode
{
 public   class DualMileageTable
    {
        /// <summary>双里程表：每一勘测段的局部起始里程，结束里程，通过算法形成双里程</summary>
        public List<(int StarMileage, int EndMileage)> Table { get; set; }
        /// <summary>总起始里程</summary>
        public int StarMileage { get; set; }
        /// <summary>第n段局部里程m得到总里程</summary>
        public int Mileage(int n,int m) 
        {         
            var tm = StarMileage;
            var i = 0;
            foreach (var item in Table)
            {
                i++;
                if (i < n)
                    tm += item.EndMileage - item.StarMileage;
                if (i == n)
                {
                    tm += m - item.StarMileage;
                    break;
                } 
            }
            return tm;
        }
    }
}
