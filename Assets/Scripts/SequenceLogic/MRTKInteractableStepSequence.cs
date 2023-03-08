using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit;
using UnityEngine;

namespace SequenceLogic
{
    public class MRTKInteractableStepSequence : StepSequenceWithDefaultBehaviours<MRTKBaseInteractable>
    {
        public MRTKInteractableStepSequence(IList<Step<MRTKBaseInteractable>> steps) : base(steps)
        {
            OnAllBegin?.AddListener(MRTKBeginDefault);
            OnAllOperation?.AddListener(MRTKOperationDefault);
            OnAllEnd?.AddListener(MRTKEndDefault);
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
            SetInteractable(step.From, true);
            SetInteractable(step.To, false);
        }

        private void MRTKOperationDefault(Step<MRTKBaseInteractable> step)
        {
            Debug.Log("Middle");
            SetInteractable(step.To, true);
            SetInteractable(step.From, false);
        }

        private void MRTKEndDefault(Step<MRTKBaseInteractable> step)
        {
            Debug.Log("End");
            SetInteractable(step.To, false);
            SetInteractable(step.From, false);
        }
    }
}
