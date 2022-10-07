using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButtonMultiple : MonoBehaviour
{
    // FIELDS
    [SerializeField] private Button[] buttons;
    private Animator animator;
    private bool open;
    private bool close;

    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool allButtonOpen = false;
        foreach(Button B in buttons )
        {
            if(B.buttonActive) // if one button is true, open the door
            {
                allButtonOpen = true;
            }
        }
        if (allButtonOpen)
        {
            close = false;
            open = true;

        }
        else
        {
            close = true;
            open = false;
        }

        animator.SetBool("Close", close);
        animator.SetBool("Open", open);
    }
}
