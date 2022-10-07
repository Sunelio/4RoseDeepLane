using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSFX : MonoBehaviour
{
    public PlayerState state;
    public int jumpRandomSound;
    public AudioManager audioM;

    private void Start()
    {
        audioM = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        RandomJump();
        if (state.isJumping && state.isOnGrounded)
        {
            switch (jumpRandomSound)
            {
                case 0:
                    audioM.PlaySFXPlayer("PlayerJump1");
                    break;
                case 1:
                    audioM.PlaySFXPlayer("PlayerJump2");
                    break;
                case 2:
                    audioM.PlaySFXPlayer("PlayerJump3");
                    break;
                case 3:
                    audioM.PlaySFXPlayer("PlayerJump4");
                    break;
                default:
                    break;
            }

        }
        
        if(state.gravity == GravityState.DOWN || state.gravity == GravityState.UP || state.gravity == GravityState.LEFT || state.gravity == GravityState.RIGHT)
        {
            if (state.curGravityState == state.gravity)
            {
                audioM.PlaySFXPlayer("ProjectionSelection");
            }
        }

        if (state.haveSelected == true)
        {
            if (state.curGravityState != state.gravity)
            {
                audioM.PlaySFXPlayer("ProjectionValid");
            }
        }

        /*if (state.isGrabing == true)
        {
             audioM.PlaySoundObject("BoxGrab");
        }*/


        /*if (state.selectionGravity == true)
        {
            audioM.PlaySFXPlayer("SelectionGravityOn");
        }

        if (state.selectionGravity == false)
        {
            audioM.PlaySFXPlayer("SelectionGravityOff");
        }*/

    }

    public void RandomJump()
    {
        if (!state.isOnGrounded)
        {
            jumpRandomSound = Random.Range(0, 4);
        }
    }
}
