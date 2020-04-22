using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Geometry
{
  public  class Coordinate
    {
      public string X { get; set; }
     public string Y { get; set; }
     public CoordinateSystem CoordinateSystem { get; set; }

    }
    public enum CoordinateSystem
    {
        /// <summary>北京54</summary>
        BJ54,
        /// <summary>西安80</summary>
        XA80,
        /// <summary>2000国家大地坐标系</summary>
        CGCS2000,
        /// <summary>经纬度</summary>
        GCS,
    }
}
