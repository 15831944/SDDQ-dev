using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityMode

{
   /// <summary>
   /// 地质
   /// </summary>
 public   struct Geology
    {
        /// <summary>区间里程（起，止）</summary>
        public Tuple<double, double> Interval;
        /// <summary>基础类型</summary>
        public string FoundationType;

        public Geology(Tuple<double, double> interval, string foundationType)
        {
            Interval = interval ?? throw new ArgumentNullException(nameof(interval));
            FoundationType = foundationType ?? throw new ArgumentNullException(nameof(foundationType));
        }
    }
}
