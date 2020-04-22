using Infrastructure.EntityMode;

namespace Standard.Interface
{
    /// <summary>
    /// 荷载接口，各荷载规范应实现此接口
    /// </summary>
    public interface ILoadCode
    {
        double P4(AbstractWire conductor, Weather weather, LoadType loadType,double L);//风荷载

    }
    /// <summary>
    /// 电气用荷载接口，各电气规范应实现此接口
    /// </summary>
    public interface IELoadCode
    {
         double P4(AbstractWire conductor, Weather weather, LoadType loadType, double L);//风荷载

    }

}
