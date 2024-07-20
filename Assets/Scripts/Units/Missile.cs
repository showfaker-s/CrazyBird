using UnityEngine;

public class Missile : Element
{

    public Transform target;

    private bool running = false;
    //爆炸特效
    public GameObject fxExpold;

    float t = 0;
    public override void OnUpdate()
    {
        if (!running)
            return;

        if (target != null)
        {
            //目标位置-自己位置，不停更换方向
            Vector3 dir = (target.position - this.transform.position);
            //dir长度接近0，爆炸
            if (dir.magnitude < 0.1)
            {
                this.Explod();
            }
            //旋转到目标的角度
            this.transform.rotation = Quaternion.FromToRotation(Vector3.left, dir);
            //位移值
            this.transform.position += speed * Time.deltaTime * dir.normalized;
        }
        t += Time.deltaTime;
        if (t >= lifeTime)
        {
            Explod();
        }
    }
    public void Launch()
    {
        side = E_Element_SIDE.ENEMY;
        running = true;
    }

    public void Explod()
    {
        Destroy(this.gameObject);
        //导弹自己的位置、旋转
        Instantiate(fxExpold, this.transform.position, Quaternion.identity);

        if (target != null)
        {
            Player2 p = target.GetComponent<Player2>();
            p.Damage(power);
        }
    }
}
