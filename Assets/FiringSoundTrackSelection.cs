using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringSoundTrackSelection : MonoBehaviour
{
 private AudioSource thisAudioSource;
    public List<AudioClip> audiosToPlay;
    // Start is called before the first frame update
        void Start()
        {
        thisAudioSource = GetComponent<AudioSource>();
        }
        public  void ShootingSound()
        {
        thisAudioSource.PlayOneShot(RandomMusic.RandomTrackSelection(audiosToPlay));
        }



}
