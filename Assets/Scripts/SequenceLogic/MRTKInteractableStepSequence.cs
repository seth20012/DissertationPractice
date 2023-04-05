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
            OnSequenceEnd?.AddListener(ResetDesk);
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
            ResetDesk();

            step.From.gameObject.SetActive(true);
            step.From.IsPokeSelected.OnExited.AddListener((k) => step.Operation?.Invoke());
        }

        private void MRTKOperationDefault(Step<MRTKBaseInteractable> step)
        {
            ResetDesk();

            step.To.gameObject.SetActive(true);
            step.To.IsPokeSelected.OnExited.AddListener((k) => step.OnExit?.Invoke());
        }

        private void MRTKEndDefault(Step<MRTKBaseInteractable> step)
        {
            ResetDesk();

            ContinueSteps();
        }

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
