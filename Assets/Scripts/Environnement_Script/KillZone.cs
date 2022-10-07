using UnityEngine;

public class KillZone : MonoBehaviour
{
    private Transform playerSpawn;
    private AudioManager audioM;
    private void Awake()
    {
        playerSpawn = GameObject.FindGameObjectWithTag("Respawn").transform;
        audioM = FindObjectOfType<AudioManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        MovePlayer player = other.GetComponent<MovePlayer>();
        Box box = other.GetComponent<Box>();
        if (player)
        {
            switch (player.state.deathState)
            {
                case DeathState.SPAWN_UP:
                    player.state.gravity = GravityState.UP;
                    break;
                case DeathState.SPAWN_DOWN:
                    player.state.gravity = GravityState.DOWN;
                    break;
                case DeathState.SPAWN_LEFT:
                    player.state.gravity = GravityState.LEFT;
                    break;
                case DeathState.SPAWN_RIGHT:
                    player.state.gravity = GravityState.RIGHT;
                    
                    break;
                default:
                    break;
            }
            player.state.isDead = true;
            player.state.curGravityState = player.state.gravity;
            player.gravity.GravityOrientation();
            player.gravity.GravityRotation();
            player.gravity.GravityCalc(player.rb);
        }
        if (box)
        {
            audioM.PlaySoundObject("BoxCrash");
            Rigidbody rbBox = box.GetComponent<Rigidbody>();
            rbBox.velocity = new Vector3(0, 0, 0);
            box.transform.position = box.boxState.spawnPosition;
            box.boxState.gravityState = box.boxState.spawnGravity;
        }
    }
}
