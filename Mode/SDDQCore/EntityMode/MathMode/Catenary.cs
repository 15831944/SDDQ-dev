using SDDQCore.TheoreticalMode;
using System;
using System.Windows;


namespace SDDQCore.EntityMode.MathMode
{
    public enum LocSide { befor,after,}
   public class Catenary
    {
       public Point StarP;
       public Point EndP;
       public double P;
       public double T;
       public Catenary(){}
       public Catenary(double P, double T, Point StarP, Point EndP)
        {
           this.P = P;
           this.T = T;
           this.StarP = StarP;
           this.EndP = EndP;
        }

       public Catenary(double Flexion, Point StarP, Point EndP)
       {
           this.P = 1;
           this.T = Flexion;
           this.StarP = StarP;
           this.EndP = EndP;
       }
        /// <summary>
        /// 悬线常数(T/p)
        /// </summary>
        public double C => T / P;
       /// <summary>
       /// 线长
       /// </summary>
       public double Loc
       {
           get { return Math.Sqrt(Math.Pow(2 * C * Math.Sinh(L / (2 * C)), 2) + Math.Pow(h, 2)); }   //已核实
       }      
       
       /// <summary>电线最低点至起始悬挂点的水平距离</summary>    
       public double XoA { get { return L / 2 - C * AsinH(h / (2 * C * Math.Sinh(L / (2 * C)))); } }  //已核实
       /// <summary>电线最低点至终止悬挂点的水平距离</summary>    
       public double XoB { get { return this.L - this.XoA; } }

       /// <summary>电线最低点至起始悬挂点的垂直距离</summary>    
       public double YoA { get { return C * (Math.Cosh(this.XoA / C) - 1); } }//已核实
       /// <summary>电线最低点至终止悬挂点的垂直距离</summary>    
       public double YoB { get { return C * (Math.Cosh(this.XoB / C) - 1); } }//已核实

       /// <summary>起始悬挂点的垂直分量</summary>    
       public double GAv { get { return T * Math.Sinh(this.XoA / C); } }//已核实
       /// <summary>终止悬挂点的垂直分量</summary>    
       public double GBv { get { return T * Math.Sinh(this.XoB / C); } }//已核实
       /// <summary>
       /// 曲线方程
       /// </summary>
       /// <param name="X"></param>
       /// <returns></returns>
       public double Y(double X)
       {
           return C * (Math.Cosh((X - (this.StarP.X + this.XoA)) / C) - 1) + (this.StarP.Y - this.YoA);//已核实
       }
       /// <summary>
       /// 曲线斜率
       /// </summary>
       /// <param name="X"></param>
       /// <returns></returns>
       public double dY(double X)
       {
           return (Math.Sinh((X - (this.StarP.X + this.XoA)) / C));
       }
       /// <summary>
       /// 线长反推张力
       /// </summary>
       /// <param name="Loc"></param>
       /// <param name="EndPoint"></param>
       /// <param name="StarPoint"></param>
       /// <param name="P"></param>
       /// <returns></returns>
       public static double solveT(double Loc, Point EndPoint, Point StarPoint, double P)
       {
           if ((EndPoint -StarPoint).Length >= Loc) return double.PositiveInfinity;
           else
           {
               double K0 = Const.MIN, K1 = Const.INF, K2 = (K1 + K0) / 2;
               double Loc0 = GetLoc(K0, EndPoint, StarPoint) - Loc;
               double Loc1 = GetLoc(K1,EndPoint, StarPoint) - Loc;
               double Loc2 = GetLoc(K2, EndPoint, StarPoint) - Loc;
               while (Math.Abs(Loc2) > Const.MIN)
               {
                   if (Loc2 > 0)
                   {
                       K0 = K2;
                       K2 = (K1 + K0) / 2;

                   }
                   else
                   {
                       K1 = K2;
                       K2 = (K1 + K0) / 2;
                   }

                   Loc2 = GetLoc(K2, EndPoint, StarPoint) - Loc;

               }
               return K2 * P;
           }

       }

