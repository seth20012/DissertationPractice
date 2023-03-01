using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GOPositioningStepSequence : IEnumerable<GOPositioningStep>
{
    public IList<GOPositioningStep> Steps { get; private set; }
    private Dictionary<string, GameObject> goIdentifierLookup = new Dictionary<string, GameObject>();
    public GOPositioningStep CurrentStep { get; private set; }

    public GOPositioningStepSequence(IEnumerable<GOPositioningStep> goPositioningSteps)
    {
        Steps = (IList<GOPositioningStep>)goPositioningSteps;
    }

    public GOPositioningStepSequence(IList<GameObject> gameObjects, StepSequence steps)
    {
        Steps = new List<GOPositioningStep>();
        for (var i = 0; i < steps.UniqueItems.Count; i++)
        {
            goIdentifierLookup.Add(steps.UniqueItems[i], gameObjects[i]);
        }

        foreach (Step step in steps.Steps)
        {
            Debug.Log(goIdentifierLookup.Keys);
            Steps.Add(new GOPositioningStep(goIdentifierLookup[step.From], goIdentifierLookup[step.To]));
        }
    }

    public IEnumerator<GOPositioningStep> GetEnumerator()
    {
        foreach(GOPositioningStep goStep in Steps)
        {
            yield return goStep;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
