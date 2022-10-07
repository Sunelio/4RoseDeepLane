using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class OptionScreen : MonoBehaviour
{
    public List<ResItem> resolution = new List<ResItem>();

    [Header("Value Volume & Resolution")]
    public TMP_Text resolutionLabal;
    public TMP_Text masterLabel;
    public TMP_Text musicLabel;
    public TMP_Text sfxLabel;

    [Header("Toggle")]
    public Toggle fullScreenTog;
    public Toggle vsyncTog;

    [Header("Slider")]
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider sfxSlider;

    [Header("Music")]
    public AudioMixer theMixer;

    [Header("Other")]
    private bool foundRes = true;
    private float vol = 0f;
    private int selectedDisplay;

    // Start is called before the first frame update
    void Start()
    {
        fullScreenTog.isOn = Screen.fullScreen;

        QualitySettings.vSyncCount = 1;

        if (QualitySettings.vSyncCount == 0)
        {
            vsyncTog.isOn = false;
        }
        else
        {
            vsyncTog.isOn = true;
        }

        for(int i = 0; i < resolution.Count; i++)
        {
            if(Screen.width == resolution[i].horizontal && Screen.height == resolution[i].vertical)
            {
                foundRes = true;

                selectedDisplay = i;

                UpdateResLabel();
            }
        }

        if(!foundRes)
        {
            ResItem newRes = new ResItem();
            newRes.horizontal = Screen.width;
            newRes.vertical = Screen.height;

            resolution.Add(newRes);
            selectedDisplay = resolution.Count - 1;

            UpdateResLabel();
        }

        theMixer.GetFloat("MasterVol", out vol);
        masterSlider.value = vol;

        theMixer.GetFloat("MusicVol", out vol);
        musicSlider.value = vol;

        theMixer.GetFloat("SFXVol", out vol);
        sfxSlider.value = vol;

        masterLabel.text = Mathf.RoundToInt(masterSlider.value + 80).ToString();
        musicLabel.text = Mathf.RoundToInt(musicSlider.value + 80).ToString();
        sfxLabel.text = Mathf.RoundToInt(sfxSlider.value + 80).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResLeft()
    {
        selectedDisplay--;
        if(selectedDisplay < 0)
        {
            selectedDisplay = 0;
        }

        UpdateResLabel();
    }

    public void ResRight()
    {
        selectedDisplay++;
        if (selectedDisplay > resolution.Count - 1)
        {
            selectedDisplay = resolution.Count - 1;
        }

        UpdateResLabel();
    }

    public void UpdateResLabel()
    {
        resolutionLabal.text = resolution[selectedDisplay].horizontal.ToString() + " x " + resolution[selectedDisplay].vertical.ToString();
    }

    public void ApplyGraphics()
    {
        Screen.fullScreen = fullScreenTog.isOn;

        if(vsyncTog.isOn)
        {
            QualitySettings.vSyncCount = 1;
        }
        else
        {
            QualitySettings.vSyncCount = 0;
        }

        Screen.SetResolution(resolution[selectedDisplay].horizontal, resolution[selectedDisplay].vertical, fullScreenTog.isOn);
    }

    public void SetMasterVol()
    {
        masterLabel.text = Mathf.RoundToInt(masterSlider.value + 80).ToString();

        theMixer.SetFloat("MasterVol", masterSlider.value);

        PlayerPrefs.SetFloat("MasterVol", masterSlider.value);
    }
    public void SetMusicVol()
    {
        musicLabel.text = Mathf.RoundToInt(musicSlider.value + 80).ToString();

        theMixer.SetFloat("MusicVol", musicSlider.value);

        PlayerPrefs.SetFloat("MusicVol", musicSlider.value);
    }
    public void SetSFXVol()
    {
        sfxLabel.text = Mathf.RoundToInt(sfxSlider.value + 80).ToString();

        theMixer.SetFloat("SFXVol", sfxSlider.value);

        PlayerPrefs.SetFloat("SFXVol", sfxSlider.value);
    }
}

[System.Serializable]
public class ResItem
{
    public int horizontal;
    public int vertical;
}
