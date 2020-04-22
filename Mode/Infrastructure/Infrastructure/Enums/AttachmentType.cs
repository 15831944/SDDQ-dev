using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Enums
{
    /// <summary>挂点类型</summary>
    public enum AttachmentType
    {
        /// <summary>地线耐张</summary>
        GN,
        /// <summary>地线悬垂</summary>
        GX,
        /// <summary>导线耐张</summary>
        N,
        /// <summary>导线悬垂I</summary>
        I,
        /// <summary>导线悬垂V</summary>
        V,
        /// <summary>导线悬垂L</summary>
        L,
        /// <summary>跳线I</summary>
        TI,
        /// <summary>跳线V</summary>
        TV,
        /// <summary> I型刚跳 </summary>
        GTI,
        /// <summary> V型刚跳 </summary>
        GTV,
        /// <summary> 相间 </summary>
        Phase,
    }
}
