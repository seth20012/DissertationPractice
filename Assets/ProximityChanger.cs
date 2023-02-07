using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class ProximityChanger : MonoBehaviour
{
    protected double _rate;
    protected float _currentValue;
    protected Vector3 _currentDistance;

    [SerializeField] protected float valueAtMaxDistance;
    [SerializeField] protected float valueAtMinDistance;
    [SerializeField] protected float maxDistance;
    [SerializeField] protected float minDistance;
    [SerializeField] protected GameObject referenceObject;

    protected void Start()
    {
        // Calculate the rate to use in formulas later
        _rate = VectorDecay.CalculateRate(valueAtMinDistance, valueAtMaxDistance, maxDistance - minDistance);
    }


    protected void Update()
    {
        _currentDistance = referenceObject.transform.position - gameObject.transform.position;

        if (_currentDistance.magnitude > maxDistance)
        {
            _currentValue = valueAtMaxDistance;
        }
        else if (_currentDistance.magnitude < minDistance)
            _currentValue = valueAtMinDistance;
        else
            _currentValue = CalculateExponent();
    }

    private float CalculateExponent()
    {

        return VectorDecay.CalculateDecay(valueAtMinDistance, _rate, _currentDistance.magnitude - minDistance);

    }
}
