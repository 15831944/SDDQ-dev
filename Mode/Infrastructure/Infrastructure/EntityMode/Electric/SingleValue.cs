using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityMode
{
    /// <summary>
    /// 单价
    /// </summary>
  public  class SingleValue 
    {     
        /// <summary>
        /// 塔价格 元/kg
        /// </summary>
        public double TowerValue { get; set; }
        /// <summary>
        /// (基础类别, 价格 元/方)
        /// </summary>
        public Dictionary<string,double> FoundationValue { get; set; }
     
        /// <summary>
        /// 金具串价格 元/kg
        /// </summary>
        public double FittingValue { get; set; }
        /// <summary>
        /// （绝缘子代号，价格 元/片、肢）
        /// </summary>
        public Dictionary<string, double> insulatorValue { get; set; }

    }
}
