using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StepSequence : IEnumerable<Step>
{
    public IList<Step> Steps { get; private set; }

    private HashSet<string> UniqueItemsSet = new HashSet<string>();
    public List<string> UniqueItems
    {
        // Return in alphabetical order
        get => UniqueItemsSet.OrderBy(s => s).ToList();
    }

    public StepSequence(IEnumerable<Step> steps)
    {
        Steps = (IList<Step>)steps;

        foreach (Step step in Steps)
        {
            UniqueItemsSet.Add(step.From);
            UniqueItemsSet.Add(step.To);
        }
    }

    public IEnumerator<Step> GetEnumerator()
    {
        foreach (Step step in Steps)
        {
            yield return step;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
