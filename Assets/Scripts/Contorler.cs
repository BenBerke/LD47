using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contorler : MonoBehaviour
{
    public Drive[] wagons;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        foreach (var wagon in wagons)
        {
            wagon.speed = this.speed;
        }
    }
}
