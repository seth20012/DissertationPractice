using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BluetoothLE
{
    public class MultipleBuzzInstance : BLEWriteInstance
    {
        [SerializeField] private int numberOfRepeats;

        [SerializeField] private float delayBetween;

        public override void Write()
        {
            StartCoroutine(MultiSend(numberOfRepeats, delayBetween));
        }

        private IEnumerator MultiSend(int repeats, float delay)
        {
            for (var i = 0; i < repeats; i++)
            {
                base.Write();
                strength -= 1;
                yield return new WaitForSeconds(delay);
            }
        }
    }
}
