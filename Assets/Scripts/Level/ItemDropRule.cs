using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropRule : MonoBehaviour
{
    public Item item;
    public float itemDropRatio;

    public void Execute(Vector3 pos)
    {
        if (Random.Range(0f, 100f) < itemDropRatio)
        {
            Item rule = Instantiate<Item>(item);
            //Ë¢µÀ¾ß
            rule.transform.position = pos;
            Destroy(rule, 8f);
        }
    }
}
