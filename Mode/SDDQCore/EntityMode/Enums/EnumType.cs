using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDDQCore.Enums
{
    /// <summary>
    /// 地线力学方式
    /// </summary>
    public enum EarthWireMechanicalType
    {
        /// <summary>
        /// 配合法
        /// </summary>
        Match,
        /// <summary>
        /// 安全系数法
        /// </summary>
        Safety
    }
    public enum WindInputType
    {
        /// <summary>
        /// 风速
        /// </summary>
        Speed,
        /// <summary>
        /// 风压
        /// </summary>
        Press
    }
}
