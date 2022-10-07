using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public float Timer;
    public bool canActivate;
    public bool buttonActive = false;
    private AudioManager audioM;
    private Animator animator;
    
    private void Start()
    {
        audioM = FindObjectOfType<AudioManager>();
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        canActivate = true;
    }
    private void OnTriggerStay(Collider other)
    {
        MovePlayer test = other.GetComponent<MovePlayer>();
        if (test != null)
        {
            if (other.GetComponent<PlayerState>().isGrabing && canActivate && !buttonActive)
            {
                buttonActive = true;
                animator.SetBool("Open",true);
                StartCoroutine("StartAnimation");
                canActivate = false;
                audioM.PlaySoundObject("ButtonOn");
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        canActivate = false;
    }

    private IEnumerator StartAnimation()
    {
        yield return new WaitForSeconds(Timer);
        audioM.PlaySoundObject("ButtonOff");
        animator.SetBool("Open", false);
        buttonActive = false;
    }
}
