using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step
{
    public string From { get; private set; }
    public string To { get; private set; }

    public Step(string from, string to)
    {
        From = from;
        To = to;
    }
}
