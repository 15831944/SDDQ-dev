using Infrastructure.Enums;
using SDDQCore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDDQCore.EntityMode
{
    /// <summary>
    /// K值类
    /// </summary>
    public class K
    {
        public K() { }
        public Voltage Voltage { get; set; }
        public string WireName { get; set; }
      //  public Ktype Ktype { get; set; }
        public Double value { get; set; }
    }

}
