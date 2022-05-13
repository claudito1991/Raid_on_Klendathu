using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTrackSelection : MonoBehaviour
{
    // Start is called before the first frame update    private AudioSource thisAudioSource;
    public List<AudioClip> audiosToPlay;
    private AudioSource thisAudioSource;

    void Start()
    {
         thisAudioSource = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void OnEnable()
    {
       
        thisAudioSource.PlayOneShot(RandomMusic.RandomTrackSelection(audiosToPlay));
    }
}
