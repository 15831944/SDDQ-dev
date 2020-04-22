using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDDQCore.WireMechanics
{
    class Tension
    {

        //计算Fm：已知条件，P，档距，气温，拉力
        private double Fm(double p, double l, double t, double t0 ,double A, double E, double a)
        {
            double Fm;
            Fm = A * E * p * p * l * l / (24 * t0 * t0) - t0 - A * a * E * t;
            return Fm;
        }

        //状态方程求解   控制条件fm，档距,截面积，弹性系数，线膨胀系数，P值，气温 ，最大使用张力 f(x)=x^3+ax^2-b
        private double StateSolution(double Fm, double l, double A,double E, double a ,double p, double t, double Tm)
        {
            double tn, tn1;
            double a1 = Fm + A * E * a * t;
            double b1 = A * E * p * p * l * l / 24;
            tn = Tm;
            do

            {
                tn1 = tn;
                tn = tn1 - (tn1 * tn1 * (tn1 + a1) - b1) / (3 * tn1 * tn1 + 2 * a1 * tn1);
            } while (Math.Abs(tn1 - tn) > 10e-6);
            return tn1;
        }
        
        
        //地线控制档距求解 0.102L+1
        public double Controlspan(double h, double S)
        { //二分法求值过程
            double h1;
            double Lq, Lq1, Lq2;
            Lq1 = 40000;
            Lq2 = 10;
           
            do
            {
                Lq = (Lq1 + Lq2) / 2;
                h1 = ((0.012 * Lq) * (0.012 * Lq) + 0.036 * Lq - 2 * (S * S - 1)) / 2 / Math.Sqrt((1 + 0.012 * Lq) * (1 + 0.012 * Lq) - S * S);
                //判断值在函数要求值的上或下方
                if (h > h1)
                    Lq2 = Lq;
                else
                    Lq1 = Lq;

            } while (Math.Abs(h1 - h) > 0.000001);
            return Lq;
        }
    }
}
