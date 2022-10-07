using UnityEngine;


public class Box : MonoBehaviour
{
    [HideInInspector] public BoxState boxState;
    private GameObject player;
    private MovePlayer movePlayer;
    private Rigidbody rb;

    public void Awake()
    {
        // Get Player
        movePlayer = FindObjectOfType<MovePlayer>();
        player = movePlayer.gameObject;

        // Box component
        rb = GetComponent<Rigidbody>();
        boxState = GetComponent<BoxState>();
        boxState.spawnPosition = transform.position;
        boxState.isInRightRoom = false;
    }

    public void OnTriggerStay(Collider other)
    {
        MovePlayer player = other.GetComponent<MovePlayer>();
        if (player)
        {
            movePlayer.gravity = player.GetComponent<Gravity>();
            movePlayer.state = player.GetComponent<PlayerState>();
            boxState.inRange = true;
        }

    }
    public void OnTriggerExit(Collider other)
    {
        boxState.inRange = false;
    }
    private void Update()
    {
        switch (boxState.spawnGravity)
        {
            case GravityState.UP:
                boxState.direction = new Vector3(0f, 9.81f, 0f);
                break;
            case GravityState.DOWN:
                boxState.direction = new Vector3(0f, -9.81f, 0f);
                break;
            case GravityState.LEFT:
                boxState.direction = new Vector3(0f, 0, 9.81f);
                break;
            case GravityState.RIGHT:
                boxState.direction = new Vector3(0f, 0f, -9.81f);
                break;
            default:
                break;
        }
        if (movePlayer.state.isDead)
        {
            transform.position = boxState.spawnPosition;
            boxState.gravityState = boxState.spawnGravity;
            rb.AddForce(boxState.direction * rb.mass, ForceMode.Force);
        }
        if (boxState.canChangeGravity && boxState.inRange && boxState.isInRightRoom)
        {
            boxState.gravityState = movePlayer.state.curGravityState;
            movePlayer.gravity.GravityCalc(rb, rb.mass);
        }
        if (!boxState.canChangeGravity && boxState.gravityState == movePlayer.state.curGravityState)
        {
            movePlayer.gravity.GravityCalc(rb, rb.mass);
        }
        if (movePlayer.state.isDestroyBox == true)
        {
            Destroy(gameObject);
        }

    }
}


