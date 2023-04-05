using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace SequenceLogic
{
    /// <summary>
    /// Monobehaviour that creates MRTKInteractable Sequences
    /// </summary>
    public class MRTKInteractableSequenceInstance : MonoBehaviour
    {
        private MRTKInteractableStepSequence _mrtkInteractableStepSequence;

        /// <summary>
        /// Public wrapper so that other Monobehaviours may listen for when a sequence ends
        /// </summary>
        public UnityEvent OnSequenceInstanceEnded { get; } = new UnityEvent();
        
        [SerializeField] private MRTKBaseInteractable[] interactables;
        [SerializeField] private StepReader stepReader;

        // Start is called before the first frame update
        private void Start()
        {
            // Turn everything off
            foreach (var interactable in interactables)
            {
                var go = interactable.gameObject;
                go.SetActive(false);
            }
        }

        /// <summary>
        /// Create an MRTKInteractable Sequence from the current task set in the StepReader
        /// </summary>
        public void CreateSequence()
        {
            // Convert basic task loaded from JSON to a list of MRTK Interactable steps
            var mrtkInteractablesSequence = StepUtils.StepSequenceConvert(
                stepReader.currentSequence.uniqueItems, interactables, stepReader.currentSequence);
            
            // Create an MRTKInteractable StepSequence from the steps
            _mrtkInteractableStepSequence = new MRTKInteractableStepSequence(mrtkInteractablesSequence);
            
            // Expose the sequence ended event
            _mrtkInteractableStepSequence.OnMRTKSequenceEnded?.AddListener(OnSequenceInstanceEnded.Invoke);
            
            _mrtkInteractableStepSequence.ContinueSteps(); // Begin
        }

        /// <summary>
        /// Continues the current MRTKInteractable sequence
        /// Exposes functionality to other Monobehaviours
        /// </summary>
        public void Continue()
        {
            _mrtkInteractableStepSequence.ContinueSteps();
        }
    }
}
