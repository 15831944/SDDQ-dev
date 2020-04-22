using Infrastructure.EntityMode;
using Infrastructure.Interface;
using Standard.Interface;
using System;

namespace Standard
{
    /// <summary>
    /// 架空输电线路荷载规范DLT5551-2018
    /// </summary>
    public class DLT5551_2018: ILoadCode, ISetMaxWindCode  //需重写为单列模式
    {
        void ISetMaxWindCode.setMaxWindWeather(double z, MaxWind MaxWind)
        {
            MaxWind.WindSpeed = MaxWind.BasicWindSpeed*Math.Pow(z/10,0.15);
        }
        double ILoadCode.P4(AbstractWire conductor, Weather weather, LoadType loadType, double L)
        {
            double z;
            if (weather is MaxWind)
                z = 10*Math.Pow(weather.WindSpeed / weather.BasicWindSpeed,1/0.15);
            else z = 10;
            // return βc(z)*  this.α(weather.BasicWindSpeed) * weather.WindPress * this.μsc(conductor.Diameter, weather.IceThickness) * (conductor.Diameter + 2 * weather.IceThickness) * this.B1(weather.IceThickness);
            return 1;
        }

        /// <summary>
        /// 风荷载
        /// </summary>
        /// <returns></returns>
        public static double Wx(double βc,double αL, double Wz, double μsc,double d,double Lp,double B1)
        {
            return βc * αL * Wz * μsc * d * Lp * B1/1000;
        }

        /// <summary>
        ///阵风系数
        /// </summary>
        private double βc(double z) { return γc*(1+2* g* Iz(z)); }

        /// <summary>
        ///湍流强度
        /// </summary>
        public static double Iz(double z) { return I10() * Math.Pow(z / 10, -α()); }
        /// <summary>
        /// 档距折减系数（跳线）
        /// </summary>
        private double αL(LoadType loadType, εcVoltageType votageType, double z)
        {
          return (1 + 2 * g* εc(loadType, votageType) * Iz(z)* δL() ) / (1 + 5 * Iz(z));          
        }
        /// <summary>
        /// 档距折减系数（非跳线）
        /// </summary>
        private double αL(LoadType loadType, εcVoltageType votageType, double z, double Lp)
        {
            return (1 + 2 * g * εc(loadType, votageType) * Iz(z) * δL(Lx(),Lp)) / (1 + 5 * Iz(z));
        }
        public static double W0(double windspeed) { return 1; }
        /// <summary>
        /// 风压高度变化系数
        /// </summary>
        /// <param name="z"></param>
        /// <returns></returns>
        public static double μz(double z)
        {
            return Math.Pow(z / 10, 2*α());
        }
        /// <summary>
        /// 风速高度变化系数
        /// </summary>
        /// <param name="z"></param>
        /// <returns></returns>
        public static double μzSpeed(double z)
        {
            return Math.Pow(z/10, α());
        }

        /// <summary>
        /// 体型系数
        /// </summary>
        /// <param name="diameter">外径（mm）</param>
        /// <returns></returns>
        public static double μsc(double diameter)
        {
            if (diameter>=17)  
            {
                return 1;
            }
           else return 1.1;
        }

        /// <summary>
        /// 覆冰风荷载增大系数
        /// </summary>
        /// <param name="icethickness">冰厚（mm）</param>
        /// <returns></returns>
        public static double B1(double icethickness,LoadType loadType)
        {
            switch (loadType)
            {
                case LoadType.M:
                case LoadType.E: return 1;
                default:
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
            }
        }
        private  double γc=>0.9;
        private double g=> 2.5; 
        

        private static double I10() { return 0.14; }
        public static double α() { return 0.15; }


        public static double εc(LoadType loadType, εcVoltageType votageType)
        {
            if (loadType == LoadType.M) { return 0; }
            else if(loadType == LoadType.TL) { return 1; }
            else if(loadType == LoadType.ML)
            { 
                switch (votageType)
                    {
                      case εcVoltageType.A: return 0.5;
                      case εcVoltageType.B: return 0.8;
                      case εcVoltageType.C: return 0.85;
                      default: return 0.95;
                     }
             }
            else throw new Exception();
        }
        
        /// <summary>
        /// 档距因子（跳线用）
        /// </summary>
        /// <returns></returns>
        public static double δL() { return 1; }
        /// <summary>
        /// 档距因子（非跳线用）
        /// </summary>
        /// <param name="Lx"></param>
        /// <param name="Lp"></param>
        /// <returns></returns>
        public static double δL( double Lx, double Lp )
        {
           return Math.Sqrt(12 * Lx * Math.Pow(Lp, 3) + 54 * Math.Pow(Lx, 4) - 36 * Math.Pow(Lx, 3) * Lp - 72 * Math.Pow(Lx, 4) * Math.Exp(-Lp / Lx) + 18 * Math.Pow(Lx, 4) * Math.Exp(-2 * Lp / Lx)) / (3 * Lp * Lp);
        }
        public static double Lx() { return 50; }

        public static εcVoltageType ToεcVotageType(string Votage)
        {
            string s =String.Copy(Votage);
            s.Replace("±","");
            if (s == "大跨越") s = "1100";
            double votage = Double.Parse(s);
            if (votage <= 330) { return εcVoltageType.A; }
            else if (votage <= 750) { return εcVoltageType.B; }
            else if (votage <= 1000) { return εcVoltageType.C; }
            else return εcVoltageType.D;
        }


    }
}
