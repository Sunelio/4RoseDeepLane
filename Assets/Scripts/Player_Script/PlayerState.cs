using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GravityState
{
    UP,
    DOWN,
    LEFT,
    RIGHT
}
public enum DeathState
{
    SPAWN_UP,
    SPAWN_DOWN,
    SPAWN_LEFT,
    SPAWN_RIGHT
}

public enum BoxWeight
{
    NONE,
    LIGHT,
    MEDIUM,
    HEAVY
}


public class PlayerState : MonoBehaviour
{
    

    [Header("StatePlayer")]
    [SerializeField] private float cowotyJumpTime;
    public bool isOnGrounded = true;
    public bool isWalking = false;
    public bool isRuning = false;
    public bool isJumping = false;
    public bool isPaused = false;
    public bool isPlayerTriggerCameraWall = false;
    public bool isPlayerTriggerCameraZ = false;
    public bool isFixedZCamera = false;
    public bool isCameraFollow = true;
    public bool isDead = false;
    public bool isPositionLoad = false;
    public bool godMode = false;

    [Header("StateGravity")]
    public GravityState gravity;
    public GravityState curGravityState;
    public DeathState deathState;
    public bool inChange;
    public bool gravityZone;
    public bool selectionGravity;
    public bool haveSelected;

    [Header("Grab")]
    public bool isGrabing;
    public bool canGrab;
    public bool cancelGrab;
    public bool colWall;
    public BoxWeight weight;


    [Header("CheckGround")]
    [SerializeField] public Transform checkGround;
    [SerializeField] private float radiusCheckSphere;
    [SerializeField] public LayerMask ground;

    [Header("CheckScene")]
    public int previousLevel;
    public bool isDestroyBox = false;
    public bool isLoadChapter = false;

    [Header("Sounds")]
    public bool isAlreadyPlayed = false;
    public bool isAlreadyPlayedSecond = false;

    public void Awake()
    {
        gravity = GravityState.DOWN;
    }

    public void Update()
    {
        isOnGrounded = Physics.CheckSphere(checkGround.position, radiusCheckSphere, ground);

        if (isOnGrounded)
            inChange = false;
    }
    IEnumerator CowotyJump()
    {
        isOnGrounded = true;
        yield return new WaitForSeconds(cowotyJumpTime);
        isOnGrounded = false;

    }
}
