using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController instance;

    public AudioSource[] music;
    public AudioSource[] sfx;

    public bool alreadyStarted;
    [SerializeField]
    private int whichAmbientToPlay;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
            DevelopmentPlay();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void PlayMusic(int i)
    {
        foreach(AudioSource a in music)
        {
            if(a.isPlaying)
            {
                a.Stop();
            }
        }
        music[i].Play();
    }

    public void DevelopmentPlay()
    {
        if (!music[whichAmbientToPlay].isPlaying)
        {
            music[whichAmbientToPlay].Play();
        }
    }
    public void StopMusic(int i)
    {
        music[i].Stop();
    }

    public void PlaySFX(int index) //EXPLOSION SOUND NOT LICENSED 
    {
        sfx[index].PlayOneShot(sfx[index].clip);
    }

    public void StopSFX(int index)
    {
        sfx[index].Stop();
    }
}
