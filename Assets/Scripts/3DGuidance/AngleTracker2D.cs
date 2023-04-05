using System.Collections;
using Interfaces;
using UnityEngine;
using UnityEngine.Events;

namespace _3DGuidance
{
    public class AngleTracker2D : MonoBehaviour, IChangeValue
    {
        private float _value;
    
        /// <inheritdoc/>
        public UnityEvent<float> OnValueChanged { get; } = new UnityEvent<float>();
    
        /// <inheritdoc/>
        public float Value
        {
            get => _value;
            private set 
            {
                _value = value;
                OnValueChanged?.Invoke(value); 
            }
        }

        [SerializeField] private GameObject objectToTrack;

        // Start is called before the first frame update
        void Start()
        {
            OnValueChanged?.AddListener((float value) => Debug.Log(value));
            StartCoroutine(UpdateAngle());
        }

        private IEnumerator UpdateAngle()
        {
            while (true)
            {
                var forward = (transform.position - objectToTrack.transform.position);
                Value = Vector3.SignedAngle(objectToTrack.transform.forward, forward, Vector3.up);

                Debug.Log(Value);
                var sin = Mathf.Sin(Mathf.Deg2Rad * Value);
                Debug.Log("L : " + (0.5 - sin / 2) + ", R : " + (0.5 + sin / 2));
                yield return new WaitForSeconds(0.15f);
            }
        }
    }
}
