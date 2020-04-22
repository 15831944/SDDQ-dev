using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDDQCore.EntityMode
{
    public class Span
    {
        public double SMileage { get; set; }
        public double EMileage { get; set; }
        /// <summary>
        ///悬线
        /// </summary>
        public Dictionary<int,WireSpan> WireSpans { get; set; }
        public bool Connector { get; set; }
        /// <summary>
        /// 相间间隔棒，从小号侧起算距离，线号，线号，名称
        /// </summary>
        public List<(int,int,int,string)> PhaseSpacer { get; set; }

        /// <summary>
        /// 迁改：项目名称，工程量描述
        /// </summary>

        public  List<(string, string)>  Migrate{ get; set; }

        public string Remark { get; set; }
    }
}
