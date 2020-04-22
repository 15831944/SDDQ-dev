using Infrastructure.EntityMode;
using SDDQCore.AssemblyMode;
using SDDQCore.AssemblyModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SDDQCore.WireMechanics
{
    /// <summary>
    /// 控制气象条件及档距
    /// </summary>
 public class ControlCondition
    {      
        private WireAndCoefficient wireAndCoefficient;
        private WeatherGroup weatherGroup;       
        public ControlCondition(WireAndWeather wireAndWeather)
        {          
            this.wireAndCoefficient = wireAndWeather.WireAndCoefficient;
            this.weatherGroup = wireAndWeather.WeatherGroup;
            WeatherAndControlspanList = new SortedList<double, Weather>();
            this.WeatherAndControlspanListSet();
        }
        public SortedList<double, Weather> WeatherAndControlspanList { get;private set; }
        private void  WeatherAndControlspanListSet()
        {
            double Lmin = 0.1;
            double Lmax = 9999.9;
            double Lup = Lmax;  //区间上限
            double Ldown = Lmin;//区间下限
            WeatherAndControlspanList.Add(Lmax, Control(Lmax));//把大档放入表单
            do
            {
                if (WeatherAndControlspanList.ContainsValue(Control(Lmin))) return;//如果最大和最小档距均为一个控制气象则返回
                else
                {
                    while ((Lup - Ldown) >= 0.1)//区间计算完成
                    {
                        if (WeatherAndControlspanList.ContainsValue(Control((Lup + Ldown) / 2)))//如果中间档距控制气象已在大档中则往更小档距找
                        {
                            Lup = (Lup + Ldown) / 2; //中间档距为区间上限，区间下限不动
                        }
                        else //否则往更大档距找
                        {
                            Ldown = (Lup + Ldown) / 2;//中间档距为区间下限，区间上限不动
                        }
                    }
                    WeatherAndControlspanList.Add(Ldown, Control(Ldown));//临界档距放入表单
                    Lup = Ldown;//在0-临界档距之间继续找
                    Ldown = Lmin;
                }
            } while (true);
        }
        public Weather ControlWeather(double L)
        {
            foreach (var item in WeatherAndControlspanList)
            {
                if (L<= item.Key)
                {
                    return item.Value;
                }                
            }
            throw new Exception("ControlWeather");
        }
        /// <summary>控制张力</summary>
        public double Tc(double L)
        {             
            if (ControlWeather(L) is AveTemperature) 
                return wireAndCoefficient.DesignTension * wireAndCoefficient.C;
           return wireAndCoefficient.DesignTension / wireAndCoefficient.F;
        }
        public static  double  Tc(WireAndWeather wireAndWeather, double L)
        {         
            return new ControlCondition(wireAndWeather).Tc(L);
        }
        /// <summary>某档控制气象条件及张力</summary>        
        public static (Weather, double) ControlWeatherAndTm(WireAndWeather wireAndWeather, double L)
        {
            var s = new ControlCondition(wireAndWeather);
            return (s.ControlWeather(L), s.Tc(L));
        }
        private Weather Control(double L) //返回档距下的控制气象条件
        {
           var FmWeatherPairs = new List<(double, Weather)>(4);
            
            FmWeatherPairs.Add((Fm(this.weatherGroup.MinTemperature, L), this.weatherGroup.MinTemperature));          
            FmWeatherPairs.Add((Fm(this.weatherGroup.AveTemperature, L), this.weatherGroup.AveTemperature));
            FmWeatherPairs.Add((Fm(this.weatherGroup.MaxWind, L), this.weatherGroup.MaxWind)); 
            FmWeatherPairs.Add((Fm(this.weatherGroup.Ice, L), this.weatherGroup.Ice));
            return FmWeatherPairs.OrderBy(s => s.Item1).Last().Item2;         
        }


        /// <summary>
        /// Fm判据
        /// </summary>
        /// <returns></returns>
        private double Fm(double E, double a, double P, double T, double A, double t, double L)
        { return ((E * Math.Pow(P, 2) * Math.Pow(L, 2) / (24 * Math.Pow(T, 2))) - T / A - a * E * t); }
        private double Fm(Weather weather,double L)
        {
            if (weather is AveTemperature)
                return Fm(wireAndCoefficient.Conductor.Elasticity, wireAndCoefficient.Conductor.LinearExpansivity, new WireLoad(wireAndCoefficient.Conductor, weather).P7, wireAndCoefficient.DesignTension * wireAndCoefficient.C, wireAndCoefficient.Conductor.CalculateSection, weather.Temperature, L);
            else return Fm(wireAndCoefficient.Conductor.Elasticity, wireAndCoefficient.Conductor.LinearExpansivity, new WireLoad(wireAndCoefficient.Conductor, weather).P7, wireAndCoefficient.DesignTension / wireAndCoefficient.F, wireAndCoefficient.Conductor.CalculateSection, weather.Temperature, L);
        }
    }
}
