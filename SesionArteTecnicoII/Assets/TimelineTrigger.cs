using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class TimelineTrigger : MonoBehaviour
{
    public int index;
    public TimelineAsset timeline;
    public PlayableDirector controlPlayable;

    public static event FNotify_1Params<int> OnPlayTimeline;
    public static event FNotify OnTimelineEnd;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnDisable()
    {
        OnTimelineEnd?.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
           controlPlayable.Play();
            OnPlayTimeline?.Invoke(index);
            controlPlayable.stopped += ControlPlayable_stopped;

        }
    }

    private void ControlPlayable_stopped(PlayableDirector obj)
    {
        OnTimelineEnd?.Invoke();
    }
}
