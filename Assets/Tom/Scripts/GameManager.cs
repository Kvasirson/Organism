using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    #region Variables

    

    private PlayerActions _playerActions;
    public ref PlayerActions PlayerActions
    {
        get => ref _playerActions;
    }

    private int _score;

    private static GameManager _instance;
    public static GameManager Instance
    {
        get => _instance;
    }

    #region Controller events
    public event Action OnWheelUp;
    public event Action OnWheelDown;

    public event Action OnLeftThrusterUp;
    public event Action OnLeftThrusterDown;

    public event Action OnRightThrusterUp;
    public event Action OnRightThrusterDown;

    public event Action OnU1Pressed;
    public event Action OnU2Pressed;
    public event Action OnU3Pressed;
    public event Action OnD1Pressed;
    public event Action OnD2Pressed;
    public event Action OnD3Pressed;
    #endregion

    #region Controller values
    [SerializeField]
    private float m_wheelStepValue;
    public float WheelStepValue
    {
        get => m_wheelStepValue;
    }

    [SerializeField]
    private float m_leftThrusterStepValue;
    public float LeftThrusterStepValue
    {
        get => m_leftThrusterStepValue;
    }

    [SerializeField]
    private float m_rightThrusterStepValue;
    public float RightThrusterStepValue
    {
        get => m_rightThrusterStepValue;
    }

    [SerializeField]
    private float m_U1SteppValue;
    public float U1StepValue
    {
        get => m_U1SteppValue;
    }

    [SerializeField]
    private float m_U2SteppValue;
    public float U2StepValue
    {
        get => m_U2SteppValue;
    }

    [SerializeField]
    private float m_U3SteppValue;
    public float U3StepValue
    {
        get => m_U3SteppValue;
    }

    [SerializeField]
    private float m_D1SteppValue;
    public float D1StepValue
    {
        get => m_D1SteppValue;
    }

    [SerializeField]
    private float m_D2SteppValue;
    public float D2StepValue
    {
        get => m_D2SteppValue;
    }

    [SerializeField]
    private float m_D3SteppValue;
    public float D3StepValue
    {
        get => m_D3SteppValue;
    }
    #endregion

    #endregion

    private void Awake()
    {
        if(_instance != null)
        {
            Destroy(this);
        }

        _instance = this;
    }

    void OnLevelFinish()
    {

    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            OnWheelUp?.Invoke();
        }

        if (Input.GetKey(KeyCode.Z))
        {
            OnWheelDown?.Invoke();
        }

        if (Input.GetKey(KeyCode.E))
        {
            OnLeftThrusterUp?.Invoke();
        }

        if (Input.GetKey(KeyCode.R))
        {
            OnLeftThrusterDown?.Invoke();
        }

        if (Input.GetKey(KeyCode.T))
        {
            OnRightThrusterUp?.Invoke();
        }

        if (Input.GetKey(KeyCode.Y))
        {
            OnRightThrusterDown?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            OnU1Pressed?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            OnU2Pressed?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            OnU3Pressed?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            OnD1Pressed?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            OnD2Pressed?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            OnD3Pressed?.Invoke();
        }
    }
}
