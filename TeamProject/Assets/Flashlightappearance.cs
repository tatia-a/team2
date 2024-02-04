using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlightappearance : MonoBehaviour
{
    [SerializeField] GameObject flashlight;
    private void Start()
    {
        flashlight.SetActive(false);
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (flashlight.activeSelf == true)
            {
                flashlight.SetActive(false);
            }
            else
            {
                flashlight.SetActive(true);
            }
        }
    }
}