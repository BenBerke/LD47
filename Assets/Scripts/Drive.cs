using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive : MonoBehaviour
{
    public GameObject tunnel;
    public int next;
    public float speed = 0.1f;
    public List<Transform> track;

    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        var temp = tunnel.GetComponentInChildren<Transform>();
        foreach (Transform segment in temp)
        {
            track.Add(segment);
        }

        var tm = Vector3.Angle(transform.localRotation * Vector3.forward, track[next].position + offset - transform.position);
        if (Vector3.Angle(Quaternion.Euler(0, tm, 0) * transform.localRotation * Vector3.forward, track[next].position + offset - transform.position) < Vector3.Angle(Quaternion.Euler(0, -tm, 0) * transform.localRotation * Vector3.forward, track[next].position + offset - transform.position))//right hand turn bug
        {
            //transform.rotation *= Quaternion.Euler(0, temp, 0);
            gole = transform.rotation * Quaternion.Euler(0, tm, 0);
            rotate = Quaternion.Euler(0, tm * steps, 0);
        }
        else
        {
            //transform.rotation *= Quaternion.Euler(0, -temp, 0);
            gole = transform.rotation * Quaternion.Euler(0, -tm, 0);
            rotate = Quaternion.Euler(0, -tm * steps, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (track[next].position + offset - transform.position).normalized * speed;
        if ((track[next].position - transform.position).magnitude < 2)
        {
            //transform.position = track[next].position;
            next++;
            if (next >= track.Count)
            {
                next = 0;
                //next = 280;
            }
            //transform.rotation = Quaternion.FromToRotation(transform.rotation * Vector3.forward, track[next].position - transform.position);
            var temp = Vector3.Angle(transform.localRotation * Vector3.forward, track[next].position + offset - transform.position);
            /*
            if (temp > 10)
            {
                Debug.DrawLine(transform.position, transform.position + transform.localRotation * Vector3.forward, Color.red);
                Debug.DrawLine(transform.position, transform.position + (track[next].position + offset - transform.position), Color.blue);
                Debug.LogError("Angle " + temp + " " + transform.localRotation * Vector3.forward + " " + (track[next].position + offset - transform.position) + " " + next);
            }
            */
            if (Vector3.Angle(Quaternion.Euler(0, temp, 0) * transform.localRotation * Vector3.forward, track[next].position + offset - transform.position) < Vector3.Angle(Quaternion.Euler(0, -temp, 0) * transform.localRotation * Vector3.forward, track[next].position + offset - transform.position))//right hand turn bug
            {
                //transform.rotation *= Quaternion.Euler(0, temp, 0);
                gole = transform.rotation * Quaternion.Euler(0, temp, 0);
                rotate = Quaternion.Euler(0, temp * steps, 0);
            }
            else
            {
                //transform.rotation *= Quaternion.Euler(0, -temp, 0);
                gole = transform.rotation * Quaternion.Euler(0, -temp, 0);
                rotate = Quaternion.Euler(0, -temp * steps, 0);
            }

        }
        if (transform.rotation != gole)
            transform.rotation *= rotate;
        //Debug.DrawLine(transform.position, transform.position + transform.localRotation * Vector3.forward, Color.red);
    }
    Quaternion gole;
    Quaternion rotate;
    float steps = 0.1f;
}
