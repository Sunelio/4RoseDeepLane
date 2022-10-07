using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public AudioMixer theMixer;

    public Sound[] sounds;
    public PlayerSFXSound[] SFXSounds;
    public SoundObject[] objects;
    public Voice[] voice;
    public UI[] uiObject;

    public static AudioManager instance;

    private void Awake()
    {

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.volume = s.pitch;
            s.source.loop = s.loop;
            s.source.playOnAwake = s.Awake; 

            s.source.outputAudioMixerGroup = s.ModifSFX;
        }

        foreach (PlayerSFXSound j in SFXSounds)
        {
            j.source = gameObject.AddComponent<AudioSource>();
            j.source.clip = j.clip;

            j.source.volume = j.volume;
            j.source.volume = j.pitch;
            j.source.loop = j.loop;
            j.source.playOnAwake = j.Awake;


            j.source.outputAudioMixerGroup = j.ModifSFX;
        }

        foreach (SoundObject so in objects)
        {
            so.source = gameObject.AddComponent<AudioSource>();
            so.source.clip = so.clip;

            so.source.volume = so.volume;
            so.source.volume = so.pitch;
            so.source.loop = so.loop;
            so.source.playOnAwake = so.Awake;


            so.source.outputAudioMixerGroup = so.ModifSFX;
        }

        foreach (Voice v in voice)
        {
            v.source = gameObject.AddComponent<AudioSource>();
            v.source.clip = v.clip;

            v.source.volume = v.volume;
            v.source.volume = v.pitch;
            v.source.loop = v.loop;
            v.source.playOnAwake = v.Awake;


            v.source.outputAudioMixerGroup = v.ModifSFX;
        }

        foreach (UI ui in uiObject)
        {
            ui.source = gameObject.AddComponent<AudioSource>();
            ui.source.clip = ui.clip;

            ui.source.volume = ui.volume;
            ui.source.volume = ui.pitch;
            ui.source.loop = ui.loop;
            ui.source.playOnAwake = ui.Awake;


            ui.source.outputAudioMixerGroup = ui.ModifSFX;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        PlayTheme("Theme");

        if(PlayerPrefs.HasKey("MasterVol"))
        {
            theMixer.SetFloat("MasterVol", PlayerPrefs.GetFloat("MasterVol"));
        }

        if (PlayerPrefs.HasKey("MusicVol"))
        {
            theMixer.SetFloat("MusicVol", PlayerPrefs.GetFloat("MusicVol"));
        }

        if (PlayerPrefs.HasKey("SFXVol"))
        {
            theMixer.SetFloat("SFXVol", PlayerPrefs.GetFloat("SFXVol"));
        }
    }
    public void PlayTheme(string name)
    {
        Sound s = Array.Find(sounds, sounds => sounds.name == name);
        s.source.Play();

    }

    public void PlaySFXPlayer(string name)
    {
        PlayerSFXSound j = Array.Find(SFXSounds, SFXSounds => SFXSounds.name == name);
        j.source.Play();

    }

        public void StopSFXPlayer(string name)
        {
            PlayerSFXSound j = Array.Find(SFXSounds, SFXSounds => SFXSounds.name == name);
            j.source.Stop();

        }

        public void PlaySoundObject(string name)
        {
            SoundObject so = Array.Find(objects, objects => objects.name == name);
            so.source.Play();

        }
        public void StopSoundObject(string name)
        {
            SoundObject so = Array.Find(objects, objects => objects.name == name);
            so.source.Stop();

        }

        public void PlayVoice(string name)
        {
            Voice v = Array.Find(voice, voice => voice.name == name);
            v.source.Play();

        }

        public void PlayUI(string name)
        {
            UI ui = Array.Find(uiObject, uiObject => uiObject.name == name);
            ui.source.Play();

        }
    

}
