using Infrastructure.EntityMode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standard.Interface
{
    /// <summary>
    /// 电气关联气象条件设置的规范
    /// </summary>
  public interface ISetEWeatherCode
    {
        /// <summary>
        /// 设置与大风关联的气象值
        /// </summary>
        /// <param name="Maxwind">导线平均高处风速</param>
        /// <param name="relatedWeather">需设置的关联气象</param>
        /// <returns></returns>
       void SetRelatedWeather(double maxWindSpeed, RelatedWeather relatedWeather);
    
    }
    /// <summary>
    /// 大风气象设置
    /// </summary>
    public interface ISetMaxWindCode
    {
        void setMaxWindWeather(double z, MaxWind MaxWind);
    }
}
