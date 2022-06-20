using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;
    public static AudioManager SingletonInstance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<AudioManager>();
                if (_instance == null)
                {
                    GameObject gameObject = new GameObject();
                    gameObject.name = "Audio";
                    _instance = gameObject.AddComponent<AudioManager>();
                    DontDestroyOnLoad(gameObject);
                }
            }
            return _instance;
        }
    }

    [SerializeField]
    private List<AudioItem> _soundItems;
    [SerializeField]
    private List<MusicItem> _musicItems;
    [SerializeField]
    private AudioSource _soundSource;
    [SerializeField]
    private AudioSource _musicSource;
    [SerializeField]
    private AudioMixer _mixer;

    private AudioManager()
    {
        
    }
    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void SetMixerValue(string chanel, float val)
    {
        _mixer.SetFloat(chanel,val);
    }
    public void PlaySound(AudioName soundName)
    {     
        for(int i = 0; i< _soundItems.Count; i++)
        {
            if(_soundItems[i].audio == soundName)
            {
                _soundSource.clip = _soundItems[i].value;
                _soundSource.Play();
            }
        }
    }

    public void PlayMusic(MusicName soundName)
    {
        for (int i = 0; i < _musicItems.Count; i++)
        {
            if (_musicItems[i].audio == soundName)
            {
                _musicSource.clip = _musicItems[i].value;
                _musicSource.Play();
            }
        }
    }
}

[Serializable]
public class AudioItem
{
    public AudioName audio;
    public AudioClip value;
}

[Serializable]
public class MusicItem
{
    public MusicName audio;
    public AudioClip value;
}

public enum AudioName
{
    BallistaPull = 1,
    BallistaFire = 2,
    ButtonClick = 3,
    Explosion = 4,
    HitSound = 5
}

public enum MusicName
{
    MenuMusic = 1,
    WorldMapMusic = 2,
    GrassLandMusic = 3,
    ForestMusic = 4,
    CavernMusic = 5,
    VulcanicMusic = 6
}