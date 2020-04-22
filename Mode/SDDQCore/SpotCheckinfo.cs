using Infrastructure.AssemblyModel;
using SDDQCore.EntityMode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDDQCore
{
  public  class SpotCheckInfo
    {
      
        /// <summary>
        /// 塔串组合规则
        /// </summary>
        public List<(int TowerGroup,int StringsGroup)> TowerStringRule { get; set; }
        /// <summary>塔串组：Tkey为组号，可通过[组号][塔序号]索引</summary>
        public Dictionary<int, List<TowerString>> TowerStringDic { get; set; }//XML后需自组装
        public List<(int StarMileage, int EndMileage,int TowerStringGroup)> SectionTowerString { get; set; }
        public List<(int StarMileage, int EndMileage, string FoundationType)> SectionFoundationType { get; set; }
       /// <summary>
       /// 点位立塔规则
       /// </summary>
        public List<(int StarMileage, int EndMileage,string Rule)> TowerRule { get; set; }
        /// <summary>
        /// 塔位与交叉物水平禁距
        /// </summary>
        public double CrossHoriz { get; set; }
        public int minSpan { get; set; }
        public int MaxSpan { get; set; }
    }
}
