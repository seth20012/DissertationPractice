using System.Collections.Generic;
using System.Linq;

namespace SequenceLogic
{
    public static class StepUtils
    {
        public static IList<Step<K>> StepSequenceConvert<T, K>(IList<T> orderedUniqueValues1, IList<K> orderedUniqueValues2,
            StepSequence<T> stepSequenceToConvert)
        {
            IList<Step<K>> stepList = stepSequenceToConvert.Select(
                step => new Step<K>(orderedUniqueValues2[orderedUniqueValues1.IndexOf(step.From)],
                    orderedUniqueValues2[orderedUniqueValues1.IndexOf(step.To)])).ToList();

            return stepList;
        }
    }
}
