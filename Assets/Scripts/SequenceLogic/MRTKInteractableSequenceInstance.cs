using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

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
            foreach (var interactable in interactables)
            {
                var go = interactable.gameObject;
                go.SetActive(false);
            }

            var mrtkInteractablesSequence = StepUtils.StepSequenceConvert(
                stepReader.stringStepSequence.uniqueItems, interactables, stepReader.stringStepSequence);
            _positioningSteps = new MRTKInteractableStepSequence(mrtkInteractablesSequence);

            // Begin the sequence
            _positioningSteps.ContinueSteps();
        }

        public void ContinueSteps()
        {
            _positioningSteps.ContinueSteps();
        }
    }
}
