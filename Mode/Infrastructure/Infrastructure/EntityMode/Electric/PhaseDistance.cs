using Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityMode
{
  public  class PhaseDistance
    {
        public string voltage { get; set; }
        /// <summary>
        /// 水平距离
        /// </summary>
        public double Dp { get; set; }
        /// <summary>
        /// 垂直距离
        /// </summary>
        public double Dz { get; set; }
        /// <summary>
        /// 等效线间距离
        /// </summary>
        /// <param name="IPhaseDistance">符合此接口的规范</param>
        /// <returns></returns>
        public double Dx(IPhaseDistance IPhaseDistance) { return IPhaseDistance.Dx(this.Dp,this.Dz); }
    }
}
