using System;
using System.Xml.Serialization;

namespace Infrastructure.EntityMode
{

    /// <summary>
    /// 导线类(用于一般张力计算)
    /// </summary>
  //  [XmlType("导线")]
    public class Conductor : AbstractWire
    {
        /// <summary> 额定拉断力N  </summary>    
       // [XmlElement(@"额定拉断力N")]
        public double RatedStrength { get; set; }
        /// <summary>  弹性系数N/mm^2 </summary>   
      //  [XmlElement(@"弹性系数Npermm2")] //序列化时名称不能含/ " " ^
        public double Elasticity { get; set; }
        /// <summary>  线膨胀系数1/℃  </summary>       
       // [XmlElement(@"线膨胀系数1per度")]
        public double LinearExpansivity { get; set; }
     //   [XmlElement(@"20度直流电阻ohmperkm")]
        public double? DCResistance { get; set; }
      //  [XmlElement(@"降温值(负)")]
        public double? Creep { get; set; }
    }
    
}
