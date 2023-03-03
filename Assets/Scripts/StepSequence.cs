using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StepSequence : IEnumerable<Step>
{
    private HashSet<string> UniqueItemsSet = new HashSet<string>();
    private readonly IList<Step> _steps;
    
    /// <summary>
    /// An alphabetical list of unique items present within the steps
    /// </summary>
    public List<string> UniqueItems => UniqueItemsSet.OrderBy(s => s).ToList();

    public StepSequence(IEnumerable<Step> steps)
    {
        _steps = (IList<Step>)steps;

        foreach (Step step in _steps)
        {
            UniqueItemsSet.Add(step.From);
            UniqueItemsSet.Add(step.To);
        }
    }

    public IEnumerator<Step> GetEnumerator()
    {
        return _steps.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
