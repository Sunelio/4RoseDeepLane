using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalRotation : MonoBehaviour
{
    public MovePlayer player;
    public PlayerState state;
    public Vector2 input;
    private float targetAngle;


    public void Awake()
    {
    }
    void Update()
    {
        switch (state.gravity)
        {
            case GravityState.UP:
                 targetAngle = Mathf.Atan2(-player.moveInputs.x, -player.moveInputs.y) * Mathf.Rad2Deg;
                transform.localRotation = Quaternion.Euler(0, targetAngle, 0);
                break;
            case GravityState.DOWN:
                 targetAngle = Mathf.Atan2(player.moveInputs.x, player.moveInputs.y) * Mathf.Rad2Deg;
                transform.localRotation = Quaternion.Euler(0, targetAngle, 0);
                break;
            case GravityState.LEFT:
                 targetAngle = Mathf.Atan2(player.moveInputs.x, player.moveInputs.y) * Mathf.Rad2Deg;
                transform.localRotation = Quaternion.Euler(0, targetAngle, 0);
                break;
            case GravityState.RIGHT:
                 targetAngle = Mathf.Atan2(-player.moveInputs.x,- player.moveInputs.y) * Mathf.Rad2Deg;
                transform.localRotation = Quaternion.Euler(0, targetAngle, 0);
                break;
        } 
    }
}
