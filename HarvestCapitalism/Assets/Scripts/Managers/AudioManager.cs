using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
#region Singleton

    public static AudioManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    #endregion

    public AudioMixer myMixer;
    public AudioMixerGroup SFXGroup;
    public AudioMixerGroup MusicGroup;
    public AudioClip sfx_button, sfx_attack, sfx_plantseed, sfx_pickfruit, sfx_interact,
        sfx_enemyattack, sfx_enemydie, sfx_hit, sfx_daystart, sfx_nightstart, sfx_gameover, sfx_step;

    public AudioClip menuMusic, ingameMusic;

    public GameObject SoundSource;

    public GameObject currentMusicObject;
    private void Start()
    {
    }
    public void PlaySFX(string sfxName)
    {
        switch (sfxName)
        {
            case "sfx_button":
                CreateSFXSource(sfx_button);
                break;
            case "sfx_attack":
                CreateSFXSource(sfx_attack);
                break;
            case "sfx_plantseed":
                CreateSFXSource(sfx_plantseed);
                break;
            case "sfx_pickfruit":
                CreateSFXSource(sfx_pickfruit);
                break;
            case "sfx_interact":
                CreateSFXSource(sfx_interact);
                break;
            case "sfx_enemyattack":
                CreateSFXSource(sfx_enemyattack);
                break;
            case "sfx_enemydie":
                CreateSFXSource(sfx_enemydie);
                break;
            case "sfx_hit":
                CreateSFXSource(sfx_hit);
                break;
            case "sfx_daystart":
                CreateSFXSource(sfx_daystart);
                break;
            case "sfx_nightstart":
                CreateSFXSource(sfx_nightstart);
                break;
            case "sfx_gameover":
                CreateSFXSource(sfx_gameover);
                break;
            case "sfx_step":
                CreateSFXSource(sfx_step);
                break;
        }
    }

    public void PlayMusic(string musicName)
    {
        switch (musicName)
        {
            case "menuMusic":
                CreateMusicSource(menuMusic);
                break;
            case "ingameMusic":
                CreateMusicSource(ingameMusic);
                break;
        }
    }

    void CreateSFXSource(AudioClip clip)
    {
        //Create the prefab
        GameObject newSource = Instantiate(SoundSource, transform);
        //Put the clip in the audio Source
        newSource.GetComponent<AudioSource>().clip = clip;
        //Put the source on the SFX mixer
        newSource.GetComponent<AudioSource>().outputAudioMixerGroup = SFXGroup;
        //Play the clip
        newSource.GetComponent<AudioSource>().Play();
    }
    void CreateMusicSource(AudioClip clip)
    {
        //Check if there is already a musicObject playing a music
        if(currentMusicObject)
        {
            Destroy(currentMusicObject);
        }
        //Create a music prefab
        currentMusicObject = Instantiate(SoundSource, transform);
        //Put the clip in the audio Source
        currentMusicObject.GetComponent<AudioSource>().clip = clip;
        //Make sure it loops
        currentMusicObject.GetComponent<AudioSource>().loop = true;
        //Set mixerGroup to Music group
        currentMusicObject.GetComponent<AudioSource>().outputAudioMixerGroup = MusicGroup;
        //Play the clip
        currentMusicObject.GetComponent<AudioSource>().Play();
    }
    
}
