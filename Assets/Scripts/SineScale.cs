using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineScale : IScale
{
    public float CalculateOutputValue(float input)
    {
        return Mathf.Sin(Mathf.Deg2Rad * input);
    }
}
