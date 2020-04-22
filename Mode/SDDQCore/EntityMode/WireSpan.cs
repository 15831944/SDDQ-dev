using SDDQCore.EntityMode.MathMode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDDQCore.EntityMode
{
  public   class WireSpan
    {
        public List<CatenaryStruct> Catenarys { get; set; }
        public List<(string,int)> Damper { get; set; }

        public string Spacer { get; set; }

        public List<(int,string)> AntiDance { get; set; }
    }
}
