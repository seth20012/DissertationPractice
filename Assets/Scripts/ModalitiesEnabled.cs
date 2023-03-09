using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModalitiesEnabled : MonoBehaviour
{
    public static ModalitiesEnabled Instance;

    public bool VisualsEnabled { get; set; }
    public bool HapticsEnabled { get; set; }
    public bool AudioEnable { get; set; }
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
}
