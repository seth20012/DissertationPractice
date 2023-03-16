using UnityEngine;

namespace BluetoothLE
{
    public class WriteOnEnable : MonoBehaviour
    {
        [SerializeField] private BLEWriteInstance[] BleWriteInstances;

        public void OnEnable()
        {
            foreach (var bleWriteInstance in BleWriteInstances)
            {
                bleWriteInstance.Write();
            }
        }
    }
}
