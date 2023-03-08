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
                interactable.gameObject.ChangeOpacity(1f);
                interactable.IsPokeSelected.OnEntered.AddListener((k) => ContinueSteps());
            }
            else
            {
                interactable.gameObject.ChangeOpacity(0f);
                interactable.IsPokeSelected.OnEntered.RemoveAllListeners();
            }
        }

        private void MRTKBeginDefault(Step<MRTKBaseInteractable> step)
        {
            SetInteractable(step.From, true);
            SetInteractable(step.To, false);
        }

        private void MRTKOperationDefault(Step<MRTKBaseInteractable> step)
        {
            SetInteractable(step.To, true);
            SetInteractable(step.From, false);
        }

        private void MRTKEndDefault(Step<MRTKBaseInteractable> step)
        {
            SetInteractable(step.To, false);
            SetInteractable(step.From, false);
        }
    }
}
