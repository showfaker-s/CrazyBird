using UnityEngine;



public class Enemy : Unit
{
    public float lifeTime;


    public E_Enemy_TYPE enemyType;


    void Start()
    {
        Destroy(this.gameObject, lifeTime);
        Init();
        OnStart();
    }

    public virtual void OnStart()
    {

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
        Inity = UnityEngine.Random.Range(range.x, range.y);
        //改y
        transform.localPosition += new Vector3(0, Inity, 0);
    }

    protected void Fly()
    {
        float y = 0;
        if (enemyType == E_Enemy_TYPE.SWING)
        {
            y = Mathf.Sin(Time.timeSinceLevelLoad) * 3f;
        }
        this.transform.position = new Vector3(this.transform.position.x - Time.deltaTime * flySpeed, Inity + y);

        /*curPos.x += flySpeed * Time.deltaTime;
        transform.position = new Vector3(flySpeed * Time.deltaTime , y, 0);
        transform.localPosition = new Vector3(this.transform.position.x - (Time.deltaTime * flySpeed), Inity + y);*/

    }
    /*private float t = 0;
        private void fire()
        {
            //t += Time.deltaTime;
            if (t > 1 / fireSpeed)
            {
                //会变成player的子物体，跟着子物体走
                //Instantiate(bullet, this.transform);
                //GameObject go = Instantiate(bullet);
                GameObject go = Instantiate(bullet, transform.position, Quaternion.identity, this.transform);
                go.transform.position = transform.position;
                go.GetComponent<Element>().Dir = 1;
                //改颜色
                SpriteRenderer[] SRs = go.GetComponentsInChildren<SpriteRenderer>();
                foreach(SpriteRenderer sr in SRs)
                {
                    sr.color = Color.red;
                }
                t = 0;
            }
        }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player_Bullet"))
        {
            Element e = new Element();
            if (this.gameObject.tag == "BOSS")
            {
                this.Damage(e.power);
            }
            else if (this.gameObject.tag == "Enemy")
            {
                Die();
            }

        }
    }

    /*    private void Die()
        {
            death = true;
            _ani.SetTrigger("Die");
            Destroy(this.gameObject,0.2f);
        }*/
}
