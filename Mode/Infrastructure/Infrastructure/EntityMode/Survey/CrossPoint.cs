using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Media3D;

namespace Infrastructure.EntityMode
{
    /// <summary>
    /// 交跨或钻越点
    /// </summary>
   public struct CrossPoint
    {
        /// <summary>总里程</summary>
        public int mileage;
        /// <summary>双里程</summary>
        public int secondarymileage;
        /// <summary>交点坐标（Y为顺线路方向，X向右）</summary>
        public Point CPoint { get; set; }
        public List<Point3D> Points { get; set; }
}
}
