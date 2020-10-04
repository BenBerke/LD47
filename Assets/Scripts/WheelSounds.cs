using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelSounds : MonoBehaviour
{
    public AudioSource first;
    public AudioSource second;

    public Drive dr;
    public bool loop = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(sound());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator sound()
    {
        while (loop)
        {
            if (dr.speed > 0)
            {
                first.Play();
                yield return new WaitForSeconds(1 / (1 + 2 * dr.speed));
                second.Play();
            }
            yield return new WaitForSeconds(5 / (1 + 2 * dr.speed));
        }
    }
}
