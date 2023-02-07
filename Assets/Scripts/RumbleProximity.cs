using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RumbleProximity : ProximityChanger
{
    [SerializeField] PS4Controller controller;
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        controller.GameController.SetMotorSpeeds(_currentValue, _currentValue);
    }
}
