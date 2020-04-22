using Infrastructure.EntityMode;
using SDDQCore.AssemblyModel;
using Standard.Interface;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace SDDQCore.WireMechanics
{
    public  class WireLoadGroup
    {
        private AbstractWire abstractWire;
        private WeatherGroup weatherGroup;
        private ILoadCode loadCode;
        private IELoadCode eLoadCode;
        public WireLoadGroup(WireAndWeather wireAndWeather, ILoadCode loadCode,IELoadCode eLoadCode)
        {
           abstractWire = wireAndWeather.WireAndCoefficient.Conductor;
           weatherGroup = wireAndWeather.WeatherGroup;
           this.loadCode = loadCode;
           this.eLoadCode = eLoadCode;
            SetP();
        }
        public WireLoadGroup(WireAndWeather wireAndWeather)
        {
            abstractWire = wireAndWeather.WireAndCoefficient.Conductor;
            weatherGroup = wireAndWeather.WeatherGroup;
            Assembly assembly = Assembly.LoadFrom("Standard.dll");
            var cType = assembly.GetType("Standard." + OTL.OTLProject.ProjectInfo.LoadCode);
            loadCode = (ILoadCode)Activator.CreateInstance(cType);
            cType = assembly.GetType("Standard." + OTL.OTLProject.ProjectInfo.ELoadCode);
            eLoadCode = (IELoadCode)Activator.CreateInstance(cType);
            SetP();
        }
        #region 只读属性 
        public double P1 { get; private set; }
        public double P2 { get; private set; }
        public List<double> OtherP2 { get; private set; }
        public double P3 { get; private set;  }
        public List<double> OtherP3 { get; private set; }
        public double P4L_Maxwind { get; private set; }
        public double P4E_Maxwind { get; private set; }
        public double P4E_Operate { get; private set; }
        public double P4E_Lightning { get; private set; }
        public List<double> OtherP4L { get; private set; }
        public double P5 { get; private set; }
        public double OtherP5 { get; private set; }
        public double P6L_Maxwind { get; private set; }
        public double P6E_Maxwind { get; private set; }
        public double P6E_Operate { get; private set; }
        public double P6E_Lightning { get; private set; }
        public List<double> OtherP6L { get; private set; }
        public double P7 { get; private set; }
        public double OtherP7 { get; private set; }
        #endregion

        private void SetP()
        {
           var wireLoad = new WireLoad(abstractWire, weatherGroup.Ice, loadCode);
            P1 = wireLoad.P1;
            P2 = wireLoad.P2;
            P3 = wireLoad.P3;
            P5 = wireLoad.P4;
            P7 = wireLoad.P7;
            wireLoad = new WireLoad(abstractWire, weatherGroup.MaxWind, loadCode);
            P4L_Maxwind = wireLoad.P4;
            P6L_Maxwind = wireLoad.P7;
            wireLoad = new WireLoad(abstractWire, weatherGroup.MaxWind, eLoadCode);
            P4E_Maxwind = wireLoad.P4;
            P6E_Maxwind = wireLoad.P7;
            wireLoad = new WireLoad(abstractWire, weatherGroup.Operate, eLoadCode);
            P4E_Operate = wireLoad.P4;
            P6E_Operate = wireLoad.P7;
            wireLoad = new WireLoad(abstractWire, weatherGroup.Lightning, eLoadCode);
            P4E_Lightning = wireLoad.P4;
            P6E_Lightning = wireLoad.P7;
            //  OtherP4L = otherP4L;
            // OtherP2 = otherP2;
            //  OtherP3 = otherP3;
            // OtherP5 = otherP5;
            //  OtherP6L = otherP6L;
            //  OtherP7 = otherP7;
        }
    }
}
