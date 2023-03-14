using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SequenceLogic
{
    public class StepSequence<T>: IEnumerable<Step<T>>
    {
        protected int Index = 0;
        protected readonly HashSet<T> UniqueItemsSet = new HashSet<T>();
        protected readonly IList<Step<T>> Steps;

        protected StepSequence(IList<Step<T>> steps)
        {
            Steps = steps;

            foreach (Step<T> step in Steps)
            {
                UniqueItemsSet.Add(step.From);
                UniqueItemsSet.Add(step.To);
            }
        }

        public virtual IEnumerator<Step<T>> GetEnumerator()
        {
            while (Index < Steps.Count)
            {
                var currentStep = Steps[Index];
                Debug.Log(Index);
                currentStep.OnEntry?.Invoke();
                Index++;
                yield return currentStep;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
