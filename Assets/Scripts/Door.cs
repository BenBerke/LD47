using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool doorstate;
    public Vector3 closed;
    public Vector3 opened;
    public float closetime = 5;

    // Start is called before the first frame update
    void Start()
    {
        closed = transform.localPosition;
        opened = transform.localPosition + Vector3.up * 100;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Swap()
    {
        if (doorstate)
        {
            open();
        }
        else
        {
            close();
        }
    }

    private void open()
    {
        transform.localPosition = opened;
        Invoke("close", closetime);
        doorstate = false;
    }

    private void close()
    {
        transform.localPosition = closed;
        //CancelInvoke("close");
        doorstate = true;
    }
}
