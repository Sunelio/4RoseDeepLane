using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class ListCheckPoint : MonoBehaviour
{
    public List<GameObject> checkPoints = new List<GameObject>();
    private MovePlayer player;
    private void Awake()
    {
        player = GetComponent<MovePlayer>();
    }
    public void Update()
    {
        if (player.isTPNextCheckPoint && checkPoints != null)
        {
            Debug.Log("t");
            transform.position = checkPoints[0].transform.position;
            StartCoroutine(RemoveFistElement());
        }
        
    }
    IEnumerator RemoveFistElement()
    {
        yield return new WaitForSeconds(2);
        checkPoints.RemoveAt(0);
    }
}
