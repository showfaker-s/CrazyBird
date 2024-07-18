using UnityEngine;

public class SpawnRule : MonoBehaviour
{
    public Unit monster;

    //初始时间
    public float InitTime;
    //刷新周期
    public float period;
    //最大数量
    public int MaxNum;

    public int HP;
    public int attack;

    float timeSinceLevelStart = 0;

    float levelStartTime = 0;
    //怪物当前数量
    int curNum = 0;
    float timer = 0;

    /*    public ItemDropRule dropRule;

        ItemDropRule rule;*/
    void Start()
    {
        //游戏启动时间
        this.levelStartTime = Time.realtimeSinceStartup;
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLevelStart = Time.realtimeSinceStartup - this.levelStartTime;

        if (curNum >= MaxNum) return;
        if (timeSinceLevelStart > InitTime)
        {//开始刷怪
            timer += Time.deltaTime;

            if (timer > period)
            {
                timer = 0;
                Enemy enemy = UnitManager.Instance.GenarateEnemy(this.monster.gameObject);
                enemy.MaxHP = this.HP;
                enemy.attack = this.attack;
                //enemy.OnDeath += Enemy_OnDeath;
                curNum++;
            }
        }
    }
}
