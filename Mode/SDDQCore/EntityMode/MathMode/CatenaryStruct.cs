using Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SDDQCore.EntityMode.MathMode
{
    public struct CatenaryStruct
    {
        public Point EPoint;
        public Point SPoint;
        public double P;
        public double T;
        public Voltage Voltage;
        /// <summary>
        /// 导线名称或串名称
        /// </summary>
        public string WireName;
    }
}
