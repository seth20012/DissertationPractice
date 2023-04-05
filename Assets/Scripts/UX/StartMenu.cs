using BluetoothLE;
using SequenceLogic;
using UnityEngine;

namespace UX
{
    /// <summary>
    /// UX controller for the start menu
    /// </summary>
    public class StartMenu : MonoBehaviour
    {
        [SerializeField] private MRTKInteractableSequenceInstance mrtkInteractableSequenceInstance;
        [SerializeField] private DeviceUWP leftDevice, rightDevice;

        private void Start()
        {
            // Bring menu up when user finishes task sequence
            mrtkInteractableSequenceInstance.OnSequenceInstanceEnded?.AddListener(() => gameObject.SetActive(true));
        }
        
        /// <summary>
        /// When user toggles the haptic modality, give the watches a buzz
        /// </summary>
        /// <param name="toggled">Status of the toggle</param>
        public void HapticsToggled(bool toggled)
        {
            if (!toggled) return;
            // Wake up watches
            leftDevice.Input = new int[] { 200, 100 };
            rightDevice.Input = new int[] { 200, 100 };
        }
    }
}
