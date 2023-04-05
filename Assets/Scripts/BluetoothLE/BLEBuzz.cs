namespace BluetoothLE
{
    /// <summary>
    /// Writes to a BLE Device to make it buzz
    /// </summary>
    public class BLEBuzz
    {
        private readonly DeviceUWP _deviceUWP;

        /// <summary>
        /// BLE Writer constructor
        /// </summary>
        /// <param name="device">A BLE device</param>
        public BLEBuzz(DeviceUWP device)
        {
            _deviceUWP = device;
        }

        /// <summary>
        /// Make the device buzz
        /// </summary>
        /// <param name="strength">Strength of buzz</param>
        /// <param name="length">Length of buzz</param>
        public void Write(int strength, int length)
        {
            _deviceUWP.Input = new int[] { strength, length };
        }
    }
}
