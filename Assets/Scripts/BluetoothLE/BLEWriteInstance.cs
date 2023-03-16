using System;
using UnityEngine;
using UnityEngine.Events;

namespace BluetoothLE
{
    public class BLEWriteInstance : MonoBehaviour
    {
        public BLEWrite writer;

        [Range(0, 255)][SerializeField] protected int strength;
        [Range(0, 255)] [SerializeField] protected int length;
        [SerializeField] private DeviceUWP device;

        protected void Start()
        {
            writer = new BLEWrite(device);
        }

        public void Write()
        {
            writer.Write(strength, length);
        }
    }
}
