using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asignment : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider info)
    {
        Debug.Log("enter");
        info.transform.SetParent(this.transform);

    }
    void OnTriggerExit(Collider info)
    {
        if (info.transform.parent == this.transform)//otherwise it will kick us out when changing cars
        {
            //info.transform.rotation *= transform.rotation;//rotationbug
            info.transform.SetParent(null);
        }
    }
}
