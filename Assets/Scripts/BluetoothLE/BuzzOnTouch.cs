using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace BluetoothLE
{
    /// <summary>
    /// Creates a buzz on the wrist of the users hand that is touching the object
    /// </summary>
    public class BuzzOnTouch : MonoBehaviour
    {
        private BLEBuzz _leftBuzz;
        private BLEBuzz _rightBuzz;
    
        [SerializeField] private MRTKBaseInteractable interactable;
        [SerializeField] private PokeInteractor leftHand;
        [SerializeField] private PokeInteractor rightHand;
        [SerializeField] private DeviceUWP leftDevice;
        [SerializeField] private DeviceUWP rightDevice;

        private void Start()
        {
            _leftBuzz = new BLEBuzz(leftDevice);
            _rightBuzz = new BLEBuzz(rightDevice);
        }

        private void OnEnable()
        {
            interactable.firstSelectEntered?.AddListener(OnPoke);
        }

        private void OnDisable()
        {
            interactable.firstSelectEntered?.RemoveListener(OnPoke);
        }

        private void OnPoke(SelectEnterEventArgs args)
        {
            // The interactor that poked object
            var interactor = args.interactorObject;
            
            // Buzz the corresponding wrist
            if ((PokeInteractor)interactor == leftHand)
            {
                _leftBuzz.Write(180, 30);
            }
            else if ((PokeInteractor)interactor == rightHand)
            {
                _rightBuzz.Write(180, 30);
            }
        }
    }
}
