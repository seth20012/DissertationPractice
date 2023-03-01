using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class StepReader : MonoBehaviour
{
    public StepSequence Steps { get; private set; }
    [SerializeField] private TextAsset jsonSteps;
    // Start is called before the first frame update
    void Awake()
    {
        var stepList = JsonConvert.DeserializeObject<List<Step>>(jsonSteps.ToString());
        Steps = new StepSequence(stepList);
        Debug.Log(Steps.UniqueItems.Count);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
