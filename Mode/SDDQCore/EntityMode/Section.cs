using Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDDQCore.EntityMode
{
    public class Section
    {
        List<(Voltage, double)> K { get; set; }
        /// <summary>耐张段长 </summary>
        double L { get; set; }
        /// <summary>代表档距 </summary>
        double Lr { get; set; }
        /// <summary>放松系数 </summary>
        List<(Voltage, double)> Kf { get; set; }
        public List<Span> Spans { get; set; }
    }
}
