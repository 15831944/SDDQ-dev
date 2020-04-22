using Infrastructure.Enums;
using SDDQCore.AssemblyMode;
using SDDQCore.AssemblyModel;
using SDDQCore.WireMechanics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace OTLApplication
{
  public static  class Mechanic
    {
        public static FlowDocument Report(WeatherGroup weatherGroup, List<(Voltage, WireAndCoefficient)> wireList)
        {
            var result = new FlowDocument();
            //写基本气象

            foreach (var wire in wireList)
            {
                //生成导线气象组
                var wireAndWeather = new WireAndWeather(wire.Item2, weatherGroup);
                //写导线规格

                //写风类气象条件
                var wireLoadGroup = new WireLoadGroup(wireAndWeather);
                //写荷载组
                var cs = new ControlCondition(wireAndWeather); 
                //写临界档距


            }


            return result;
        }


    }
}
