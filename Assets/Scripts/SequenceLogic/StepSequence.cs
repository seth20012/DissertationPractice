using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SequenceLogic
{
    /// <summary>
    /// An enumerable sequence of Steps
    /// Will enumerate over each step and activate their behaviours
    /// </summary>
    /// <typeparam name="T">The type of the To & From Step objects</typeparam>
    public class StepSequence<T>: IEnumerable<Step<T>>
    {
        // Current enumerator index
        private int _index = 0;
        
        protected readonly HashSet<T> UniqueItemsSet = new HashSet<T>();
        protected UnityEvent OnSequenceEnd { get; } = new UnityEvent();
        
        // The list of steps within the sequence
        public readonly IList<Step<T>> Steps;

        /// <summary>
        /// Step Sequence constructor
        /// </summary>
        /// <param name="steps">A list of steps</param>
        protected StepSequence(IList<Step<T>> steps)
        {
            Steps = steps;

            // Create unique set of To & From objects
            foreach (Step<T> step in Steps)
            {
                UniqueItemsSet.Add(step.From);
                UniqueItemsSet.Add(step.To);
            }
        }

        /// <summary>
        /// Enumerates over the steps, triggering their functionality
        /// </summary>
        /// <returns>The current step (better access the list for individual items)</returns>
        public virtual IEnumerator<Step<T>> GetEnumerator()
        {
            while (_index < Steps.Count)
            {
                // Trigger the step entry functionality
                var currentStep = Steps[_index];
                currentStep.OnEntry?.Invoke();
                
                // Move on
                _index++;
                yield return currentStep;
            }
            OnSequenceEnd?.Invoke(); // Signal that the sequence is over
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
