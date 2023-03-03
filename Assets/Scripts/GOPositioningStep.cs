using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit;
using UnityEngine;
using UnityEngine.Events;

public enum StepStatus
{
    AtStart,
    InProcess,
    AtEnd
}

public class GOPositioningStep
{
    /// <summary>
    /// The item correlating to the beginning of the step
    /// </summary>
    public MRTKBaseInteractable From { get; private set; }
    
    /// <summary>
    /// The item correlating to the end of the step
    /// </summary>
    public MRTKBaseInteractable To { get; private set; }
    
    /// <summary>
    /// The status of the step
    /// </summary>
    public StepStatus Status { get; set; }

    public GOPositioningStep(MRTKBaseInteractable from, MRTKBaseInteractable to)
    {
        From = from;
        To = to;
    }
}
