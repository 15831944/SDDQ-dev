using Infrastructure.AssemblyMode;
using Infrastructure.AssemblyModel;
using Infrastructure.EntityMode;
using Infrastructure.Enums;
using SDDQCore.AssemblyMode;
using SDDQCore.AssemblyModel;
using SDDQCore.EntityMode;
using System;
using System.Collections.Generic;

namespace SDDQCore
{
    /// <summary>
    /// 请调用OTL.getOTLProject方法得到此实列
    /// </summary>
    public class OTLProject
    {
        public ProjectInfo ProjectInfo { get; set; }
        public SingleValue singleValue { get; set; }

        #region 库数据,用Dic方便引用、查询       
        /// <summary>Tkey为其name</summary>
        public Dictionary<string, WeatherGroup> WeatherGroups { get; set; }
        /// <summary>Tkey为其name</summary>
        public Dictionary<string, Conductor> Conductors { get; set; }
        /// <summary>Tkey为其name</summary>
        public Dictionary<string, Conductor> EarthWires { get; set; }
        /// <summary>Tkey为其name</summary>
        public Dictionary<string, OPGW> OPGWs { get; set; }
        /// <summary>Tkey为其name</summary>
        public Dictionary<string, OPGW> ADSSs { get; set; }
        /// <summary>Tkey为其name</summary>
        public Dictionary<string, Fittingstring> Fittingstrings { get; set; }
        /// <summary>Tkey为其TypeCode</summary>
        public Dictionary<string, Insulator> Insulators { get; set; }
        /// <summary>Tkey为其TypeCode</summary>
        public Dictionary<string, Fitting> Spacers { get; set; }
        /// <summary>
        /// 防振锤：Tkey为其TypeCode
        /// </summary>
        public Dictionary<string, Fitting> AntiVibrationHammers { get; set; }
        /// <summary>
        /// 双摆防舞器：Tkey为其TypeCode
        /// </summary>
        public Dictionary<string, Fitting> AntiDances { get; set; }
        /// <summary>
        /// 重锤片：Tkey为其TypeCode
        /// </summary>
        public Dictionary<string, Fitting> Hammers { get; set; }
        /// <summary>Tkey为其name</summary>
        public Dictionary<string, Tower> Towers { get; set; }     
    /// <summary>塔头挂点坐标：Tkey为杆塔名、编号</summary>
       public Dictionary<string, Dictionary<string, AttachmentPoint3D>> TowersAttachPoint { get; set; }
        /// <summary>Tkey为Tkey为杆塔名称</summary>
        public Dictionary<string,List<Foundation>> Foundations { get; set; }
        /// <summary>Tkey为其name</summary>
        public Dictionary<string, GroundDevice> GroundDevices { get; set; }

        public List<Insulation> insulations { get; set; }
        #endregion

        #region 组装类数据
        /// <summary>Tkey为其组装名</summary>
        public Dictionary<int, Dictionary<string, Strings>> StringsDic { get; set; }
        /// <summary>Tkey为其name</summary>
        public Dictionary<string, Strings> PhaseStrings { get; set; }
        /// <summary>Tkey为其name</summary>
        public Dictionary<int, List<string>> TowerGroup { get; set; }
        #endregion
        public SpotCheckInfo SpotCheckInfo { get; set; }
        #region 勘测 
        /// <summary>特征码对照表</summary> //需重构为单独文件
        public Dictionary<int, FeatureType> Features { get; set; }
        /// <summary>
        /// 勘测数据集合
        /// </summary>
        public Terrain Terrain { get; set; }
        #endregion
        #region 规则
        /// <summary>对地距离：电压等级,海拔,对地距离</summary>
        public Dictionary<Voltage,SortedList<double,double>> GroundDistance { get; set; }
        /// <summary>河流垂直距离：5年一遇洪水位，最高航行水位桅杆，百年一遇洪水位，冬季冰面</summary>
        public Dictionary<Voltage, (double, double, double, double)> RiverDistance { get; set; }
        /// <summary>
        /// 特征物的交跨距离：电压等级，特征码,垂直距离，水平距离
        /// </summary>
        public Dictionary<Voltage,Dictionary<FeatureType, (double Vertical, double? Horizontal)>> FeatureDistance { get; set; }
        /// <summary>特征物的净距：电压等级,特征码,净距</summary>
        public Dictionary<Voltage, Dictionary<FeatureType, double>> FeatureClearance { get; set; }
        ///塔位距离
        #endregion
        
        #region 分区情况
        /// <summary>气象区：起总里程,止里程，气象名，（电压等级，导线及系数）</summary>
        public  List<(int StarMileage, int EndMileage, string WeatherGroupName, List<(Voltage, WireAndCoefficient)> VoltageWire)> WeatherAndWires { get; set; }
        /// <summary>污区：起总里程,止里程，污区名</summary>
        List<(int StarMileage, int EndMileage, string)> Pollutions { get; set; }
        /// <summary>居民区：起总里程,止里程</summary>
        List<(int StarMileage, int EndMileage)> ResidentArea { get; set; }
        #endregion
        #region 杆塔位
        /// <summary> 杆塔位</summary>
        List<Node> Nodes { get; set; }
        #endregion    
        #region 耐张段
        public List<Section> Sections { get; set; }       
        #endregion


    }

    public  class OTL 
    {
        private static OTLProject myOTLProject=null;
        private static SpotCheckInfo mySpotCheckInfo = null;
        public static  OTLProject OTLProject 
        {
            get { if (myOTLProject == null) return new OTLProject(); else return myOTLProject; }
            set => myOTLProject = value;
        }
        private static SpotCheckInfo SpotCheckInfo
        {
            get { if (mySpotCheckInfo == null) return new SpotCheckInfo(); else return mySpotCheckInfo; }
            set => mySpotCheckInfo = value;
        }
    }
}
