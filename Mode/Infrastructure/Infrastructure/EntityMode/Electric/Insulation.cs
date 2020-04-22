using Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityMode
{
  public  class Insulation
    {
        /// <summary>
        /// 污区等级
        /// </summary>
        public string Pollution { get; set; }
        /// <summary>
        /// 悬垂配置片数
        /// </summary>
        public Dictionary<Voltage,Dictionary<string,int>> IString { get; set; }
        /// <summary>
        /// 耐张配置片数
        /// </summary>
        public Dictionary<Voltage, Dictionary<string, int>> NString { get; set; }
    }
}
