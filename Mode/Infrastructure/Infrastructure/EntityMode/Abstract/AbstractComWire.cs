using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Infrastructure.EntityMode
{
    /// <summary>
    /// 可用于一般张力计算的抽象线类
    /// </summary>
 public   abstract class AbstractComWire:AbstractWire
    {
        /// <summary> 额定拉断力N  </summary>    
        [XmlElement("额定拉断力N")]
        public double RatedStrength { get; set; }
        /// <summary>  弹性系数N/mm^2 </summary>   
        [XmlElement("弹性系数N每mm2")]
        public double Elasticity { get; set; }
        /// <summary>  线膨胀系数1/℃  </summary>       
        [XmlElement("线膨胀系数每度")]
        public double LinearExpansivity { get; set; }
        [XmlElement("20度直流电阻ohm每公里")]
        public double? DCResistance { get; set; }
        /// <summary>
        /// 降温值请填小于零的
        /// </summary>
        [XmlElement("降温负值")]        
        public double? Creep { get; set; }
    }
}
