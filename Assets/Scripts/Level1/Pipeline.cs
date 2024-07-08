using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipeline : MonoBehaviour
{
    public Vector3 speed;

    public Vector2 range;

    public int Count = 0;
    void Start()
    {
        float y = Random.Range(range.x, range.y);
        transform.localPosition = new Vector3(0, y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += speed * Time.deltaTime;
    }
}
