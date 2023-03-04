using UnityEngine;

public class ScaleManager : MonoBehaviour
{
    protected float _currentValue;
    protected ScaleInstance _scaleInstance;
    protected IChangeValue _changingValue;
    protected ITakeFloatInput _takeFloatInput;

    protected void Start()
    {
        _changingValue = GetComponent<IChangeValue>();
        _takeFloatInput = GetComponent<ITakeFloatInput>();
        _scaleInstance = GetComponent<ScaleInstance>();
        _changingValue.OnValueChanged?.AddListener(HandleValueChange);
    }

    protected void HandleValueChange(float value)
    {
        _currentValue = _scaleInstance.Scaler.CalculateOutputValue(value);
        Debug.Log(_currentValue);
        _takeFloatInput.Input = _currentValue;
    }
}
