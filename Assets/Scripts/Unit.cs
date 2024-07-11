using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public Animator _ani;

    public float flyspeed;

    public float fireSpeed;

    public float HP;

    protected bool death = false;


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
        fire();
        fly();
    }


    private void fly()
    {
    }

    private void fire()
    {
    }

    public void Init()
    {
        
    }

    private void Die()
    {
    }
}
