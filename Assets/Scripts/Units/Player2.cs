using UnityEngine;

public class Player2 : Unit
{

    //public Animator _ani;
    //public float flyspeed;

    // public GameObject bullet;
    //每秒发射多少颗
    //public float fireSpeed;

    //public float hp;

    //private bool death;

    private Vector2 curPos;
    private Vector3 initPos;


    public delegate void DeathNotify();

    public event DeathNotify OnDeath;

    //没完善
    public delegate void AtkedNotify();

    public event DeathNotify Atked;
    public override void OnStart()
    {
        initPos = this.transform.position;
        death = false;
    }

    public override void OnUpdate()
    {

        curPos.x += Input.GetAxis("Horizontal") * Time.deltaTime * flySpeed;
        curPos.y += Input.GetAxis("Vertical") * Time.deltaTime * flySpeed;
        if (Input.GetButton("Fire1"))
        {
            Fire();
        }
        this.transform.position = curPos;
    }
    public void Init()
    {
        curPos = initPos;
        this.transform.position = initPos;
        this.Idle();
        this.death = false;
        this.hp = this.MaxHP;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy_Bullet"))
        {
            Element bullet = collision.GetComponent<Element>();
            hp = hp - bullet.power;
            //不能等于0
            if (hp <= 0)
            {
                Die();
                if (OnDeath != null)
                {
                    OnDeath();
                }
            }
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Die();
            if (OnDeath != null)
            {
                OnDeath();
            }
        }
    }

}
