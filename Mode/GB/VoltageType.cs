using System;
using System.Collections.Generic;
using System.Text;

namespace Standard
{

    public enum εcVoltageType
    {
        /// <summary>
        /// 110kV-330kV
        /// </summary>
        A,
        /// <summary>
        /// 500kV-750kV
        /// </summary>
        B,
        /// <summary>
        /// 特高压
        /// </summary>
        C,
        /// <summary>
        /// 大跨越
        /// </summary>
        D
    }    
   
    public enum γcType
    {
        /// <summary>
        /// 非特高压跳线
        /// </summary>
        CT,
        /// <summary>
        /// 特高压跳线
        /// </summary>
        TT,
        /// <summary>
        /// 大跨越
        /// </summary>
        L,
        /// <summary>
        /// 一般线路
        /// </summary>
       C
    }

}
