using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class ProximityChanger : MonoBehaviour
{
    protected float _currentValue;
    protected Vector3 _currentDistance;
    protected ExponentialScaler _exponentialScaler;

    [SerializeField] protected float valueAtMaxDistance;
    [SerializeField] protected float valueAtMinDistance;
    [SerializeField] protected float maxDistance;
    [SerializeField] protected float minDistance;
    [SerializeField] protected GameObject referenceObject;

    protected void Start()
    {
        _exponentialScaler = new ExponentialScaler(minDistance, maxDistance, valueAtMinDistance, valueAtMaxDistance);
    }


    protected void Update()
    {
        _currentDistance = referenceObject.transform.position - gameObject.transform.position;

        _currentValue = _exponentialScaler.CalculateOutputValue(_currentDistance.magnitude);
    }
}
