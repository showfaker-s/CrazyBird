using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Unit : MonoBehaviour
{
    public Animator _ani;
    
    public GameObject bullet;

    public float flySpeed;
    //每秒发射多少颗
    public float fireSpeed;

    public float HP;

    public bool death = false;
    //fire计时器
    protected float t = 0;


    void Start()
    {
        
    }

    void Update()
    {
        if (death)
        {
            Die();
            return;
        }
        Fire();
        fly();
    }

/*    public void Init()
    {

    }*/
    private void fly()
    {
    }

    protected void Fire()
    {
        t += Time.deltaTime;
        if (t > 1 / fireSpeed)
        {
            GameObject go = Instantiate(bullet);
            go.transform.position = transform.position;
            t = 0;
            //go.GetComponent<Element>().direction = 
        }
    }


    protected void Die()
    {
        death = true;
        _ani.SetTrigger("Die");
        Destroy(this.gameObject, 0.2f);
    }
}
