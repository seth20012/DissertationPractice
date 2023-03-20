using System;
using System.Collections;
using System.Collections.Generic;
using BluetoothLE;
using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BuzzOnTouch : MonoBehaviour
{
    private BLEWrite _leftWrite;
    private BLEWrite _rightWrite;
    
    [SerializeField] private MRTKBaseInteractable interactable;
    [SerializeField] private PokeInteractor leftHand;
    [SerializeField] private PokeInteractor rightHand;
    [SerializeField] private DeviceUWP leftDevice;
    [SerializeField] private DeviceUWP rightDevice;

    private void Start()
    {
        _leftWrite = new BLEWrite(leftDevice);
        _rightWrite = new BLEWrite(rightDevice);
    }

    private void OnEnable()
    {
        interactable.firstSelectEntered?.AddListener(OnPoke);
    }

    private void OnDisable()
    {
        interactable.firstSelectEntered?.RemoveListener(OnPoke);
    }

    private void OnPoke(SelectEnterEventArgs args)
    {
        var interactor = args.interactorObject;

        if ((PokeInteractor)interactor == leftHand)
        {
            _leftWrite.Write(180, 30);
        }
        else if ((PokeInteractor)interactor == rightHand)
        {
            _rightWrite.Write(180, 30);
        }
    }
}
