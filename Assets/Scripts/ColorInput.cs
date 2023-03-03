using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColorInput : MonoBehaviour, ITakeFloatInput
{
    public UnityEvent<float> OnInputChanged { get; private set; } = new UnityEvent<float>();
    public float Input
    {
        set => OnInputChanged?.Invoke(value);
    }

    [SerializeField] private GameObject go;

    // Start is called before the first frame update
    private void Start()
    {
        OnInputChanged?.AddListener((value) => go.ChangeOpacity(value));
    }
}
