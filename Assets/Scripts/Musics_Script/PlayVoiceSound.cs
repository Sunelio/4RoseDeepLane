using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayVoiceSound : MonoBehaviour
{
    public AudioManager audioM;
    public string voiceAudio;

    private void Start()
    {
        audioM = FindObjectOfType<AudioManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        MovePlayer player = other.GetComponent<MovePlayer>();
        if (player)
        {
            audioM.PlayVoice(voiceAudio);
            Destroy(gameObject);
        }
    }
}
