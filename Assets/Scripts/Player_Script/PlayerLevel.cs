using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LevelState
{
    ONE,
    TWO,
    TREE,
    FOUR,
}
public class PlayerLevel : MonoBehaviour
{
    [Header("level stat")]
    public LevelState level;

    private void Awake()
    {
        //level = LevelState.TREE;
    }
}
