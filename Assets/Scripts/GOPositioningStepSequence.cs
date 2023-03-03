using System.Collections;
using System.Linq;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit;
using UnityEngine;
using UnityEngine.Events;

public class GOPositioningStepSequence : IEnumerable<GOPositioningStep>
{
    private readonly Dictionary<string, MRTKBaseInteractable> _itemsIdentifierLookup = new Dictionary<string, MRTKBaseInteractable>();
    private readonly IList<GOPositioningStep> _goPositioningSteps;
    
    /// <summary>
    /// StepOperation delegate. Performs an action during a PositioningStep
    /// </summary>
    public delegate void GOStepOperation(GOPositioningStep goPositioningStep);
    
    /// <summary>
    /// The StepOperation method run to initialise a step
    /// </summary>
    public GOStepOperation Begin { get; set; }
        
    /// <summary>
    /// The StepOperation method run when the user begins a step
    /// </summary>
    public GOStepOperation Operation { get; set; }
        
    /// <summary>
    /// The StepOperation method run when the user completes a step
    /// </summary>
    public GOStepOperation End { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="goPositioningSteps"></param>
    public GOPositioningStepSequence(IEnumerable<GOPositioningStep> goPositioningSteps)
    {
        _goPositioningSteps = (IList<GOPositioningStep>)goPositioningSteps;

        Begin += BeginDefault;
        Operation += DoOperationDefault;
    }

    /// <summary>
    /// GOPositioningStepSequence Constructor
    /// </summary>
    /// <param name="items">An ordered list of GameObjects to be used as step sequence To/From items</param>
    /// <param name="stepSequence">The StepSequence to follow</param>
    public GOPositioningStepSequence(IList<MRTKBaseInteractable> items, StepSequence stepSequence)
    {
        _goPositioningSteps = new List<GOPositioningStep>();
        
        for (var i = 0; i < stepSequence.UniqueItems.Count; i++)
        {
            // Match the ordered GameObject list to the alphabetically ordered object within the StepSequence
            _itemsIdentifierLookup.Add(stepSequence.UniqueItems[i], items[i]);
        }

        foreach (Step step in stepSequence)
        {
            // Add the correct GameObjects as the From and To items
            _goPositioningSteps.Add(new GOPositioningStep(_itemsIdentifierLookup[step.From], _itemsIdentifierLookup[step.To]));
        }

        // Add default functionality to delegate methods
        Begin += BeginDefault;
        Operation += DoOperationDefault;
    }

    /// <summary>
    /// Iterate through a step sequence running any associated functionality
    /// </summary>
    /// <returns>The step being operated on</returns>
    public IEnumerator<GOPositioningStep> GetEnumerator()
    {
        foreach(GOPositioningStep goStep in _goPositioningSteps)
        {
            switch (goStep.Status)
            {
                case StepStatus.AtStart:
                    Begin(goStep);
                    Debug.Log("Begin!");
                    yield return goStep;
                    break;
                case StepStatus.InProcess:
                    Operation(goStep);
                    Debug.Log("Operate!");
                    yield return goStep;
                    break;
                default:
                    End(goStep);
                    Debug.Log("End!");
                    continue;
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private void BeginDefault(GOPositioningStep goPositioningStep)
    {
        goPositioningStep.Status = StepStatus.InProcess;
    }

    private void DoOperationDefault(GOPositioningStep goPositioningStep)
    {
        goPositioningStep.Status = StepStatus.AtEnd;
    }
}
