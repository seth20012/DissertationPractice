using UnityEngine;

namespace BluetoothLE
{
    /// <summary>
    /// Trigger a BLE Write instance when a Monobehaviour is enabled
    /// </summary>
    public class WriteOnEnable : MonoBehaviour
    {
        /// <summary>
        /// List of BLE writer instances
        /// </summary>
        [SerializeField] private BLEBuzzInstance[] BleWriteInstances;

        public void OnEnable()
        {
            // Trigger each of the BLE write instances to make devices buzz
            foreach (var bleWriteInstance in BleWriteInstances)
            {
                bleWriteInstance.Write();
            }
        }
    }
}
