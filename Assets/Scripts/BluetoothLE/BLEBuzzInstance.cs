using System;
using UnityEngine;
using UnityEngine.Events;

namespace BluetoothLE
{
    /// <summary>
    /// A Monobehaviour instance of BLE Writer
    /// </summary>
    public class BLEBuzzInstance : MonoBehaviour
    {
        private BLEBuzz _buzzer;
        
        // Only allow one byte size
        [Range(0, 255)][SerializeField] protected int strength;
        [Range(0, 255)] [SerializeField] protected int length;
        [SerializeField] private DeviceUWP device;

        protected void Awake()
        {
            _buzzer = new BLEBuzz(device);
        }

        /// <summary>
        /// Write to the BLE device using values defined in the inspector
        /// </summary>
        public virtual void Write()
        {
            _buzzer.Write(strength, length);
        }
    }
}
