using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.math
{
  public static  class UnitConvert
    {
    public static double WindSpeedToPress(double WindSpeed) => WindSpeed * WindSpeed / 1600;

     public static  double  WindPressToSpeed(double WindPress) => Math.Sqrt(WindPress * 1600);
    }
}
