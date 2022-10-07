using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using System.Collections;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [Header("Walk Value")]
    [Tooltip("The speed value is modifie by the runing value")]
    [SerializeField] public float moveSpeed;
    [Tooltip("If the lerp time is equal to 1 you don t have lag")]
    [SerializeField] private float lerpTime;

    [Header("Run Value")]
    [Tooltip("This value replace moveSpeed if we press runing input ")]
    public float running;
    [Tooltip("This value is for keep the initial moove speed")]
    [SerializeField] public float currSpeed;

    [Header("Death")]
    public float deathCompter;
    public float initDeathCompter;
    public bool StartCompter;
    private Animator deathTransition;
    private Transform respawn;

    [Header("Jump Value")]
    [Tooltip("The y axis is equal to jump Force")]
    public float jumpForce;

    [Header("Other")]
    [Tooltip("Script ref to Gravity")]
    public Gravity gravity;
    [Tooltip("Script ref to Player State")]
    [HideInInspector] public PlayerState state;
    [Tooltip(" ref to Player RigidBody")]
    [HideInInspector] public Rigidbody rb;

    [Tooltip("This vector is the Move gamepad")]
    [HideInInspector] public Vector2 moveInputs;
    [Tooltip("This vector is the vector calculate by the Gravity")]
    [HideInInspector] public Vector3 dirInputs;
    public float compter;
    [SerializeField] private bool getInputDown = false;
    private AudioManager audioM;

    public bool isTPNextCheckPoint = false;
    // Start is called before the first frame update
    void Start()
    {
        respawn = GameObject.FindGameObjectWithTag("Respawn").transform;
        deathTransition = GameObject.FindGameObjectWithTag("Transition").GetComponent<Animator>();
        currSpeed = moveSpeed;
        initDeathCompter = deathCompter;
        state = GetComponent<PlayerState>();
        rb = rb.GetComponent<Rigidbody>();
        gravity = GetComponent<Gravity>();
        rb.velocity = Vector3.zero;
        audioM = FindObjectOfType<AudioManager>();
    }



    private void FixedUpdate()
    {
        gravity.GravityCalc(rb);

        if (!state.inChange && state.isWalking)
            Walk(moveInputs);

        if (state.isJumping && state.isOnGrounded)
            Jump();
    }
    //Principal Update function
    private void Update()
    {
        if (!state.inChange)
        {
            gravity.GravitySelection();
        }
        if (state.haveSelected)
        {
            gravity.GravityRotation();
        }
        if(StartCompter)
        {
            deathCompter -= Time.deltaTime;
        }
        if(deathCompter <= 0)
        {
            state.isDead = true;
        }
        Dead();
        if (state.isGrabing && !state.isAlreadyPlayed && state.canGrab)
        {
            audioM.PlaySoundObject("BoxGrab");
            state.isAlreadyPlayed = true;
        }
        if (!state.isGrabing && !state.gravityZone)
        {
            state.isAlreadyPlayed = false;
            state.isAlreadyPlayedSecond = false;
        }
        if (state.weight == BoxWeight.HEAVY && state.isWalking && !state.isAlreadyPlayedSecond)
        {
            audioM.PlaySoundObject("BoxMove");
            state.isAlreadyPlayedSecond = true;
        }
        if (!state.isGrabing)
        {
            audioM.StopSoundObject("BoxMove");
        }
    }

    // the walk Function change if the gravity is update on the z axis
    public void Walk(Vector2 direction)
    {
        if (state.isRuning)
            moveSpeed = running;

        else if (!state.isGrabing)
            moveSpeed = currSpeed;

        gravity.DirectionMovePlayer(direction);
        rb.velocity = Vector3.Lerp(rb.velocity, dirInputs, lerpTime);
    }

    public void Jump()
    {
        gravity.JumpPlayer(jumpForce);
    }

    public void CheatLevelUp()
    {
        gravity.playerLvl.level = LevelState.FOUR;
        
    }
    public void ReturnLastCheckPoint()
    {
        transform.position = GameObject.FindGameObjectWithTag("Respawn").transform.position;
        switch (state.deathState)
        {
            case DeathState.SPAWN_UP:
                state.gravity = GravityState.UP;
                break;
            case DeathState.SPAWN_DOWN:
                state.gravity = GravityState.DOWN;
                break;
            case DeathState.SPAWN_LEFT:
                state.gravity = GravityState.LEFT;
                break;
            case DeathState.SPAWN_RIGHT:
                state.gravity = GravityState.RIGHT;

                break;
            default:
                break;
        }
        state.curGravityState = state.gravity;
        gravity.GravityOrientation();
        gravity.GravityRotation();
        gravity.GravityCalc(rb);
    }
    public void NextCheckPoint()
    {
        
    }

    private void Dead()
    {
        if (state.isDead)
        {
            StartCoroutine(FadeDeath());
            rb.isKinematic = false;
            state.gravityZone = false;
            deathCompter = initDeathCompter;
            state.isDead = false;
        }
    }
    // ====================All The inputs function Player=======================\\
    public void WalkInputs(InputAction.CallbackContext context)
    {
        moveInputs = context.ReadValue<Vector2>();
        if (!context.canceled && !state.selectionGravity)
            state.isWalking = true;
        if (context.canceled)
            state.isWalking = false;
    }


    public void GrabInputs(InputAction.CallbackContext context)
    {
        state.isGrabing = context.performed;
        state.cancelGrab = context.canceled;
    }


    public void RunInputs(InputAction.CallbackContext context)
    {
        state.isRuning = context.performed;
    }

    public void JumpInputs(InputAction.CallbackContext context)
    {
        if (!state.isPaused)
            state.isJumping = context.performed;
        if (context.canceled)
            state.isJumping = false;
    }

    public void SelectionGravityInputs(InputAction.CallbackContext context)
    {
        if (state.weight != BoxWeight.HEAVY)
        {
            if (gravity.playerLvl.level != LevelState.ONE && !state.inChange)
            {
                if (!state.gravityZone && !state.isPaused)
                {
                    state.selectionGravity = context.performed;
                    state.haveSelected = context.canceled;
                }
            }
        }
    }
    public void GravityChangeuPInputs(InputAction.CallbackContext context)
    {
        compter = Mathf.Clamp(compter, 0, 5);
        if (state.selectionGravity)
        {
            if (!getInputDown)
            {
                StartCoroutine(InputLagUp());
                getInputDown = true;
            }

        }
        if (context.canceled)
        {
            getInputDown = false;
        }



    }
    public void GravityChangeDownInputs(InputAction.CallbackContext context)
    {
        compter = Mathf.Clamp(compter, 0, 5);
        if (state.selectionGravity)
        {
            if (!getInputDown)
            {
                StartCoroutine(InputLagDown());
                getInputDown = true;
            }

        }
        if (context.canceled)
        {
            getInputDown = false;
        }



    }
    public void NextCheckPoint(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isTPNextCheckPoint = true;
        }
        if (context.canceled || context.performed)
        {
            isTPNextCheckPoint = false;
        }

    }
    private IEnumerator InputLagUp()
    {
        compter++;
        switch(gravity.playerLvl.level)
        {
            case LevelState.TWO:
                if (compter == 3)
                {
                    compter = 1;
                }
                break;
            case LevelState.TREE:
                if (compter == 4)
                {
                    compter = 1;
                }
                break;
            case LevelState.FOUR:
                if (compter == 5)
                {
                    compter = 1;
                }
                break;
            default:
                break;
        }
        
        yield return new WaitForEndOfFrame();
    }
    private IEnumerator InputLagDown()
    {
        
        compter--;
        switch (gravity.playerLvl.level)
        {
            case LevelState.TWO:
                if (compter == 0)
                {
                    compter = 2;
                }
                break;
            case LevelState.TREE:
                if (compter == 0)
                {
                    compter = 3;
                }
                break;
            case LevelState.FOUR:
                if (compter == 0)
                {
                    compter = 4;
                }
                break;
            default:
                break;
        }
        yield return new WaitForEndOfFrame();
    }

    public IEnumerator FadeDeath()
    {
        rb.isKinematic = true;
        deathTransition.SetBool("FadeIn", true);
        deathTransition.SetBool("FadeOut", false);
        yield return new WaitForSeconds(1);
        ReturnLastCheckPoint();
        yield return new WaitForSeconds(1);
        deathTransition.SetBool("FadeIn", false);
        deathTransition.SetBool("FadeOut", true);
    }
    
}