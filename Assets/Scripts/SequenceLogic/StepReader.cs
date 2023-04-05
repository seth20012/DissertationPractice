using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace SequenceLogic
{
    /// <summary>
    /// Read a list of task steps from a JSON list
    /// </summary>
    public class StepReader : MonoBehaviour
    {
        
        /// <summary>
        /// The current index for the active list of instructions
        /// </summary>
        public int index { get; set; }
        
        /// <summary>
        /// The current list of instructions
        /// </summary>
        public StringStepSequence currentSequence => _stringStepSequences[index];

        private readonly List<StringStepSequence> _stringStepSequences = new List<StringStepSequence>();

        [SerializeField] private TextAsset[] jsonStepsLists;
        
        private void Awake()
        {
            // Load in the task lists from the supplied json files
            foreach (var jsonSteps in jsonStepsLists)
            {
                var stepList = JsonConvert.DeserializeObject<List<Step<string>>>(jsonSteps.ToString());
                _stringStepSequences.Add(new StringStepSequence(stepList));
            }
        }
    }
}
