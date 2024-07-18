using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Level : MonoBehaviour
{

    public int LevelID;
    public string Name;

    public BOSS Boss;

    public List<SpawnRule> Rules = new List<SpawnRule>();

    
    public UnityAction<LEVEL_RESULT> OnLevelEnd;

    float timeSinceLevelStart = 0;

    float levelStartTime = 0;


    public float bossTime = 60f;

    float timer = 0;

    BOSS boss = null;
    public enum LEVEL_RESULT
    {
        NONE,
        SUCCESS,
        FAILD
    }

    public LEVEL_RESULT result = LEVEL_RESULT.NONE;

    Coroutine coroutine = null;
    private void Start()
    {
        StartRun();
    }
    public void StartRun()
    {

        if(coroutine == null) 
        coroutine = StartCoroutine(RunLevel()); 
    }
    public void StopRun()
    {
        StopCoroutine(coroutine);
    }
    IEnumerator RunLevel()
    {
        //UIManager.Instance.ShowLevelStart(string.Format("LEVEL {0} {1}", this.LevelID, this.Name));
        yield return new WaitForSeconds(2f);

        for (int i = 0; i < Rules.Count; i++)
        {
            SpawnRule rule = Instantiate<SpawnRule>(Rules[i]);
        }
    }


    void Update()
    {
        timeSinceLevelStart = Time.realtimeSinceStartup - this.levelStartTime;

        if (this.result != LEVEL_RESULT.NONE)
        {
            if (boss != null) Destroy(boss,0.2f);
            return;
        }

        if (timeSinceLevelStart > bossTime)
        {
            if (boss == null)
            {
                timer = 0;
                boss = (BOSS)UnitManager.Instance.GenarateEnemy(this.Boss.gameObject);
                boss.target = Game2.Instance.player2;
                boss.Fly();
                boss.OnDeath += Boss_OnDeath;

            }
        }
    }

    private void Boss_OnDeath(Unit sender)
    {
        this.result = LEVEL_RESULT.SUCCESS;
        if (this.OnLevelEnd != null)
        this.OnLevelEnd(this.result);
    }
}
