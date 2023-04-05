using UnityEngine.Events;

namespace Interfaces
{
    public interface IChangeValue
    {
        float Value { get; }
        UnityEvent<float> OnValueChanged { get; }
    }
}
