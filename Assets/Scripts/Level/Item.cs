using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int AddHp = 50;

    public GameObject bullet;
    public float Godlife = 3;
    void Update()
    {
        this.transform.position += new Vector3(0, -1f * Time.deltaTime, 0);

    }
    public void Use(Unit target)
    {
        target.AddHP(this.AddHp);
        Destroy(this.gameObject);
    }
}
