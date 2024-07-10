using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public GameObject EnemyTemplate;

    List<Enemy> Enemies = new List<Enemy>();

    public float bornSpeed;

    //生成enemy的位置
    public Vector2 range;


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
    IEnumerator GenarateEnemys()
    {
        while (true)
        {
            GenarateEnemy();



            yield return new WaitForSeconds(bornSpeed);

        }
    }

    void GenarateEnemy()
    {
        float y = UnityEngine.Random.Range(range.x, range.y);
        GameObject obj = Instantiate(EnemyTemplate, transform);
        //改y
        obj.transform.localPosition = new Vector3(0, y, 0);
        Enemy p = obj.GetComponent<Enemy>();
        Enemies.Add(p);
    }

}
