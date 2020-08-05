using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] AudioSource DingSFX = null;
    [SerializeField] AudioSource SuccessSFX = null;

    public void PlayDing()
    {
        DingSFX.Play();
    }
    public void PlaySuccess()
    {
        SuccessSFX.Play();
    }
}
