using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityMode
{
 public  class Fitting : AbstractEntityIce
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        /// <summary>  受风面积m2 </summary>
        public double WindArea { get; set; }
    }
}
