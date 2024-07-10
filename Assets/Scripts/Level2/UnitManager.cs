using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public GameObject EnemyTemplate;

    List<Enemy> Enemies = new List<Enemy>();

    public float bornSpeed;

    //����enemy��λ��
    public Vector2 range;


    //���ٹܵ��б��еĹܵ�
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
            //�����Ѿ����ɵ�
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
        //��y
        obj.transform.localPosition = new Vector3(0, y, 0);
        Enemy p = obj.GetComponent<Enemy>();
        Enemies.Add(p);
    }

}
