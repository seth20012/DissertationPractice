using System.Collections;
using Interfaces;
using UnityEngine;
using UnityEngine.Events;

namespace _3DGuidance
{
    public class DistanceTracker2D : MonoBehaviour, IChangeValue
    {
        public float Value { get; private set; }
        public UnityEvent<float> OnValueChanged { get; private set; } = new UnityEvent<float>();

        [SerializeField] private GameObject objectToTrack;

        private void OnEnable()
        {
            StartCoroutine(UpdateDistance());
        }

        private void OnDisable()
        {
            StopCoroutine(UpdateDistance());
        }

        private IEnumerator UpdateDistance()
        {
            while (true)
            {
                Value = Vector3.Distance(gameObject.transform.position, objectToTrack.transform.position);
                OnValueChanged?.Invoke(Value);
                yield return new WaitForSeconds(0.25f);
            }
        }
    }
}
