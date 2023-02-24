using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ScaleInstance : MonoBehaviour
{
    public IScale Scaler { get; protected set; }
}
