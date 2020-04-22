using SDDQCore.AssemblyMode;
using SDDQCore.AssemblyModel;
using Standard.Interface;
using System;
using System.Reflection;

namespace SDDQCore.WireMechanics
{
    public  class WireAndWeather
    {
        private ISetEWeatherCode setEWeatherCode;
        private ISetMaxWindCode setMaxWindCode;
        public WireAndWeather(WireAndCoefficient conductor, WeatherGroup weatherGroup, ISetEWeatherCode setEWeatherCode, ISetMaxWindCode setMaxWindCode)
        {
            WireAndCoefficient = conductor;
            WeatherGroup = weatherGroup.Clone();
            this.setMaxWindCode = setMaxWindCode;
            this.setEWeatherCode = setEWeatherCode;
            SetWindWeather();
        }
        /// <summary>
        /// 采用OTL默认规则
        /// </summary>
        /// <param name="conductor"></param>
        /// <param name="weatherGroup"></param>
        public WireAndWeather(WireAndCoefficient conductor, WeatherGroup weatherGroup)
        {
            WireAndCoefficient = conductor;
            WeatherGroup = weatherGroup.Clone();
            Assembly assembly = Assembly.LoadFrom("Standard.dll");
            var cType = assembly.GetType("Standard." + OTL.OTLProject.ProjectInfo.ELoadCode);
            setEWeatherCode = (ISetEWeatherCode)Activator.CreateInstance(cType);
             cType = assembly.GetType("Standard." + OTL.OTLProject.ProjectInfo.LoadCode);
            setMaxWindCode = (ISetMaxWindCode)Activator.CreateInstance(cType);
            SetWindWeather();
        }
        public WireAndCoefficient WireAndCoefficient { get;  }
    
        public WeatherGroup WeatherGroup { get;  }

        private void SetWindWeather() 
        {
            setMaxWindCode.setMaxWindWeather(WireAndCoefficient.z, WeatherGroup.MaxWind);
            setEWeatherCode.SetRelatedWeather(WeatherGroup.MaxWind.WindSpeed, WeatherGroup.Lightning);
            setEWeatherCode.SetRelatedWeather(WeatherGroup.MaxWind.WindSpeed, WeatherGroup.Operate);
        }

    }
}
