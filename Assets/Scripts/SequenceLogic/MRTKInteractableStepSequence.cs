using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit;
using UnityEngine;

namespace SequenceLogic
{
    public class MRTKInteractableStepSequence : StepSequence<MRTKBaseInteractable>
    {
        /// <summary>
        /// StepOperation delegate. Performs an action during a PositioningStep
        /// </summary>
        public delegate void StepOperation(Step<MRTKBaseInteractable> mrtkInteractablePositioningStep);
    
        /// <summary>
        /// The StepOperation method run to initialise a step
        /// </summary>
        public StepOperation Begin { get; set; }
        
        /// <summary>
        /// The StepOperation method run when the user begins a step
        /// </summary>
        public StepOperation Operation { get; set; }
        
        /// <summary>
        /// The StepOperation method run when the user completes a step
        /// </summary>
        public StepOperation End { get; set; }
    
        public MRTKInteractableStepSequence(IList<Step<MRTKBaseInteractable>> steps) : base(steps)
        {
            Begin += BeginDefault;
            Operation += DoOperationDefault;
        }

        /// <summary>
        /// GOPositioningStepSequence Constructor
        /// </summary>
        /// <param name="items">An ordered list of GameObjects to be used as step sequence To/From items</param>
        /// <param name="stringStepSequence">The StepSequence to follow</param>
        public MRTKInteractableStepSequence(IList<MRTKBaseInteractable> items, StringStepSequence stringStepSequence)
            : base(StepUtils.StepSequenceConvert(stringStepSequence.uniqueItems, items, stringStepSequence))
        {
            // Add default functionality to delegate methods
            Begin += BeginDefault;
            Operation += DoOperationDefault;
        }

        /// <summary>
        /// Iterate through a step sequence running any associated functionality
        /// </summary>
        /// <returns>The step being operated on</returns>
        public override IEnumerator<Step<MRTKBaseInteractable>> GetEnumerator()
        {
            foreach(Step<MRTKBaseInteractable> step in Steps)
            {
                switch (step.Status)
                {
                    case StepStatus.AtStart:
                        Begin(step);
                        Debug.Log("Begin!");
                        yield return step;
                        break;
                    case StepStatus.InProcess:
                        Operation(step);
                        Debug.Log("Operate!");
                        yield return step;
                        break;
                    default:
                        End(step);
                        Debug.Log("End!");
                        continue;
                }
            }
        }

        private void BeginDefault(Step<MRTKBaseInteractable> mrtkInteractablePositioningStep)
        {
            mrtkInteractablePositioningStep.Status = StepStatus.InProcess;
        }

        private void DoOperationDefault(Step<MRTKBaseInteractable> mrtkInteractablePositioningStep)
        {
            mrtkInteractablePositioningStep.Status = StepStatus.AtEnd;
        }
    }
}
