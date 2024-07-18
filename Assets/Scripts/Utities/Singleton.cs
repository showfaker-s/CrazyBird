using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//在不同的类中使用不同的类型参数来创建单例对象
//指定了泛型类型参数 T 必须具有无参构造函数
class Singleton<T> where T : new()
{
    static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                //不能直接使用 new T() 这种方式来实例化对象
                ////因为编译器无法确定 T 的类型是否具有无参构造函数
                instance = new T();
            }
            return instance;

        }
    }
}

