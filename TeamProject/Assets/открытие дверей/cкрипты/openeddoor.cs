using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openeddoor : MonoBehaviour
{
    public float smooth = 2.0f;
    public float  DoorOpenAngle = 90.0f;
    private Vector3 defaultRot;
    public Vector3 openRot;
    private bool enter;
    private bool open;
    void Start()
    {

        defaultRot = transform.eulerAngles;
        openRot = new Vector3(defaultRot.x, defaultRot.y + DoorOpenAngle, defaultRot.z);
    }

    void Update()
    {
        if (open)
        {
            transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, openRot, Time.deltaTime * smooth);
        }
        else
        {
            transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, defaultRot, Time.deltaTime * smooth);
        }
        if (Input.GetKeyDown(KeyCode.F) && enter)
        {
            open = !open;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            print("чтот не работает но работает");
            enter = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            enter = false;
        }
    }
}
