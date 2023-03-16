namespace BluetoothLE
{
    public class BLEWrite
    {
        protected DeviceUWP deviceUWP;

        public BLEWrite(DeviceUWP device)
        {
            deviceUWP = device;
        }

        public void Write(int strength, int length)
        {
            deviceUWP.Input = new int[] { strength, length };
        }
    }
}
