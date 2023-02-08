using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RumbleInput : MonoBehaviour, ITakeFloatInput
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
