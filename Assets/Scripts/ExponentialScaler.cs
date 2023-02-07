public class ExponentialScaler
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

        Rate = VectorDecay.CalculateRate(valueAtMinInput, valueAtMaxInput, MaxInput - MinInput);
    }

    public float CalculateOutputValue(float input)
    {
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
            return VectorDecay.CalculateDecay(ValueAtMinInput, Rate, input - MinInput);
        }
    }
}
