using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Infrastructure.EntityMode
{
    /// <summary>
    /// 可用于荷载计算的抽象线类,所有导线的基类
    /// </summary>
  public  abstract class AbstractWire
    {
        /// <summary>  名称   </summary>  
      //  [XmlElement("来源")]
        public string Source { get; set; }

        /// <summary>  名称   </summary>  
      //  [XmlElement("型号")]
        public string Name { get; set; }
        /// <summary>  计算截面mm^2  </summary>    
     //   [XmlElement("截面mm2")]
        public double CalculateSection { get; set; }
        /// <summary> 外径mm  </summary>   
      //  [XmlElement("外径mm")]
        public double Diameter { get; set; }
        /// <summary>  单位质量kg/m </summary>  
      //  [XmlElement("单位质量kg每m")]
        public double Quality { get; set; }
       

     //   [XmlElement("锁定")]
        public bool locked { get; set; }

    }
}
