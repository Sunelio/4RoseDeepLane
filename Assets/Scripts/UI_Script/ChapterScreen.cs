using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChapterScreen : MonoBehaviour
{
    [Header("Chapter")]
    [Tooltip("Chapter Tutorial")]
    public string chapter1;
    [Tooltip("Chapter Kitchen")]
    public string chapter2;
    [Tooltip("Chapter Bedroom")]
    public string chapter3;
    [Tooltip("Chapter Bathroom")]
    public string chapter4;
    [Tooltip("Chapter Basement")]
    public string chapter5;
    [Tooltip("Chapter Laboratory")]
    public string chapter6;
    public AudioManager audioM;

    private void Start()
    {
        audioM = FindObjectOfType<AudioManager>();
    }

    public void ChapterOne()
    {
        audioM.PlayUI("ClickUI");
        ActivePlayer.activP = true;
        SceneManager.LoadScene(chapter1);
    }

    public void ChapterTwo()
    {
        audioM.PlayUI("ClickUI");
        ActivePlayer.activP = true;
        SceneManager.LoadScene(chapter2);
        
    }

    public void ChapterThree()
    {
        audioM.PlayUI("ClickUI");
        ActivePlayer.activP = true;
        SceneManager.LoadScene(chapter3);
    }

    public void ChapterFour()
    {
        audioM.PlayUI("ClickUI");
        ActivePlayer.activP = true;
        SceneManager.LoadScene(chapter4);
    }

    public void ChapterFive()
    {
        audioM.PlayUI("ClickUI");
        ActivePlayer.activP = true;
        SceneManager.LoadScene(chapter5);
    }

    public void ChapterSix()
    {
        audioM.PlayUI("ClickUI");
        ActivePlayer.activP = true;
        SceneManager.LoadScene(chapter6);
    }
}
