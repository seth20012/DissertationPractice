using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Events;

namespace SequenceLogic
{
    public class StepReader : MonoBehaviour
    {
        private int _index;
        public List<StringStepSequence> stringStepSequences { get; private set; } = new List<StringStepSequence>();
        public StringStepSequence currentSequence => stringStepSequences[_index];
        public UnityEvent OnNoMoreSequences { get; private set; } = new UnityEvent();

        [SerializeField] private TextAsset[] jsonStepsLists;
        // Start is called before the first frame update
        private void Awake()
        {
            _index = -1;
            foreach (var jsonSteps in jsonStepsLists)
            {
                var stepList = JsonConvert.DeserializeObject<List<Step<string>>>(jsonSteps.ToString());
                stringStepSequences.Add(new StringStepSequence(stepList));
            }
        }

        public void NewSequence()
        {
            if (_index < stringStepSequences.Count - 1)
            {
                _index++;
            }
            else
            {
                OnNoMoreSequences?.Invoke();
            }
        }
    }
}
