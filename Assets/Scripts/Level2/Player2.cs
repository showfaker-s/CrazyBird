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
    //ÿ�뷢����ٿ�
    public float fireSpeed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
            //����player�������壬������������
            //Instantiate(bullet, this.transform);
            GameObject go = Instantiate(bullet);
            go.transform.position = transform.position;
            t = 0;
        }



    }
}
