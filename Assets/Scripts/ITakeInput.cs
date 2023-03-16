using UnityEngine.Events;

public interface ITakeInput<T>
{
    T Input { set; }
    UnityEvent<T> OnInputChanged { get; }
}
