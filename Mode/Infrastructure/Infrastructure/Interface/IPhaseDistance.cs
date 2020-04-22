using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interface
{
    /// <summary>
    /// 线间距离计算接口（各电气规范应实现）
    /// </summary>
    public interface IPhaseDistance
    {
        double Dx(double Dp, double Dz);
        double D(double ki, double Lk,double U,double fc);
    }
}
