using System.Windows;
using System.Collections.Generic;
using Infrastructure.Generic;
using System;
using Infrastructure.Enums;
using Infrastructure.Geometry;
using System.Windows.Media.Media3D;

namespace Infrastructure.EntityMode
{
    /// <summary>
    /// 挂点（全高处为(0,0,0)往下为负Z为线路前进方向）详细定义见OTL编程指南
    /// </summary>
    public abstract class AttachmentPoint3D // by zlf
    {
        public AttachmentPoint3D()
        {
        }
        public AttachmentPoint3D(Voltage voltage, AttachmentType type, List<Point3D> points)
        {
            Type = type;
            Voltage = voltage;
            Points = points;
        }
        public AttachmentType Type { get; set; }
        public List<Point3D> Points { get; set; }
        public Voltage Voltage { get; set; }
    }

    public class IAttachmentPoint3D: AttachmentPoint3D
    {
        public IAttachmentPoint3D() { }
        public IAttachmentPoint3D(Voltage voltage, AttachmentType type, Point3D point3D)
       : base(voltage, type, new List<Point3D> { point3D }) { }
    }

    public class VAttachmentPoint3D : AttachmentPoint3D
    {
        public VAttachmentPoint3D() { }
        public VAttachmentPoint3D(Voltage voltage, AttachmentType type, (Point3D, Point3D) point3Ds,double vangle)              
       : base(voltage, type, new List<Point3D> { point3Ds.Item1, point3Ds.Item2 }) 
        {
            Vangle = vangle;
        }
        public VAttachmentPoint3D(Voltage voltage, AttachmentType type, List<Point3D> point3Ds, double vangle)
        : base(voltage, type, point3Ds)
        {
            Vangle = vangle;
        }
        public double Vangle { get; set; }

    }
}
