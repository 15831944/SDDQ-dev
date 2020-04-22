using Infrastructure.AssemblyMode;
using Infrastructure.AssemblyModel;
using Infrastructure.EntityMode;
using Infrastructure.Enums;
using IOCommon;
using SDDQCore.EntityMode;
using SDDQCore.Terrains;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SDDQCore
{

    public static class Factory
    {
    public   static List<Tower> TowerList(Voltage voltage, TowerType towerType, string basename, double hcmin,double hcmax,double htmin,double step, 
                                    double lh, double lv, double kv, double angle, double angleSpan, double maxSpan, double? downwardAngle,
                                    Dictionary<string, AttachmentPoint3D> hangPointList, Dictionary<string, (double Root, double Weigh)> RootWeightDic)
        {
            List<Tower> towerList = new List<Tower>();
           double hc = hcmin;
            while (hc<=hcmax)
            {
                Tower tower = new Tower
                {
                    Name = basename + "-" + hc.ToString(),
                    Voltage = voltage,
                    Ht = htmin,
                    DownwardAngle = downwardAngle,
                    HangPointList = hangPointList,
                    Lh = lh,
                    Lv = lv,
                    kv = kv,
                    Angle = angle,
                    AngleSpan = angleSpan,
                    hc = hc,
                   
                };
                tower.Root = RootWeightDic[tower.Name].Root;
                tower.Weight= RootWeightDic[tower.Name].Weigh;
                towerList.Add(tower);
                hc += step;
                htmin += step;
            }     
            return towerList;
        }
      public static List<TowerString> TowerStringList(List<Tower> TowerList,List<Strings> stringsList)
        {
            var TowerStringList = new List<TowerString>();
           foreach (var item in TowerList)
            {
                TowerStringList.Add(new TowerString(item,stringsList));
            }
            return TowerStringList;
        }     
        public static TOPO terrain(List<String> TOPO)//风偏点、钻越点数据也可重构此方法得到
        {
            string[] TOPOtitle = TOPO[0].Split(',');
            foreach (var item in TOPOtitle) item.Trim();
            TOPO terrain = new TOPO((Voltage)Enum.Parse(typeof(Voltage),TOPOtitle[0]), int.Parse(TOPOtitle[1]));
            TOPO.RemoveAt(0);
            foreach (var item in TOPO)
            {
                string[] s = item.Split(',');
                foreach (var it in s) it.Trim();
                TerrainPoint TerrainPoint = new TerrainPoint(int.Parse(s[0]), int.Parse(s[1]),int.Parse(s[2]),
    int.Parse(s[3]), double.Parse(s[4]),s[6]);
                switch (s[5])
                {
                    case "0":
                        TerrainPoint.allow = int.Parse(s[5]);
                        TerrainPoint.GroupNo = 0;
                        TerrainPoint.TowerNo = 0;
                            break;
                    case "1":
                        TerrainPoint.allow = int.Parse(s[5]);
                        TerrainPoint.GroupNo = 1;
                        TerrainPoint.TowerNo = 0;
                        break;
                    default:
                        TerrainPoint.allow =2;
                        TerrainPoint.GroupNo = 1;
                        // TerrainPoint.GroupNo = int.Parse(s[5].Substring(1, 2));
                        TerrainPoint.TowerNo = int.Parse(s[5].Substring(3));
                        break;
                }
                terrain.Points.Add(TerrainPoint);
            }
            return terrain;
        }

        private static Terrain Terrain(List<TerrainData> TerrainDatas)
        {
            int dxd=0, wnd=0,cro=0,hyd=0,tre=0;
            foreach (var item in TerrainDatas)
            {
                dxd += int.Parse(item.Dxd[0][0]);
                if (item.Wnd!=null)
                    wnd += int.Parse(item.Wnd[0][0]);
                if (item.Cro != null)
                    cro += int.Parse(item.Cro[0][0]);
                if (item.Hyd != null)
                    hyd += int.Parse(item.Hyd[0][0]);
                if (item.Tre != null)
                    tre += int.Parse(item.Tre[0][0]);
            }
            var terrain = new Terrain
            {
                SurveyPointWidth = double.Parse(TerrainDatas[0].Dxd[0][1]),
                DualMileageTable = new DualMileageTable
                {StarMileage= int.Parse(TerrainDatas[0].Dxd[0][2]),
                 Table =new List<(int StarMileage, int EndMileage)>(),
                },
                SurveyPoints = new List<SurveyPoint>(dxd),
                WindPoints=new List<WindPoint>(wnd),
                CrossPoints =new List<CrossPoint>(cro),
                Hydrologies=new List<Hydrology>(hyd),
                Trees=new List<Tree>(tre),
            };
          
            foreach (var item in TerrainDatas)
            {
              var  w = terrain.SurveyPointWidth;
                item.Dxd.RemoveAt(0);
                terrain.DualMileageTable.Table.Add((int.Parse(item.Dxd[0][0]), int.Parse(item.Dxd.Last()[0])));
                var sec = TerrainDatas.FindIndex(t => t==item)+1;
                foreach (var surveyPoints in item.Dxd)
                {
                    if (terrain.SurveyPoints.Count==0|| surveyPoints!= item.Dxd.First())
                    {                       
                        var surveyPoint = new SurveyPoint
                        {                            
                            mileage =terrain.DualMileageTable.Mileage(sec,int.Parse(surveyPoints[0])),//由此种方法得到的总里程对UI输入禁区不利
                            middle = (0, double.Parse(surveyPoints[1])),
                            right = (w, double.Parse(surveyPoints[2])),
                            left = (-w, double.Parse(surveyPoints[3])),
                            cross = (0, double.Parse(surveyPoints[4])),
                            Feature = int.Parse(surveyPoints[6]),
                        };
                        FeatureType type;
                        if (OTL.OTLProject.Features.TryGetValue(surveyPoint.Feature, out type))
                        {
                            switch (type)
                            {
                                case FeatureType.Ground:
                                    break;
                                case FeatureType.WindPoint:
                                    break;
                                case FeatureType.CornerPile:
                                    surveyPoint.Angle = double.Parse(surveyPoints[5]);
                                    break;
                                default://交跨物
                                    surveyPoint.crossAngle = double.Parse(surveyPoints[5]);
                                    break;

                            }                          
                        }
                        else throw new Exception("特征码错误");
                        terrain.SurveyPoints.Add(surveyPoint);
                    }                 
                }
                foreach (var windPoints in item.Wnd)
                {
                    var windPoint = new WindPoint
                    {
                        mileage = terrain.DualMileageTable.Mileage(sec, int.Parse(windPoints[0])),//由此种方法得到的总里程对UI输入禁区不利
                        WindPs=new List<(double, double)>(),                        
                    };
                    for (int i = 1; i < windPoints.Length; i+=2)
                    {
                        windPoint.WindPs.Add((double.Parse(windPoints[i]), double.Parse(windPoints[i+1])));
                    }
                    terrain.WindPoints.Add(windPoint);
                }

            }          
            return terrain;
        }

        public static Terrain Terrain(List<(string Dxd,string Wnd,string Cro, string Hdy,string Tre)> TerrainFiles)
        {
            List<TerrainData> TerrainDatas=new List<TerrainData>();
            foreach (var item in TerrainFiles)
            {
                var terrainData = new TerrainData();
                 terrainData.Dxd=FileOperate.ReadFile(item.Dxd,' ');
                if (item.Wnd!=null)
                    terrainData.Wnd = FileOperate.ReadFile(item.Wnd, ' ');
                if (item.Cro  != null)
                    terrainData.Cro = FileOperate.ReadFile(item.Cro, ' ');
                if (item.Hdy != null)
                    terrainData.Hyd = FileOperate.ReadFile(item.Hdy, ' ');
                if (item.Tre != null)
                    terrainData.Tre= FileOperate.ReadFile(item.Tre, ' ');
                TerrainDatas.Add(terrainData);
            }           
            return Terrain(TerrainDatas);
        }

        public static (Dictionary<string , (double Root,double Weigh) > RootWeightDic, Dictionary<string , List<Foundation>> FoundDic) RootAndFoundation(string fnd) 
        {
            var rootWeightDic = new Dictionary<string, (double Root, double Weigh)>();
            var FoundDic = new Dictionary<string, List<Foundation>>();
            var data = FileOperate.ReadFile(fnd, ',');
            string[] title = data[0];
            data.RemoveAt(0);
            foreach (var s in data)
            {
                var f = new List<Foundation>();
                rootWeightDic.Add(s[0], (double.Parse(s[1]), double.Parse(s[2])));             
                for (int i = 3; i < s.Length; i++)
                { f.Add(new Foundation(s[0], title[i], double.Parse(s[i]))); }
                FoundDic.Add(s[0],f);
            }
            return (rootWeightDic, FoundDic);
        }
    }
}
