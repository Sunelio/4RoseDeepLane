using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterRoom : MonoBehaviour
{
    public float raycastSize;
    public PlayerState state;
    public Transform Raypos;

    // Start is called before the first frame update
    void Start()
    {
        GameObject g = GameObject.Find("Player");
        state = g.GetComponent<PlayerState>();
        Raypos = GameObject.Find("Raypos").transform;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        Ray ray = new Ray(transform.position, transform.forward);

        Debug.DrawRay(transform.position, transform.forward * raycastSize, Color.white);

        if(state.curGravityState == GravityState.LEFT)
        {
            if (Physics.Raycast(ray, out hit, raycastSize))
            {
                if (hit.collider.gameObject.tag == "Player")
                {
                    if (Raypos.position.y < transform.position.y)
                    {
                        state.isPlayerTriggerCameraWall = false;
                    }
                    if (Raypos.position.y > transform.position.y)
                    {
                        state.isPlayerTriggerCameraWall = true;
                    }
                }
                

            }
        }
        if(state.curGravityState == GravityState.DOWN)
        {
            state.isPlayerTriggerCameraWall = false;
        }
    }
}