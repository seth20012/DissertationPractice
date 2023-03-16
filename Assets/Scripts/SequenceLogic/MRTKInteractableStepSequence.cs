using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit;
using UnityEngine;
using UnityEngine.Events;

namespace SequenceLogic
{
    public class MRTKInteractableStepSequence : StepSequenceWithDefaultBehaviours<MRTKBaseInteractable>
    {
        public UnityEvent OnMRTKSequenceEnded { get; private set; }= new UnityEvent();
        
        public MRTKInteractableStepSequence(IList<Step<MRTKBaseInteractable>> steps) : base(steps)
        {
            OnAllBegin?.AddListener(MRTKBeginDefault);
            OnAllOperation?.AddListener(MRTKOperationDefault);
            OnAllEnd?.AddListener(MRTKEndDefault);
            
            OnSequenceEnd?.AddListener(OnMRTKSequenceEnded.Invoke);
        }

        /// <summary>
        /// Continues the running of the sequence
        /// </summary>
        public void ContinueSteps()
        {
            GetEnumerator().MoveNext();
        }
        
        private void SetInteractable(MRTKBaseInteractable interactable, bool value)
        {
            if (value)
            {
                interactable.IsPokeSelected.OnExited.AddListener((k) => ContinueSteps());
            }
            else
            {
                interactable.IsPokeSelected.OnEntered.RemoveAllListeners();
            }
            interactable.gameObject.SetActive(value);
        }

        private void MRTKBeginDefault(Step<MRTKBaseInteractable> step)
        {
            Debug.Log("Start");

            step.To.IsPokeSelected.OnExited.RemoveAllListeners();
            step.From.IsPokeSelected.OnExited.RemoveAllListeners();
            
            step.From.gameObject.SetActive(true);
            step.From.IsPokeSelected.OnExited.AddListener((k) => step.Operation?.Invoke());
            
            step.To.gameObject.SetActive(false);
        }

        private void MRTKOperationDefault(Step<MRTKBaseInteractable> step)
        {
            Debug.Log("Middle");

            step.To.IsPokeHovered.OnExited.RemoveAllListeners();
            step.From.IsPokeHovered.OnExited.RemoveAllListeners();
            
            step.From.gameObject.SetActive(false);
            
            step.To.gameObject.SetActive(true);
            step.To.IsPokeSelected.OnExited.AddListener((k) => step.OnExit?.Invoke());
        }

        private void MRTKEndDefault(Step<MRTKBaseInteractable> step)
        {
            Debug.Log("End");

            step.From.IsPokeSelected.OnExited.RemoveAllListeners();
            step.From.gameObject.SetActive(false);
            
            step.To.IsPokeSelected.OnExited.RemoveAllListeners();
            step.To.gameObject.SetActive(false);
            
            ContinueSteps();
        }
    }
}
