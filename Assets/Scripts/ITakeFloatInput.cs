using UnityEngine.Events;

public interface ITakeFloatInput
{
    float Input { set; }
    UnityEvent<float> OnInputChanged { get; }
}
