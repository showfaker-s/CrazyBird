using UnityEngine;



public class Enemy : Unit
{
    public float lifeTime;


    public E_Enemy_TYPE enemyType;

    public override void OnStart()
    {
        Destroy(this.gameObject, lifeTime);
        Init();
    }
    public override void OnUpdate()
    {
        Fly();
        Fire();
    }
    //生成enemy的位置
    public Vector2 range;

    float Inity = 0;
    private void Init()
    {
        Inity = Random.Range(range.x, range.y);
        //改y
        transform.localPosition += new Vector3(0, Inity, 0);
    }

    protected void Fly()
    {
        float y = 0;
        this._rigidbodyBird.simulated = true;

        if (enemyType == E_Enemy_TYPE.SWING)
        {
            y = Mathf.Sin(Time.timeSinceLevelLoad) * 3f;
        }
        this.transform.position = new Vector3(this.transform.position.x - Time.deltaTime * flySpeed, Inity + y);

        /*curPos.x += flySpeed * Time.deltaTime;
        transform.position = new Vector3(flySpeed * Time.deltaTime , y, 0);
        transform.localPosition = new Vector3(this.transform.position.x - (Time.deltaTime * flySpeed), Inity + y);*/

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Element bullet = collision.GetComponent<Element>();
        if (bullet == null || bullet.side == E_Element_SIDE.ENEMY) return;
        if (bullet.side == E_Element_SIDE.PLAYER)
        {
            this.Damage(bullet.power);
        }
        /*        Debug.Log("!!!");
                if (collision.gameObject.CompareTag("Player_Bullet"))
                {
                    Element bullet = collision.GetComponent<Element>();
                    this.Damage(bullet.power);
                    //Destroy(collision);
                }*/
    }
}
