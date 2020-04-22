using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.EntityMode;
using Infrastructure.Interface;
using Standard.Interface;
using Infrastructure.math;
namespace Standard
{
    /// <summary>
    /// 以GB50545_2010为抽象类的基础实现 
    /// </summary>
    public abstract class BasisCode : ILoadCode, IELoadCode, ISetEWeatherCode,ISetMaxWindCode
    {    
       double ILoadCode.P4(AbstractWire conductor, Weather weather, LoadType loadType, double L)
        {
            return this.α(weather.BasicWindSpeed) * weather.WindPress * this.μsc(conductor.Diameter, weather.IceThickness) * (conductor.Diameter + 2 * weather.IceThickness) * this.B1(weather.IceThickness);
        }
        double IELoadCode.P4(AbstractWire conductor, Weather weather, LoadType loadType, double L)
        {
            return this.αE(weather.BasicWindSpeed) * weather.WindPress * this.μsc(conductor.Diameter, weather.IceThickness) * (conductor.Diameter + 2 * weather.IceThickness) * this.B1(weather.IceThickness);
        }
        void ISetMaxWindCode.setMaxWindWeather(double z, MaxWind MaxWind)
        {
            MaxWind.WindSpeed = MaxWind.BasicWindSpeed * Wz(z);
        }
        void ISetEWeatherCode.SetRelatedWeather(double maxWindSpeed, RelatedWeather relatedWeather)
        {
            if (relatedWeather is Lightning)
            {
                if (maxWindSpeed >= 35)
                    relatedWeather.WindSpeed = 15;
                else relatedWeather.WindSpeed = 10;
            }
            else
            {
                relatedWeather.WindSpeed = maxWindSpeed / 2;
                if (relatedWeather.WindSpeed < 15)
                    relatedWeather.WindSpeed = 15;
            }

        }
        #region  可重写的私有函数
        #endregion
        /// <summary>
        /// 覆冰风荷载增大系数
        /// </summary>
        /// <param name="icethickness">冰厚（mm）</param>
        /// <returns></returns>
        protected virtual  double B1(double icethickness)
        {
            if (icethickness == 0) { return 1; }
            else if (icethickness <= 5) { return 1.1; }
            else if (icethickness <= 10) { return 1.2; }
            else if (icethickness <= 15) { return 1.3; }
            else if (icethickness <= 20) { return 1.5; }
            else if (icethickness <= 25) { return 1.7; }
            else if (icethickness <= 30) { return 1.8; }
            else if (icethickness <= 40) { return 1.9; }
            else { return 2; }
        }
        /// <summary>
        /// 体型系数
        /// </summary>
        /// <param name="diameter">外径（mm）</param>覆冰时μsc==1.2
        /// <returns></returns>
        protected virtual double μsc(double diameter, double icethickness)
        {
            if (icethickness != 0)
            {
                return 1.2;
            }
            else if (diameter >= 17)
            {
                return 1.1;
            }
            else { return 1.2; };
        }
        /// </summary> 力学用风压不均匀系数 </summary>
        protected virtual double α(double basicWindSpeed)
        {
            if (basicWindSpeed < 20) { return 1.0; }
            else if (basicWindSpeed < 27) { return 0.85; }
            else if (basicWindSpeed < 31.5) { return 0.75; }
            else { return 0.70; }
        }
        /// </summary> 电气用风压不均匀系数 </summary>
        protected virtual double αE(double basicWindSpeed)
        {
            if (basicWindSpeed < 20) { return 1.0; }
            else if (basicWindSpeed < 27) { return 0.75; }
            else { return 0.61; }
        }
        protected virtual double Wz(double z)
        {
            return Math.Pow(z / 10, 0.16);
        }      
    }

}

