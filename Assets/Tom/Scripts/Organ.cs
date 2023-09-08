using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Organ : MonoBehaviour
{
    #region Variables
    GameManager _gameManager;

    #region Multipliers
    float _wheelUpAddValue;
    float _wheelDownAddValue;
    float _leftThrusterUpAddValue;
    float _leftThrusterDownAddValue;
    float _rightThrusterUpAddValue;
    float _rightThrusterDownAddValue;
    float _U1AddValue;
    float _U2AddValue;
    float _U3AddValue;
    float _D1AddValue;
    float _D2AddValue;
    float _D3AddValue;
    #endregion

    [Header("Game variables")]

    [SerializeField]
    private float m_value;

    [SerializeField]
    private List<OrganController> m_controllers;

    [Header("Init")]
    [Tooltip("Pas touche les GD !")]
    [SerializeField]
    private GageTransition m_transitionScript;
    [SerializeField]
    GameObject m_gageVisuals;

    #endregion

    private void Start()
    {
        if (m_controllers.Count == 0)
        {
            m_gageVisuals.SetActive(false);
            return;
        }

        _gameManager = GameManager.Instance;

        _gameManager.GetScores += CalculateScore;
        m_transitionScript.SetFill(m_value);

        foreach (OrganController controller in m_controllers)
        {
            switch (controller.Controller)
            {
                case ControllerType.WheelUp:
                    _gameManager.OnWheelUp += OnWheelUp;
                    _wheelUpAddValue = controller.Multiplier * _gameManager.WheelStepValue;
                    break;

                case ControllerType.WheelDown:
                    _gameManager.OnWheelDown += OnWheelDown;
                    _wheelDownAddValue = controller.Multiplier * _gameManager.WheelStepValue;
                    break;

                case ControllerType.LeftThrusterUp:
                    _gameManager.OnLeftThrusterUp += OnLeftThrusterUp;
                    _leftThrusterUpAddValue = controller.Multiplier * _gameManager.LeftThrusterStepValue;
                    break;

                case ControllerType.LeftThrusterDown:
                    _gameManager.OnLeftThrusterDown += OnLeftThrusterDown;
                    _leftThrusterDownAddValue = controller.Multiplier * _gameManager.LeftThrusterStepValue;
                    break;

                case ControllerType.RightThrusterUp:
                    _gameManager.OnRightThrusterUp += OnRightThrusterUp;
                    _rightThrusterUpAddValue = controller.Multiplier * _gameManager.RightThrusterStepValue;
                    break;

                case ControllerType.RightThrusterDown:
                    _gameManager.OnRightThrusterDown += OnRightThrusterDown;
                    _rightThrusterDownAddValue = controller.Multiplier * _gameManager.RightThrusterStepValue;
                    break;

                case ControllerType.ButtonU1:
                    _gameManager.OnU1Pressed += OnButtonU1;
                    _U1AddValue = controller.Multiplier * _gameManager.U1StepValue;
                    break;

                case ControllerType.ButtonU2:
                    _gameManager.OnU2Pressed += OnButtonU2;
                    _U2AddValue = controller.Multiplier * _gameManager.U2StepValue;
                    break;

                case ControllerType.ButtonU3:
                    _gameManager.OnU3Pressed += OnButtonU3;
                    _U3AddValue = controller.Multiplier * _gameManager.U3StepValue;
                    break;

                case ControllerType.ButtonD1:
                    _gameManager.OnD1Pressed += OnButtonD1;
                    _D1AddValue = controller.Multiplier * _gameManager.D1StepValue;
                    break;

                case ControllerType.ButtonD2:
                    _gameManager.OnD2Pressed += OnButtonD2;
                    _D2AddValue = controller.Multiplier * _gameManager.D2StepValue;
                    break;
            }
        }
    }

    private void CalculateScore()
    {
        _gameManager.AddScore((Mathf.Abs(Mathf.Abs(m_value - 0.5f) - 0.5f))*2);
    }

    private void LoseCheck()
    {
        if (m_value >= 1)
        {
            m_value = 1;
            _gameManager.OnLose();

            return;
        }

        if (m_value <= 0)
        {
            m_value = 0;
            _gameManager.OnLose();

            return;
        }
    }

    private void OnWheelUp()
    {
        m_value += _wheelUpAddValue * Time.deltaTime;

        LoseCheck();

        m_transitionScript.SetFill(m_value);
    }

    private void OnWheelDown()
    {
        m_value -= _wheelDownAddValue * Time.deltaTime;

        LoseCheck();

        m_transitionScript.SetFill(m_value);
    }

    private void OnLeftThrusterUp()
    {
        m_value += _leftThrusterUpAddValue * Time.deltaTime;

        LoseCheck();

        m_transitionScript.SetFill(m_value);
    }

    private void OnLeftThrusterDown()
    {
        m_value -= _leftThrusterDownAddValue * Time.deltaTime;

        LoseCheck();

        m_transitionScript.SetFill(m_value);
    }

    private void OnRightThrusterUp()
    {
        m_value += _rightThrusterUpAddValue * Time.deltaTime;

        LoseCheck();

        m_transitionScript.SetFill(m_value);
    }

    private void OnRightThrusterDown()
    {
        m_value -= _rightThrusterDownAddValue * Time.deltaTime;

        LoseCheck();

        m_transitionScript.SetFill(m_value);
    }

    private void OnButtonU1()
    {
        m_value += _U1AddValue;

        LoseCheck();

        m_transitionScript.SetFill(m_value);
    }

    private void OnButtonU2()
    {
        m_value += _U2AddValue;

        LoseCheck();

        m_transitionScript.SetFill(m_value);
    }

    private void OnButtonU3()
    {
        m_value += _U3AddValue;

        LoseCheck();

        m_transitionScript.SetFill(m_value);
    }

    private void OnButtonD1()
    {
        m_value += _D1AddValue;

        LoseCheck();

        m_transitionScript.SetFill(m_value);
    }

    private void OnButtonD2()
    {
        m_value += _D2AddValue;

        LoseCheck();

        m_transitionScript.SetFill(m_value);
    }

    private void OnDestroy()
    {
        foreach (OrganController controller in m_controllers)
        {
            switch (controller.Controller)
            {
                case ControllerType.WheelUp:
                    _gameManager.OnWheelUp += OnWheelUp;
                    _wheelUpAddValue = controller.Multiplier * _gameManager.WheelStepValue;
                    break;

                case ControllerType.WheelDown:
                    _gameManager.OnWheelDown += OnWheelDown;
                    _wheelDownAddValue = controller.Multiplier * _gameManager.WheelStepValue;
                    break;

                case ControllerType.LeftThrusterUp:
                    _gameManager.OnLeftThrusterUp += OnLeftThrusterUp;
                    _leftThrusterUpAddValue = controller.Multiplier * _gameManager.LeftThrusterStepValue;
                    break;

                case ControllerType.LeftThrusterDown:
                    _gameManager.OnLeftThrusterDown += OnLeftThrusterDown;
                    _leftThrusterDownAddValue = controller.Multiplier * _gameManager.LeftThrusterStepValue;
                    break;

                case ControllerType.RightThrusterUp:
                    _gameManager.OnRightThrusterUp += OnRightThrusterUp;
                    _rightThrusterUpAddValue = controller.Multiplier * _gameManager.RightThrusterStepValue;
                    break;

                case ControllerType.RightThrusterDown:
                    _gameManager.OnRightThrusterDown += OnRightThrusterDown;
                    _rightThrusterDownAddValue = controller.Multiplier * _gameManager.RightThrusterStepValue;
                    break;

                case ControllerType.ButtonU1:
                    _gameManager.OnU1Pressed -= OnButtonU1;
                    _U1AddValue = controller.Multiplier * _gameManager.U1StepValue;
                    break;

                case ControllerType.ButtonU2:
                    _gameManager.OnU2Pressed -= OnButtonU2;
                    _U2AddValue = controller.Multiplier * _gameManager.U2StepValue;
                    break;

                case ControllerType.ButtonU3:
                    _gameManager.OnU3Pressed -= OnButtonU3;
                    _U3AddValue = controller.Multiplier * _gameManager.U3StepValue;
                    break;

                case ControllerType.ButtonD1:
                    _gameManager.OnD1Pressed -= OnButtonD1;
                    _D1AddValue = controller.Multiplier * _gameManager.D1StepValue;
                    break;

                case ControllerType.ButtonD2:
                    _gameManager.OnD2Pressed -= OnButtonD2;
                    _D2AddValue = controller.Multiplier * _gameManager.D2StepValue;
                    break;
            }
        }

        _gameManager.GetScores -= CalculateScore;
    }
}
