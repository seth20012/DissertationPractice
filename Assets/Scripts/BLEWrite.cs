using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BLEWrite : MonoBehaviour, ITakeFloatInput
{
    public float Input 
    {
        set => OnInputChanged?.Invoke(value);
    }

    public UnityEvent<float> OnInputChanged { get; } = new UnityEvent<float>();

    [SerializeField] private string deviceId;
    [SerializeField] private string serviceId;
    [SerializeField] private string characteristicId;

    private void Start()
    {
        OnInputChanged?.AddListener(HandleInputChanged);
    }

    private void HandleInputChanged(float value)
    {
        byte[] payload = { (byte)(int)value };
        BleApi.BLEData data = new BleApi.BLEData();
        data.buf = new byte[512];
        data.size = (short)payload.Length;
        data.deviceId = deviceId;
        data.serviceUuid = serviceId;
        data.characteristicUuid = characteristicId;
        for (int i = 0; i < payload.Length; i++)
            data.buf[i] = payload[i];
        // no error code available in non-blocking mode
        BleApi.SendData(in data, false);
    }
}
