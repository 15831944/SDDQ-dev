using System;
using System.Collections.Generic;
using SDDQCore.EntityMode;
namespace SDDQCore.Generic
{
   /// <summary>
   /// 按水平档距降序比较
   /// </summary>
    public   class NodeLhCompare : IComparer<Node>
    {
        public int Compare(Node x, Node y)
        {
            return y.TowerString.Tower.Lh.CompareTo(x.TowerString.Tower.Lh);
        }
    }
    /// <summary>
    /// 按价值比较
    /// </summary>
    public class TupleValueCompare : IComparer<Tuple<Node,Node, int>>
    {
        public int Compare(Tuple<Node, Node, int> x, Tuple<Node,Node, int> y)
        {
            return x.Item3.CompareTo(y.Item3);
        }
    }

}
