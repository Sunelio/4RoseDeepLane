using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Knife : MonoBehaviour
{
    public GameObject objectToDestroy;
    public float speed;
    public float timer;
    private AudioManager audioM;
    public Vector3 Direction;
    private void Start()
    {
        audioM = FindObjectOfType<AudioManager>();
    }
    void Update()
    {
        transform.Translate(Direction * speed);
        StartCoroutine(Respawn(transform));
    }
    IEnumerator Respawn(Transform objectToMove)
    {       
        yield return new WaitForSeconds(timer);
        audioM.PlaySoundObject("Knife Planted");
        Destroy(objectToDestroy);
    }
}
