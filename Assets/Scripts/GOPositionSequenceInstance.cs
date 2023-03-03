using Microsoft.MixedReality.Toolkit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

internal class GOPositionSequenceInstance : MonoBehaviour
{
    private GOPositioningStepSequence _positioningSteps;

    [SerializeField] private MRTKBaseInteractable[] interactables;
    [SerializeField] private StepReader stepReader;

    // Start is called before the first frame update
    private void Start()
    {
        var gos = new List<GameObject>();
        foreach (var interactable in interactables)
        {
            var go = interactable.gameObject;
            gos.Add(go);
            go.ChangeOpacity(0f); // Hide
        }

        _positioningSteps = new GOPositioningStepSequence(interactables, stepReader.StepSequence);
        
        // Add visualisation to the delegate methods
        _positioningSteps.Begin += OnStart;
        _positioningSteps.Operation += OnTransition;
        _positioningSteps.End += OnEnd;

        // Begin the sequence
        ContinueSteps();


    }

    private void OnStart(GOPositioningStep goPositioningStep)
    {
        SetInteractable(goPositioningStep.From, true);
        SetInteractable(goPositioningStep.To, false);
    }

    private void OnTransition(GOPositioningStep goPositioningStep)
    {
        SetInteractable(goPositioningStep.To, true);
        SetInteractable(goPositioningStep.From, false);
    }

    private void OnEnd(GOPositioningStep goPositioningStep)
    {
        SetInteractable(goPositioningStep.To, false);
        SetInteractable(goPositioningStep.From, false);
    }

    private void SetInteractable(MRTKBaseInteractable interactable, bool value)
    {
        if (value)
        {
            interactable.gameObject.ChangeOpacity(1f);
            interactable.IsPokeSelected.OnEntered.AddListener((k) => ContinueSteps());
        }
        else
        {
            interactable.gameObject.ChangeOpacity(0f);
            interactable.IsPokeSelected.OnEntered.RemoveAllListeners();
        }
    }

    /// <summary>
    /// Continues the running of the sequence
    /// </summary>
    public void ContinueSteps()
    {
        _positioningSteps.GetEnumerator().MoveNext();
    }
}
