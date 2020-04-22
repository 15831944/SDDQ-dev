using Infrastructure.Interface;
using Infrastructure.math;
using System.Xml.Serialization;

namespace Infrastructure.EntityMode
{
    /// <summary> 气象条件 </summary>    
    public class Weather
    {
        /// <summary>  名称  </summary>       
        public string Name { get; set; }
        /// <summary>  气温℃   </summary>       
        public double Temperature { get; set; }
        /// <summary>  冰厚mm   </summary>      
        public double IceThickness { get; set; }
        /// <summary>  10m高基本风速 m/s   </summary>
        public virtual double BasicWindSpeed { get; set; }
        [XmlIgnore]
        /// <summary>  风速 m/s   </summary>
        public virtual double  WindSpeed{ get => this.BasicWindSpeed; set => this.BasicWindSpeed = value; }
    /// <summary>  基本风压 Pa   </summary>
        [XmlIgnore]
        public  double BassWindPress
        { get => UnitConvert.WindSpeedToPress(BasicWindSpeed); set => BasicWindSpeed = UnitConvert.WindPressToSpeed(value); }
        [XmlIgnore]
        /// <summary>  风压 Pa   </summary>        
        public virtual double WindPress { get => this.BassWindPress; set => WindSpeed = value; }

        public Weather Clone()
        {
            return (Weather)this.MemberwiseClone();
        }

    }

}
