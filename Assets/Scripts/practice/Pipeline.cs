using UnityEngine;

public class Pipeline : MonoBehaviour
{
    public Vector3 speed;

    public Vector2 range;

    //public int Count = 0;
    //计时器
    float t = 0;
    void Start()
    {
        Init();
    }

    public void Init()
    {
        float y = Random.Range(range.x, range.y);
        transform.localPosition = new Vector3(0, y, 0);
    }
    void Update()
    {
        transform.position += speed * Time.deltaTime;
        t += Time.deltaTime;
        //每t秒初始化一次
        if (t > 6f)
        {
            t = 0;
            this.Init();
        }
    }
}
