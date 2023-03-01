using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GOPositioningStep
{
    public GameObject From { get; private set; }
    public GameObject To { get; private set; }
    public bool Complete { get; private set; }
    public UnityEvent Started { get; private set; } = new UnityEvent();
    public UnityEvent Transitioning { get; private set; } = new UnityEvent();
    public UnityEvent Finished { get; private set; } = new UnityEvent();

    public GOPositioningStep(GameObject from, GameObject to)
    {
        From = from;
        To = to;
    }
}
