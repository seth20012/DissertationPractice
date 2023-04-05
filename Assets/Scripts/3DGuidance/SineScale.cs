using Interfaces;
using UnityEngine;

namespace _3DGuidance
{
    public class SineScale : IScale
    {
        public float CalculateOutputValue(float input)
        {
            return Mathf.Sin(Mathf.Deg2Rad * input);
        }
    }
}
