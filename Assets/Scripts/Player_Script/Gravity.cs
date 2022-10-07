using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

[RequireComponent(typeof(Rigidbody))]
public class Gravity : MonoBehaviour
{
    [Header("level")]
    public PlayerLevel playerLvl;

    [Header("Gravity Selection")]
    [Tooltip("the value off the Time scale when the slow motion is on")]
    public float slowMotionValue;
    private float initSlowMotion;
    private float startTimeScale;
    private float startFixedDeltaTime;

    [Header("Gravity Value")]
    [Tooltip("Value off the Gravity on the axis Y")]
    [HideInInspector] public float axisY;
    [Tooltip("Value off the Gravity on the axis X")]
    [HideInInspector] public float axisZ;
    public float compteur;

    public Light lightSelection;
    public Light spotLight;

    private Vector3 currGravity;

    [Tooltip("Vector to define the current Gravity drection")]

    public Vector3 gravityDirection;
    private Vector3 gravityInit = new Vector3(0, -9.81f, 0);

    [Header("Rotation Value")]
    [Tooltip("Vector to define the rotation Game object player")]
    public Vector3 rotation;
    private float trunSmoothVelocity;
    public float trunSpeed;
    [SerializeField] private Quaternion initRotation;


    [Header("Other")]
    [Tooltip("Ref to the Move Player script")]
    public MovePlayer player;
    public VisualEffect gravityEffect;




    //Init all the value
    private void Awake()
    {
        initRotation = transform.localRotation;
        gravityDirection = gravityInit;
        currGravity = gravityDirection;
        initSlowMotion = slowMotionValue;

        startTimeScale = Time.timeScale;
        startFixedDeltaTime = Time.fixedDeltaTime;
        
    }

    // Add Force to the axis Gravity direction.
    public void GravityCalc(Rigidbody rb)
    {
        rb.AddForce(gravityDirection, ForceMode.Force);

    }
    public void GravityCalc(Rigidbody rb, float mass)
    {
        rb.AddForce(gravityDirection * mass, ForceMode.Force);
    }

    // When the wheel selection is acitvate this fonction call all the value in interaction with the trigger.
    public void GravitySelection()
    {
        if (ConditionWheel())
        {
            lightSelection.enabled = true;
            spotLight.enabled = false;
            gravityEffect.Play();
            StartSlowMotion();
            GravityChange();
        }
        else
        {
            gravityEffect.Stop();
            player.state.curGravityState = player.state.gravity;
            StoptSlowMotion();
            lightSelection.enabled = false;
            spotLight.enabled = true;
        }

    }



    // This function change the gravity with the moveInputs value.
    public void GravityChange()
    {

       if (Vector3.Magnitude(player.moveInputs) > 0.1f)
        {

            if (player.compter == 3)
            {
                player.state.gravity = GravityState.UP;
            }
            if (player.compter == 1)
            {
                player.state.gravity = GravityState.DOWN;
            }
            if (player.compter == 2)
            {
                player.state.gravity = GravityState.LEFT;
            }
            if (player.compter == 4 )
            {
                player.state.gravity = GravityState.RIGHT;
            }
            GravityOrientation();
        }
    }
    //This function change the direction calcul if we change the gravity direction.
    public void DirectionMovePlayer(Vector2 direction)
    {
        
        switch (player.state.gravity)
        {
            case GravityState.LEFT:
                DirMovePLayerLeft(direction);
                DirRotationLeft(90);
                
                break;
            case GravityState.RIGHT:
                DirMovePLayerLeft(direction);
                DirRotationRight(90);
                break;
            case GravityState.UP:
                DirMovePLayerDown(direction);
                DirRotationUP(180);
                break;
            case GravityState.DOWN:
                DirMovePLayerDown(direction);
                DirRotationDown();
                break;
            default:
                break;
        }
    }

    public void JumpPlayer(float jumpForce)
    {
        switch (player.state.gravity)
        {
            case GravityState.LEFT:
                JumpLeft(jumpForce);
                break;
            case GravityState.RIGHT:
                JumpRight(jumpForce);
                break;
            case GravityState.UP:
                JumpUp(jumpForce);
                break;
            case GravityState.DOWN:
                JumpDown(jumpForce);
                break;
            default:
                break;
        }
    }
    public void GravityOrientation()
    {
        
        switch (player.state.gravity)
        {
            case GravityState.LEFT:
                rotation = new Vector3(-90, 0, 0);
                transform.localEulerAngles = rotation;
                break;
            case GravityState.RIGHT:
                rotation = new Vector3(90, 0, 0);
                transform.localEulerAngles = rotation;
                break;
            case GravityState.UP:
                rotation = new Vector3(180, 0, 0);
                transform.localEulerAngles = rotation;
                break;
            case GravityState.DOWN:
                rotation = new Vector3(0, 0, 0);
                transform.localEulerAngles = rotation;
                break;
            default:
                break;
        }
    }

