using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController instance;

    public AudioSource[] music;
    public AudioSource[] sfx;

    public bool alreadyStarted;

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

    public void DevelopmentPlay()
    {
        if (!music[0].isPlaying)
        {
            music[0].Play();
        }
    }
    public void StopMusic()
    {
        music[0].Stop();
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
