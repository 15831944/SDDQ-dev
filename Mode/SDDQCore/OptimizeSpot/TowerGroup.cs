using Infrastructure.AssemblyModel;
using Infrastructure.Enums;
using SDDQCore.EntityMode;
using System;
using System.Collections.Generic;

namespace SDDQCore.OptimizeSpot
{
    /// <summary>
    /// 杆塔组
    /// </summary>
    public  class TowerGroup
    {
        public TowerGroup(uint n0, List<TowerString> towerStrings)
        {
            N0 = n0;
            TowerStrings = towerStrings ?? throw new ArgumentNullException(nameof(towerStrings));
        }
        public TowerGroup(uint n0, List<TowerString>[] towerStrings)
        {
            N0 = n0;
            TowerStrings=new List<TowerString>();
            foreach (var item in towerStrings) TowerStrings.AddRange(item);
        }

        /// <summary>分组号 </summary>
        public uint N0 { get; set; }
        public List<TowerString> TowerStrings { get; set; }
        /// <summary>
        /// 塔组中的耐张塔
        /// </summary>
        /// <returns></returns>
        public List<TowerString> N()
        {
            return TowerStrings.FindAll(delegate (TowerString TowerString)
            {
                return TowerString.Tower.TowerType == TowerType.N;
            });
        }
        public List<TowerString> N(double angle)
        {
            return TowerStrings.FindAll(delegate (TowerString Tower)
            {
                return (Tower.Tower.TowerType == TowerType.N&& Tower.Tower.Angle>=Math.Abs(angle));
            });
        }
        /// <summary>
        /// 塔组中的直线塔
        /// </summary>
        /// <returns></returns>
        public List<TowerString> Z()
        {
            return TowerStrings.FindAll(delegate (TowerString Tower)
            {
                return Tower.Tower.TowerType == TowerType.Z;
            });
        }
        /// <summary>
        /// 塔组中的直转塔
        /// </summary>
        /// <returns></returns>
        public List<TowerString> ZJ()
        {
            return TowerStrings.FindAll(delegate (TowerString Tower)
            {
                return Tower.Tower.TowerType == TowerType.Z;
            });
        }

        public  void SetTowerWeight( Dictionary<string, double> TowerWeightDic)
        {
            foreach (var item in this.TowerStrings)
            {
                item.Tower.Weight = TowerWeightDic[item.Tower.Name];
            }
        }
        public  void SetTowerRoot(Dictionary<string, double> TowerRootDic)
        {
            foreach (var item in this.TowerStrings)
            {
                item.Tower.Root = TowerRootDic[item.Tower.Name];
            }
        }
    }
}
