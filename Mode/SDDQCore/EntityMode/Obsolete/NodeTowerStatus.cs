
using SDDQCore.TheoreticalMode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SDDQCore.EntityMode
{
    [Obsolete("此类将被抛弃，不要使用，zlf", true)]
    public  class NodeTowerStatus
    {
        //public NodeTowerStatus(Node fatherNode,Node node, Node sonNode,string voltage,double fatherK, double sonK)
        //{
        //    Node = node ?? throw new ArgumentNullException(nameof(node));
        //    if (fatherNode == null) fatherCatenary = null;
        //    else fatherCatenary =new Parabola(new intPoint(fatherNode.mileage, fatherNode.Hs[voltage]), new intPoint(node.mileage, node.Hs[voltage]), fatherK);
        //    if (sonNode == null) sonCatenary = null;
        //    else sonCatenary = new Parabola(new intPoint(node.mileage, node.Hs[voltage]), new intPoint(sonNode.mileage, sonNode.Hs[voltage]), sonK);
        //}
        //public NodeTowerStatus(Node fatherNode, Node node, Parabola sonCatenary, string voltage, double fatherK)
        //{
        //    Node = node ?? throw new ArgumentNullException(nameof(node));
        //    if (fatherNode == null) fatherCatenary = null;
        //    else fatherCatenary = new Parabola(new intPoint(fatherNode.mileage, fatherNode.Hs[voltage]), new intPoint(node.mileage, node.Hs[voltage]), fatherK);
        //   this.sonCatenary = sonCatenary;
        //}

        //private Parabola fatherCatenary { get; set; }
        //private Parabola sonCatenary { get; set; }
        ///// <summary>
        ///// 此杆塔节点
        ///// </summary>
        //public Node Node { get; }
        ///// <summary>垂直档距</summary>
        //public double Lv 
        //{
        //    get
        //    {
        //        if (fatherCatenary == null) return sonCatenary.ALv;
        //        else if (sonCatenary == null) return fatherCatenary.BLv;
        //        else return fatherCatenary.BLv + sonCatenary.ALv;
        //    }
        //}
        ///// <summary>水平档距</summary>
        //public double Lh
        //{
        //    get
        //    {
        //        if (fatherCatenary == null) return sonCatenary.Lh;
        //        else if (sonCatenary == null) return fatherCatenary.Lh;
        //        else return fatherCatenary.Lh + sonCatenary.Lh;
        //    }
        //}

        //public double kv => Lh / Lv;






    }
}
