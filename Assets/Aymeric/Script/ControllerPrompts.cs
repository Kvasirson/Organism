using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerPrompts : MonoBehaviour
{
    [SerializeField]
    Image m_wheel;

    [SerializeField]
    Image m_LThruster;

    [SerializeField]
    Image m_RThruster;

    [SerializeField]
    Image U1;

    [SerializeField]
    Image U2;

    [SerializeField]
    Image U3;

    [SerializeField]
    Image D1;

    [SerializeField]
    Image D2;

    [SerializeField]
    Image D3;

    private static ControllerPrompts _instance;
    public static ControllerPrompts Instance
    {
        get => _instance;
    }

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(this);
        }

        _instance = this;
    }

    public void SetController(ControllerType controller)
    {
        switch (controller)
        {
            case ControllerType.WheelUp:
                {
                    Debug.Log("ff");
                    m_wheel.color = Color.white;
                    break;
                }

            case ControllerType.WheelDown:
                {
                    m_wheel.color = Color.white;
                    break;
                }

            case ControllerType.LeftThrusterUp:
                {
                    m_LThruster.color = Color.white;
                    break;
                }

            case ControllerType.LeftThrusterDown:
                {
                    m_LThruster.color = Color.white;
                    break;
                }

            case ControllerType.RightThrusterUp:
                {
                    m_RThruster.color = Color.white;
                    break;
                }

            case ControllerType.RightThrusterDown:
                {
                    m_RThruster.color = Color.white;
                    break;
                }

            case ControllerType.ButtonU1:
                {
                    U1.color = Color.white;
                    break;
                }

            case ControllerType.ButtonU2:
                {
                    U2.color = Color.white;
                    break;
                }

            case ControllerType.ButtonU3:
                {
                    U3.color = Color.white;
                    break;
                }

            case ControllerType.ButtonD1:
                {
                    D1.color = Color.white;
                    break;
                }

            case ControllerType.ButtonD2:
                {
                    D2.color = Color.white;
                    break;
                }
        }
    }
}
