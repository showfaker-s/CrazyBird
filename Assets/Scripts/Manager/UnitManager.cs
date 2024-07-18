using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoSingleton<UnitManager>
{
    public List<Enemy> enemies = new List<Enemy>();

    Coroutine coroutine = null;

    public Enemy GenarateEnemy(GameObject template)
    {
        //随时判断空保证安全
        if (template == null || LevelManager.Instance.level.result != Level.LEVEL_RESULT.NONE) return null;

        GameObject obj = Instantiate(template, this.transform);
        Enemy p = obj.GetComponent<Enemy>();
        this.enemies.Add(p);
        //进行后续处理
        return p;
    }
    public void Stop()
    {
        this.enemies.Clear();
    }
}
