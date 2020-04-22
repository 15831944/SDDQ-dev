using Infrastructure.EntityMode;
using SDDQCore.EntityMode;
using SDDQCore.TheoreticalMode;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System;


namespace SDDQCore
{
    public static class Check
    {
        //    /// <summary>
        //    /// 检查对地
        //    /// </summary>
        //    /// <param name="nodeSpan"></param>
        //    /// <param name=" CatenaryMethod"></param>
        //    /// <returns></returns>
        //    public static bool Ground(NodeSpan nodeSpan,string voltage,double  k)
        //    {
        //       return  CheckGround(nodeSpan.TerrainPointSet,
        //              new Parabola(new intPoint(nodeSpan.StarNode.mileage, 10*nodeSpan.StarNode.Hs[voltage]), new intPoint(nodeSpan.EndNode.mileage, 10*nodeSpan.EndNode.Hs[voltage]), k));
        //     }
        //    /// <summary>
        //    /// 需要使用方保证地形点在悬线内
        //    /// </summary>
        //    /// <param name="TerrainPointSet"></param>
        //    /// <param name="ICatenary"></param>
        //    /// <returns></returns>
        //    private static bool CheckGround(IEnumerable<TerrainPoint> TerrainPointSet, Parabola ICatenary)
        //    {
        //        bool result = false;
        //        if (TerrainPointSet.All(TerrainPoint=> TerrainPoint.acceptElev<= ICatenary.SpanLowP.Y)) result = true;
        //        else result= TerrainPointSet.All(TerrainPoint => TerrainPoint.acceptElev <= ICatenary.Y(TerrainPoint.mileage).Y);
        //        return result;
        //    }

        //    public static bool Tower(NodeTowerStatus nodeTowerStatus)
        //    {
        //        Tower tower = nodeTowerStatus.Node.TowerString.Tower;
        //        if (tower.TowerType==TowerType.N)
        //        {
        //            if (nodeTowerStatus.Lh <=tower.Lh+ (tower.angle-Math.Abs(nodeTowerStatus.Node.angle))*tower.angleSpan &&
        //               nodeTowerStatus.Lh <=tower.Lv) return true;
        //            else return false;
        //        }
        //        else
        //        {
        //            if (nodeTowerStatus.Lh <= tower.Lh - Math.Abs(nodeTowerStatus.Node.angle)* tower.angleSpan &&
        //               nodeTowerStatus.Lv <= tower.Lv && nodeTowerStatus.kv >= tower.kv) return true;
        //            else return false;
        //        }          

        //    }
        //    /// <summary>
        //    /// 垂直档距
        //    /// </summary>
        //    /// <param name="nodeTowerStatus"></param>
        //    /// <returns></returns>
        //    public static bool Lv(NodeTowerStatus nodeTowerStatus)
        //    {
        //        Tower tower = nodeTowerStatus.Node.TowerString.Tower;
        //        if ( nodeTowerStatus.Lv <= tower.Lv ) return true;
        //        else return false;
        //    }

        //    public static bool Lv(NodeTowerStatus nodeTowerStatus,Tower tower)
        //    {            
        //        if (nodeTowerStatus.Lv <= tower.Lv) return true;
        //        else return false;
        //    }
        //    /// <summary>
        //    /// 水平档距
        //    /// </summary>
        //    /// <param name="nodeTowerStatus"></param>
        //    /// <returns></returns>
        //    public static bool Lh(NodeTowerStatus nodeTowerStatus)
        //    {
        //        Tower tower = nodeTowerStatus.Node.TowerString.Tower;
        //        if (nodeTowerStatus.Lh <= tower.Lh + (tower.angle - Math.Abs(nodeTowerStatus.Node.angle))) return true;
        //        else return false;
        //    }
        //    public static bool Lh(int starmileage,Node node, int endmileage)
        //    {
        //        Tower tower = node.TowerString.Tower;
        //        if ((endmileage- starmileage)  <=2*( tower.Lh + (tower.angle - Math.Abs(node.angle)))) return true;
        //        else return false;
        //    }
        //    public static bool kv(NodeTowerStatus nodeTowerStatus)
        //    {
        //        Tower tower = nodeTowerStatus.Node.TowerString.Tower;
        //        if (tower.TowerType != TowerType.N)
        //        {
        //            if (nodeTowerStatus.kv >= tower.kv) return true;
        //            else return false;
        //        }
        //        else return true;
        //    }

