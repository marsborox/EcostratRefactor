using System.Collections.Generic;
using UnityEngine;
public class SoundManager : SingletonPresistent<SoundManager>
{
    public static new SoundManager instance => SingletonPresistent<SoundManager>.instance;
    public List<AudioClip> sounds;
    private AudioSource audioSource;

    //public static SoundManager instance;

    protected override void Awake()
    {
        base.Awake();
        //instance = this;
        audioSource = GetComponent<AudioSource>();
    }
    public AudioClip FindSoundByName(string name)
    {
        return sounds.Find((x) => x.name == name);
    }
    public void EventOpen()
    {
        audioSource.PlayOneShot(FindSoundByName("eventopen"));
    }
    public void Click()
    {
        audioSource.PlayOneShot(FindSoundByName("click"));
    }
    public void Victory()
    {
        audioSource.PlayOneShot(FindSoundByName("victory"));
    }
    public void Defeat()
    {
        audioSource.PlayOneShot(FindSoundByName("defeat"));
    }
    public void Illegality()
    {
        audioSource.PlayOneShot(FindSoundByName("illegality"));
    }
    public void Income()
    {
        audioSource.PlayOneShot(FindSoundByName("income"));
    }
    public void Penalty()
    {
        audioSource.PlayOneShot(FindSoundByName("penalty"));
    }

    public void Upgrade(int number)
    {
        audioSource.PlayOneShot(FindSoundByName("upgrade" + number.ToString()));
    }
    public void Speed(int number)
    {
        audioSource.PlayOneShot(FindSoundByName(number.ToString() + "xtime"));
    }
    public void PlaySound(AudioClip sound)
    {
        audioSource.PlayOneShot(sound);
    }
}
