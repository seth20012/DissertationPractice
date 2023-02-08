using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScaleManager : MonoBehaviour
{
    protected float _currentValue;
    protected ExponentialScaler _exponentialScaler;
    protected IChangeValue _changingValue;
    protected ITakeFloatInput _takeFloatInput;

    [SerializeField] protected float valueAtMaxInput;
    [SerializeField] protected float valueAtMinInput;
    [SerializeField] protected float maxInput;
    [SerializeField] protected float minInput;

    protected void Start()
    {
        _changingValue = GetComponent<IChangeValue>();
        _takeFloatInput = GetComponent<ITakeFloatInput>();
        _exponentialScaler = new ExponentialScaler(minInput, maxInput, valueAtMinInput, valueAtMaxInput);
        _changingValue.OnValueChanged?.AddListener(HandleValueChange);
    }

    protected void HandleValueChange(float value)
    {
        _currentValue = _exponentialScaler.CalculateOutputValue(value);
        _takeFloatInput.Input = _currentValue;
    }
}
