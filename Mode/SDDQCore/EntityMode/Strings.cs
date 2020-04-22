using Infrastructure.Enums;
using System;
using Infrastructure.EntityMode;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace SDDQCore.EntityMode
{
    /// <summary>
    /// 绝缘子串
    /// </summary>
    public abstract class Strings // by zlf
    {

        /// <summary> 名称="金具名,绝缘子名,单联绝缘子片数"，用来自组装其内部的金具、绝缘子</summary>       
        protected abstract string Name 
        { get; set; }       
       
        /// <summary>  别名,明细表用</summary>       
        public string AliasName { get; set; }
        public Voltage Voltage { get; set; }      
        public abstract double Length { get; set; }
      
        /// <summary>  质量kg </summary>       
        public double Weight { get { return Fittingstring.Weight + Fittingstring.Union * UnitPies * Insulator.Weight; } }
        [XmlIgnore]
        public Fittingstring Fittingstring { get; set; }
        [XmlIgnore]
        public Insulator Insulator { get; set; }
        [XmlIgnore]
        /// <summary>  单联片数 </summary>
        public int UnitPies { get; set; }       
        /// <summary>  受风面积m2 </summary>
        public double WindArea { get { return Fittingstring.WindArea + Fittingstring.Union * UnitPies * Insulator.WindArea; } }
    }
    /// <summary>
    /// V串(含跳串)
    /// </summary>
    public class VStrings : Strings
    {
        /// <summary>
        /// V串等效长度，L串为低挂点至导线悬点高度
        /// </summary>
            
        public override double Length { get; set; }
        /// <summary>
        ///   转角外肢挂点至导线与两挂点比值>=0.5,V串为0.5
        /// </summary>
        public double Lk { get; set; } = 0.5;
        protected override string Name
        {
            get => Fittingstring.Name + "," + Insulator.TypeCode + "," + UnitPies + "," + Vangle;            
            set
            {
                var otl = OTL.OTLProject;
                string[] s = value.Split(',');
                Fittingstring = otl.Fittingstrings[s[0]];               
                Insulator = otl.Insulators[s[1]];
                this.UnitPies = int.Parse(s[2]);
                Vangle=double.Parse(s[3]);
            }
        }             
        /// <summary>
        /// V串角度
        /// </summary>
        public double Vangle { get; set; }
    }
    /// <summary>
    /// I串(含跳串、耐张串)
    /// </summary>
    public class IStrings : Strings
    {
        
        [XmlIgnore]
        public override double Length 
        {
            get
            {
               if (Insulator == null) return (double)Fittingstring.Length;
                return (double)Fittingstring.Length + Insulator.Length * UnitPies;               
            }
            set { }
        }
        protected override string Name
        {
            get
            {
                if (Insulator == null) return Fittingstring.Name;
                return Fittingstring.Name + "," + Insulator.TypeCode + "," + UnitPies;
            }
            set 
            {
                var otl = OTL.OTLProject;
                string[] s = value.Split(',');
                Fittingstring = otl.Fittingstrings[s[0]];
                if (s.Length > 1)
                {
                    Insulator = otl.Insulators[s[1]];
                    this.UnitPies = int.Parse(s[2]);
                }                  
            }
        }          
    }
}
