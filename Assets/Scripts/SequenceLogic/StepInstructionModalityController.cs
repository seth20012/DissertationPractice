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
        if (ModalitiesEnabled.Instance.VisualsEnabled) StartCoroutine(DelayModality(visualModality));
        if (ModalitiesEnabled.Instance.HapticsEnabled) StartCoroutine(DelayModality(hapticModality));
        if (ModalitiesEnabled.Instance.AudioEnable) StartCoroutine(DelayModality(auditoryModality));
    }

    private void OnDisable()
    {
        visualModality.SetActive(false);
        hapticModality.SetActive(false);
        auditoryModality.SetActive(false);
    }

    private IEnumerator DelayModality(GameObject modality)
    {
        yield return new WaitForSeconds(0.25f);
        modality.SetActive(true);
    }
}
