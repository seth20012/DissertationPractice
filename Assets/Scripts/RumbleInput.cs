using Interfaces;
using UnityEngine;
using UnityEngine.Events;

public class RumbleInput : MonoBehaviour, ITakeInput<float>
{
    public UnityEvent<float> OnInputChanged { get; } = new UnityEvent<float>();
    public float Input
    {
        set => OnInputChanged?.Invoke(value);
    }

    [SerializeField] PS4Controller controller;

    void Start()
    {
        OnInputChanged.AddListener(HandleInputChanged);
    }

    private void HandleInputChanged(float value)
    {
        controller.GameController.SetMotorSpeeds(value, value);
    }
}
