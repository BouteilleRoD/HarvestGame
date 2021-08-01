using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
    [SerializeField] AudioMixer myMixer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMusicVolume(float volume)
    {
        myMixer.SetFloat("MusicVolume", volume);
    }
    public void SetEffectVolume(float volume)
    {
        myMixer.SetFloat("SFXVolume", volume);
    }
}