    public void GravityRotation()
    {
        switch (player.state.gravity)
        {
            case GravityState.LEFT:
                
                gravityDirection = new Vector3(0, 0, axisZ);
                break;
            case GravityState.RIGHT:
                gravityDirection = new Vector3(0, 0, -axisZ);
                break;
            case GravityState.UP:
                gravityDirection = new Vector3(0, axisY, 0);
                break;
            case GravityState.DOWN:
                gravityDirection = currGravity;
                break;
            default:
                break;
        }
        player.rb.velocity = Vector3.zero;
        player.state.inChange = true;
        player.state.haveSelected = false;
    }

    public void JumpDown(float jumpForce)
    {
        player.rb.velocity = new Vector3(player.rb.velocity.x, jumpForce, player.rb.velocity.z);
    }
    public void JumpUp(float jumpForce)
    {
        player.rb.velocity = new Vector3(player.rb.velocity.x, -jumpForce, player.rb.velocity.z);
    }
    public void JumpRight(float jumpForce)
    {
        player.rb.velocity = new Vector3(player.rb.velocity.x, player.rb.velocity.y, jumpForce);
    }
    public void JumpLeft(float jumpForce)
    {
        player.rb.velocity = new Vector3(player.rb.velocity.x, player.rb.velocity.y, -jumpForce);
    }
    public void DirMovePLayerLeft(Vector2 direction)
    {
        player.dirInputs = new Vector3(direction.x * player.moveSpeed * Time.deltaTime, direction.y * player.moveSpeed * Time.deltaTime, player.rb.velocity.z);
    }
    public void DirMovePLayerDown(Vector2 direction)
    {
        player.dirInputs = new Vector3(direction.x * player.moveSpeed * Time.deltaTime, player.rb.velocity.y, direction.y * player.moveSpeed * Time.deltaTime);
    }
    public void DirRotationDown()
    {
        if (player.state.weight != BoxWeight.HEAVY)
        {
            float targetAngle = Mathf.Atan2(player.moveInputs.x, player.moveInputs.y) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref trunSmoothVelocity, trunSpeed);
            transform.rotation = Quaternion.Euler(0, angle, 0);
        }
    }

    public void DirRotationUP(float rotationX)
    {
        if (player.state.weight != BoxWeight.HEAVY)
        {
            float targetAngle = Mathf.Atan2(-player.moveInputs.x, -player.moveInputs.y) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(-transform.eulerAngles.y, targetAngle, ref trunSmoothVelocity, trunSpeed);
            transform.rotation = Quaternion.Euler(rotationX, angle, 0);
        }
    }

    public void DirRotationLeft(float rotationX)
    {
        if (player.state.weight != BoxWeight.HEAVY)
        {
            float targetAngle = Mathf.Atan2(player.moveInputs.x, player.moveInputs.y) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref trunSmoothVelocity, trunSpeed);
            transform.localRotation = Quaternion.Euler(angle - rotationX, rotationX, -rotationX);
        }
    }

    public void DirRotationRight(float rotationX)
    {
        if (player.state.weight != BoxWeight.HEAVY)
        {
            float targetAngle = Mathf.Atan2(player.moveInputs.x, player.moveInputs.y) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref trunSmoothVelocity, trunSpeed);
            transform.localRotation = Quaternion.Euler(angle - rotationX, rotationX, rotationX);
        }
    }


    //Start slowMotion value.
    public void StartSlowMotion()
    {
           
        Time.timeScale = slowMotionValue;
        Time.fixedDeltaTime = startFixedDeltaTime * slowMotionValue;
        StartCoroutine(SlowMotion());
    }

    //End the slowMotion value.
    public void StoptSlowMotion()
    {
        slowMotionValue = initSlowMotion;
        if (startTimeScale == Time.timeScale || player.state.isPaused)
            return;
        
        Time.timeScale = startTimeScale;
        Time.fixedDeltaTime = startFixedDeltaTime;
    }

    private bool ConditionWheel()
    {
        if (!player.state.gravityZone && player.state.selectionGravity && !player.state.inChange && playerLvl.level != LevelState.ONE)
            return true;
        else
            return false;
    }  
    private IEnumerator SlowMotion()
    {
        if (player.state.isOnGrounded)
        {
            player.rb.velocity = Vector3.zero;
            player.rb.velocity = gravityDirection * -1;
        }
        yield return new WaitForSeconds(0.2f);
        slowMotionValue = 0;
         
    }

}
