using Microsoft.MixedReality.Toolkit.UX;
using UnityEngine;

public class Resizer : MonoBehaviour
{
    private Slider _slider;

    [SerializeField] private GameObject go;
    [SerializeField] Vector3 _maxSize;
    [SerializeField] Vector3 _minSize;

    // Start is called before the first frame update
    void Start()
    {
        _slider = gameObject.GetComponent<Slider>();
        _slider.OnValueUpdated.AddListener(ResizeObject);
        _slider.Value = Mathf.InverseLerp(_minSize.x, _maxSize.x, go.transform.localScale.x); // Set initial slider value
    }

    private void ResizeObject(SliderEventData arg0)
    {
        go.transform.localScale = Vector3.Lerp(_minSize, _maxSize, arg0.NewValue); // Re-scale the GameObject using slider
    }
}
