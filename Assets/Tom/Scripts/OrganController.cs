using System;
using UnityEngine;

[Serializable]
public class OrganController
{
    [SerializeField]
    private ControllerType m_controller = 0;

    [SerializeField]
    private float m_multiplier = 0;

    public ControllerType Controller
    {
        get => m_controller; 
    }

    public float Multiplier
    {
        get => m_multiplier;
    }
}
