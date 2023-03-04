using System;

public static class ExponentialUtils
{
    public static double CalculateExponentialRate(float startValue, float endValue, float delta)
    {
        return Math.Log(startValue / endValue) / delta;
    }

    public static float CalculateValueAtDelta(float startValue, double rate, float delta)
    {
        return (float)(startValue * Math.Exp(-rate * delta));
    }
}
