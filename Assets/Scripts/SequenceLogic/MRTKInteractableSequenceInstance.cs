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

            _positioningSteps = new MRTKInteractableStepSequence(interactables, stepReader.stringStepSequence);
        
            // Add visualisation to the delegate methods
            _positioningSteps.Begin += OnStart;
            _positioningSteps.Operation += OnTransition;
            _positioningSteps.End += OnEnd;

            // Begin the sequence
            ContinueSteps();


        }

        private void OnStart(Step<MRTKBaseInteractable> mrtkInteractablePositioningStep)
        {
            SetInteractable(mrtkInteractablePositioningStep.From, true);
            SetInteractable(mrtkInteractablePositioningStep.To, false);
        }

        private void OnTransition(Step<MRTKBaseInteractable> mrtkInteractablePositioningStep)
        {
            SetInteractable(mrtkInteractablePositioningStep.To, true);
            SetInteractable(mrtkInteractablePositioningStep.From, false);
        }

        private void OnEnd(Step<MRTKBaseInteractable> mrtkInteractablePositioningStep)
        {
            SetInteractable(mrtkInteractablePositioningStep.To, false);
            SetInteractable(mrtkInteractablePositioningStep.From, false);
        }

        private void SetInteractable(MRTKBaseInteractable interactable, bool value)
        {
            if (value)
            {
                interactable.gameObject.ChangeOpacity(1f);
                interactable.IsPokeSelected.OnEntered.AddListener((k) => ContinueSteps());
            }
            else
            {
                interactable.gameObject.ChangeOpacity(0f);
                interactable.IsPokeSelected.OnEntered.RemoveAllListeners();
            }
        }

        /// <summary>
        /// Continues the running of the sequence
        /// </summary>
        public void ContinueSteps()
        {
            _positioningSteps.GetEnumerator().MoveNext();
        }
    }
}
