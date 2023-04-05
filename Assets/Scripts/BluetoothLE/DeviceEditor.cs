using Interfaces;
using UnityEngine;
using UnityEngine.Events;

namespace BluetoothLE
{
    public class DeviceEditor : MonoBehaviour, ITakeInput<int[]>
    {
        public int[] Input 
        {
            set => OnInputChanged?.Invoke(value);
        }

        public UnityEvent<int[]> OnInputChanged { get; } = new UnityEvent<int[]>();

        [SerializeField] private string deviceId;
        [SerializeField] private string serviceId;
        [SerializeField] private string characteristicId;

        private void Start()
        {
            OnInputChanged?.AddListener(HandleInputChanged);
        }

        private void HandleInputChanged(int[] values)
        {
            byte[] payload = { (byte)values[0], (byte)values[1] };
            BleApi.BLEData data = new BleApi.BLEData();
            data.buf = new byte[512];
            data.size = (short)payload.Length;
            data.deviceId = deviceId;
            data.serviceUuid = serviceId;
            data.characteristicUuid = characteristicId;
            for (int i = 0; i < payload.Length; i++)
                data.buf[i] = payload[i];
            Debug.Log(payload[0]);
            Debug.Log(payload[1]);
            // no error code available in non-blocking mode
            BleApi.SendData(in data, false);
        }
    }
}
