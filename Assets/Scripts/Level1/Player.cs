using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float jumpForce;
    private Vector3 InitPos;

    public Rigidbody2D _rigidbody2D;
    public Animator _ani;
    private bool death;
    void Start()
    {
        jumpForce = 200f;
        death = false;
        InitPos = this.transform.position;
        Idle();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            fly();
        }

    }
    public void Idle()
    {
        this._rigidbody2D.simulated = false;
        _rigidbody2D.velocity = Vector2.zero;
        _ani.SetTrigger("Idle");
    }
    public void fly()
    {
        this._rigidbody2D.simulated = true;
        _ani.SetTrigger("InGame");
        _rigidbody2D.velocity = Vector2.zero;
        _rigidbody2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Force);


    }
    public void Die()
    {
        death = true;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pipeline"))
        {
            death = true;
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
/*        if (collision.gameObject.CompareTag("Score"))
        {
            //¼Ó·Ö
        }*/
    }
}
