using UnityEngine;

public class Element : MonoBehaviour
{
    public float speed;

    public float power = 1;

    public Vector3 direction = Vector3.zero;

    public E_Element_SIDE side;

    public float lifeTime;
    void Start()
    {
        Destroy(this.gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        OnUpdate();
    }
    public virtual void OnUpdate()
    {
        this.transform.position += speed * Time.deltaTime * direction;

        //·É³öÆÁÄ»
        /*        if (Screen.safeArea.Contains(Camera.main.WorldToScreenPoint(this.transform.position)) == false)
                {
                    Destroy(this.gameObject, 2f);
                }*/
        if (!GameUtil.Instance.InScreen(this.transform.position))
        {
            Destroy(this.gameObject, 2f);
        }
    }
}
