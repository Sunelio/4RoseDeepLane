using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverSwitch : MonoBehaviour
{
    public bool canActivate;
    public bool open = false;
    private Animator animator;
    [SerializeField] private bool once = false;
    private AudioManager audioM;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    
    void Start()
    {
        audioM = FindObjectOfType<AudioManager>();
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

            if (other.GetComponent<PlayerState>().isGrabing && canActivate && !open)
            {
                open = true;
                canActivate = false;
                if (!test.state.isAlreadyPlayed)
                {
                    audioM.PlaySoundObject("LeverOn");
                    test.state.isAlreadyPlayed = true;
                }
                animator.SetBool("Open",true);
            }
            if (other.GetComponent<PlayerState>().isGrabing && open && canActivate && !once)
            {
                Debug.Log("desactivate");
                open = false;
                canActivate = false;
                audioM.PlaySoundObject("LeverOff");
                animator.SetBool("Open", false);

            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        MovePlayer test = other.GetComponent<MovePlayer>();
        if (test)
        {
            canActivate = false;
            test.state.isAlreadyPlayed = false;
        }
        
    }
}
