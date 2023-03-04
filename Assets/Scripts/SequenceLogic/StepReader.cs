using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using SequenceLogic;

public class StepReader : MonoBehaviour
{
    public StringStepSequence stringStepSequence { get; private set; }
    [SerializeField] private TextAsset jsonSteps;
    // Start is called before the first frame update
    private void Awake()
    {
        var stepList = JsonConvert.DeserializeObject<List<Step<string>>>(jsonSteps.ToString());
        stringStepSequence = new StringStepSequence(stepList);
    }
}
