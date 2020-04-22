using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Enums
{
    /// <summary> 地物特征</summary>
    public enum FeatureType
    {
        /// <summary> 地面</summary>
        Ground,
        /// <summary> 转角桩</summary>
        CornerPile,
        /// <summary>风偏点</summary>
        WindPoint,
        /// <summary> 居民区</summary>
        ResidentialArea,
        /// <summary> 交通困难地区</summary>
        DifficultTrafficArea,
        /// <summary> 步行可到达山坡</summary>
        HillsideWithinWalkingdistance,
        /// <summary> 步行不可到达山坡</summary>
        HillsideWithoutWalkingdistance,
        /// <summary> 跨越树木</summary>
        Tree,
        /// <summary> 果树及经济作物</summary>
        FruitTree,
        /// <summary> 房屋及建筑物</summary>
        House,
        /// <summary> 一级通信线</summary>
        PrimaryCL,
        /// <summary> 二级通信线</summary>
        SecondaryCL,
        /// <summary> 高铁</summary>        
        Highrail,
        /// <summary>电气化铁路（非高铁）</summary>
        ERail,
        /// <summary>铁路（非电气化）</summary>
        Rail,
        /// <summary>标准轨</summary>
        StandardGuage,
        /// <summary>窄轨</summary>
        NarrowGuage,
        /// <summary> 高速</summary>        
        highway,
        /// <summary>一级公路</summary>
        PrimaryRoad,
        /// <summary>公路</summary>
        Road,
        /// <summary>小道、机耕路</summary>
        Trail,
        /// <summary>10kV电力线路</summary>
        TL10kV,
        /// <summary>电力线路</summary>
        TL,
        /// <summary>电力线塔头</summary>
        TowerHead,
        /// <summary> 220kV及以上输电线路</summary>
        TLabove220,
        /// <summary> 重要输电线路</summary>
        ImportantTL,
        /// <summary> 弱电线路</summary>
        LowTL,
        /// <summary>一级通航河流</summary>
        PrimaryRiver,
        /// <summary>二级通航河流</summary>
        SecondaryRiver,
        /// <summary>通航河流(非一、二级)</summary>
        NavigeRriver,
        /// <summary>不通航河流、小溪</summary>
        River,
        /// <summary>特殊管道（见电气交跨规范）</summary>
        SpecialPipe,
        /// <summary>索道</summary>
        RopeWay,
        /// <summary>电车道（有轨及无轨）</summary>
        TramsandTrolleysWay,
    }
}