       public static double GetLoc(double Flexion, Point StarP, Point EndP)
       {        
         return new Catenary(Flexion,StarP,EndP).Loc;
       }
       public double GetY(double Loc,LocSide LocSide)
       {
           double Xs = this.StarP.X;
           double Xe = this.EndP.X;
           double Xav = (Xs+Xe)/2;
          
           if (LocSide == LocSide.after)
           {
               Catenary Catenaryav = new Catenary(this.C, this.StarP, new Point(Xav, this.Y(Xav)));
               while (Math.Abs(Catenaryav.Loc-Loc)>Const.error)
               {
                   if (Catenaryav.Loc>Loc)
                   {
                       Xe = Xav;
                       Xav = (Xs+Xe)/2;
                   }
                   else
                   {
                       Xs = Xav;
                       Xav = (Xs + Xe) / 2;
                   }
                   Catenaryav = new Catenary(this.C, this.StarP, new Point(Xav, this.Y(Xav)));
               }
              
           }
           else
           {
               Catenary Catenaryav = new Catenary(this.C,  new Point(Xav, this.Y(Xav)),this.EndP);
               while (Math.Abs(Catenaryav.Loc - Loc) > Const.error)
               {
                   if (Catenaryav.Loc > Loc)
                   {
                       Xs = Xav;
                       Xav = (Xs + Xe) / 2;
                   }
                   else
                   {
                       Xe = Xav;
                       Xav = (Xs + Xe) / 2;
                   }
                   Catenaryav = new Catenary(this.C, new Point(Xav, this.Y(Xav)), this.EndP);
               }
           }
           return this.Y(Xav);
       }
   
       /// <summary>
       /// 起始悬挂点的垂直分量
       /// </summary>
       /// <param name="P"></param>
       /// <param name="T"></param>
       /// <param name="StarP"></param>
       /// <param name="EndP"></param>
       /// <returns></returns>
       public static double GetGAv(double P, double T, Point StarP, Point EndP)
       {
           return new Catenary(P, T, StarP, EndP).GAv;
       }
       /// <summary>
       /// 终止悬挂点的垂直分量
       /// </summary>
       /// <param name="P"></param>
       /// <param name="T"></param>
       /// <param name="StarP"></param>
       /// <param name="EndP"></param>
       /// <returns></returns>
       public static double GetGBv(double P, double T, Point StarP, Point EndP)
       {
           return new Catenary(P, T, StarP, EndP).GBv;
       }

