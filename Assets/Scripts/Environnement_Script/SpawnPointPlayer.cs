using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointPlayer : MonoBehaviour
{
    public PlayerState state;
    public Transform player;
    public Animator animator;

    private void Start()
    {
        GameObject g = GameObject.Find("Player");
        state = g.GetComponent<PlayerState>();
        player = GameObject.Find("Player").transform;
        animator = GameObject.FindGameObjectWithTag("Transition").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (state.isPositionLoad == true)
        {
            StartCoroutine("FadeNextLevel");
            state.isPositionLoad = false;
        }
    }

    public IEnumerator FadeNextLevel()
    {
        animator.SetBool("FadeIn", true);
        animator.SetBool("FadeOut", false);
        yield return new WaitForSeconds(1);
        player.transform.position = transform.position;
        yield return new WaitForSeconds(1);
        animator.SetBool("FadeIn", false);
        animator.SetBool("FadeOut", true);
    }
}
