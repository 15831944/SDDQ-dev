using Infrastructure.AssemblyModel;
using Infrastructure.Geometry;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace SDDQCore.EntityMode
{
    [XmlType("塔位")]
    public  class Node
    {
        /// <summary>
        /// OTL显示用
        /// </summary>
        [XmlElement("总里程")]
        public  double mileage { get; set; }
        /// <summary>
        /// 明细表用里程
        /// </summary>
        [XmlElement("明细表里程")]
        public (double,double?) SecondaryMileage { get; set; }

        [XmlElement("高程")]
        public double elevation { get; set; }
        [XmlElement("设计桩号")]
        public string designNO { get; set; }
        [XmlElement("运行桩号")]
        public string deviceNO { get; set; }
        [XmlElement("转角度数")]
        public string Angle { get; set; }
        [XmlElement("设计高差")]
        public double heightdifference { get; set; }
        [XmlElement("塔及其串")]
        public TowerString TowerString { get; set; } //重构出好的序列化和反序列化
        [XmlIgnore]
        public double kv { get; }
        [XmlElement("水平档距")]
        public double? Lh { get; set; }
        [XmlElement("垂直档距")]
        public double? Lv { get; set; }
        [XmlElement("接地型式")]
        public String Ground { get; set; }
        [XmlElement("附件")]
        public List<(string,string,int)> Annex { get; set; }
      
        [XmlElement("迁改")]
        public List<(string, string)> Migrate { get; set; }
        [XmlElement("备注")]
        public List<string> Remarks { get; set; }

        [XmlElement("坐标")]
        public List<Coordinate> CoordinateList { get; set; }


}


}
