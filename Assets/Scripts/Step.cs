using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step
{
    /// <summary>
    /// The item correlating to the beginning of the step
    /// </summary>
    public string From { get; private set; }
    
    /// <summary>
    /// The item correlating to the end of the step
    /// </summary>
    public string To { get; private set; }
    
    public Step(string from, string to)
    {
        From = from;
        To = to;
    }
}
