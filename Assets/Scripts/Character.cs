using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Camera cam;
    public Light lamp;
    public AudioSource source;
    public float turnSpeed = 10;
    public float moveSpeed = 10;
    public float jumpForce = 10;
    public float maxVelocity = 1;
    public bool jump;

    public Rigidbody rb;
    private Vector3 look;
    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //cam.transform.rotation *= Quaternion.Euler(Input.GetAxis("Mouse Y") * turnspeed, 0, 0);
        //cam.transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * turnspeed, 0);
        look += new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X")) * turnSpeed;
        look.x = Mathf.Clamp(look.x, -90, 90);
        cam.transform.localRotation = Quaternion.Euler(look.x, 0, 0);
        transform.localRotation = Quaternion.Euler(0, look.y, 0);

        Vector3 move = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")) * moveSpeed;
        Debug.DrawLine(transform.position, transform.position + transform.rotation * move);
        //rb.AddRelativeForce(move, ForceMode.VelocityChange);
        //rb.MovePosition(transform.localPosition + transform.rotation * move);
        if (rb.velocity.magnitude < maxVelocity)
        {
            rb.AddForce(transform.rotation * move, ForceMode.VelocityChange);
        }
        if (move.magnitude > 0.01f && !source.isPlaying && jump)
        {
            source.Play();
        }
        if (jump && Input.GetKeyDown(KeyCode.Space))
        {
            jump = false;
            rb.AddForce(0, jumpForce, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            lamp.enabled = !lamp.enabled;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            var rey = new Ray(cam.transform.position, cam.transform.position + cam.transform.rotation * Vector3.forward);
            Debug.DrawLine(cam.transform.position, cam.transform.position + cam.transform.rotation * Vector3.forward, Color.cyan, 1);
            if (Physics.Raycast(cam.transform.position, cam.transform.rotation * Vector3.forward, out RaycastHit hit))
            {
                if ((hit.point - transform.position).magnitude < 3)
                {
                    Debug.DrawLine(cam.transform.position, hit.point, Color.red, 10f);
                    //if (hit.collider.tag == "Interactable")
                    {
                        Debug.Log("Interact " + hit.collider.name);
                        var temp = hit.collider.GetComponent<Door>();
                        if (temp != null)
                        {
                            temp.Swap();
                        }
                        var temp2 = hit.collider.GetComponent<buttonScript>();
                        if (temp2 != null)
                        {
                            temp2.press();
                        }
                        var temp3 = hit.collider.GetComponent<LeverSript>();
                        if (temp3 != null)
                        {
                            temp3.speed();
                        }
                    }
                }
            }

        }
    }

    void OnCollisionEnter()
    {
        jump = true;
    }
}
