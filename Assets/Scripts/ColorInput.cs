using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColorInput : MonoBehaviour, ITakeFloatInput
{
    private Color _color;

    public UnityEvent<float> OnInputChanged { get; private set; } = new UnityEvent<float>();
    public float Input
    {
        set => OnInputChanged?.Invoke(value);
    }

    [SerializeField] private MeshRenderer meshRenderer;

    // Start is called before the first frame update
    private void Start()
    {
        _color = meshRenderer.material.color; // Inherit the materials color settings
        OnInputChanged?.AddListener(HandleInputChanged);
    }

    private void HandleInputChanged(float value)
    {
        _color.a = value; // Set color opacity
        meshRenderer.material.color = _color;
    }
}
