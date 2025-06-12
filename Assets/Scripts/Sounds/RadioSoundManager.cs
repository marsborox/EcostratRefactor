using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioSoundManager : Singleton<RadioSoundManager>
{ 
    
    private AudioSource audioSource;
    public static new RadioSoundManager instance=>Singleton<RadioSoundManager>.instance;
    public List<AudioClip> radioSounds;
    private void Awake()
    {
        base.Awake();
        audioSource = GetComponent<AudioSource>();
        //instance = this;
    }
    public void PlayRadioSound()
    {
        if (!audioSource.isPlaying)
        {
            int random = Random.Range(0, radioSounds.Count);
            audioSource.PlayOneShot(radioSounds[random]);
        }
    }
    public void StopPlaying()
    {
        audioSource.Stop();
    }
}
