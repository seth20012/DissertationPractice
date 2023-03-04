using UnityEngine;

public class ActiveToggle : MonoBehaviour
{
    private bool _isActive;
    // Start is called before the first frame update
    void Start()
    {
        _isActive = gameObject.activeInHierarchy;
    }

    public void Toggle()
    {
        _isActive = !_isActive;
        gameObject.SetActive(_isActive);
    }
}
