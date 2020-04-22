using Infrastructure.Generic;
using System;
using System.Linq;
using System.Collections.Generic;
using Infrastructure.Enums;

namespace Infrastructure.AssemblyModel
{
    /// <summary>
    /// 地形(生成TOPO文件)
    /// </summary>
    public  struct  TOPO
    {
     
        public TOPO(Voltage voltage,int width) : this()
        {
            this.width = width;
            Voltage = voltage;
            this.Points = new List<TerrainPoint>();
        }

        /// <summary> 测量边线宽度 </summary>
        public int width { get; set; }
        /// <summary> 预处理允许高程所用电压 </summary>
        public Voltage Voltage { get; set; }
        /// <summary>预处理后地面模型数据</summary>
        public List<TerrainPoint> Points { get; set; }
        public IEnumerable<TerrainPoint> GetPointSet(int mileageLow,int mileageUp)
        {
            return Points.Where(Point =>  ((Point.mileage <= mileageUp) && (Point.mileage >= mileageLow)));
        }
    }
    /// <summary>
    ///  预处理后地面模型数据点
    /// </summary>
    public struct  TerrainPoint
    {
        /// <summary>里程（米）</summary>
        public int mileage;
        /// <summary>中线高程(分米)</summary>
        public int middle;
        /// <summary>允许高程(分米)</summary>       
        public int acceptElev;
        /// <summary>转角度数</summary>       
        public double angle;
        /// <summary>半径等于边线宽时的设计高差(分米)</summary>
        public int elevationDiff;
        /// <summary>0为不可立塔，1可立塔，2为必须塔位</summary>
        public int allow;
        /// <summary>1为可立第1大组塔，2为可立第2大组塔</summary>
        public int GroupNo;
        /// <summary>杆塔代号,在X大组中的号,0为任意</summary>
        public int TowerNo;
        /// <summary>基础类型</summary>
        public string FoundationType;

        public TerrainPoint(int mileage, int middle, int acceptElev, int elevationDiff, double angle, string foundationType) : this()
        {
            this.mileage = mileage;
            this.middle = middle;
            this.acceptElev = acceptElev;
            this.angle = angle;
            this.elevationDiff = elevationDiff;
            FoundationType = foundationType ?? throw new ArgumentNullException(nameof(foundationType));
        }

        public TerrainPoint(int mileage, int middle, int acceptElev, int elevationDiff, double angle, int allow, int groupNo, int towerNo, string foundationType)
        :this(mileage, middle, acceptElev, elevationDiff, angle, foundationType)
        {
            this.allow = allow;
            GroupNo = groupNo;
            TowerNo = towerNo;           
        }



    }
}
