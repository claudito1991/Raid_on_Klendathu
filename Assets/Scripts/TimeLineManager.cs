using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class TimeLineManager : MonoBehaviour
{
    public PlayableDirector cutsceneTimeline;
    
    public PlayableDirector playableTimeline;

        void OnEnable()
    {
        //cutsceneTimeline.stopped += OnCutscenePlayableDirectorStopped;
    }
    // Start is called before the first frame update
    void Start()
    {
     // playableTimeline.Stop();
     // cutsceneTimeline.Play();
     playableTimeline.Play();
      
    }

    public void OnCutscenePlayableDirectorStopped( PlayableDirector obj)
    {
        if(cutsceneTimeline == obj)
        {
           playableTimeline.Play(); 
        }
    }


    // Update is called once per frame
    void Update()
    {
    
    }
}