       /// <summary>
       /// 线长反推后侧挂点(给定X点)
       /// </summary>
       /// <param name="Loc"></param>
       /// <param name="Flexion"></param>
       /// <param name="StarPoint"></param>
       /// <param name="X"></param>
       /// <returns></returns>
       public static Point[] GetPointX(double Loc,double Flexion, Point StarPoint,double X)
       {
           double Y1 = StarPoint.Y + Math.Sqrt(Math.Pow(Loc, 2) - Math.Pow(X, 2)) - Const.MIN;
           double Y2 = StarPoint.Y - Math.Sqrt(Math.Pow(Loc, 2) - Math.Pow(X, 2)) + Const.MIN;
           double Y3 = StarPoint.Y;
           double Y4 = (Y1 + Y3) / 2;//上部中点
           double Y5 = (Y2 + Y3) / 2;//下部中点

          
           double Loc4 = GetLoc(Flexion, StarPoint, new Point(X, Y4)) - Loc;
           if (GetLoc(Flexion, StarPoint, new Point(X, Y3))>Loc)
           {
              return new Point[2] { new Point(X,Double.NaN), new Point(X, Double.NaN) };  
           }

           while (Math.Abs(Loc4) > Const.MIN)
           {if (Loc4 > 0)  //上部中点值大于0往下找点
               {   Y1 = Y4;   //上点下移
                   Y4 = (Y3 + Y1) / 2; //新中点
               }
               else{
                   Y3 = Y4;
                   Y4 = (Y3 + Y1) / 2;  }
               Loc4 = GetLoc(Flexion, StarPoint, new Point(X, Y4)) - Loc;
           }
           double Loc5 = GetLoc(Flexion, StarPoint, new Point(X, Y5)) - Loc;
           while (Math.Abs(Loc5) > Const.MIN)
           {
               if (Loc5 > 0)  //下部中点值大于0往上找点
               {
                   Y2 = Y5;   //下点上移
                   Y5 = (Y3 + Y2) / 2; //新中点
               }
               else
               {
                   Y3 = Y5;
                   Y5 = (Y3 + Y2) / 2;
               }
               Loc5 = GetLoc(Flexion, StarPoint, new Point(X, Y5)) - Loc;
           } 
           return new Point[2] { new Point(X, Y4), new Point(X, Y5) };
       }
       /// <summary>
       /// 线长反推后侧挂点(给定dY)
       /// </summary>
       /// <param name="Loc"></param>
       /// <param name="Flexion"></param>
       /// <param name="StarPoint"></param>
       /// <param name="dY">相对于StarPoint.Y的差值</param>
       /// <returns></returns>
       public static Point GetPointYb(double Loc, double Flexion, Point StarPoint, double dY)
       {
           if (Math.Abs(dY) >= Loc)
           {
               return new Point(double.NaN, StarPoint.Y + dY);
           }
           else
           {
               double Xstar = StarPoint.X + Const.MIN;
               double Xend = StarPoint.X + Math.Sqrt(Math.Pow(Loc, 2) - Math.Pow(dY, 2)) - Const.MIN;
               double Xave = (Xstar + Xend) / 2;
               double Locave = GetLoc(Flexion, StarPoint, new Point(Xave, StarPoint.Y + dY));
               while (Math.Abs(Locave - Loc) > Const.MIN)
               {
                   if (Locave > Loc)
                   {
                       Xend = Xave;
                       Xave = (Xstar + Xend) / 2;
                   }
                   else
                   {
                       Xstar = Xave;
                       Xave = (Xstar + Xend) / 2;
                   }
                   Locave = GetLoc(Flexion, StarPoint, new Point(Xave, StarPoint.Y + dY));
               } return new Point(Xave, StarPoint.Y + dY);
           }

       }
       /// <summary>
       /// 线长反推前侧挂点(给定dY)
       /// </summary>
       /// <param name="Loc"></param>
       /// <param name="Flexion"></param>
       /// <param name="EndPoint"></param>
       /// <param name="dY">相对于EndPoint.Y的差值</param>
       /// <returns></returns>
       public static Point GetPointYa(double Loc, double Flexion, Point EndPoint, double dY)
       {
           if (Math.Abs(dY) >= Loc)
           {
               return new Point(double.NaN, EndPoint.Y + dY);
           }
           else
           {
               double Xend = EndPoint.X - Const.MIN;
               double Xstar = EndPoint.X - Math.Sqrt(Math.Pow(Loc, 2) - Math.Pow(dY, 2)) + Const.MIN;
               double Xave = (Xstar + Xend) / 2;
               double Locave = GetLoc(Flexion,new Point(Xave, EndPoint.Y + dY), EndPoint);
               while (Math.Abs(Locave - Loc) > Const.MIN)
               {
                   if (Locave > Loc)
                   {
                       Xstar = Xave;
                       Xave = (Xstar + Xend) / 2;
                   }
                   else
                   {
                       Xend = Xave;
                       Xave = (Xstar + Xend) / 2;
                   }
                   Locave = GetLoc(Flexion, new Point(Xave, EndPoint.Y + dY), EndPoint);
               } return new Point(Xave, EndPoint.Y + dY);
           }

       }
       #region 私有方法     
       /// <summary>
       /// 高差
       /// </summary>
       public double h
       {
           get { return EndP.Y - StarP.Y; }
       }
       /// <summary>
       /// 档距
       /// </summary>
       public double L
       {
           get { return EndP.X - StarP.X; }
       }
       /// <summary>反双曲正弦</summary>
       private double AsinH(double x)
       { return Math.Log(x + Math.Sqrt(x * x + 1)); }
       /// <summary>反双曲余弦</summary>
       private double AcosH(double x)
       { return Math.Log(x + Math.Sqrt(x * x - 1)); }
       #endregion

    }
     
}
