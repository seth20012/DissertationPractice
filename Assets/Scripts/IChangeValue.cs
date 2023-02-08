using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IChangeValue
{
    float Value { get; }
    UnityEvent<float> OnValueChanged { get; }
}
