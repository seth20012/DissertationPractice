using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class OnlyTakeGreaterInput : ScaleManager
{
    protected List<IChangeValue> changingValues;
    protected List<float> values = new List<float>(2) { 0, 0 };

    // Start is called before the first frame update
    protected override void Start()
    {
        changingValues = gameObject.GetComponents<IChangeValue>().ToList();
        TakeInput = GetComponent<ITakeInput<float>>();
        _scaleInstance = GetComponent<ScaleInstance>();
        
        foreach (var changingValue in changingValues)
        {
            var index = changingValues.IndexOf(changingValue);
            changingValue.OnValueChanged?.AddListener((val) => HandleValueChange(index, val));
        }
    }

    protected void OnEnable()
    {
        values = new List<float>(2) { 0, 0 };
    }

    protected void HandleValueChange(int index, float value)
    {
        var scaledValue = _scaleInstance.Scaler.CalculateOutputValue(value);
        values[index] = scaledValue;
        Debug.Log("Index : " + index);
        Debug.Log("Value : " + scaledValue);
        
        if (!values.Any(v => v < scaledValue)) TakeInput.Input = scaledValue;
    }
}
