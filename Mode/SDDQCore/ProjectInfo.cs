using Infrastructure.Enums;
using SDDQCore.Enums;
using System.Collections.Generic;

namespace SDDQCore
{
    public  class ProjectInfo
    {
        /// <summary>  名称  </summary>       
        public string Name { get; set; }        
        public SortedSet<Voltage> Voltages { get; set; } 
        /// <summary>重力加速度 </summary>  
        public double g { get; set; }
        public double IceDensity { get; set; }
        /// <summary>
        /// 地线力学方式
        /// </summary>
        public EarthWireMechanicalType EarthWireMechanicalType { get; set; }
        /// <summary>
        /// 风输入方式
        /// </summary>
        public WindInputType WindInputType { get; set; }
        /// <summary>
        ///  实现结构荷载的规范
        /// </summary>
        public string LoadCode { get; set; }
        /// <summary>
        ///  实现电气荷载的规范
        /// </summary>
        public string ELoadCode { get; set; }


    }


}
