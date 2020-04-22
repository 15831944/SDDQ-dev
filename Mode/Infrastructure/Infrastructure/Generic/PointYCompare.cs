using System;
using System.Collections.Generic;
using System.Windows;
namespace Infrastructure.Generic
{
    [Obsolete("此类将被抛弃，不要使用，zlf", true)]
    public class PointYCompare : IComparer<Point>
    {
        public int Compare(Point x, Point y)
        {
            return x.Y.CompareTo(y.Y);
        }
    }
}