        //    public static bool kv(NodeTowerStatus nodeTowerStatus, Tower tower)
        //    {          
        //        if (tower.TowerType != TowerType.N)
        //        {
        //            if (nodeTowerStatus.kv >= tower.kv) return true;
        //            else return false;
        //        }
        //        else return true;
        //    }

        //    public static bool kvlv(Node GrandNode,Node FatherNode,Parabola sonCatenary,
        //        string Voltage, double k1,ref SortedDictionary<int, int> kvDic_FatherNode, ref SortedDictionary<int, int> kvnotDic_FatherNode)
        //    {
        //        NodeTowerStatus myNodeTowerStatus = null;
        //        if (kvDic_FatherNode.Count==0&& kvnotDic_FatherNode.Count==0)
        //        {
        //            myNodeTowerStatus = new NodeTowerStatus(GrandNode, FatherNode, sonCatenary, Voltage, k1);
        //            if (kv(myNodeTowerStatus, FatherNode.TowerString.Tower))
        //            {
        //                if (Lv(myNodeTowerStatus, FatherNode.TowerString.Tower))
        //                {
        //                    kvDic_FatherNode.Add(GrandNode.mileage, GrandNode.Hs[Voltage]);
        //                    return true;
        //                }
        //                else
        //                {
        //                    return false;
        //                }                                                   
        //            }
        //            else
        //            {
        //                kvnotDic_FatherNode.Add(GrandNode.mileage, GrandNode.Hs[Voltage]);                   
        //                return false;
        //            }
        //        }
        //        else
        //        {
        //            bool kv1=false;
        //            bool kv2=false;
        //            if (kvDic_FatherNode.Count != 0)//kv值通过的里程、挂高，同里程、离FatherNode远里程比此挂高低的点通过kv值检查
        //            {
        //                foreach (var item in kvDic_FatherNode.Reverse())
        //                {
        //                    if (GrandNode.mileage<= item.Key)
        //                    {
        //                        if ((int)GrandNode.Hs[Voltage]<= item.Value)
        //                        {
        //                            kv1 = true;//查找kvDic_FatherNode通过kv值检查
        //                            if (!kvDic_FatherNode.ContainsKey(GrandNode.mileage))
        //                                kvDic_FatherNode.Add(GrandNode.mileage, (int)GrandNode.Hs[Voltage]);
        //                            myNodeTowerStatus = new NodeTowerStatus(GrandNode, FatherNode, sonCatenary, Voltage, k1);
        //                            if (Lv(myNodeTowerStatus, FatherNode.TowerString.Tower))
        //                            {
        //                                return true;
        //                            }                                                        
        //                        }
        //                    }
        //                    else
        //                    {
        //                        kv1 = false;//结论未知
        //                        break;
        //                    }
        //                }
        //            } 
        //            if (kvnotDic_FatherNode.Count != 0)  //kv值未通过的里程、挂高，同里程、离FatherNode近里程比此挂高高的点未通过kv值检查
        //            {
        //                foreach (var item in kvnotDic_FatherNode)
        //                {
        //                    if (GrandNode.mileage >= item.Key)
        //                    {
        //                        if ((int)GrandNode.Hs[Voltage] >= item.Value)
        //                        {
        //                            kv2 = true;//查找kvnotDic_FatherNode通过kv值检查(结论为false)
        //                            if (!kvnotDic_FatherNode.ContainsKey(GrandNode.mileage))
        //                                kvnotDic_FatherNode.Add(GrandNode.mileage, (int)GrandNode.Hs[Voltage]);
        //                           return false;
        //                        }
        //                    }
        //                    else
        //                    {
        //                        kv2 = false;//结论未知
        //                        break;
        //                    }
        //                }
        //            }
        //            if (kv1==false&& kv2==false)
        //            {
        //                myNodeTowerStatus = new NodeTowerStatus(GrandNode, FatherNode, sonCatenary, Voltage, k1);
        //                if (kv(myNodeTowerStatus, FatherNode.TowerString.Tower))
        //                {
        //                  kvDic_FatherNode[GrandNode.mileage]=(int)GrandNode.Hs[Voltage];
        //                    if (Lv(myNodeTowerStatus, FatherNode.TowerString.Tower))
        //                    {
        //                        return true;
        //                    }
        //                }
        //                else
        //                {
        //                    kvnotDic_FatherNode[GrandNode.mileage]=(int)GrandNode.Hs[Voltage];                       
        //                    return false;
        //                }
        //            }         
        //        }
        //        return false;
        //    }
        //}


    }
}