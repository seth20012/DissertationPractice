using UnityEngine;
using UnityEngine.Events;

#if WINDOWS_UWP
using System;
using System.Threading.Tasks;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Bluetooth;
using Windows.Devices.Bluetooth.GenericAttributeProfile;
using Windows.Devices.Enumeration;
using Windows.Storage.Streams;
#endif

namespace BluetoothLE
{
    public class DeviceUWP : MonoBehaviour, ITakeInput<int[]>
    {

#if WINDOWS_UWP
    private BluetoothLEDevice bluetoothLEDevice = null;
    private GattDeviceService selectedService;
    private GattCharacteristic selectedCharacteristic;
    private DeviceWatcher deviceWatcher;
#endif

        public int[] Input
        {
            set => OnInputChanged?.Invoke(value);
        }

        public UnityEvent<int[]> OnInputChanged { get; } = new UnityEvent<int[]>();
        [SerializeField] private string bluetoothAddress;
        [SerializeField] private string serviceUUID;
        [SerializeField] private string characteristicUUID;

        // Start is called before the first frame update
        void Start()
        {
            OnInputChanged?.AddListener(SendValue);
#if WINDOWS_UWP
        // Query for extra properties you want returned
        string[] requestedProperties = { "System.Devices.Aep.DeviceAddress", "System.Devices.Aep.IsConnected" };

        deviceWatcher =
                DeviceInformation.CreateWatcher(
                        BluetoothLEDevice.GetDeviceSelectorFromPairingState(false),
                        requestedProperties,
                        DeviceInformationKind.AssociationEndpoint);

        // Register event handlers before starting the watcher.
        // Added, Updated and Removed are required to get all nearby devices
        deviceWatcher.Added += DeviceWatcher_Added;
        deviceWatcher.Updated += DeviceWatcher_Updated;
        deviceWatcher.Removed += DeviceWatcher_Removed;

        // EnumerationCompleted and Stopped are optional to implement.
        deviceWatcher.EnumerationCompleted += DeviceWatcher_EnumerationCompleted;
        deviceWatcher.Stopped += DeviceWatcher_Stopped;

        // Start the watcher.
        deviceWatcher.Start();
#endif
        }

#if WINDOWS_UWP
    private void DeviceWatcher_Stopped(DeviceWatcher sender, object args)
    {
    }

    private void DeviceWatcher_EnumerationCompleted(DeviceWatcher sender, object args)
    {
    }

    private void DeviceWatcher_Removed(DeviceWatcher sender, DeviceInformationUpdate args)
    {
    }

    private async void DeviceWatcher_Added(DeviceWatcher sender, DeviceInformation args)
    {
        if ((string)args.Properties["System.Devices.Aep.DeviceAddress"] == bluetoothAddress)
        {
            deviceWatcher.Stop();
            bluetoothLEDevice = await BluetoothLEDevice.FromIdAsync(args.Id);
            var serviceResponse = await bluetoothLEDevice.GetGattServicesForUuidAsync(new Guid(serviceUUID));
            selectedService = serviceResponse.Services[0];
            var characteristicResponse = await selectedService.GetCharacteristicsForUuidAsync(new Guid(characteristicUUID));
            selectedCharacteristic = characteristicResponse.Characteristics[0];
        }
    }

    private void DeviceWatcher_Updated(DeviceWatcher sender, DeviceInformationUpdate args)
    {
    }
#endif
        private async void SendValue(int[] values)
        {
            byte[] buffervalue = { (byte)values[0], (byte)values[1] };
#if WINDOWS_UWP
        IBuffer writer = buffervalue.AsBuffer();
        var result = await selectedCharacteristic.WriteValueAsync(writer);
#endif
            Debug.Log(buffervalue[0]);
        }
    }
}
