using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public string name;

    public AudioClip clip;

    public AudioMixerGroup ModifSFX;

    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;

    public bool loop;
    public bool Awake;

    [HideInInspector]
    public AudioSource source;

}

[System.Serializable]
public class PlayerSFXSound
{
    public string name;

    public AudioClip clip;

    public AudioMixerGroup ModifSFX;

    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;

    public bool loop;
    public bool Awake;

    [HideInInspector]
    public AudioSource source;
}

[System.Serializable]
public class SoundObject
{
    public string name;

    public AudioClip clip;

    public AudioMixerGroup ModifSFX;

    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;

    public bool loop;
    public bool Awake;

    [HideInInspector]
    public AudioSource source;
}

[System.Serializable]
public class UI
{
    public string name;

    public AudioClip clip;

    public AudioMixerGroup ModifSFX;

    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;

    public bool loop;
    public bool Awake;

    [HideInInspector]
    public AudioSource source;
}

[System.Serializable]
public class Voice
{
    public string name;

    public AudioClip clip;

    public AudioMixerGroup ModifSFX;

    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;

    public bool loop;
    public bool Awake;

    [HideInInspector]
    public AudioSource source;
}