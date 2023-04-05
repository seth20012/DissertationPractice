using Interfaces;
using UnityEngine;

namespace _3DGuidance
{
    public abstract class ScaleInstance : MonoBehaviour
    {
        public IScale Scaler { get; protected set; }
    }
}
