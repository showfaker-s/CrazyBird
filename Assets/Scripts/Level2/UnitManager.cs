using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public GameObject Enemy1Template;
    public GameObject Enemy2Template;
    public GameObject Enemy3Template;

    List<Enemy> Enemies = new List<Enemy>();

    public float bornSpeed1;
    public float bornSpeed2;
    public float bornSpeed3;




    //销毁管道列表中的管道
    public void Init()
    {
        for (int i = 0; i < Enemies.Count; i++)
        {
            Destroy(Enemies[i].gameObject);
        }
        Enemies.Clear();
    }

    Coroutine coroutine = null;
    public void StartRun()
    {
        coroutine = StartCoroutine(GenarateEnemys());
    }
    public void StopRun()
    {
        StopCoroutine(coroutine);
        for (int i = 0; i < Enemies.Count; i++)
        {
            //隐藏已经生成的
            Enemies[i].enabled = false;

        }
    }
    private float t1 = 0;
    private float t2 = 0;
    private float t3 = 0;
    IEnumerator GenarateEnemys()
    {
        while (true)
        {
            if(t1 > bornSpeed1)
            {
                GenarateEnemy(Enemy1Template);
                t1 = 0;
            }
            if (t2 > bornSpeed2)
            {
                GenarateEnemy(Enemy2Template);
                t2 = 0;
            }
            if (t3 > bornSpeed3)
            {
                GenarateEnemy(Enemy3Template);
                t3 = 0;
            }
            t1++;
            t2++;
            //t3++;



            yield return new WaitForSeconds(1);

        }
    }

    void GenarateEnemy(GameObject template)
    {
        //随时判断空保证安全
        if (template == null) return;

        GameObject obj = Instantiate(template,this.transform);

        Enemy p = obj.GetComponent<Enemy>();
        Enemies.Add(p);
    }

}
