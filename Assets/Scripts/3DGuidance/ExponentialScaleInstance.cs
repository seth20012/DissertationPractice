using UnityEngine;

namespace _3DGuidance
{
    public class ExponentialScaleInstance : ScaleInstance
    {
        [SerializeField] protected float valueAtMaxInput;
        [SerializeField] protected float valueAtMinInput;
        [SerializeField] protected float maxInput;
        [SerializeField] protected float minInput;
        // Start is called before the first frame update
        void Start()
        {
            Scaler = new ExponentialScaler(minInput, maxInput, valueAtMinInput, valueAtMaxInput);
        }
    }
}
