using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transition : MonoBehaviour
{
    
    public Animator animator;
    public IEnumerator Fade()
    {

        animator.SetBool("FadeIn",true);
        animator.SetBool("FadeOut", false);
        yield return new WaitForSeconds(2f);
    }
    public IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(1);
        animator.SetBool("FadeIn", false);
        animator.SetBool("FadeOut", true);
    }

}
