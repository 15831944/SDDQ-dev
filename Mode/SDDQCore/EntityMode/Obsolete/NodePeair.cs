using Infrastructure.AssemblyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDDQCore.EntityMode
{
    /// <summary>
    /// 节点对
    /// </summary>
    [Obsolete("此类将被抛弃，不要使用，zlf", true)]
    public  class NodePair
    {
        public NodePair(Node node, Node fatherNode)
        {
            Node = node ?? throw new ArgumentNullException(nameof(node));
            FatherNode = fatherNode;
        }

        public Node Node { get; set; }
        public Node FatherNode { get; set; }
        public override  bool Equals(object o)
        {
            if (o == null) return false;
            if (this == o) return true;
            if (o.GetType() == this.GetType())
            {
                if (this.FatherNode==null&& ((NodePair)o).FatherNode==null)
                {
                    if (this.Node == ((NodePair)o).Node) return true;
                     else return false;
                }
                if (this.Node == ((NodePair)o).Node && this.FatherNode == ((NodePair)o).FatherNode) return true;
                else return false;
            }
            else return false;
        }




    }
    [Obsolete("此类将被抛弃，不要使用，zlf", true)]
    public class ThreeNode
    {
        public ThreeNode(Node node, Node sonNode, Node fatherNode)
        {
            Node = node ?? throw new ArgumentNullException(nameof(node));
            SonNode = sonNode;
            FatherNode = fatherNode;
            FatherNodePair = new NodePair(Node, FatherNode);
            SonNodePair= new NodePair(SonNode,Node);
        }

        public Node Node { get;  }
        public Node SonNode { get;}
        public Node FatherNode { get; }
        public NodePair FatherNodePair { get; }
        public NodePair SonNodePair { get; }
    }
}
