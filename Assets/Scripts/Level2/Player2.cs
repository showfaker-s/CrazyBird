using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : Unit
{
    public Animator _ani;

    private Vector2 curPos;

    public float flyspeed;

    public GameObject bullet;
    //ÿ�뷢����ٿ�
    public float fireSpeed;

    public float HP;

    private bool death;

    public delegate void DeathNotify();

    public event DeathNotify Ondeath;
    //û����
    public delegate void AtkedNotify();

    public event DeathNotify Atked;
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
        curPos.x += Input.GetAxis("Horizontal") * Time.deltaTime * flyspeed;
        curPos.y += Input.GetAxis("Vertical") * Time.deltaTime * flyspeed;
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
            //����player�������壬������������
            //Instantiate(bullet, this.transform);
            GameObject go = Instantiate(bullet);
            go.transform.position = transform.position;
            t = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Element bullet = collision.GetComponent<Element>();
        if (collision.gameObject.CompareTag("Enemy_Bullet"))
        {
            HP = HP - bullet.power;
            //���ܵ���0
            if(HP <= 0)
            {
                death = true;
            }
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            death = true;
            HP = 0;
        }


    }

    private void Die()
    {
        Destroy(this.gameObject, 0.2f);
    }
}
