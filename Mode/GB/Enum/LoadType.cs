using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standard
{
    public enum LoadType
    {
        /// <summary>荷载力学计算</summary>
        M,
        /// <summary>
        /// 荷载计算
        /// </summary>
        ML,
        /// <summary>
        /// 电气力学计算
        /// </summary>
        E,
        /// <summary>
        /// 电气荷载计算
        /// </summary>
        EL,
        /// <summary>
        /// 跳线荷载
        /// </summary>
        TL,
        /// <summary>
        /// 跳线电气
        /// </summary>
        TE
    }
}
