using System.Xml.Serialization;

namespace Infrastructure.EntityMode
{
    public  class OPGW:Conductor
    {
        [XmlElement("光缆结构形式")]
        /// <summary>
        /// 光缆结构形式
        /// </summary>
        public string FiberType { get; set; }
        [XmlElement("光缆芯数")]
        public int OpticalFiber { get; set; }

        [XmlElement("短路容量kA2s")]
        public double HeatCapacity { get; set; }
    }
}
