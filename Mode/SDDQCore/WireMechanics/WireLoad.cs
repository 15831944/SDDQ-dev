using Infrastructure.EntityMode;
using Standard;
using Standard.Interface;
using System;
using System.Reflection;

namespace SDDQCore.WireMechanics
{
    public class WireLoad
        {
        public WireLoad(AbstractWire conductor, Weather weather,  ILoadCode wireLoadCode,LoadType loadType=LoadType.M, double g=9.80665, double iceDensity=0.9, double Lp=100)
        {
            SetP1P2(conductor, weather, g, iceDensity);
            this.P4 = wireLoadCode.P4(conductor, weather, loadType, Lp);
        }
        /// <summary>
        /// 采用OTL中的标准生成荷载力学计算用P值
        /// </summary>
       
        public WireLoad(AbstractWire conductor, Weather weather, LoadType loadType = LoadType.M, double g = 9.80665, double iceDensity = 0.9, double Lp = 100)
        {
            Assembly assembly = Assembly.LoadFrom("Standard.dll");
            var cType = assembly.GetType("Standard." + OTL.OTLProject.ProjectInfo.LoadCode);
           var loadCode = (ILoadCode)Activator.CreateInstance(cType);          
            SetP1P2(conductor, weather, g, iceDensity);
            this.P4 = loadCode.P4(conductor, weather, loadType, Lp);
        }
        public WireLoad(AbstractWire conductor, Weather weather, IELoadCode eLoadCode, LoadType loadType = LoadType.E, double g = 9.80665, double iceDensity = 0.9, double Lp = 100)
        {
            SetP1P2(conductor, weather, g, iceDensity);
            this.P4 = eLoadCode.P4(conductor, weather, loadType, Lp);
        }
        public double P1 { get; private set; }
        public double P2 { get; private set; }
        public double P3 => P1 + P2;
        public double P4 { get; }
        public double P7 => Math.Sqrt( P3* P3 + P4 * P4);
        private void SetP1P2(AbstractWire conductor, Weather weather, double g,double iceDensity)
        {
            P1 = g * conductor.Quality;
            P2 = g * iceDensity * Math.PI * weather.IceThickness * (weather.IceThickness + conductor.Diameter) / 1000;
        }

    }
}
