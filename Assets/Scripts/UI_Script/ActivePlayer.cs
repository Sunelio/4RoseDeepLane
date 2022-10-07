using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivePlayer : MonoBehaviour
{
    public PlayerState state;
    public GameObject player;
    public static bool activP;

    // Update is called once per frame
    void Update()
    {
        if(activP == true)
        {
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            players[0].gameObject.SetActive(true);
            Destroy(players[1].gameObject);
            state.isPositionLoad = true;
            activP= false;
        }
    }
}
