using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoubleBuzz : WriteOnEnable
{
    private IEnumerator BuzzTwice()
    {
        toWrite.Input = valueToWrite;
        yield return new WaitForSeconds(0.5f);
        toWrite.Input = valueToWrite-1; // Edit every slightly to register BLE change
    }

    protected override void OnEnable()
    {
        StartCoroutine(BuzzTwice());
    }
}
