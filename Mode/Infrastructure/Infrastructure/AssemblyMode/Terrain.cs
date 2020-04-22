using Infrastructure.EntityMode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.AssemblyMode
{
    /// <summary>
    /// 勘测数据集合
    /// </summary>
 public class Terrain
    {
        /// <summary>双里程表</summary>
        public DualMileageTable DualMileageTable { get; set; }
        public double SurveyPointWidth { get; set; }
        /// <summary>
        ///   测点：里程为总里程
        /// </summary>
        public List<SurveyPoint> SurveyPoints { get; set; }//dxd
        /// <summary>
        ///   风偏点：里程为总里程
        /// </summary>
        public List<WindPoint> WindPoints { get; set; }//wnd
        /// <summary>交跨或钻越点(三维校验用)</summary>
        public List<CrossPoint> CrossPoints { get; set; }//cros
        /// <summary>
        ///   水文：里程为总里程
        /// </summary>
        public List<Hydrology> Hydrologies { get; set; }//hyd
        /// <summary>
        /// 树木：里程为总里程
        /// </summary>
        public List<Tree> Trees { get; set; }//tre
    }
}
