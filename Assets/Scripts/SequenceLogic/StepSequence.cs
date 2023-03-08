using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

namespace SequenceLogic
{
    public class StepSequence<T>: IEnumerable<Step<T>>
    {
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
            foreach(Step<T> step in Steps)
            {
                switch (step.Status)
                {
                    case StepStatus.AtStart:
                        step.OnEntry?.Invoke();
                        yield return step;
                        break;
                    case StepStatus.InProcess:
                        step.Operation?.Invoke();
                        yield return step;
                        break;
                    default:
                        step.OnExit?.Invoke();
                        continue;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
