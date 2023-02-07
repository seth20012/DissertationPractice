using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VectorDecay
{
    public static double CalculateRate(float startValue, float endValue, float distance)
    {
        return Math.Log(startValue / endValue) / distance;
    }

    public static float CalculateDecay(float startValue, double rate, float distance)
    {
        return (float)(startValue * Math.Exp(-rate * distance));
    }

    public static float CalculateGrowth(float startValue, double rate, float distance)
    {
        return (float)(startValue * Math.Exp(rate * distance));
    }
}
