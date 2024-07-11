using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Unit : MonoBehaviour
{
    public Animator _ani;
    
    public GameObject bullet;

    public float flySpeed;
    //ÿ�뷢����ٿ�
    public float fireSpeed;

    public float HP;

    public bool death = false;
    //fire��ʱ��
    protected float t = 0;

    public E_Element_SIDE side;


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
            //go.GetComponent<Element>().direction = go.GetComponent<Element>().side == E_Element_SIDE.PLAYER ? Vector3.right : Vector3.left;
            go.GetComponent<Element>().direction = this.side == E_Element_SIDE.PLAYER ? Vector3.right : Vector3.left;

        }
    }


    protected void Die()
    {
        death = true;
        _ani.SetTrigger("Die");
        Destroy(this.gameObject, 0.2f);
    }
}
