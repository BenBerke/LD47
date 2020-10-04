using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addLights : MonoBehaviour
{
    public int every = 1;
    public int intensity = 1;
    public int range = 1;
    public int up = 1;
    // Start is called before the first frame update
    void Start()
    {
        var children = GetComponentsInChildren<Transform>();
        for (int i = 0; i < children.Length; i += every)
        {
            var point = new GameObject();
            //point.transform.SetParent(children[i]);
            point.transform.position = children[i].transform.position + Vector3.up * up;
            Light lamp = point.gameObject.AddComponent(typeof(Light)) as Light;
            lamp.intensity = intensity;
            lamp.range = range;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
