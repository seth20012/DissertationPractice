using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOPositionSequenceInstance : MonoBehaviour
{
    public GOPositioningStepSequence PositioningSteps { get; private set; }

    [SerializeField] private GameObject[] gameObjects;
    [SerializeField] private StepReader stepReader;

    // Start is called before the first frame update
    void Start()
    {
        PositioningSteps = new GOPositioningStepSequence(gameObjects, stepReader.Steps);
        Debug.Log(PositioningSteps.Steps[0].From.name);
    }
}
