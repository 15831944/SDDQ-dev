using Infrastructure.AssemblyModel;
using Infrastructure.EntityMode;
using Infrastructure.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDDQCore;
using SDDQCore.AssemblyMode;
using SDDQCore.AssemblyModel;
using SDDQCore.Enums;
using Standard;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Media.Media3D;
using Test;
using SDDQCore.EntityMode;

namespace OTLTests
{
    [TestClass()]
    public class OTLTest
    {
        [TestMethod()]
        public static void OTLSetting()
        {
            var otl = OTL.OTLProject = new OTLProject
            {
                ProjectInfo = new ProjectInfo
                {
                    Name = "500kV，220kV同塔四回路工程",
                    g = 9.80665,
                    Voltages = new SortedSet<Voltage> { Voltage.G, Voltage.AC500kV, Voltage.AC220kV },
                    WindInputType = WindInputType.Speed,
                    EarthWireMechanicalType = EarthWireMechanicalType.Match,
                    IceDensity = 0.9,
                    ELoadCode = GB50545_2010.classname,
                    LoadCode = GB50545_2010.classname,
                },
                singleValue = new SingleValue
                {
                    FittingValue = 16000,
                    insulatorValue = new Dictionary<string, double>
                    { { @"U300BP", 300 },
                        { @"U420BP", 400 },
                        { @"FXB4-500/300", 2000 },
                        { @"FXB4-500/400", 3000 },

                    },
                    TowerValue = 11000,
                    FoundationValue = new Dictionary<string, double>
                    { { @"挖孔基础", 300 },
                        { @"灌注桩基础", 1100 },
                        { @"601", 300 },
                    },
                },
                WeatherGroups = new Dictionary<string, WeatherGroup>
                {
                    { @"气象一", new WeatherGroup(@"气象一")
                    {
                        MinTemperature = new Weather
                        {
                            Name = "最低气温",
                            Temperature = -10,
                            BasicWindSpeed = 0,
                            IceThickness = 0
                        },
                        Ice = new Weather
                        {
                            Name = "覆冰",
                            Temperature = -5,
                            BasicWindSpeed = 10,
                            IceThickness = 10
                        },
                        AveTemperature = new AveTemperature
                        {
                            Name = "平均气温",
                            Temperature = 15,
                            BasicWindSpeed = 0,
                            IceThickness = 0
                        },
                        MaxWind = new MaxWind
                        {
                            Name = "基本风速",
                            Temperature = 10,
                            BasicWindSpeed = 27,
                            IceThickness = 0
                        },
                        MaxTemperature = new Weather
                        {
                            Name = "最高气温",
                            Temperature = 40,
                            BasicWindSpeed = 0,
                            IceThickness = 0
                        },
                        Install = new Weather
                        {
                            Name = "安装",
                            Temperature = -5,
                            BasicWindSpeed = 10,
                            IceThickness = 0
                        },
                        Lightning = new Lightning
                        {
                            Name = "外过电压",
                            Temperature = 15,
                            IceThickness = 0
                        },
                        Operate = new Operate
                        {
                            Name = "内过电压",
                            Temperature = 15,
                            IceThickness = 0
                        },
                    }
                    },
                },
                Conductors = new Dictionary<string, Conductor>
                {
                    { @"JL/G1A-630/45", new Conductor
                    { Name = @"JL/G1A-630/45",
                        CalculateSection = 674,
                        Diameter = 33.8,
                        Quality = 2.0792,
                        RatedStrength = 150450,
                        Elasticity = 63000,
                        LinearExpansivity = 2.09E-5,
                    } },
                    { @"JL/G1A-400/35", new Conductor
                    { Name = @"JL/G1A-400/35",
                        CalculateSection = 674,
                        Diameter = 33.8,
                        Quality = 2.0792,
                        RatedStrength = 150450,
                        Elasticity = 63000,
                        LinearExpansivity = 2.09E-5
                    } },
                },
                EarthWires = new Dictionary<string, Conductor>
                {
                    { @"LBGJ-100", new Conductor
                    { Name = @"LBGJ-100",
                        CalculateSection = 105,
                        Diameter = 33.8,
                        Quality = 0.7,
                        RatedStrength = 150450,
                        Elasticity = 63000,
                        LinearExpansivity = 2.09E-5,
                    } },
                },
                OPGWs = new Dictionary<string, OPGW>
                {
                    { @"OPGW-100", new OPGW
                    { Name = @"OPGW-100",
                        OpticalFiber = 24,
                        FiberType = @"G.655",
                        HeatCapacity = 150,
                        CalculateSection = 105,
                        Diameter = 33.8,
                        Quality = 0.7,
                        RatedStrength = 150450,
                        Elasticity = 63000,
                        LinearExpansivity = 2.09E-5,
                    } },
                },
                Spacers = new Dictionary<string, Fitting>
                {
                    { @"FJZD-445/34B", new Fitting { Name = @"FJZD-445/34B", Weight = 10 } },
                    { @"FJZ-240/28A", new Fitting { Name = @"FJZ-240/28A", Weight = 4 } }
                },
                Hammers = new Dictionary<string, Fitting>
                {
                    { @"FZC-20", new Fitting { Name = @"FZC-20", Weight = 20 } },
                },
                AntiVibrationHammers = new Dictionary<string, Fitting>
                {
                    { @"FRY-4/6", new Fitting { Name = @"FRY-4/6", Weight = 7.5 } },
                    { @"FRY-1/2", new Fitting { Name = @"FRY-1/2", Weight = 2.8 } },
                    { @"FRY-2/3", new Fitting { Name = @"FRY-2/3", Weight = 5.0 } }
                },
                AntiDances = new Dictionary<string, Fitting>
                {

                    { @"SB-500", new Fitting { Name = @"SB-500", Weight = 50 } },
                },
                PhaseStrings = new Dictionary<string, Strings>(),
                GroundDevices = new Dictionary<string, GroundDevice>
                {
                    { @"TM-30", new GroundDevice { Name = @"TM-30" } },

                },
                Features = new Dictionary<int, FeatureType>
                 {
                    {200,FeatureType.Tree },{220,FeatureType.House },{116,FeatureType.PrimaryCL },{120,FeatureType.SecondaryCL },
                    {159,FeatureType.Highrail },{161,FeatureType.ERail },{160,FeatureType.Rail},{162,FeatureType.StandardGuage},
                    {163,FeatureType.NarrowGuage},{149,FeatureType.highway },{151,FeatureType.PrimaryRoad},{150,FeatureType.Road },
                    {156,FeatureType.Trail },{100,FeatureType.TL },{95,FeatureType.TowerHead },{94,FeatureType.TLabove220 },
                    {96,FeatureType.ImportantTL },{101,FeatureType.LowTL },{305,FeatureType.PrimaryRiver },{306,FeatureType.SecondaryRiver },
                    {304,FeatureType.NavigeRriver },{300,FeatureType.River },{310,FeatureType.SpecialPipe },{180,FeatureType.RopeWay },{157,FeatureType.TramsandTrolleysWay },
                    {502,FeatureType.ResidentialArea },{503,FeatureType.DifficultTrafficArea },{504,FeatureType.HillsideWithinWalkingdistance },{505,FeatureType.HillsideWithoutWalkingdistance },
                    {901,FeatureType.CornerPile }, {405,FeatureType.WindPoint },  { 0, FeatureType.Ground },{ 105, FeatureType.TL},{ 107, FeatureType.TL},{ 115, FeatureType.LowTL},
            },
                Foundations = new Dictionary<string, List<Foundation>>(),
                StringsDic = new Dictionary<int, Dictionary<string, Strings>>
                {
                    { 1, new Dictionary<string, Strings>() },
                    { 2, new Dictionary<string, Strings>() },
                },
                TowersAttachPoint = new Dictionary<string, Dictionary<string, AttachmentPoint3D>>
                 {
                     /// <summary>5/2H2-SSZ1型塔500kV"V串"三个导线挂点（右侧）</summary>
                     { @"5E1-Z1",new  Dictionary<string, AttachmentPoint3D>
                     {
                         { "#3",new  VAttachmentPoint3D { Voltage = Voltage.AC500kV, Type =  AttachmentType.V, Points= new List<Point3D>{ new Point3D { X=1.5, Y=-4.5, Z=0.0},new Point3D { X=12.567, Y=-4.5, Z=0.0} },Vangle=95} },
                         {"#4",new  VAttachmentPoint3D { Voltage = Voltage.AC500kV, Type =  AttachmentType.V, Points= new List<Point3D>{ new Point3D { X=4.01, Y=-17.4, Z=0.0},new Point3D {X =15.01,Y =-17.4, Z =0.0} },Vangle=95} },
                         { "#5",new  VAttachmentPoint3D { Voltage = Voltage.AC500kV, Type =  AttachmentType.V, Points= new List<Point3D>{ new Point3D { X=2.26, Y=-29.2, Z=0.0},new Point3D {X =13.26,Y = -29.2, Z =0.0} },Vangle=95} },
                         { "#6", new  VAttachmentPoint3D { Voltage = Voltage.AC220kV, Type =  AttachmentType.V, Points= new List<Point3D>{ new Point3D { X=3.221, Y=-42.1, Z=0.0},new Point3D { X =8.848,Y =-42.1, Z =0.0} },Vangle=90} },
                         { "#7",new  VAttachmentPoint3D { Voltage = Voltage.AC220kV, Type =  AttachmentType.V, Points= new List<Point3D>{ new Point3D { X=9.848, Y=-42.1, Z=0.0},new Point3D {X =15.475,Y =-42.1, Z =0.0} },Vangle=90} },
                         { "#8" ,new  VAttachmentPoint3D { Voltage = Voltage.AC220kV, Type =  AttachmentType.V, Points= new List<Point3D>{ new Point3D { X=4.221, Y=-50, Z=0.0},new Point3D {X =9.848,Y = -50, Z =0.0} },Vangle=90} },
                         { "#1",new  IAttachmentPoint3D { Voltage = Voltage.G, Type =  AttachmentType.GX, Points= new List<Point3D>{ new Point3D { X=12, Y=0, Z=0.0}}} },
                        { "#2", new  IAttachmentPoint3D { Voltage = Voltage.G, Type =  AttachmentType.GX, Points= new List<Point3D>{ new Point3D { X=-12, Y=0, Z=0.0}}} },
                     } },
                     { @"5E1-Z2",new  Dictionary<string, AttachmentPoint3D>
                     {
                         { "#3",new  VAttachmentPoint3D { Voltage = Voltage.AC500kV, Type =  AttachmentType.V, Points= new List<Point3D>{ new Point3D { X=1.5, Y=-4.5, Z=0.0},new Point3D { X=12.567, Y=-4.5, Z=0.0} },Vangle=95} },
                         {"#4",new  VAttachmentPoint3D { Voltage = Voltage.AC500kV, Type =  AttachmentType.V, Points= new List<Point3D>{ new Point3D { X=4.01, Y=-17.4, Z=0.0},new Point3D {X =15.01,Y =-17.4, Z =0.0} },Vangle=95} },
                         { "#5",new  VAttachmentPoint3D { Voltage = Voltage.AC500kV, Type =  AttachmentType.V, Points= new List<Point3D>{ new Point3D { X=2.26, Y=-29.2, Z=0.0},new Point3D {X =13.26,Y = -29.2, Z =0.0} },Vangle=95} },
                         { "#6", new  VAttachmentPoint3D { Voltage = Voltage.AC220kV, Type =  AttachmentType.V, Points= new List<Point3D>{ new Point3D { X=3.221, Y=-42.1, Z=0.0},new Point3D { X =8.848,Y =-42.1, Z =0.0} },Vangle=90} },
                         { "#7",new  VAttachmentPoint3D { Voltage = Voltage.AC220kV, Type =  AttachmentType.V, Points= new List<Point3D>{ new Point3D { X=9.848, Y=-42.1, Z=0.0},new Point3D {X =15.475,Y =-42.1, Z =0.0} },Vangle=90} },
                         { "#8" ,new  VAttachmentPoint3D { Voltage = Voltage.AC220kV, Type =  AttachmentType.V, Points= new List<Point3D>{ new Point3D { X=4.221, Y=-50, Z=0.0},new Point3D {X =9.848,Y = -50, Z =0.0} },Vangle=90} },
                         { "#1",new  IAttachmentPoint3D { Voltage = Voltage.G, Type =  AttachmentType.GX, Points= new List<Point3D>{ new Point3D { X=12, Y=0, Z=0.0}}} },
                        { "#2", new  IAttachmentPoint3D { Voltage = Voltage.G, Type =  AttachmentType.GX, Points= new List<Point3D>{ new Point3D { X=-12, Y=0, Z=0.0}}} },
                     } },
                     { @"5E1-Z3",new  Dictionary<string, AttachmentPoint3D>
                     {
                         { "#3",new  VAttachmentPoint3D { Voltage = Voltage.AC500kV, Type =  AttachmentType.V, Points= new List<Point3D>{ new Point3D { X=1.5, Y=-4.5, Z=0.0},new Point3D { X=12.567, Y=-4.5, Z=0.0} },Vangle=95} },
                         {"#4",new  VAttachmentPoint3D { Voltage = Voltage.AC500kV, Type =  AttachmentType.V, Points= new List<Point3D>{ new Point3D { X=4.01, Y=-17.4, Z=0.0},new Point3D {X =15.01,Y =-17.4, Z =0.0} },Vangle=95} },
                         { "#5",new  VAttachmentPoint3D { Voltage = Voltage.AC500kV, Type =  AttachmentType.V, Points= new List<Point3D>{ new Point3D { X=2.26, Y=-29.2, Z=0.0},new Point3D {X =13.26,Y = -29.2, Z =0.0} },Vangle=95} },
                         { "#6", new  VAttachmentPoint3D { Voltage = Voltage.AC220kV, Type =  AttachmentType.V, Points= new List<Point3D>{ new Point3D { X=3.221, Y=-42.1, Z=0.0},new Point3D { X =8.848,Y =-42.1, Z =0.0} },Vangle=90} },
                         { "#7",new  VAttachmentPoint3D { Voltage = Voltage.AC220kV, Type =  AttachmentType.V, Points= new List<Point3D>{ new Point3D { X=9.848, Y=-42.1, Z=0.0},new Point3D {X =15.475,Y =-42.1, Z =0.0} },Vangle=90} },
                         { "#8" ,new  VAttachmentPoint3D { Voltage = Voltage.AC220kV, Type =  AttachmentType.V, Points= new List<Point3D>{ new Point3D { X=4.221, Y=-50, Z=0.0},new Point3D {X =9.848,Y = -50, Z =0.0} },Vangle=90} },
                         { "#1",new  IAttachmentPoint3D { Voltage = Voltage.G, Type =  AttachmentType.GX, Points= new List<Point3D>{ new Point3D { X=12, Y=0, Z=0.0}}} },
                        { "#2", new  IAttachmentPoint3D { Voltage = Voltage.G, Type =  AttachmentType.GX, Points= new List<Point3D>{ new Point3D { X=-12, Y=0, Z=0.0}}} },
                     } },
                     { @"5E1-Z4",new  Dictionary<string, AttachmentPoint3D>
                     {
                         { "#3",new  VAttachmentPoint3D { Voltage = Voltage.AC500kV, Type =  AttachmentType.V, Points= new List<Point3D>{ new Point3D { X=1.5, Y=-4.5, Z=0.0},new Point3D { X=12.567, Y=-4.5, Z=0.0} },Vangle=95} },
                         {"#4",new  VAttachmentPoint3D { Voltage = Voltage.AC500kV, Type =  AttachmentType.V, Points= new List<Point3D>{ new Point3D { X=4.01, Y=-17.4, Z=0.0},new Point3D {X =15.01,Y =-17.4, Z =0.0} },Vangle=95} },
                         { "#5",new  VAttachmentPoint3D { Voltage = Voltage.AC500kV, Type =  AttachmentType.V, Points= new List<Point3D>{ new Point3D { X=2.26, Y=-29.2, Z=0.0},new Point3D {X =13.26,Y = -29.2, Z =0.0} },Vangle=95} },
                         { "#6", new  VAttachmentPoint3D { Voltage = Voltage.AC220kV, Type =  AttachmentType.V, Points= new List<Point3D>{ new Point3D { X=3.221, Y=-42.1, Z=0.0},new Point3D { X =8.848,Y =-42.1, Z =0.0} },Vangle=90} },
                         { "#7",new  VAttachmentPoint3D { Voltage = Voltage.AC220kV, Type =  AttachmentType.V, Points= new List<Point3D>{ new Point3D { X=9.848, Y=-42.1, Z=0.0},new Point3D {X =15.475,Y =-42.1, Z =0.0} },Vangle=90} },
                         { "#8" ,new  VAttachmentPoint3D { Voltage = Voltage.AC220kV, Type =  AttachmentType.V, Points= new List<Point3D>{ new Point3D { X=4.221, Y=-50, Z=0.0},new Point3D {X =9.848,Y = -50, Z =0.0} },Vangle=90} },
                         { "#1",new  IAttachmentPoint3D { Voltage = Voltage.G, Type =  AttachmentType.GX, Points= new List<Point3D>{ new Point3D { X=12, Y=0, Z=0.0}}} },
                        { "#2", new  IAttachmentPoint3D { Voltage = Voltage.G, Type =  AttachmentType.GX, Points= new List<Point3D>{ new Point3D { X=-12, Y=0, Z=0.0}}} },
                     } },
                     { @"5E1-J1",new   Dictionary<string, AttachmentPoint3D>
                     {   /// <summary>导线耐张挂点</summary>
                         { "#3_1", new  IAttachmentPoint3D { Voltage = Voltage.AC500kV, Type =  AttachmentType.N, Points= new List<Point3D>{ new Point3D { X=7.50, Y=-7.0, Z=-2.5}}} },
                         { "#4_1", new  IAttachmentPoint3D { Voltage = Voltage.AC500kV, Type =  AttachmentType.N, Points= new List<Point3D>{ new Point3D { X=7.50, Y=-7.0, Z=2.5}}}},
                         { "#5_1",  new  IAttachmentPoint3D { Voltage = Voltage.AC500kV, Type =  AttachmentType.N, Points= new List<Point3D>{ new Point3D { X=11.00, Y=-18.9, Z=-2.5}}}},
                         { "#3_2", new  IAttachmentPoint3D { Voltage = Voltage.AC500kV, Type =  AttachmentType.N, Points= new List<Point3D>{ new Point3D { X=11.00, Y=-18.9, Z=2.5}}}},
                         { "#4_2", new  IAttachmentPoint3D { Voltage = Voltage.AC500kV, Type =  AttachmentType.N, Points= new List<Point3D>{ new Point3D { X=9.00, Y=-30.1, Z=-2.5}}}},
                         { "#5_2", new  IAttachmentPoint3D { Voltage = Voltage.AC500kV, Type =  AttachmentType.N, Points= new List<Point3D>{ new Point3D { X=9.00, Y=-30.1, Z=2.5}}}},
                         { "#6", new  IAttachmentPoint3D { Voltage = Voltage.AC220kV, Type =  AttachmentType.N, Points= new List<Point3D>{ new Point3D { X=6.40, Y=-42.1, Z=-2.5}}}},
                         { "#7", new  IAttachmentPoint3D { Voltage = Voltage.AC220kV, Type =  AttachmentType.N, Points= new List<Point3D>{ new Point3D { X=6.40, Y=-42.1, Z=2.5}}}},
                         { "#8", new  IAttachmentPoint3D { Voltage = Voltage.AC220kV, Type =  AttachmentType.N, Points= new List<Point3D>{ new Point3D { X=13.50, Y=-42.1, Z=-2.5}}}},
                         { "#6_2", new  IAttachmentPoint3D { Voltage = Voltage.AC220kV, Type =  AttachmentType.N, Points= new List<Point3D>{ new Point3D { X=13.50, Y=-42.1, Z=2.5}}}},
                         { "#7_2", new  IAttachmentPoint3D { Voltage = Voltage.AC220kV, Type =  AttachmentType.N, Points= new List<Point3D>{ new Point3D { X=8.9, Y=-49.1, Z=-2.5}}}},
                         { "#8_2", new  IAttachmentPoint3D { Voltage = Voltage.AC220kV, Type =  AttachmentType.N, Points= new List<Point3D>{ new Point3D { X=8.9, Y=-49.1, Z=2.5}}}},
                         /// <summary>跳线挂点</summary>
                         { "#3_t", new  IAttachmentPoint3D { Voltage = Voltage.AC500kV, Type =  AttachmentType.TI, Points= new List<Point3D>{ new Point3D { X=9.50, Y=-7.0, Z=0.0}}}},
                         { "#4_t", new  IAttachmentPoint3D { Voltage = Voltage.AC500kV, Type =  AttachmentType.TI, Points= new List<Point3D>{ new Point3D { X=11.50, Y=-18.9, Z= 0.0 } }}},
                         { "#5_t",new  IAttachmentPoint3D { Voltage = Voltage.AC500kV, Type =  AttachmentType.TI, Points= new List<Point3D>{ new Point3D { X=11.00, Y=-30.1, Z= 0.0 } }}},
                         { "#6_t", new  IAttachmentPoint3D { Voltage = Voltage.AC220kV, Type =  AttachmentType.TI, Points= new List<Point3D>{ new Point3D { X=6.40, Y=-42.1, Z= 0.0 } }}},
                         { "#7_t",new  IAttachmentPoint3D { Voltage = Voltage.AC220kV, Type =  AttachmentType.TI, Points= new List<Point3D>{ new Point3D { X=13.50, Y=-42.1, Z= 0.0 } }}},
                         { "#8_t", new  IAttachmentPoint3D { Voltage = Voltage.AC220kV, Type =  AttachmentType.TI, Points= new List<Point3D>{ new Point3D { X=8.9, Y=-49.1, Z= 0.0 }}}},
                         /// <summary>地线耐张挂点</summary>
                         { "#1", new  IAttachmentPoint3D { Voltage = Voltage.AC500kV, Type =  AttachmentType.GN, Points= new List<Point3D>{ new Point3D { X=13.86, Y=0.0, Z=-1.5}}}},
                         { "#2",new  IAttachmentPoint3D { Voltage = Voltage.AC500kV, Type =  AttachmentType.GN, Points= new List<Point3D>{ new Point3D { X=13.86, Y=0.0, Z=1.5}}}},
                     }},
                     { @"5E1-J2",new   Dictionary<string, AttachmentPoint3D>
                     {   /// <summary>导线耐张挂点</summary>
                         { "#3_1", new  IAttachmentPoint3D { Voltage = Voltage.AC500kV, Type =  AttachmentType.N, Points= new List<Point3D>{ new Point3D { X=7.50, Y=-7.0, Z=-2.5}}} },
                         { "#4_1", new  IAttachmentPoint3D { Voltage = Voltage.AC500kV, Type =  AttachmentType.N, Points= new List<Point3D>{ new Point3D { X=7.50, Y=-7.0, Z=2.5}}}},
                         { "#5_1",  new  IAttachmentPoint3D { Voltage = Voltage.AC500kV, Type =  AttachmentType.N, Points= new List<Point3D>{ new Point3D { X=11.00, Y=-18.9, Z=-2.5}}}},
                         { "#3_2", new  IAttachmentPoint3D { Voltage = Voltage.AC500kV, Type =  AttachmentType.N, Points= new List<Point3D>{ new Point3D { X=11.00, Y=-18.9, Z=2.5}}}},
                         { "#4_2", new  IAttachmentPoint3D { Voltage = Voltage.AC500kV, Type =  AttachmentType.N, Points= new List<Point3D>{ new Point3D { X=9.00, Y=-30.1, Z=-2.5}}}},
                         { "#5_2", new  IAttachmentPoint3D { Voltage = Voltage.AC500kV, Type =  AttachmentType.N, Points= new List<Point3D>{ new Point3D { X=9.00, Y=-30.1, Z=2.5}}}},
                         { "#6", new  IAttachmentPoint3D { Voltage = Voltage.AC220kV, Type =  AttachmentType.N, Points= new List<Point3D>{ new Point3D { X=6.40, Y=-42.1, Z=-2.5}}}},
                         { "#7", new  IAttachmentPoint3D { Voltage = Voltage.AC220kV, Type =  AttachmentType.N, Points= new List<Point3D>{ new Point3D { X=6.40, Y=-42.1, Z=2.5}}}},
                         { "#8", new  IAttachmentPoint3D { Voltage = Voltage.AC220kV, Type =  AttachmentType.N, Points= new List<Point3D>{ new Point3D { X=13.50, Y=-42.1, Z=-2.5}}}},
                         { "#6_2", new  IAttachmentPoint3D { Voltage = Voltage.AC220kV, Type =  AttachmentType.N, Points= new List<Point3D>{ new Point3D { X=13.50, Y=-42.1, Z=2.5}}}},
                         { "#7_2", new  IAttachmentPoint3D { Voltage = Voltage.AC220kV, Type =  AttachmentType.N, Points= new List<Point3D>{ new Point3D { X=8.9, Y=-49.1, Z=-2.5}}}},
                         { "#8_2", new  IAttachmentPoint3D { Voltage = Voltage.AC220kV, Type =  AttachmentType.N, Points= new List<Point3D>{ new Point3D { X=8.9, Y=-49.1, Z=2.5}}}},
                         /// <summary>跳线挂点</summary>
                         { "#3_t", new  IAttachmentPoint3D { Voltage = Voltage.AC500kV, Type =  AttachmentType.TI, Points= new List<Point3D>{ new Point3D { X=9.50, Y=-7.0, Z=0.0}}}},
                         { "#4_t", new  IAttachmentPoint3D { Voltage = Voltage.AC500kV, Type =  AttachmentType.TI, Points= new List<Point3D>{ new Point3D { X=11.50, Y=-18.9, Z= 0.0 } }}},
                         { "#5_t",new  IAttachmentPoint3D { Voltage = Voltage.AC500kV, Type =  AttachmentType.TI, Points= new List<Point3D>{ new Point3D { X=11.00, Y=-30.1, Z= 0.0 } }}},
                         { "#6_t", new  IAttachmentPoint3D { Voltage = Voltage.AC220kV, Type =  AttachmentType.TI, Points= new List<Point3D>{ new Point3D { X=6.40, Y=-42.1, Z= 0.0 } }}},
                         { "#7_t",new  IAttachmentPoint3D { Voltage = Voltage.AC220kV, Type =  AttachmentType.TI, Points= new List<Point3D>{ new Point3D { X=13.50, Y=-42.1, Z= 0.0 } }}},
                         { "#8_t", new  IAttachmentPoint3D { Voltage = Voltage.AC220kV, Type =  AttachmentType.TI, Points= new List<Point3D>{ new Point3D { X=8.9, Y=-49.1, Z= 0.0 }}}},
                         /// <summary>地线耐张挂点</summary>
                         { "#1", new  IAttachmentPoint3D { Voltage = Voltage.AC500kV, Type =  AttachmentType.GN, Points= new List<Point3D>{ new Point3D { X=13.86, Y=0.0, Z=-1.5}}}},
                         { "#2",new  IAttachmentPoint3D { Voltage = Voltage.AC500kV, Type =  AttachmentType.GN, Points= new List<Point3D>{ new Point3D { X=13.86, Y=0.0, Z=1.5}}}},
                     }},
                 },
                GroundDistance = new Dictionary<Voltage, SortedList<double, double>>
                {
                    { Voltage.AC500kV, new SortedList<double, double> { { 1000, 11 }, { 3000, 11 } } },
                    { Voltage.AC220kV, new SortedList<double, double> { { 3000, 7 } } },
                },
                RiverDistance = new Dictionary<Voltage, (double, double, double, double)>
                {
                    { Voltage.AC500kV, (9.5, 6.0, 6.5, 11.0) },
                    { Voltage.AC220kV, (7.0, 3.0, 4.0, 6.5) }
                },
                FeatureDistance = new Dictionary<Voltage, Dictionary<FeatureType, (double, double?)>>
                {

                    { Voltage.AC500kV, new Dictionary<FeatureType, (double, double?)>
                    {
                        { FeatureType.ERail,(16.0,30.0) },{ FeatureType.Highrail, (16.0,30.0) },
                        { FeatureType.StandardGuage, (14.0,30.0) },{ FeatureType.NarrowGuage, (14.0,30.0) },
                        { FeatureType.highway,(14.0,30.0) }, { FeatureType.Road,(14.0,8.0) },
                        { FeatureType.TramsandTrolleysWay, (16.0,8.0) },{ FeatureType.LowTL,(8.5,8.0) },
                        { FeatureType.TL,(6.0,13.0) },{ FeatureType.TowerHead, (8.5,13.0) },
                        { FeatureType.SpecialPipe, (7.5,30.0) },{ FeatureType.RopeWay,(6.5,7.5) },
                        { FeatureType.House,(9.0,5.0) }, { FeatureType.Tree,(7.0,null) },
                        { FeatureType.FruitTree,(7,null) }
                    } },
                    { Voltage.AC220kV, new Dictionary<FeatureType, (double, double?)>
                    {
                        { FeatureType.ERail,(12.5,30.0) },{ FeatureType.Highrail,(12.5,30.0) },
                        { FeatureType.StandardGuage,(8.5,30.0) },{ FeatureType.NarrowGuage,(7.5,30.0) },
                        { FeatureType.highway,(8.0,30.0) },{ FeatureType.Road,(8.0,5.0) },
                        { FeatureType.TramsandTrolleysWay,(11.0,8.0) },{ FeatureType.LowTL,(4.0,5.0) },
                        { FeatureType.TL,(4.0,7.0) },{ FeatureType.TowerHead,ValueTuple.Create (4.0,7.0) },
                        { FeatureType.SpecialPipe,(5.0,30.0) },{ FeatureType.RopeWay,(4.0,5.0) },
                        { FeatureType.House,(6.0,2.5) }, { FeatureType.Tree,(4.5,null) },
                        { FeatureType.FruitTree,(3.5,null) },
                    }
                    },
                },
                FeatureClearance = new Dictionary<Voltage, Dictionary<FeatureType, double>>
                {

                    { Voltage.AC500kV, new Dictionary<FeatureType, double>
                    {
                        { FeatureType.House, 8.5 },{ FeatureType.Tree, 7 }

                    } },
                    { Voltage.AC220kV, new Dictionary<FeatureType, double>
                    {
                        { FeatureType.House, 5 },{ FeatureType.Tree, 4 }

                    } },

                },
                insulations=new List<Insulation> 
                {
                    new Insulation{ Pollution=@"中污区", 
                        IString=new Dictionary<Voltage, Dictionary<string, int>>
                        {{Voltage.AC500kV,new Dictionary<string, int>{ { @"U300BP", 25 },{ @"U420BP",25 }, } }, } },
                },
                Fittingstrings = new Dictionary<string, Fittingstring>
                {
                    { @"GN1", new Fittingstring
                    { Name = @"GN1",IceWeightList = new Dictionary<string, double> { { @"10mm", 5 }, { @"20mm", 8 } },
                        Type = AttachmentType.GN, Union = 1, WindArea = 0.1, Weight = 7,
                    } },
                    { @"GN2", new Fittingstring
                    { Name = @"GN2",IceWeightList = new Dictionary<string, double> { { @"10mm", 5 }, { @"20mm", 8 } },
                        Type = AttachmentType.GN, Union = 1, WindArea = 0.1, Weight = 7,
                    } },
                    { @"GX", new Fittingstring
                    { Name = @"GN",IceWeightList = new Dictionary<string, double> { { @"10mm", 5 }, { @"20mm", 8 } },
                        Type = AttachmentType.GX, Union = 1, WindArea = 0.1, Weight = 5,
                    } },
                    { @"V30", new Fittingstring
                    { Name = @"V30",IceWeightList = new Dictionary<string, double> { { @"10mm", 20 }, { @"20mm", 50 } },
                        Type = AttachmentType.V, Union = 2, WindArea = 0.1, Weight = 70,
                    } },
                    { @"SV30", new Fittingstring
                    { Name = @"SV30", IceWeightList = new Dictionary<string, double> { { @"10mm", 40 }, { @"20mm", 100 } },
                        Type = AttachmentType.V,  Union = 4, WindArea = 0.2, Weight = 180,
                    } },
                    { @"SN30", new Fittingstring
                    { Name = @"SN30",IceWeightList = new Dictionary<string, double> { { @"10mm", 80 }, { @"20mm", 200 } },
                        Type = AttachmentType.N, Length = 2.2, Union = 2, WindArea = 0.15, Weight = 300,
                    } },
                    { @"SN42", new Fittingstring
                    { Name = @"SN42",IceWeightList = new Dictionary<string, double> { { @"10mm", 80 }, { @"20mm", 200 } },
                        Type = AttachmentType.N, Length = 2.2, Union = 2, WindArea = 0.15, Weight = 300,
                    } },
                },
                Insulators = new Dictionary<string, Insulator>
                {
                     { @"U100CN", new Insulator { TypeCode = @"U100CN", Length = 0.175, Weight = 10.5, RatedLoad = 100,InsulatorType=InsulatorType.PC } },
                    { @"U300BP", new Insulator { TypeCode = @"U300BP", Length = 0.195, Weight = 14.5, RatedLoad = 300, InsulatorType=InsulatorType.PC } },
                    { @"U420BP", new Insulator { TypeCode = @"U420BP", Length = 0.205, Weight = 18.0, RatedLoad = 420, InsulatorType=InsulatorType.PC } },
                    { @"FXB4-220/300", new Insulator { TypeCode = @"FXB4-220/300", Length = 2.5, Weight = 16.3, RatedLoad = 300, InsulatorType=InsulatorType.H } },
                    { @"FXB4-500/300", new Insulator { TypeCode = @"FXB4-500/300", Length = 4.45, Weight = 21.3, RatedLoad = 300, InsulatorType=InsulatorType.H } },
                    { @"FXB4-500/400", new Insulator { TypeCode = @"FXB4-500/400", Length = 4.45, Weight = 28.2, RatedLoad = 400, InsulatorType=InsulatorType.H  } },
                    { @"XJFXB4-500/400", new Insulator { TypeCode = @"XJFXB4-500/400", Length = 7, Weight = 28.2, RatedLoad = 400,InsulatorType=InsulatorType.H  } },
                },
            };

           //otl.PhaseStrings.Add(@"XJ-500", new IStrings(@"XJ-500", Voltage.AC500kV, otl.Fittingstrings[@"I30"], otl.Insulators[@"XJFXB4-500/400"]));
            otl.StringsDic[1].Add(@"V30_500", new IStrings { AliasName= @"V30", Voltage= Voltage.AC500kV, Fittingstring= otl.Fittingstrings[@"V30"], Insulator= otl.Insulators[@"FXB4-500/300"] ,UnitPies=1});
            otl.StringsDic[1].Add(@"SN42_500", new IStrings { AliasName = @"SN42", Voltage = Voltage.AC500kV, Fittingstring = otl.Fittingstrings[@"SN42"], Insulator = otl.Insulators[@"U420BP"], UnitPies = 28 });       
            otl.WeatherAndWires = new List<(int, int, string, List<(Voltage, WireAndCoefficient)>)>
            {
                  ( 0,10000,@"气象一",new List<(Voltage, WireAndCoefficient)>
                    {
                      (Voltage.AC500kV,new WireAndCoefficient { Conductor=otl.Conductors[@"JL/G1A-630/45"], z=20}),
                      (Voltage.AC220kV,new WireAndCoefficient { Conductor=otl.Conductors[@"JL/G1A-400/35"], z=15}),
                      (Voltage.G,new WireAndCoefficient { Conductor=otl.EarthWires[@"LBGJ-100"]}),
                      (Voltage.G,new WireAndCoefficient { Conductor=otl.OPGWs[@"OPGW-100"]}),
                    }
                  ),
                };
            otl.Terrain = Factory.Terrain(new List<(string Dxd, string Wnd, string Cros, string Hdy, string Tre)>
                {
                    ( TestsCom.path+"j1_j2.dxd", TestsCom.path+"j1_j2.wnd", null, null, null),
                    ( TestsCom.path+"j2_j3.dxd", TestsCom.path+"j2_j3.wnd", null, null, null),
                      ( TestsCom.path+"j3_j4.dxd", TestsCom.path+"j3_j4.wnd", null, null, null),
                });
           // otl.TowersAttachPoint.Add(@"5E1-Z2",otl.TowersAttachPoint[@"5E1-Z1"]);
           //otl.TowersAttachPoint.Add(@"5E1-Z3", new Dictionary<string, AttachmentPoint3D>(otl.TowersAttachPoint[@"5E1-Z1"]));
           //otl.TowersAttachPoint.Add(@"5E1-Z4", new Dictionary<string, AttachmentPoint3D>(otl.TowersAttachPoint[@"5E1-Z1"]));
           // otl.TowersAttachPoint.Add(@"5E1-J2", new Dictionary<string, AttachmentPoint3D>(otl.TowersAttachPoint[@"5E1-J1"]));
            #region 杆塔
            var t = Factory.RootAndFoundation(TestsCom.path + "基础.fnd");//含根开及塔重、基础
            otl.Foundations = t.FoundDic;
            var TowerListZ1 = Factory.TowerList(Voltage.AC500kV, TowerType.Z, "5E1-Z1", 24, 45, 34, 1, 400, 600,
                                                    0.85, 3, 50, 700, 30, otl.TowersAttachPoint["5E1-Z1"], t.RootWeightDic);
             var TowerListZ2 = Factory.TowerList(Voltage.AC500kV, TowerType.Z, "5E1-Z2", 27, 51, 34, 1, 500, 800,
                                         0.8, 3, 50, 900, 30, otl.TowersAttachPoint["5E1-Z2"], t.RootWeightDic);
             var TowerListZ3 = Factory.TowerList(Voltage.AC500kV, TowerType.Z, "5E1-Z3", 24, 48, 31, 1, 700, 1000,
                             0.7, 3, 50, 1300, 30, otl.TowersAttachPoint["5E1-Z3"], t.RootWeightDic);
            var TowerListJ1 = Factory.TowerList(Voltage.AC500kV, TowerType.N, "5E1-J1", 18, 39, 28, 1, 400, 600,
                              0, 20, 50, 800, null, otl.TowersAttachPoint["5E1-J1"], t.RootWeightDic);
             var TowerListJ2 = Factory.TowerList(Voltage.AC500kV, TowerType.N, "5E1-J2", 18, 39, 28, 1, 400, 600,
               0, 90, 50, 800, null, otl.TowersAttachPoint["5E1-J1"], t.RootWeightDic);
            var towerList = new List<Tower>();
            towerList.AddRange(TowerListZ1);
           towerList.AddRange(TowerListZ2);
             towerList.AddRange(TowerListZ3);
            towerList.AddRange(TowerListJ1);
          towerList.AddRange(TowerListJ2);
            otl.Towers = towerList.ToDictionary(p => p.Name);
            otl.TowerGroup = new Dictionary<int, List<string>> { { 1, otl.Towers.Keys.ToList() }, };
            #endregion         
        }

    }
}
