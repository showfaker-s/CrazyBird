using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Const;


public class Enemy : Unit
{
    public Animator _ani;

    //private Vector2 curPos;

    public float flySpeed;

    public GameObject bullet;
    //每秒发射多少颗
    public float fireSpeed;

    public float lifeTime;

    public bool death = false;

    public E_Enemy_TYPE enemyType;


    void Start()
    {
        Destroy(this.gameObject, lifeTime);
        Init();
    }
    //生成enemy的位置
    public Vector2 range;

    float Inity = 0;
    private void Init()
    {
        Inity = UnityEngine.Random.Range(range.x, range.y);
        //改y
        transform.localPosition += new Vector3(0, Inity, 0);
    }

    void Update()
    {
        fly();
        fire();
    }


    private void fly()
    {
        float y = 0;
        if (enemyType == E_Enemy_TYPE.SWING)
        {
            y = Mathf.Sin(Time.timeSinceLevelLoad) * 3f;
        }
        //curPos.x += flySpeed * Time.deltaTime;
        //transform.position = new Vector3(flySpeed * Time.deltaTime , y, 0);
        //transform.localPosition = new Vector3(this.transform.position.x - (Time.deltaTime * flySpeed), Inity + y);
        this.transform.position = new Vector3(this.transform.position.x - Time.deltaTime * flySpeed, Inity + y);

    }
    private float t = 0;
    private void fire()
    {
        t += Time.deltaTime;
        if (t > 1 / fireSpeed && !death)
        {
            //会变成player的子物体，跟着子物体走
            //Instantiate(bullet, this.transform);
            //GameObject go = Instantiate(bullet);
            GameObject go = Instantiate(bullet, transform.position, Quaternion.identity, this.transform);
            go.transform.position = transform.position;
            //go.GetComponent<Element>().Dir = 1;
            //改颜色
/*            SpriteRenderer[] SRs = go.GetComponentsInChildren<SpriteRenderer>();
            foreach(SpriteRenderer sr in SRs)
            {
                sr.color = Color.red;
            }*/

            t = 0;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player_Bullet")){
            Die();
        }
    }

    private void Die()
    {
        death = true;
        
        _ani.SetTrigger("Die");
        Destroy(this.gameObject,0.2f);

    }
}
