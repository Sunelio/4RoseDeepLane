using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
public class Anti_Gravity : MonoBehaviour
{
    private MovePlayer player;
    private Box box;
    public VFXAntiGravityZone vFX;
    private AudioManager audioM;
    private void Start()
    {
        audioM = FindObjectOfType<AudioManager>();
    }


    private void OnTriggerEnter(Collider other)
    {

        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb)
        {
            player = other.GetComponent<MovePlayer>();
            box = other.GetComponent<Box>();
            if (player)
            {
                vFX.isVignetteFade = true;
                player.state.gravityZone = true;
                if (player.state.selectionGravity)
                {
                    player.state.selectionGravity = false;
                }
                if (!player.state.isAlreadyPlayed)
                {
                    audioM.PlaySoundObject("Anti-Gravity-Zone");
                    player.state.isAlreadyPlayed = true;
                }
            }
            if (box)
            {
                box.boxState.isInGravityZone = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (player)
        {
            player.state.gravityZone = false;
            vFX.isVignetteFade = false;
            player.state.isAlreadyPlayed = false;
            audioM.StopSoundObject("Anti-Gravity-Zone");
        }
        if (box)
        {
            box.boxState.isInGravityZone = false;
        }
    }
}
