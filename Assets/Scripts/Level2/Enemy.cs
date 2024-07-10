using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator _ani;

    //private Vector2 curPos;

    public float flySpeed;

    public GameObject bullet;
    //每秒发射多少颗
    public float bulletSpeed;

    public float lifeTime;

    public bool death = false;

    void Start()
    {
        Destroy(this.gameObject, lifeTime);
    }
    void Update()
    {
        fly();
        fire();
    }

    private void fly()
    {
        //curPos.x += flySpeed * Time.deltaTime;
        transform.position += new Vector3(flySpeed * Time.deltaTime , 0, 0);
    }
    private float t = 0;
    private void fire()
    {
        t += Time.deltaTime;
        if (t > 1 / bulletSpeed && !death)
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
