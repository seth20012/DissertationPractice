using System;
using System.Collections;
using System.Collections.Generic;
using SequenceLogic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private StepReader stepReader;
    [SerializeField] private MRTKInteractableSequenceInstance mrtkInteractableSequenceInstance;

    private void Start()
    {
        mrtkInteractableSequenceInstance.OnSequenceInstanceEnded?.AddListener(() => gameObject.SetActive(true));
        stepReader.OnNoMoreSequences?.AddListener(() => gameObject.SetActive(false));
    }
}
