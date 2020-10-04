using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    public List<Light> list;
    // Start is called before the first frame update
    void Start()
    {
        list = lights();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.O))
        {
            AllOff();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            AllOn();
        }
        */
    }

    void AllOff()
    {
        list = lights();
        foreach (var lit in list)
        {
            lit.enabled = false;
        }
    }

    void AllOn()
    {
        foreach (var lit in list)
        {
            lit.enabled = true;
        }
    }

    List<Light> lights()
    {
        var temp = FindObjectsOfType<Light>();
        List<Light> arrangement = new List<Light>();
        foreach (var item in temp)
        {
            if (item.gameObject.name != "Flashlight")
            {
                arrangement.Add(item);
            }
        }
        return arrangement;
    }

    void OnTriggerEnter()
    {
        AllOff();
        Invoke("AllOn", 10f);
    }
}
