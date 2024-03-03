using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class baaar : MonoBehaviour
{
    public float smooth = 0.2f;
    public float DoorOpenAngle = 90.0f;
    public GameObject door;
    public openeddoor op;
    public Image img;
    public bool ope;
    private void Start()
    {
    }
    private void Update()
    {
        if(Input.GetKey(KeyCode.E))
        {
            img.fillAmount += 0.02F;
            if(img.fillAmount >= 1)
            {
                img.gameObject.SetActive(false);
                print("yeee!");
                door.transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, op.openRot, Time.deltaTime * smooth);
            }
        }
    }
}
