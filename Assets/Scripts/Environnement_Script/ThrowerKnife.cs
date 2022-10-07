using UnityEngine;

public class ThrowerKnife : MonoBehaviour
{
    public GameObject Knife;
    private float timerBtwShoots;
    public float startTimer;
    private AudioManager audioM;
    public Quaternion Rotationknife;

    private void Start()
    {
        audioM = FindObjectOfType<AudioManager>();
        timerBtwShoots = startTimer;
    }
    private void Update()
    {
        if(timerBtwShoots<=0)
        {
            Instantiate(Knife,transform.position, Rotationknife);
            audioM.PlaySoundObject("Knife Sparkle");
            timerBtwShoots = startTimer;
        }
        else
            timerBtwShoots -= Time.deltaTime;
    }
}