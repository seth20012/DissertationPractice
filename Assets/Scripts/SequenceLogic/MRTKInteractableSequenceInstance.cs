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

        public UnityEvent OnSequenceInstanceEnded { get; private set; } = new UnityEvent();
        
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
        }

        public void CreateSequence()
        {
            var mrtkInteractablesSequence = StepUtils.StepSequenceConvert(
                stepReader.currentSequence.uniqueItems, interactables, stepReader.currentSequence);
            _positioningSteps = new MRTKInteractableStepSequence(mrtkInteractablesSequence);
            _positioningSteps.OnMRTKSequenceEnded?.AddListener(OnSequenceInstanceEnded.Invoke);
            
            _positioningSteps.ContinueSteps();
        }

        public void Continue()
        {
            _positioningSteps.ContinueSteps();
        }
    }
}
