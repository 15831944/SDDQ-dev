using Microsoft.VisualStudio.TestTools.UnitTesting;
using OTLTests;
using SDDQCore;
using SDDQCore.WireMechanics;
using System.Collections.Generic;


namespace OTLTests
{
    [TestClass()]
    public class WireMechanicTests
    {
        [TestMethod()]
        public void WireLoadTest()
        {
            OTLTest.OTLSetting();
            var otl = OTL.OTLProject;
            List<(string, WireLoadGroup)> wireLoadGroups=new List<(string, WireLoadGroup)>();
            foreach (var item in otl.WeatherAndWires)
                foreach (var s in item.Item4)
                {
                    var wireAndWeather = new WireAndWeather(s.Item2,otl.WeatherGroups[item.Item3]);
                    var wireLoadGroup = new WireLoadGroup(wireAndWeather);//荷载组
                    wireLoadGroups.Add((s.Item2.Conductor.Name, wireLoadGroup));
                    var cs = new ControlCondition(wireAndWeather); //控制档距
                    var T = WireMechanic.Tension(wireAndWeather, wireAndWeather.WeatherGroup.MaxTemperature, 500);
                }
     
        }
    }
}