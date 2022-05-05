using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip audioToPlay;
    public AudioSource mainAudio;
    // Start is called before the first frame update

    void OnEnable()
    {
        PlayerMovement.playerExploded += PlayerExplosion;
    }

    private void PlayerExplosion()
    {
        mainAudio.PlayOneShot(audioToPlay);
    }
}
