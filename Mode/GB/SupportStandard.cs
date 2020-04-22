using System.Collections.Generic;

namespace Standard
{
    /// <summary>
    /// 程序支持的标准集,在UI中通过string类名实列化
    /// </summary>
    public static  class SupportStandard
    {
        public static List<string> ILoadCode { get; }
        public static List<string> IELoadCode { get; }
        public static List<string> ICleanceCode { get; }

       static SupportStandard() 
        {
            ILoadCode = new List<string> { "DLT5551_2018", GB50545_2010.classname};
            //继续
        } 
    }
}
