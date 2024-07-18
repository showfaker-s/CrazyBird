using UnityEngine;

//让T类型参数必须是 MonoBehaviour 或其子类
public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                //从场景中去找，因为继承了mono，不能new
                instance = FindObjectOfType<T>();
            }
            return instance;

        }
    }
}

