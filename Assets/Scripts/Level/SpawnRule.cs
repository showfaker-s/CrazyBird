using UnityEngine;

public class SpawnRule : MonoBehaviour
{
    public Unit monster;

    //��ʼʱ��
    public float InitTime;
    //ˢ������
    public float period;
    //�������
    public int MaxNum;

    public int HP;
    public int attack;

    float timeSinceLevelStart = 0;

    float levelStartTime = 0;
    //���ﵱǰ����
    int curNum = 0;
    float timer = 0;

    /*    public ItemDropRule dropRule;

        ItemDropRule rule;*/
    void Start()
    {
        //��Ϸ����ʱ��
        this.levelStartTime = Time.realtimeSinceStartup;
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLevelStart = Time.realtimeSinceStartup - this.levelStartTime;

        if (curNum >= MaxNum) return;
        if (timeSinceLevelStart > InitTime)
        {//��ʼˢ��
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
