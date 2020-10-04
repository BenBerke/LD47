using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverSript : MonoBehaviour
{
    public Contorler cons;
    public Vector3 turn;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void speed()
    {
        if (cons.speed < 0.3f)
        {
            cons.speed += 0.1f;
            transform.rotation *= Quaternion.Euler(turn);
        }
        else
        {
            cons.speed = 0f;
            transform.rotation *= Quaternion.Euler(-3 * turn);
        }
    }
}
