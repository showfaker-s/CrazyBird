using UnityEngine;

public class Player2 : Unit
{
    private Vector2 curPos;
    private Vector3 initPos;

    //√ªÕÍ…∆
    public delegate void AtkedNotify();

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
        if (this.death)
            return;
        Element bullet = collision.GetComponent<Element>();
        Enemy enemy = collision.GetComponent<Enemy>();
        Item item = collision.gameObject.GetComponent<Item>();
        if (item != null)
        {
            item.Use(this);
        }
        if ((bullet == null && enemy == null)) return;
        if (enemy != null)
        {
            this.Die();
        }
        if (bullet != null && bullet.side == E_Element_SIDE.ENEMY)
        {
            this.Damage(bullet.power);
        }
    }

}
