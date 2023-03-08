using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit;
using UnityEngine;

public class StepInstructionModalityController : MonoBehaviour
{
    [SerializeField] private GameObject visualModality;
    [SerializeField] private GameObject hapticModality;
    [SerializeField] private GameObject auditoryModality;

    private void OnEnable()
    {
        if (ModalitiesEnabled.VisualsEnabled) visualModality.SetActive(true);
        if (ModalitiesEnabled.HapticsEnabled) hapticModality.SetActive(true);
        if (ModalitiesEnabled.AudioEnable) auditoryModality.SetActive(true);
    }

    private void OnDisable()
    {
        visualModality.SetActive(false);
        hapticModality.SetActive(false);
        auditoryModality.SetActive(false);
    }
}
