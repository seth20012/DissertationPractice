using System.Collections.Generic;
using System.Linq;

namespace SequenceLogic
{
    public class StringStepSequence : StepSequence<string>
    {
        /// <summary>
        /// An alphabetical list of unique items present within the steps
        /// </summary>
        public List<string> uniqueItems => UniqueItemsSet.OrderBy(s => s).ToList();

        public StringStepSequence(IList<Step<string>> steps) : base(steps)
        {
        }
    }
}
