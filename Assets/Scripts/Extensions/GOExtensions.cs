using UnityEngine;

namespace Extensions
{
    public static class GOExtensions
    {
        public static void ChangeOpacity(this GameObject go, float value)
        {
            MeshRenderer meshRenderer = go.GetComponent<MeshRenderer>();
            Color color = meshRenderer.material.color;
            color.a = value;
            meshRenderer.material.color = color;
        }
    }
}
