using Infrastructure.EntityMode;
using Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media.Media3D;
using System.Xml.Serialization;

namespace SDDQCore.EntityMode
{
    /// <summary>
    /// 塔及其串
    /// </summary>
    public class TowerString // by zlf
    {
        public TowerString(Tower tower, List<Strings> stringsList)
        {
            Tower = tower;
            StringsDic = new Dictionary<AttachmentPoint3D, Strings>();
            foreach (AttachmentPoint3D attachmentPoint3D in tower.HangPointList.Values)//串组装至挂点上
            {
                foreach (Strings Strings in stringsList)
                {
                    if ((attachmentPoint3D.Type == Strings.Fittingstring.Type) && (attachmentPoint3D.Voltage == Strings.Voltage))
                    {
                        StringsDic.Add(attachmentPoint3D, Strings);
                        break;
                    }
                }
            }
        }
        [XmlIgnore]
        public Tower Tower { get; set; }

        public string TowerName 
        { 
            get=>Tower.Name; 
            set 
            { this.Tower = OTL.OTLProject.Towers[value];
              this.Tower.HangPointList = OTL.OTLProject.TowersAttachPoint[value];
            } 
        }
        /// <summary>(挂点，金具串) </summary>
        public Dictionary<AttachmentPoint3D, Strings> StringsDic { get; set; }
        /// <summary>
        /// 导线悬挂点
        /// </summary>
        /// <returns></returns>
        public Point3D Hs(AttachmentPoint3D attachmentPoint3D)
        {
            if (attachmentPoint3D.Type == AttachmentType.GN || attachmentPoint3D.Type == AttachmentType.N)
                return attachmentPoint3D.Points.First();
            else if (attachmentPoint3D.Type == AttachmentType.GX || attachmentPoint3D.Type == AttachmentType.I)
                return Point3D.Add(attachmentPoint3D.Points.First(), new Vector3D(0, -StringsDic[attachmentPoint3D].Length, 0));
            else if (attachmentPoint3D.Type == AttachmentType.V|| attachmentPoint3D.Type == AttachmentType.L)
            {
                var qure = (from point in attachmentPoint3D.Points
                           orderby point.X                          
                           select point).ToList();
                return new Point3D(qure[0].X+(qure[1].X- qure[0].X)* ((VStrings)StringsDic[attachmentPoint3D]).Lk, qure[0].Y- StringsDic[attachmentPoint3D].Length, 0);
            }            
            else
                throw new Exception("挂点错误，找不到导线悬挂点");
        }
        /// <summary>
        /// 跳线悬挂点(刚跳有2个)
        /// </summary>
        /// <returns></returns>
        public (Point3D, Point3D?) Hj(AttachmentPoint3D attachmentPoint3D)
        {
            if (attachmentPoint3D.Type == AttachmentType.TI)
                return (new Point3D(attachmentPoint3D.Points[0].X, attachmentPoint3D.Points[0].Y - StringsDic[attachmentPoint3D].Length, 0), null);
            else if (attachmentPoint3D.Type == AttachmentType.TV)
            {
               var qure= attachmentPoint3D.Points.OrderBy(s => s.X).ToList();
                return (new Point3D((qure[0].X+ qure[1].X)/2, qure[0].Y - StringsDic[attachmentPoint3D].Length, 0),null);
            }
            else if (attachmentPoint3D.Type == AttachmentType.GTI)
            {
                return (new Point3D(attachmentPoint3D.Points[0].X, attachmentPoint3D.Points[0].Y - StringsDic[attachmentPoint3D].Length, -(double)StringsDic[attachmentPoint3D].Fittingstring.GLLenth),
                    new Point3D(attachmentPoint3D.Points[0].X, attachmentPoint3D.Points[0].Y- StringsDic[attachmentPoint3D].Length, (double)StringsDic[attachmentPoint3D].Fittingstring.GLLenth));
            }
            else if (attachmentPoint3D.Type == AttachmentType.GTV)
            {
                var qure = (from point in attachmentPoint3D.Points
                            orderby point.Z, point.X
                            select point).ToList();
                return (new Point3D((qure[0].X + qure[1].X) / 2, qure[0].Y - StringsDic[attachmentPoint3D].Length, -(double)StringsDic[attachmentPoint3D].Fittingstring.GLLenth),
                       new Point3D((qure[0].X + qure[1].X) / 2, qure[0].Y - StringsDic[attachmentPoint3D].Length, (double)StringsDic[attachmentPoint3D].Fittingstring.GLLenth));
            }
            else
                throw new Exception("挂点错误，找不到跳线悬挂点");
        }
       
        /// <summary> 悬点高表(电压等级，高度) </summary>
        public Dictionary<Voltage, double> HsList 
        {
            get 
            {
                Dictionary<Voltage, double> myHsList = new Dictionary<Voltage, double>();
                foreach (var Voltage in HsVoltage())
                {
                    var qurey = (from r in StringsDic.Keys
                                 where r.Voltage == Voltage && (r.Type == AttachmentType.N || r.Type == AttachmentType.GN || r.Type == AttachmentType.GX
                                                          || r.Type == AttachmentType.I || r.Type == AttachmentType.L || r.Type == AttachmentType.V)                               
                                 select r).ToList();                   
                    myHsList.Add(Voltage, qurey.Min(s=>Hs(s).Y));                   
                }
                return myHsList;
            }
        }
       
        /// <summary> 跳线高度表(电压等级，高度) </summary>
        public Dictionary<Voltage, double> HjList
        {
            get
            {
                Dictionary<Voltage, double> myHsList = new Dictionary<Voltage, double>();
                foreach (var Voltage in HsVoltage())
                {
                    if (Voltage !=Voltage.G)
                    {
                        var qurey = (from r in StringsDic.Keys
                                     where r.Voltage == Voltage && (r.Type == AttachmentType.TI || r.Type == AttachmentType.TV || r.Type == AttachmentType.GTI
                                                              || r.Type == AttachmentType.GTV )
                                     select r).ToList();
                        myHsList.Add(Voltage, qurey.Min(s => Hj(s).Item1.Y));
                    }                   
                }
                return myHsList;
            }
        }

       
        /// <summary>相间距离( 电压等级,水平,垂直)</summary>
        public List<(Voltage, double, double)> phaseDistance { get; }
        /// <summary>此塔挂点电压等级表</summary>
        private List<Voltage> HsVoltage()
        {
           var vs = new List<Voltage>();
            foreach (var item in StringsDic.Keys)
                if (!vs.Contains(item.Voltage)) vs.Add(item.Voltage);
           return vs;
        }       

    }
}
