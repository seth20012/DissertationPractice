using System.Collections.Generic;
using UnityEngine.Events;

namespace SequenceLogic
{
    public class StepSequenceWithDefaultBehaviours<T> : StepSequence<T>
    {
        protected readonly UnityEvent<Step<T>> OnAllBegin = new UnityEvent<Step<T>>();
        protected readonly UnityEvent<Step<T>> OnAllOperation = new UnityEvent<Step<T>>();
        protected readonly UnityEvent<Step<T>> OnAllEnd = new UnityEvent<Step<T>>();
        
        protected StepSequenceWithDefaultBehaviours(IList<Step<T>> steps) : base(steps)
        {
            foreach (var step in Steps)
            {
                step.OnEntry?.AddListener(() => OnAllBegin?.Invoke(step));
                step.Operation?.AddListener(() => OnAllOperation?.Invoke(step));
                step.OnExit?.AddListener(() => OnAllEnd?.Invoke(step));
            }
        }
    }
}
