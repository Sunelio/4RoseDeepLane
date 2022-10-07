using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator lisaAnimation;
    public PlayerState state;


    // Update is called once per frame
    void Update()
    {
        WalkAnimation();
        RunAnimation();
        JumpAnimation();
        FallAnimation();
        HeavyPushAnimation();
        OtherPushAnimation();
        IdleAnimation();
    }

    private void WalkAnimation()
    {
        if(state.isWalking && state.isOnGrounded)
        {
            lisaAnimation.SetBool("Walk", true);
            lisaAnimation.SetBool("Run", false);
            lisaAnimation.SetBool("Jump", false);
            lisaAnimation.SetBool("Fall", false);
            lisaAnimation.SetBool("Hpush", false);
            lisaAnimation.SetBool("Opush", false);
        }
    }
    private void RunAnimation()
    {
        if(state.isRuning && state.isWalking && state.isOnGrounded)
        {
            lisaAnimation.SetBool("Walk", false);
            lisaAnimation.SetBool("Run", true);
            lisaAnimation.SetBool("Jump", false);
            lisaAnimation.SetBool("Fall", false);
            lisaAnimation.SetBool("Hpush", false);
            lisaAnimation.SetBool("Opush", false);
        }
    }
    private void JumpAnimation()
    {
        if (state.isJumping)
        {
            lisaAnimation.SetBool("Walk", false);
            lisaAnimation.SetBool("Run", false);
            lisaAnimation.SetBool("Jump", true);
            lisaAnimation.SetBool("Fall", false);
            lisaAnimation.SetBool("Hpush", false);
            lisaAnimation.SetBool("Opush", false);

        }
    }

    private void FallAnimation()
    {
        if(!state.isJumping && !state.isOnGrounded)
        {
            lisaAnimation.SetBool("Walk", false);
            lisaAnimation.SetBool("Run", false);
            lisaAnimation.SetBool("Jump", false);
            lisaAnimation.SetBool("Fall", true);
            lisaAnimation.SetBool("Hpush", false);
            lisaAnimation.SetBool("Opush", false);

        }
    }

    private void HeavyPushAnimation()
    {
        if(state.weight == BoxWeight.HEAVY && state.isGrabing)
        {
            lisaAnimation.SetBool("Walk", false);
            lisaAnimation.SetBool("Run", false);
            lisaAnimation.SetBool("Jump", false);
            lisaAnimation.SetBool("Fall", false);
            lisaAnimation.SetBool("Hpush", true);
            lisaAnimation.SetBool("Opush", false);

        }
    }
    private void OtherPushAnimation()
    {
        if (state.weight != BoxWeight.HEAVY && state.weight != BoxWeight.NONE && state.isGrabing)
        {
            lisaAnimation.SetBool("Walk", false);
            lisaAnimation.SetBool("Run", false);
            lisaAnimation.SetBool("Jump", false);
            lisaAnimation.SetBool("Fall", false);
            lisaAnimation.SetBool("Hpush", false);
            lisaAnimation.SetBool("Opush", true);

        }
    }
    private void IdleAnimation()
    {
        if(!state.isWalking && state.isOnGrounded && !state.isRuning && !state.isJumping && !state.selectionGravity && !state.isPaused)
        {
            lisaAnimation.SetBool("Walk", false);
            lisaAnimation.SetBool("Run", false);
            lisaAnimation.SetBool("Jump", false);
            lisaAnimation.SetBool("Fall", false);
            lisaAnimation.SetBool("Hpush", false);
            lisaAnimation.SetBool("Opush", false);
        }
        if(!state.isWalking && state.isRuning && state.isOnGrounded)
        {
            lisaAnimation.SetBool("Walk", false);
            lisaAnimation.SetBool("Run", false);
            lisaAnimation.SetBool("Jump", false);
            lisaAnimation.SetBool("Fall", false);
            lisaAnimation.SetBool("Hpush", false);
            lisaAnimation.SetBool("Opush", false);
        }
    }

}
