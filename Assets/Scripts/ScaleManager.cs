using UnityEngine;

public class ScaleManager : MonoBehaviour
{
    protected float _currentValue;
    protected ScaleInstance _scaleInstance;
    protected IChangeValue _changingValue;
    protected ITakeInput<float> TakeInput;

    protected void Start()
    {
        _changingValue = GetComponent<IChangeValue>();
        TakeInput = GetComponent<ITakeInput<float>>();
        _scaleInstance = GetComponent<ScaleInstance>();
        _changingValue.OnValueChanged?.AddListener(HandleValueChange);
    }

    protected void HandleValueChange(float value)
    {
        _currentValue = _scaleInstance.Scaler.CalculateOutputValue(value);
        Debug.Log(_currentValue);
        TakeInput.Input = _currentValue;
    }
}
