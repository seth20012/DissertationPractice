using Interfaces;

namespace _3DGuidance
{
    /// <summary>
    /// A class representing an instance of the exponential function P=P1*e^(-kt) between two values
    /// </summary>
    public class ExponentialScaler: IScale
    {
        public float ValueAtMaxInput { get; private set; }
        public float ValueAtMinInput { get; private set; }
        public float MaxInput { get; private set; }
        public float MinInput { get; private set; }
        public double Rate { get; private set; }

        public ExponentialScaler(float minInput, float maxInput, float valueAtMinInput, float valueAtMaxInput)
        {
            ValueAtMinInput = valueAtMinInput;
            ValueAtMaxInput = valueAtMaxInput;
            MinInput = minInput;
            MaxInput = maxInput;

            Rate = ExponentialUtils.CalculateExponentialRate(valueAtMinInput, valueAtMaxInput, MaxInput - MinInput);
        }

        public float CalculateOutputValue(float input)
        {
            // Don't allow the output values to go beyond the extremes
            if (input > MaxInput)
            {
                return ValueAtMaxInput;
            }
            else if (input < MinInput)
            {
                return ValueAtMinInput;
            }
            else
            {
                return ExponentialUtils.CalculateValueAtDelta(ValueAtMinInput, Rate, input - MinInput);
            }
        }
    }
}
