using Infrastructure.EntityMode;
using System;

namespace SDDQCore.WireMechanics
{
    public static class WireMechanic
  {
        private static WireAndWeather wireAndWeather;
        private static Weather controlWeather;
        private static Weather weather;
        private static double L;
        private static double Pc;
        private static double P;
        private static double Tc;
        /// <summary> 力学张力</summary>     
        public static double Tension(WireAndWeather wireAndWeather, Weather weather, double L)
        {
            var controlCondition = new ControlCondition(wireAndWeather);
            WireMechanic.wireAndWeather = wireAndWeather;
            WireMechanic.weather = weather;
            WireMechanic.L = L;
            controlWeather = controlCondition.ControlWeather(L);
            Tc = controlCondition.Tc(L);
            WireMechanic.Pc = new WireLoad(wireAndWeather.WireAndCoefficient.Conductor, controlWeather).P7;
            WireMechanic.P = new WireLoad(wireAndWeather.WireAndCoefficient.Conductor, weather).P7;
            if (weather == controlWeather) return Tc;
            else return MathNet.Numerics.RootFinding.RobustNewtonRaphson.FindRoot
                    (Fx, dFx, 2 * wireAndWeather.WireAndCoefficient.Conductor.RatedStrength, 1,accuracy:2);
        }
        ///<summary> 电气张力</summary>
        public static double TensionE(WireAndWeather wireAndWeather, Weather weather, double L)
        {
            var controlCondition = new ControlCondition(wireAndWeather);
            WireMechanic.wireAndWeather = wireAndWeather;
            WireMechanic.weather = weather;
            WireMechanic.L = L;
            controlWeather = controlCondition.ControlWeather(L);
            Tc = controlCondition.Tc(L);
            WireMechanic.Pc = new WireLoad(wireAndWeather.WireAndCoefficient.Conductor, controlWeather).P7;
            if (weather == wireAndWeather.WeatherGroup.MaxWind)
                WireMechanic.P = new WireLoadGroup(wireAndWeather).P6E_Maxwind;
            else if (weather == wireAndWeather.WeatherGroup.Lightning)
                WireMechanic.P = new WireLoadGroup(wireAndWeather).P6E_Maxwind;
            else if (weather == wireAndWeather.WeatherGroup.Operate)
                WireMechanic.P = new WireLoadGroup(wireAndWeather).P6E_Operate;
            else
                throw new Exception("电气气象有误");
            return MathNet.Numerics.RootFinding.RobustNewtonRaphson.FindRoot
                    (Fx, dFx, 2 * wireAndWeather.WireAndCoefficient.Conductor.RatedStrength, 1, 0.5);
        }        
       
        /// <summary> 电气弧垂</summary>    
        public static double SagE(WireAndWeather wireAndWeather, Weather weather, double L)
        {
            return 1;
        }
        /// <summary> 力学弧垂</summary>    
        public static double Sag(WireAndWeather wireAndWeather, Weather weather, double L)
        {
            return 1;
        }
        public static double K(WireAndWeather wireAndWeather, Weather weather, double L)
        {
            return 1;
        }
        /// <summary> 状态方程</summary>    
        private static double Fx(double T) 
        {
            var conductor = wireAndWeather.WireAndCoefficient.Conductor;
           var a=  ( Tc -  Pc * Pc * L * L * conductor.Elasticity * conductor.CalculateSection / (24 * Tc * Tc))
    +  conductor.LinearExpansivity * conductor.Elasticity * conductor.CalculateSection * (controlWeather.Temperature - weather.Temperature)
    - ( T - P * P * L * L * conductor.Elasticity * conductor.CalculateSection/(24 * T * T));
            return a;
        }
        private static double dFx(double T)
        {
            var conductor = wireAndWeather.WireAndCoefficient.Conductor;
             return -(1 + P * P * L * L * conductor.Elasticity * conductor.CalculateSection / (12* T* T* T));           
        }
    }
}
