using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Events;

namespace SequenceLogic
{
    public class StepReader : MonoBehaviour
    {
        public int index { get; set; }
        public List<StringStepSequence> stringStepSequences { get; private set; } = new List<StringStepSequence>();
        public StringStepSequence currentSequence => stringStepSequences[index];
        public UnityEvent OnNoMoreSequences { get; private set; } = new UnityEvent();

        [SerializeField] private TextAsset[] jsonStepsLists;
        // Start is called before the first frame update
        private void Awake()
        {
            foreach (var jsonSteps in jsonStepsLists)
            {
                var stepList = JsonConvert.DeserializeObject<List<Step<string>>>(jsonSteps.ToString());
                stringStepSequences.Add(new StringStepSequence(stepList));
            }
        }
    }
}
