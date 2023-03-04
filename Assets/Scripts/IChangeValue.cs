using UnityEngine.Events;

public interface IChangeValue
{
    float Value { get; }
    UnityEvent<float> OnValueChanged { get; }
}
