using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element : MonoBehaviour
{
    public float speed;

    //public int Dir = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.localPosition +=  new Vector3(speed * Time.deltaTime * Dir, 0, 0);
        this.transform.localPosition +=  new Vector3(speed * Time.deltaTime , 0, 0);
        //·É³öÆÁÄ»
        if (Screen.safeArea.Contains(Camera.main.WorldToScreenPoint(this.transform.position)) == false)
        {
            Destroy(this.gameObject,1f);
        }
    }
}
