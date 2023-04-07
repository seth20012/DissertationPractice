using System.Collections;
using System.Collections.Generic;
using SequenceLogic;
using UnityEngine;
using UnityEngine.Events;

public class ZoneStepSequenceInstance : MonoBehaviour
{
    private ZoneStepSequence _sequence;
    
    /// <summary>
    /// Public wrapper so that other Monobehaviours may listen for when a sequence ends
    /// </summary>
    public UnityEvent OnSequenceInstanceEnded { get; } = new UnityEvent();
    
    [SerializeField] private StepInstructionModalityController[] zones;
    [SerializeField] private StepReader stepReader;
    // Start is called before the first frame update
    private void Start()
    {
        // Turn everything off
        foreach (var zone in zones)
        {
            var go = zone.gameObject;
            go.SetActive(false);
        }
    }
    
    /// <summary>
    /// Create an Zone Sequence from the current task set in the StepReader
    /// </summary>
    public void CreateSequence()
    {
        // Convert basic task loaded from JSON to a list of MRTK Interactable steps
        var zoneSequence = StepUtils.StepSequenceConvert(
            stepReader.currentSequence.uniqueItems, zones, stepReader.currentSequence);
            
        // Create an MRTKInteractable StepSequence from the steps
        _sequence = new ZoneStepSequence(zoneSequence);
            
        // Expose the sequence ended event
        _sequence.OnZoneSequenceEnded?.AddListener(OnSequenceInstanceEnded.Invoke);
            
        _sequence.ContinueSteps(); // Begin
    }
    
    /// <summary>
    /// Continues the current MRTKInteractable sequence
    /// Exposes functionality to other Monobehaviours
    /// </summary>
    public void Continue()
    {
        _sequence.ContinueSteps();
    }
}
