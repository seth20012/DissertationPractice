using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Singleton to set whether certain modalities are enabled or not
/// </summary>
public class ModalitiesEnabled : MonoBehaviour
{
    /// <summary>
    /// The global class instance
    /// </summary>
    public static ModalitiesEnabled Instance;

    /// <summary>
    /// Whether to enable the visual modality aids
    /// </summary>
    public bool VisualsEnabled { get; set; }
    
    /// <summary>
    /// Whether to enable the haptic modality aids
    /// </summary>
    public bool HapticsEnabled { get; set; }
    
    /// <summary>
    /// Whether to enable the audio modality aids
    /// </summary>
    public bool AudioEnable { get; set; }
    
    // Singleton functionality
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
}
