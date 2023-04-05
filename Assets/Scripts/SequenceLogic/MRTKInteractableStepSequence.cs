using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit;
using UnityEngine;
using UnityEngine.Events;

namespace SequenceLogic
{
    /// <summary>
    /// An instance of a step sequence controlling MRTK base interactable GameObjects
    /// </summary>
    public class MRTKInteractableStepSequence : StepSequenceWithDefaultBehaviours<MRTKBaseInteractable>
    {
        /// <summary>
        /// UnityEvent to be run when the step sequence is finished
        /// </summary>
        public UnityEvent OnMRTKSequenceEnded { get; }= new UnityEvent();
        
        /// <summary>
        /// MRTKInteractableStepSequence constructor
        /// </summary>
        /// <param name="steps">A list of steps of type MRTKBaseInteractable</param>
        public MRTKInteractableStepSequence(IList<Step<MRTKBaseInteractable>> steps) : base(steps)
        {
            // Add listeners to the default step sequence behaviours
            OnAllBegin?.AddListener(MRTKBeginDefault);
            OnAllOperation?.AddListener(MRTKOperationDefault);
            OnAllEnd?.AddListener(MRTKEndDefault);
            
            // Invoke custom event when the sequence ends
            OnSequenceEnd?.AddListener(OnMRTKSequenceEnded.Invoke);
            OnSequenceEnd?.AddListener(ResetDesk);
        }

        /// <summary>
        /// Continues the running of the sequence
        /// </summary>
        public void ContinueSteps()
        {
            GetEnumerator().MoveNext();
        }

        private void MRTKBeginDefault(Step<MRTKBaseInteractable> step)
        {
            ResetDesk();

            // Turn on first element of step
            step.From.gameObject.SetActive(true);
            // Start the operation when user pokes the interactable
            step.From.IsPokeSelected.OnExited.AddListener((k) => step.Operation?.Invoke());
        }

        private void MRTKOperationDefault(Step<MRTKBaseInteractable> step)
        {
            ResetDesk();

            // Turn on second element of step
            step.To.gameObject.SetActive(true);
            // Set step to the complete state when second element is poked
            step.To.IsPokeSelected.OnExited.AddListener((k) => step.OnExit?.Invoke());
        }

        private void MRTKEndDefault(Step<MRTKBaseInteractable> step)
        {
            ResetDesk();

            // Continue to next step in the sequence
            ContinueSteps();
        }
        
        // Turn off all MRTKBaseInteractable GameObjects and remove behaviours
        private void ResetDesk()
        {
            foreach (var item in UniqueItemsSet)
            {
                item.IsPokeSelected.OnExited.RemoveAllListeners();
                item.gameObject.SetActive(false);
            }
        }
    }
}
