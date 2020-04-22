using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDDQCore;

namespace OTLTests
{
    [TestClass()]
    public class OptimumSpotTests
    {
        [TestMethod()]
        public void AutoSpotTest()//以后所有的测试文件中的数据填充行为都要放到projectlib中进行复用
        {
        //    #region 单价
        //    SingleValue singleValue = new SingleValue
        //    {
        //        TowerValue = 9000,
        //   FittingValue= 15000,
        //   FoundationValue = new Dictionary<string, double> { { "601", 300 }, { "挖孔", 400 }},
        //   insulatorValue = new Dictionary<string, double> { { "U300BP", 300 }, { "FX200", 500 } },
        //};
        //    #endregion
        //    #region 串
        //    //金具串
        //    Fittingstring GN_fittingstring = new Fittingstring("BN2Y-BG-07", 5, 70, 0.31, 0.03);
        //    Fittingstring GI_fittingstring = new Fittingstring("BX2CL-BG-07", 5, 70, 0.23, 0.03);
        //    Fittingstring SN_fittingstring = new Fittingstring("5N2-5050-30P(500/45)", 311, 600, 2.26, 0.6);
        //    Fittingstring SI_fittingstring = new Fittingstring("5XC2L-5050-24H", 136.5, 480, 1, 0.5);
        //    Fittingstring SV_fittingstring = new Fittingstring("5VC21-4550-24H", 136.5, 480, 1, 0.5);
        //    Fittingstring SL_fittingstring = new Fittingstring("5VL21-4550-24H", 136.5, 480, 1, 0.5);
        //    Fittingstring TI_fittingstring = new Fittingstring("5T-45-10H", 136.5, 100, 1, 0.5);
        //    //绝缘子
        //    //Insulator U300BP = new Insulator("U300BP", 0.205, 420, 20.6, 0.04, InsulatorType.PC);
        //    //Insulator FXBW240 = new Insulator("FXBW-500/240-2", 4.9, 210, 100, 1.03, InsulatorType.H);
        //    //Insulator FXBW120 = new Insulator("FXBW-500/120-2", 4.9, 210, 100, 1.03, InsulatorType.H);
        //    //绝缘子串
        //    Strings GN = new Strings(Voltage.G, GN_fittingstring, AttachmentType.GN);
        //    Strings GX = new Strings(Voltage.G, GI_fittingstring, AttachmentType.GX);
        //    //Strings SN = new Strings("SN30-35片",Voltage.AC500kV, 5, SN_fittingstring, U300BP, AttachmentType.N, 2, 35);
        //    //Strings SI = new Strings("SI24H-2", Voltage.AC500kV, 5, SI_fittingstring, FXBW240, AttachmentType.I, 2, 1);
        //    //Strings SV = new Strings("SV24H-2",Voltage.AC500kV, 5, SV_fittingstring, FXBW240, AttachmentType.V, 2, 2);
        //    //Strings SL = new Strings("SL24H-2", Voltage.AC500kV, 6, SV_fittingstring, FXBW240, AttachmentType.L, 2, 2);
        //    //Strings TI = new Strings("5T-10H", Voltage.AC500kV, 5, TI_fittingstring, FXBW120, AttachmentType.TI, 1, 1);
        //    #endregion
        //    #region 杆塔
        //    List<Tower> TowerListZ1 = Factory.TowerList(Voltage.AC500kV, TowerType.Z, "5E1-Z1", 24, 45, 34, 1, 400, 600,
        //                                            0.85, 3, 50, 700, 30, new List<(Voltage, double, double)> { (Voltage.AC500kV, 10, 0) },
        //                                             new List<AttachmentPoint> {new AttachmentPoint (Voltage.G, AttachmentType.GX, Point.Parse("-10,0")),
        //                                             new AttachmentPoint (Voltage.G, AttachmentType.GX, Point.Parse("10,0")),
        //                                             new AttachmentPoint (Voltage.AC500kV, AttachmentType.L,(Point.Parse("-12,-7.5"),Point.Parse("-5,-10"))),
        //                                             new AttachmentPoint (Voltage.AC500kV, AttachmentType.I, Point.Parse("10,-10")),
        //                                             new AttachmentPoint (Voltage.AC500kV, AttachmentType.V, (Point.Parse("-5,-7"),Point.Parse("5,-7")))
        //                                            });
        //    List<Tower> TowerListZ2 = Factory.TowerList(Voltage.AC500kV, TowerType.Z, "5E1-Z2", 27, 51, 34, 1, 500, 800,
        //                                0.8, 3, 50, 900, 30, new List<(Voltage, double, double)> { (Voltage.AC500kV, 10, 0) },
        //                                 new List<AttachmentPoint> {new AttachmentPoint (Voltage.G, AttachmentType.GX, Point.Parse("-10,0")),
        //                                 new AttachmentPoint (Voltage.G, AttachmentType.GX, Point.Parse("10,0")),
        //                                 new AttachmentPoint (Voltage.AC500kV, AttachmentType.I, Point.Parse("10,-10")),
        //                                 new AttachmentPoint (Voltage.AC500kV, AttachmentType.I, Point.Parse("10,-10")),
        //                                 new AttachmentPoint (Voltage.AC500kV, AttachmentType.V, (Point.Parse("-5,-7"),Point.Parse("5,-7")))
        //                                });
        //   List<Tower> TowerListZ3 = Factory.TowerList(Voltage.AC500kV, TowerType.Z, "5E1-Z3", 24, 48, 31, 1, 700, 1000,
        //                    0.7, 3, 50, 1300, 30, new List<(Voltage, double, double)> { (Voltage.AC500kV, 10, 0) },
        //                     new List<AttachmentPoint> {new AttachmentPoint (Voltage.G, AttachmentType.GX, Point.Parse("-10,0")),
        //                     new AttachmentPoint (Voltage.G, AttachmentType.GX, Point.Parse("10,0")),
        //                     new AttachmentPoint (Voltage.AC500kV, AttachmentType.I, Point.Parse("10,-10")),
        //                     new AttachmentPoint (Voltage.AC500kV, AttachmentType.I, Point.Parse("10,-10")),
        //                     new AttachmentPoint (Voltage.AC500kV, AttachmentType.V, (Point.Parse("-5,-7"),Point.Parse("5,-7")))
        //                     });
        //   List<Tower> TowerListJ1 = Factory.TowerList(Voltage.AC500kV, TowerType.N, "5E1-J1", 18, 39, 28, 1, 400, 600,
        //                     0, 20, 50, 800, null, new List<(Voltage, double, double)> { (Voltage.AC500kV, 9, 5) },
        //                     new List<AttachmentPoint> {
        //                     new AttachmentPoint (Voltage.G, AttachmentType.GN, Point.Parse("-10,0")),
        //                     new AttachmentPoint (Voltage.G, AttachmentType.GN, Point.Parse("10,0")),
        //                     new AttachmentPoint (Voltage.AC500kV, AttachmentType.N, Point.Parse("-10,-10")),
        //                     new AttachmentPoint (Voltage.AC500kV, AttachmentType.N, Point.Parse("2,-5")),
        //                     new AttachmentPoint (Voltage.AC500kV, AttachmentType.N, Point.Parse("10,-10")),
        //                     new AttachmentPoint (Voltage.AC500kV, AttachmentType.TI, Point.Parse("-10,-10")),
        //                      new AttachmentPoint (Voltage.AC500kV, AttachmentType.TV, Point.Parse("2,-5")),
        //                      new AttachmentPoint (Voltage.AC500kV, AttachmentType.TI, Point.Parse("10,-10"))
        //                     });
        //    List<Tower> TowerListJ2 = Factory.TowerList(Voltage.AC500kV, TowerType.N, "5E1-J2", 18, 39, 28, 1, 400, 600,
        //         0, 90, 50, 800, null, new List<(Voltage, double, double)> { (Voltage.AC500kV, 9, 5) },
        //         new List<AttachmentPoint> {new AttachmentPoint (Voltage.G, AttachmentType.GN, Point.Parse("-10,0")),
        //                     new AttachmentPoint (Voltage.G, AttachmentType.GX, Point.Parse("10,0")),
        //                     new AttachmentPoint (Voltage.AC500kV, AttachmentType.N, Point.Parse("-10,-10")),
        //                     new AttachmentPoint (Voltage.AC500kV, AttachmentType.N, Point.Parse("2,-5")),
        //                     new AttachmentPoint (Voltage.AC500kV, AttachmentType.N, Point.Parse("10,-10")),
        //                     new AttachmentPoint (Voltage.AC500kV, AttachmentType.TI, Point.Parse("0,-10"))
        //         });
        //    #endregion
        //    #region 塔串
        //    List<Strings> stringsList_N = new List<Strings> { GN, SN, TI };
        //    List<Strings> stringsList_X = new List<Strings> { GX, SI, SV, SL };
         //  TowerGroup towerGroup = new TowerGroup(1, new List<TowerString>[] { Factory.TowerStringList(TowerListZ1, stringsList_X),
         //      Factory.TowerStringList(TowerListZ2, stringsList_X),
        //        Factory.TowerStringList(TowerListZ3, stringsList_X),
        //        Factory.TowerStringList(TowerListJ1, stringsList_N),
        //        Factory.TowerStringList(TowerListJ2, stringsList_N)
        //    });
        //    string TowerList = null;
        //    foreach (var item in towerGroup.TowerStrings)
        //    {
        //        TowerList += item.Tower.Name + "\r\n";
        //    }
        //    Assert.AreEqual(towerGroup.Z()[0].HsList[Voltage.AC500kV], 34 - 10 - 6);
        //    #endregion
        //    #region 塔重根开基础
        //    List<string> TowerRootWeight = FileOperate.ReadFile(TestsCom.path + "基础.txt");
        //    string[] title = TowerRootWeight[0].Split(',');
        //    foreach (var item in title) item.Trim();
        //    TowerRootWeight.RemoveAt(0);
        //    Dictionary<string, double> TowerWeightDic = new Dictionary<string, double>();
        //    Dictionary<string, double> TowerRootDic = new Dictionary<string, double>();
        //    List<Foundation> Foundationlist = new List<Foundation>();
        //    foreach (var item in TowerRootWeight)
        //    {
        //        string[] s = item.Split(',');
        //        foreach (var it in s) it.Trim();
        //        TowerRootDic.Add(s[0], double.Parse(s[1]));
        //        TowerWeightDic.Add(s[0], double.Parse(s[2]));
        //        for (int i = 3; i < s.Length; i++)
        //        { Foundationlist.Add(new Foundation(s[0], title[i], double.Parse(s[i]))); }
        //    }
        //    towerGroup.SetTowerRoot(TowerRootDic);
        //    towerGroup.SetTowerWeight(TowerWeightDic);
        //    #endregion
        //    Dictionary<int, TowerGroup> TowerGroupDic = new Dictionary<int, TowerGroup>() { { 1, towerGroup } };
        //    #region 排位段信息                      
        //    Segment segment = new Segment(new Tuple<double, double>(50, 59538),
        //         new List<(Tuple<double, double>, K)>() { (new Tuple<double, double>(50, 59538), new K(Voltage.AC500kV, "JL/G1A-400/50", Ktype.Template, 8)) },
        //         new List<(Tuple<double, double>, K)>() { (new Tuple<double, double>(50, 59538), new K(Voltage.G, "GL-100", Ktype.Template, 6)) },
        //         100, 1000, 5, new List<Geology>() { (new Geology(new Tuple<double, double>(50, 59538), "604")) },
        //       singleValue);
        //    #endregion
        //    #region 地形信息
        //    List<string> TOPO = FileOperate.ReadFile(TestsCom.path + "TOPO.txt");
        //    Terrain terrain = Factory.terrain(TOPO);
        //    #endregion
        //    #region 给CPP写文件
        //    List<string> FileData = new List<string>();
        //    #region Section.txt
        //    FileData.Add(segment.MinSpan + "," + segment.MaxSpan);
        //    String line = null;
        //    foreach (var item in segment.ConductorKList)
        //    {
        //        line += item.Item1.Item1 + "," + item.Item1.Item2 + "," + item.Item2.value + ";";
        //    }
        //    FileData.Add(line);
        //    line = null;
        //    foreach (var item in segment.EarthwireKList)
        //    {
        //        line += item.Item1.Item1 + "," + item.Item1.Item2 + "," + item.Item2.value + ";";
        //    }
        //    FileData.Add(line);
        //    line = null;
        //    foreach (var item in segment.GeologyList)
        //    {
        //        line += item.Interval.Item1 + "," + item.Interval.Item2 + "," + item.FoundationType + ";";
        //    }
        //    FileData.Add(line);
        //    line = null;
        //    FileOperate.WriteFile(FileData, TestsCom.path + "Section.txt");
        //    #endregion
        //    #region TowerGroup.txt
        //    FileData = new List<string>();
        //    FileData.Add("塔组,序号,名称,Lh,Lv,kv,angle,折档,root,ht,悬点高,value,塔型,跳线高");
        //    foreach (var i in TowerGroupDic.Keys)
        //    {
        //        var no = 0;
        //        foreach (var TS in TowerGroupDic[i].TowerStrings)
        //        {
        //            ++no;
        //            line = i + "," + no + "," + TS.Tower.Name + "," + (int)TS.Tower.Lh + "," + (int)TS.Tower.Lv
        //                  + "," + TS.Tower.kv + "," + TS.Tower.Angle + "," + (int)TS.Tower.AngleSpan
        //                  + "," + TS.Tower.Root.ToString("F1") + "," + TS.Tower.Ht.ToString("F1") + "," + TS.HsList[terrain.Voltage].ToString("F1") + "," + TowerStringValue(TS, singleValue).ToString("F1");
        //            if (TS.Tower.TowerType == TowerType.N) line += ",N" + "," + TS.HjList[terrain.Voltage].ToString("F1");
        //            else line += ",Z";
        //            FileData.Add(line);
        //        }
        //    }
        //    FileOperate.WriteFile(FileData, TestsCom.path + "TowerGroup.txt");
        //    #endregion
        //    #endregion
        }


        //private double TowerStringValue(TowerString towerString,SingleValue singleValue)
        //{
        //    var V = towerString.Tower.Weight * singleValue.tower;
        //    towerString.StringsList.ToList().ForEach(delegate ((AttachmentPoint, Strings) item)
        //    {
        //        V += item.Item2.fittingstring.Weight * singleValue.fitting;
        //        if (item.Item2.Union != 0)
        //            V += item.Item2.UnitPies * item.Item2.Union * singleValue.Insulator(item.Item2.insulator.TypeCode);
        //    });
        //    return V;
        //}
    }
}