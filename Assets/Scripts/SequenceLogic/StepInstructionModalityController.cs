using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace SequenceLogic
{
    /// <summary>
    /// Turns on the correct modalities depending on global variables
    /// </summary>
    public class StepInstructionModalityController : MonoBehaviour
    {
        // Called when a hand exits the zone
        public UnityEvent HandExited { get; } = new UnityEvent();
        
        // The modality GameObjects
        [SerializeField] private GameObject visualModality;
        [SerializeField] private GameObject hapticModality;
        [SerializeField] private GameObject auditoryModality;

        private void OnEnable()
        {
            // Activate the modalities if globally set
            if (ModalitiesEnabled.Instance.VisualsEnabled) StartCoroutine(DelayModality(visualModality));
            if (ModalitiesEnabled.Instance.HapticsEnabled) StartCoroutine(DelayModality(hapticModality));
            if (ModalitiesEnabled.Instance.AudioEnable) StartCoroutine(DelayModality(auditoryModality));
        }

        private void OnDisable()
        {
            // Turn off the modalities
            visualModality.SetActive(false);
            hapticModality.SetActive(false);
            auditoryModality.SetActive(false);
        }

        // Delay the modalities slightly so as not to overwhelm the user
        private IEnumerator DelayModality(GameObject modality)
        {
            yield return new WaitForSeconds(0.25f);
            modality.SetActive(true);
        }

        private void OnTriggerExit(Collider other) => HandExited?.Invoke();
    }
}
