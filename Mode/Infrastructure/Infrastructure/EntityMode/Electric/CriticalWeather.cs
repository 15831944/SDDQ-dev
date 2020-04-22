using Infrastructure.Interface;
using Infrastructure.math;
using System.Xml.Serialization;

namespace Infrastructure.EntityMode
{

    /// <summary>平均温 </summary>    
    public class AveTemperature : Weather
    {    
    }
    /// <summary>最大风 </summary>    
    public class MaxWind : Weather
    {
        [XmlIgnore]
        /// <summary>导线平均高风速</summary>       
        public override double WindSpeed { get; set; }
        [XmlIgnore]
        /// <summary>导线平均高风压</summary>       
        public override double WindPress
        { get => UnitConvert.WindSpeedToPress(WindSpeed); set =>  WindSpeed = UnitConvert.WindPressToSpeed(value); }
    }
    /// <summary>   
        /// 与导线平均高风速关联的气象，风速不序列化（由导线平均高风速和规则确定）
        /// </summary>
    public class RelatedWeather : Weather
        {
            [XmlIgnore]
            public override double BasicWindSpeed { get; set; }
        }
    public class Operate : RelatedWeather { }
    public class Lightning : RelatedWeather { }

}
