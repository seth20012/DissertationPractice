using BluetoothLE;
using SequenceLogic;
using UnityEngine;

namespace UX
{
    public class StartMenu : MonoBehaviour
    {
        [SerializeField] private StepReader stepReader;
        [SerializeField] private MRTKInteractableSequenceInstance mrtkInteractableSequenceInstance;
        [SerializeField] private DeviceUWP leftDevice, rightDevice;

        private void Start()
        {
            mrtkInteractableSequenceInstance.OnSequenceInstanceEnded?.AddListener(() => gameObject.SetActive(true));
            stepReader.OnNoMoreSequences?.AddListener(() => gameObject.SetActive(false));
        }

        public void HapticsToggled(bool toggled)
        {
            if (!toggled) return;
            // Wake up watches
            leftDevice.Input = new int[] { 200, 100 };
            rightDevice.Input = new int[] { 200, 100 };
        }
    }
}
