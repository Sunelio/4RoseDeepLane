using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public Transform playerRespawn;
    [SerializeField] private DeathState deathState;
    private void Awake()
    {
        playerRespawn = GameObject.FindGameObjectWithTag("Respawn").transform;
    }
    public void OnTriggerEnter(Collider other)
    {
        MovePlayer player = other.GetComponent<MovePlayer>();
        if (player)
        {
            player.state.deathState = deathState;
            playerRespawn.position = transform.position;
            Destroy(gameObject);
        }
    }
}
