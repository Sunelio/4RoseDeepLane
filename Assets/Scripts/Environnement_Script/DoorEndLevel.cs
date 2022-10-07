using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEndLevel : MonoBehaviour
{
    public bool canOpen;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        PlayerState test = other.GetComponent<PlayerState>();
        if(test != null)
        {
            canOpen = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        PlayerState test = other.GetComponent<PlayerState>();
        if (test != null)
        {
            if (test.isGrabing && canOpen)
            {
                animator.SetBool("Open", true);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        canOpen = false;
    }
}
