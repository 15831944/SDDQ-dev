using Infrastructure.EntityMode;
using IOCommon;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDDQCore.AssemblyMode;
using System;
using System.Text;
using OTLTests;
using SDDQCore;
using Infrastructure.Enums;
using System.Windows.Media.Media3D;
using System.Collections.Generic;
using Test;

namespace OTLTests
{
    [TestClass()]
    public class XMLTest
    {
        /// <summary>
        /// 由ConsoleAppTest调用
        /// </summary>

        [TestMethod()]
        public static  void  OTLxml()
        {
             OTLTest.OTLSetting();
            var otl1 = OTL.OTLProject;
            var otl = new OTLProject
            {
                ADSSs = otl1.ADSSs,
                AntiDances = otl1.AntiDances,
                AntiVibrationHammers = otl1.AntiVibrationHammers,
                Conductors = otl1.Conductors,
                EarthWires = otl1.EarthWires,
                FeatureClearance = otl1.FeatureClearance,
                FeatureDistance = otl1.FeatureDistance,
                Features = otl1.Features,
                Fittingstrings = otl1.Fittingstrings,
                Foundations = otl1.Foundations,
                GroundDevices = otl1.GroundDevices,
                GroundDistance = otl1.GroundDistance,
                Hammers = otl1.Hammers,
                insulations = otl1.insulations,
                Insulators = otl1.Insulators,
                OPGWs = otl1.OPGWs,
                PhaseStrings = otl1.PhaseStrings,
                ProjectInfo = otl1.ProjectInfo,
                RiverDistance = otl1.RiverDistance,
                Sections = otl1.Sections,
                singleValue = otl1.singleValue,
                Spacers = otl1.Spacers,
                SpotCheckInfo = otl1.SpotCheckInfo,
                StringsDic = otl1.StringsDic,
                Terrain = otl1.Terrain,
                Towers = otl1.Towers,
                TowerGroup = otl1.TowerGroup,
TowersAttachPoint=otl1.TowersAttachPoint,
  WeatherGroups=otl1.WeatherGroups,
   WeatherAndWires=otl1.WeatherAndWires,
      
            };         
            Console.Out.Write(XmlHelper.XmlSerialize(otl, Encoding.UTF8));          
         XmlHelper.XmlSerializeToFile(otl, TestsCom.path+"otl.OTL", Encoding.UTF8);
            // Console.Out.Write(XmlHelper.XmlSerialize(person, Encoding.Default));

        }
    }


   
}
