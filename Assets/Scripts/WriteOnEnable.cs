using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class WriteOnEnable : MonoBehaviour
{
    [SerializeField] protected BLEWrite toWrite;

    [Range(0, 255)][SerializeField] protected int valueToWrite;

    protected virtual void OnEnable()
    {
        toWrite.Input = valueToWrite;
    }
}
