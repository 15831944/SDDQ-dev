using Infrastructure.EntityMode;
using SDDQCore.EntityMode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDDQCore.EntityMode
{
    /// <summary>
    /// 排位段信息
    /// </summary>
  public  struct Segment
    {
        /// <summary>区间（起，止）</summary>
        public Tuple<double, double> Interval;
        /// <summary>导线K值</summary>
        public List<(Tuple<double, double>, K)> ConductorKList;
        public List<(Tuple<double, double>, K)> EarthwireKList;
        /// <summary>最小档距m</summary>
        public int MinSpan;
        /// <summary>最大档距m</summary>
        public int MaxSpan;
        /// <summary>步长m</summary>
        public int Step;
        /// <summary>地质情况</summary>
        public List<Geology> GeologyList;
        /// <summary>材料单价</summary>
        public SingleValue SingleValue;

        public Segment(Tuple<double, double> interval, List<(Tuple<double, double>, K)> conductorKList,
             List<(Tuple<double, double>, K)> earthwireKList, int minSpan,int maxSpan, int step, List<Geology> geologyList, SingleValue singleValue)
        {
            Interval = interval ?? throw new ArgumentNullException(nameof(interval));
            ConductorKList = conductorKList ?? throw new ArgumentNullException(nameof(conductorKList));
            EarthwireKList = earthwireKList ?? throw new ArgumentNullException(nameof(earthwireKList));
            MinSpan = minSpan;
            MaxSpan = maxSpan;
            Step = step;
            GeologyList = geologyList ?? throw new ArgumentNullException(nameof(geologyList));
            SingleValue = singleValue ?? throw new ArgumentNullException(nameof(singleValue));
        }

        public K GetK(double mileage)
        {            
            foreach (var item in ConductorKList)
            {
                if (item.Item1.Item1<= mileage&& mileage <= item.Item1.Item2)
                {
                    return item.Item2;
                }
            }
            throw new Exception("里程不在排位段内");
        }
        public Geology GetGeology(double mileage)
        {
            foreach (var item in GeologyList)
            {
                if (item.Interval.Item1 <= mileage && mileage <= item.Interval.Item2)
                {
                    return item;
                }
            }
            throw new Exception("里程不在排位段内");
        }

    }
}
