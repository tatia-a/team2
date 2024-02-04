using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eye : MonoBehaviour
{
    private Transform player;
    private Animator animator;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        animator = GetComponent<Animator>(); 
    }

    void Update()
    {
        transform.LookAt(player);
    }

    public void SwitchAnimation(bool isDestroy)
    {
        animator.SetBool("isDestroy", isDestroy);
    }
}
