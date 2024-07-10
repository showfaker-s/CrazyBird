using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public Animator _ani;

    private Vector2 curPos;

    public float speed;

    public GameObject bullet;
    //每秒发射多少颗
    public float fireSpeed;

    public float HP;

    private bool death;

    public delegate void DeathNotify();

    public event DeathNotify Ondeath;
    void Start()
    {
        death = false;
    }

    void Update()
    {
        if (death)
        {
            Die();
            return;
        }
        curPos.x += Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        curPos.y += Input.GetAxis("Vertical") * Time.deltaTime * speed;
        if (Input.GetButton("Fire1"))
        {
            Fire();
        }
        this.transform.position = curPos;
    }
    private float t = 0;
    private void Fire()
    {
        t += Time.deltaTime;
        if(t > 1 / fireSpeed)
        {
            //会变成player的子物体，跟着子物体走
            //Instantiate(bullet, this.transform);
            GameObject go = Instantiate(bullet);
            go.transform.position = transform.position;
            t = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy_Bullet"))
        {
            HP--;
            if(HP == 0)
            {
                death = true;
            }
        }

    }

    private void Die()
    {
        Destroy(this.gameObject, 0.2f);
    }
}
