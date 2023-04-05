using Extensions;
using Interfaces;
using UnityEngine;
using UnityEngine.Events;

namespace _3DGuidance
{
    public class ColorInput : MonoBehaviour, ITakeInput<float>
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
}
