using UnityEngine.Events;

namespace Interfaces
{
    public interface ITakeInput<T>
    {
        T Input { set; }
        UnityEvent<T> OnInputChanged { get; }
    }
}
