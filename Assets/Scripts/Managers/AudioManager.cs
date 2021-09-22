using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public bool isMuted;
    public AudioSource audio;
    public AudioClip[] musicClips;
    public int soundTrack;


    private void Start() 
    {
        isMuted = false;
        audio = GetComponent<AudioSource>();
        soundTrack = Random.Range(0,musicClips.Length);
        PlayMusic();
    }
    public void PlayMusic()
    {
        audio.clip = musicClips[soundTrack];
        audio.Play();  
    }

    public void MuteAudio()
    {
        isMuted = !isMuted;
        AudioListener.pause = isMuted;
    }


}
