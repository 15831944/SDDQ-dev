using Infrastructure.EntityMode;
using Infrastructure.Enums;
using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace SDDQCore.AssemblyMode
{
    // public  class WireAndCoefficient :IXmlSerializable    ExtendedXmlSerializer对此不辨认
    public class WireAndCoefficient
    {     
        [XmlIgnore]
        public  Conductor Conductor { get; set; }

        public string ConductorName { get=>this.Conductor.Name; set { Conductor = OTL.OTLProject.Conductors[value]; } }
        /// <summary>安全系数 </summary>
        public double F { get; set; } = 2.5;
        /// <summary>平均运行张力百分数</summary>
        public double C { get; set; } = 0.25;

        /// <summary>设计拉断力系数 </summary>
        public double K { get; set; } = 0.95;
        /// <summary>
        /// 放松系数
        /// </summary>
        [XmlIgnore]
        public double Kf { get; set; } = 1;

        /// <summary>
        ///设计用拉断力 
        /// </summary>
       
        public Double DesignTension => this.Conductor.RatedStrength * this.K*this.Kf;          
        /// <summary>                                                                                 
       /// 力学计算用高度                                                                                
       /// </summary>
        public double z { get; set; }


        //public XmlSchema GetSchema()
        //{
        //    return null;
        //}

        //public void ReadXml(XmlReader reader)
        //{
        //    throw new NotImplementedException();
        //}

        //public void WriteXml(XmlWriter writer)
        //{
        //    writer.WriteElementString("Conductor", Conductor.Name);
        //    writer.WriteElementString("F", F.ToString());
        //    writer.WriteElementString("C", C.ToString());
        //    writer.WriteElementString("K", K.ToString());
        //    writer.WriteElementString("Kf", K.ToString());
        //}
    }
}
