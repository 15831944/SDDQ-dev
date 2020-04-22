using Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Infrastructure.EntityMode
{
    /// <summary>
    /// 杆塔，额定条件
    /// </summary>
   public class Tower
    {
        public string Name { get; set; }
       public Voltage Voltage { get; set; }
     public    TowerType TowerType { get; set; }
        /// <summary>全高</summary>
      public  double Ht { get; set; }

        /// <summary>呼称高,不参与计算</summary>
        public   double hc { get; set; }
        /// <summary>垂直档距</summary>
      public  double Lv { get; set; }
        /// <summary>水平档距</summary>
      public  double Lh { get; set; }

      public  double kv { get; set; }
        /// <summary>允许度数°</summary>
        public double Angle { get; set; }
        /// <summary>角度折档m/°</summary>
        public double AngleSpan { get; set; }//直线塔缩档，耐张塔放档
        /// <summary>下倾角</summary>
        public double? DownwardAngle { get; set; }
        /// <summary>重量kg</summary>
        public double Weight { get; set; }
        /// <summary>根开 </summary>
        public double Root { get; set; }
       [XmlIgnore]
        /// <summary>挂点,Tkey为编号</summary>
        public Dictionary<string,AttachmentPoint3D> HangPointList { get; set; }


    }

}
