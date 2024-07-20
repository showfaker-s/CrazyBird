using UnityEngine;

public class Unit : MonoBehaviour
{
    public Rigidbody2D _rigidbodyBird;

    public Animator _ani;

    public GameObject bullet;
    public Transform firePoint;

    public float flySpeed;
    //每秒发射多少颗
    public float fireSpeed;

    public float MaxHP = 100f;
    public float hp = 100f;

    public float attack;

    protected bool isFlying = false;

    public float speed = 100f;
    public float fireRate = 10f;


    public bool death = false;
    //fire计时器
    protected float t = 0;

    public E_Element_SIDE side;

    public delegate void DeathModify(Unit sender);
    public event DeathModify OnDeath;


    void Start()
    {
        this.Idle();
        this.hp = MaxHP;
        OnStart();
    }
    public virtual void OnStart()
    {

    }
    void Update()
    {
        if (death || this._rigidbodyBird.bodyType == RigidbodyType2D.Static)
        {
            return;
        }

        OnUpdate();
        /*        if (this.isFlying)
                    return;*/
    }

    public virtual void OnUpdate()
    {

        Fly();
    }
    public void Idle()
    {
        this._rigidbodyBird.simulated = false;
        this._ani.SetTrigger("Idle");
        //this.isFlying = false;
    }
    //player专属


    public void Fly()
    {
        this._rigidbodyBird.simulated = true;
        this._ani.SetTrigger("Fly");
        //this.isFlying = true;
    }

    protected void Fire()
    {
        t += Time.deltaTime;
        if (t > 1f / fireSpeed)
        {
            GameObject go = Instantiate(bullet);
            go.transform.localPosition = firePoint.position;
            t = 0;
            go.GetComponent<Element>().direction = this.side == E_Element_SIDE.PLAYER ? Vector3.right : Vector3.left;
            //go.transform.SetParent(null);
        }
    }
    public void Damage(float power)
    {
        //_ani.SetTrigger("Die");
        this.hp -= power;
        if (this.hp <= 0)
        {
            this.Die();
        }
    }
    public void AddHP(int hp)
    {
        this.hp += hp;
        if (this.hp > MaxHP)
            this.hp = MaxHP;
    }
    public void Die()
    {
        if (this.death)
            return;

        if (side == E_Element_SIDE.ENEMY)
        {
            Destroy(this.gameObject, 0.2f);
        }else if(side == E_Element_SIDE.PLAYER)
        {
            this.hp = 0;

        }
        if (this.OnDeath != null)
        {
            this.OnDeath(this);
        }
        this.death = true;
        this._ani.SetTrigger("Die");
        this._rigidbodyBird.bodyType = RigidbodyType2D.Dynamic;
    }

}
