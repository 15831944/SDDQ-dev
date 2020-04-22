using Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityMode
{
  public  class Insulator:AbstractEntityIce
    {
        public string TypeCode { get; set; }
        public double Length { get; set; }
        /// <summary>  荷载KN </summary>
        public double RatedLoad { get; set; }
        public double Weight { get; set; }
        /// <summary>  受风面积m2 </summary>
        public double WindArea { get; set; }
        public InsulatorType InsulatorType { get; set; }
        public double? DryDistance { get; set; }
        public double? CreepageDistance { get; set; }
    }

}
