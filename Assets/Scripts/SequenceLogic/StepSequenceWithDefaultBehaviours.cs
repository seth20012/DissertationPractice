using System.Collections.Generic;
using UnityEngine.Events;

namespace SequenceLogic
{
    /// <summary>
    /// Adds default behaviours for the Step UnityEvents
    /// </summary>
    /// <typeparam name="T">The type of the From & To step objects</typeparam>
    public class StepSequenceWithDefaultBehaviours<T> : StepSequence<T>
    {
        protected readonly UnityEvent<Step<T>> OnAllBegin = new UnityEvent<Step<T>>();
        protected readonly UnityEvent<Step<T>> OnAllOperation = new UnityEvent<Step<T>>();
        protected readonly UnityEvent<Step<T>> OnAllEnd = new UnityEvent<Step<T>>();
        
        /// <summary>
        /// StepSequence with default behaviours constructor
        /// </summary>
        /// <param name="steps">A list of steps to create a sequence from</param>
        protected StepSequenceWithDefaultBehaviours(IList<Step<T>> steps) : base(steps)
        {
            // Add the default behaviours
            foreach (var step in Steps)
            {
                step.OnEntry?.AddListener(() => OnAllBegin?.Invoke(step));
                step.Operation?.AddListener(() => OnAllOperation?.Invoke(step));
                step.OnExit?.AddListener(() => OnAllEnd?.Invoke(step));
            }
        }
    }
}
