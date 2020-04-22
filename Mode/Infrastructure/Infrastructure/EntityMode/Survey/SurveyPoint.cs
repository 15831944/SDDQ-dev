
using Infrastructure.Enums;
using System.Collections.Generic;

namespace Infrastructure.EntityMode
{
   /// <summary>
   /// 测点
   /// </summary>
    public struct SurveyPoint
    {
        /// <summary>里程</summary>
        public int mileage;
        /// <summary>中线高程</summary>
        public (double,double) middle;
        /// <summary>左边线高程</summary>
        public (double, double) left;
        /// <summary>左边线高程</summary>
        public (double, double) right;
        /// <summary>交跨高程</summary>
        public (double, double) cross;
        /// <summary>交跨角度</summary>
        public double? crossAngle;
        /// <summary>线路转角度,11.0118度</summary>
        public double Angle; 
        /// <summary>特征码</summary>
        public int Feature;
     // public FeatureType FeatureType;
        public string Remarks;

    }
}

/// <summary>
/// 风偏测点
/// </summary>
public struct WindPoint
{ 
    /// <summary>里程</summary>
    public int mileage;
    /// <summary>特征码</summary>
    public int feature;
    /// <summary>偏距，与中线高差</summary>
    public List<(double, double)> WindPs;

}
