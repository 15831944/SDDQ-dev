using Infrastructure.EntityMode;
using Infrastructure.Enums;
using System;

namespace Infrastructure.EntityMode
{
    /// <summary>
    ///金具串
    /// </summary>
    public class Fittingstring:AbstractEntityIce
    {
        public string Name { get; set; }
        /// <summary>  重量kg</summary>
        public double Weight { get; set; }
        /// <summary>
        /// I串为长度,V串无此属性
        /// </summary>
        public double? Length { get; set; }
        /// <summary>  受风面积m2 </summary>
        public double WindArea { get; set; }
        /// <summary>  联数,V串2起步 </summary>    
        public int Union { get; set; }
        /// <summary>挂点类型</summary>
        public AttachmentType Type { get; set; }
        /// <summary> 钢笼长度 </summary>
        public double? GLLenth { get; set; }

    }
}
