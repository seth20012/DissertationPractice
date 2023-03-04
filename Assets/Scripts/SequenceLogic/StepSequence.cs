using System.Collections;
using System.Collections.Generic;

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
            return Steps.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
