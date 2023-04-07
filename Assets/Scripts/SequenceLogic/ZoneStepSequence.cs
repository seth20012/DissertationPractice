using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SequenceLogic
{
    public class ZoneStepSequence : StepSequenceWithDefaultBehaviours<StepInstructionModalityController>
    {
        /// <summary>
        /// UnityEvent to be run when the step sequence is finished
        /// </summary>
        public UnityEvent OnZoneSequenceEnded { get; }= new UnityEvent();


        public ZoneStepSequence(IList<Step<StepInstructionModalityController>> steps) : base(steps)
        {
            OnAllBegin?.AddListener(ZoneBeginDefault);
            OnAllOperation?.AddListener(ZoneOperationDefault);
            OnAllEnd?.AddListener(ZoneEndDefault);
            
            // Invoke custom event when the sequence ends
            OnSequenceEnd?.AddListener(OnZoneSequenceEnded.Invoke);
            OnSequenceEnd?.AddListener(ResetDesk);
        }
        
        /// <summary>
        /// Continues the running of the sequence
        /// </summary>
        public void ContinueSteps()
        {
            GetEnumerator().MoveNext();
        }

        private void ZoneBeginDefault(Step<StepInstructionModalityController> step)
        {
            ResetDesk();
            
            step.From.gameObject.SetActive(true);
            step.From.HandExited?.AddListener(() => step.Operation?.Invoke());
        }

        private void ZoneOperationDefault(Step<StepInstructionModalityController> step)
        {
            ResetDesk();
            
            step.To.gameObject.SetActive(true);
            step.To.HandExited?.AddListener(() => step.OnExit?.Invoke());
        }

        private void ZoneEndDefault(Step<StepInstructionModalityController> step)
        {
            ResetDesk();

            ContinueSteps();
        }
        
        // Turn off all Zone GameObjects and remove behaviours
        private void ResetDesk()
        {
            foreach (var item in UniqueItemsSet)
            {
                item.HandExited?.RemoveAllListeners();
                item.gameObject.SetActive(false);
            }
        }
    }
}
