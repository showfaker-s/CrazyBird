using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element : MonoBehaviour
{
    public float speed;

    public float power;

    public Vector3 direction;

    public E_Element_SIDE side;
    void Start()
    {
        //Destroy(this.gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.localPosition +=  new Vector3(speed * Time.deltaTime * Dir, 0, 0);
        this.transform.localPosition +=  speed * Time.deltaTime * direction;
        //·É³öÆÁÄ»
        if (Screen.safeArea.Contains(Camera.main.WorldToScreenPoint(this.transform.position)) == false)
        {
            Destroy(this.gameObject,1f);
        }
    }
}
