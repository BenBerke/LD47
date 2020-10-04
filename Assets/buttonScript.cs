using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonScript : MonoBehaviour
{
    public int effect = 0;
    public GameObject[] lights;
    public GameObject front;

    public Contorler cons;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void press()
    {
        switch (effect)
        {
            case 0:
                lightsCabin();
                break;
            case 1:
                lightsFront();
                break;
            case 2:
                brakes();
                break;
        }
    }

    void lightsCabin()
    {
        foreach (var ligh in lights)
        {
            ligh.SetActive(!ligh.activeSelf);
        }
    }

    void lightsFront()
    {
        front.SetActive(!front.activeSelf);
    }

    void brakes()
    {
        Debug.Log("braking");
        cons.speed = 0;
    }
}
