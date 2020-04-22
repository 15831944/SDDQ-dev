using Infrastructure.EntityMode;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace SDDQCore.AssemblyModel
{
    [XmlType("气象组")]
    public class WeatherGroup
    {
      
        public WeatherGroup()
        {
        }

        public WeatherGroup(string Name)
        {
            this.Name = Name;
        }

        /// <summary> 名称 </summary>       
        public string Name { get; set; }  
        public Weather MinTemperature { get; set; }
        public Weather Ice { get; set; }
        public MaxWind MaxWind { get; set; }
        public Weather MaxTemperature { get; set; }
        public AveTemperature AveTemperature { get; set; }
        public Operate Operate { get; set; }
        public Lightning Lightning { get; set; }
        public Weather Install { get; set; }
      /// <summary>
      /// 外过无风
      /// </summary>
        [XmlIgnore]        
        public Weather LightningWithoutWind
        { get
            {
                if (myLightningWithoutWind==null)
                {
                    myLightningWithoutWind = Lightning.Clone();
                    myLightningWithoutWind.Name += "(无风)";
                    myLightningWithoutWind.BasicWindSpeed = 0;                  
                }             
                return myLightningWithoutWind;
            }
        }
        [XmlElement("其他气象条件")]
        public List<Weather> OtherWeatherList { get; set; }

        /// <summary>
        /// 荷载气象条件列表
        /// </summary>
        /// <returns></returns>
        public List<Weather> LWeatherList()
        {
            if (myWeatherList==null)
            {
                myWeatherList = new List<Weather>() 
                    { MinTemperature,AveTemperature,MaxWind,Ice, MaxTemperature,Install,LightningWithoutWind};
                if (OtherWeatherList !=null)
                    myWeatherList.AddRange(OtherWeatherList);
            }           
            return myWeatherList;              
        }
        /// <summary>
        /// 电气气象条件列表
        /// </summary>
        /// <returns></returns>
        public List<Weather> EWeatherList()
        {
            if (myEWeatherList == null)
                myEWeatherList = new List<Weather>() { MaxWind, Operate, Lightning };           
            return myEWeatherList;
        }
        public WeatherGroup Clone()
        {
          var result= (WeatherGroup)this.MemberwiseClone();
            result.MaxWind = (MaxWind)this.MaxWind.Clone();
            result.Lightning = (Lightning)this.Lightning.Clone();
            result.Operate= (Operate)this.Operate.Clone();
            return result;

        }

        private List<Weather> myWeatherList { get; set; }
        private List<Weather> myEWeatherList { get; set; }
        private Weather myLightningWithoutWind { get; set; }
    }
}
