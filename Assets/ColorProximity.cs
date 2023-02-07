using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorProximity : ProximityChanger
{
    private Color _color;

    // Start is called before the first frame update
    private void Start()
    {
        base.Start();
        _color = gameObject.GetComponent<MeshRenderer>().material.color;
    }

    // Update is called once per frame
    private void Update()
    {
        base.Update();

        _color.a = _currentValue;
        gameObject.GetComponent<MeshRenderer>().material.color = _color;
    }
}
