using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.DualShock;
using UnityEngine.XR.Interaction.Toolkit;

public class HandIdentifier : MonoBehaviour
{
    private IXRSelectInteractable _myInteractible;
    private IXRSelectInteractor _leftHandInteractor, _rightHandInteractor;
    private Color _defaultColor;
    private DualShockGamepad _PS4Controller;

    [SerializeField] private GameObject leftHand, rightHand;
    [SerializeField] private GameObject connectionMarker;
    // Start is called before the first frame update
    void Start()
    {
        _defaultColor = GetComponent<Renderer>().material.color;
        _myInteractible = GetComponent<IXRSelectInteractable>();
        _leftHandInteractor = leftHand.GetComponent<IXRSelectInteractor>();
        _rightHandInteractor = rightHand.GetComponent<IXRSelectInteractor>();
        _myInteractible.firstSelectEntered.AddListener(Grabbed);
        _myInteractible.lastSelectExited.AddListener(Released);

        _PS4Controller = DualShockGamepad.current;
    }

    public void Grabbed(SelectEnterEventArgs args)
    {
        var obj = args.interactorObject;

        if (obj == _leftHandInteractor)
        {
            GetComponent<Renderer>().material.color = Color.red;
            
            if (_PS4Controller == null) return;
            _PS4Controller.SetMotorSpeeds(.75f, .0f);
        }

        if (obj == _rightHandInteractor)
        {
            GetComponent<Renderer>().material.color = Color.blue;
            if (_PS4Controller == null) return;
            _PS4Controller.SetMotorSpeeds(.0f, .75f);
        }
    }

    public void Released(SelectExitEventArgs args) 
    {
        GetComponent<Renderer>().material.color = _defaultColor;
        if (_PS4Controller == null) return;
        Gamepad.all[0].SetMotorSpeeds(.0f, .0f);
    }
}
