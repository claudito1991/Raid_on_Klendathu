using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMusic : MonoBehaviour
{
    public List<AudioClip> audioClipsToPlay = new List<AudioClip>();
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(audioClipsToPlay.Count);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static AudioClip RandomTrackSelection(List<AudioClip> audios)
    {
       int index_of_music = UnityEngine.Random.Range(0, audios.Count-1);
       AudioClip track_selected = audios[index_of_music];
       Debug.Log(track_selected);
        return track_selected;
    }
}
