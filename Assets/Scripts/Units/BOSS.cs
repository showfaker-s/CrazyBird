using System.Collections;
using UnityEngine;

public class BOSS : Enemy
{
    public GameObject missileTemplate;

    public Transform firePoint2;
    public Transform firePoint3;
    //ÅÚÌ¨
    public Transform battery;

    public Unit target;


    public float fireRate2 = 10f;
    float fireTimer2 = 0;
    //´óÕÐCD
    public float UltCD = 10f;
    float fireTimer3 = 0;

    Missile missile = null;
    private void Start()
    {
        OnStart();
    }
    public override void OnStart()
    {
        this.Fly();
        StartCoroutine(Enter());
    }
    public override void OnUpdate()
    {
        //Fire();
        //Debug.Log(string.Format("x: {0}, y: {1}", this.transform.position.x, this.transform.position.y));
        if (target != null)
        {
            Vector3 dir = (target.transform.position - battery.position).normalized;
            battery.transform.rotation = Quaternion.FromToRotation(Vector3.left, dir);
        }
    }
    IEnumerator Enter()
    {
        Debug.Log("BOSS");
        this.transform.position = new Vector3(15, 0, 0);
        yield return MoveTo(new Vector3(5, 0, 0));
        yield return Attack();
    }
    IEnumerator Attack()
    {
        while (true)
        {
            fireTimer2 += Time.deltaTime;
            Fire();
            Fire2();

            fireTimer3 += Time.deltaTime;
            if (fireTimer3 > UltCD)
            {
                yield return UltraAttack();
                fireTimer3 = 0;
            }
            yield return null;
        }
    }
    IEnumerator UltraAttack()
    {
        yield return MoveTo(new Vector3(5, 5, 0));
        yield return FireMissile();
        yield return MoveTo(new Vector3(5, 0, 0));
    }
    IEnumerator MoveTo(Vector3 pos)
    {
        while (true)
        {
            Vector3 dir = (pos - this.transform.position);
            if (dir.magnitude < 0.1)
            {
                break;
            }
            this.transform.position += dir.normalized * speed * Time.deltaTime;
            yield return null;
        }
    }
    IEnumerator FireMissile()
    {
        _ani.ResetTrigger("Fly");
        _ani.SetTrigger("Skill");
        yield return new WaitForSeconds(3f);
    }
    void Fire2()
    {
        if (fireTimer2 > 1f / fireRate2)
        {
            GameObject go = Instantiate(bullet, firePoint2.position, battery.rotation);
            Element bullent = go.GetComponent<Element>();
            bullent.direction = (target.transform.position - firePoint2.position).normalized;
            //bullent.transform.position += bullent.speed * Time.deltaTime * bullent.direction;
            fireTimer2 = 0f;
        }
    }
    public void OnMissileLoad()
    {
        Debug.Log("OnMissileLoad,firePoint3:" + firePoint3.position.x + firePoint3.position.y);
        GameObject go = Instantiate(missileTemplate, firePoint3);
        missile = go.GetComponent<Missile>();
        missile.target = this.target.transform;
    }
    public void OnMissileLaunch()
    {
        Debug.Log("OnMissileLaunch");
        if (missile == null)
            return;
        // missile.transform.SetParent(null);
        missile.Launch();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player_Bullet"))
        {
            Element bullet = new Element();
            this.Damage(bullet.power);
        }

    }
}
