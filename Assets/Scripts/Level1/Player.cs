using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public float jumpForce;
    private Vector3 InitPos;

    public Rigidbody2D _rigidbody2D;
    public Animator _ani;

    private bool death;

    public delegate void DeathNotify();

    public event DeathNotify OnDeath;
    public UnityAction<int> OnScore;
    void Start()
    {
        //开始之前不能
        //this._rigidbody2D.bodyType = RigidbodyType2D.Static;
        death = false;
        InitPos = this.transform.position;
        Idle();

    }

    void Update()
    {
        if (death || this._rigidbody2D.bodyType == RigidbodyType2D.Static)//|| !Game.instance.IsGameStarted()
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            _rigidbody2D.velocity = Vector2.zero;
            fly();
        }

    }
    public void Idle()
    {
        this._rigidbody2D.simulated = false;
        _ani.SetTrigger("Idle");
    }
    public void fly()
    {
        this._rigidbody2D.simulated = true;
        _ani.SetTrigger("InGame");

        //_rigidbody2D.velocity = Vector2.zero;
        _rigidbody2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Force);


    }
    public void Die()
    {

        _ani.SetTrigger("Die");
        death = true;
        if(OnDeath != null)
        {
            OnDeath();
        }
    }

    public void Init()
    {
        _ani.ResetTrigger("Die");
        _ani.ResetTrigger("InGame");
        _ani.SetTrigger("Idle");
        this.transform.position = InitPos;
        Idle();
        death = false;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pipeline"))
        {
            Die();
        }
        if (collision.gameObject.CompareTag("Score"))
        {
            if (OnScore != null)
            {
                OnScore(1);
            }
        }
    }
}
