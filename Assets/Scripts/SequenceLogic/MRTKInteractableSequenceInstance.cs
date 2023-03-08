using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit;
using UnityEngine;

namespace SequenceLogic
{
    public class MRTKInteractableSequenceInstance : MonoBehaviour
    {
        private MRTKInteractableStepSequence _positioningSteps;

        [SerializeField] private MRTKBaseInteractable[] interactables;
        [SerializeField] private StepReader stepReader;

        // Start is called before the first frame update
        private void Start()
        {
            var gos = new List<GameObject>();
            foreach (var interactable in interactables)
            {
                var go = interactable.gameObject;
                gos.Add(go);
                go.ChangeOpacity(0f); // Hide
            }

            var mrtkInteractablesSequence = StepUtils.StepSequenceConvert(
                stepReader.stringStepSequence.uniqueItems, interactables, stepReader.stringStepSequence);
            _positioningSteps = new MRTKInteractableStepSequence(mrtkInteractablesSequence);

            // Begin the sequence
            _positioningSteps.ContinueSteps();
        }
    }
}
