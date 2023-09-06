using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Organ : MonoBehaviour
{
    #region Variables

    [SerializeField]
    private float m_value;

    [SerializeField]
    private SpriteRenderer m_fillRenderer;

    GameManager _gameManager;

    private Material _fillMaterial;

    #region Multipliers
    float _wheelAddValue;
    float _leftThrusterAddValue;
    float _rightThrusterAddValue;
    float _U1AddValue;
    float _U2AddValue;
    float _U3AddValue;
    float _D1AddValue;
    float _D2AddValue;
    float _D3AddValue;
    #endregion

    #endregion

    [SerializeField]
    private List<OrganController> m_controllers;

    private void Start()
    {
        _gameManager = GameManager.Instance;
        _fillMaterial = m_fillRenderer.material;
        _fillMaterial.SetFloat("_FillAmount", m_value);

        foreach (OrganController controller in m_controllers)
        {
            switch (controller.Controller)
            {
                case ControllerType.Wheel:
                    _gameManager.OnWheelUp += OnWheelUp;
                    _gameManager.OnWheelDown += OnWheelDown;
                    _wheelAddValue = controller.Multiplier * _gameManager.WheelStepValue;
                    break;

                case ControllerType.LeftThruster:
                    _gameManager.OnLeftThrusterUp += OnLeftThrusterUp;
                    _gameManager.OnLeftThrusterDown += OnLeftThrusterDown;
                    _leftThrusterAddValue = controller.Multiplier * _gameManager.LeftThrusterStepValue;
                    break;

                case ControllerType.RightThruster:
                    _gameManager.OnRightThrusterUp += OnRightThrusterUp;
                    _gameManager.OnRightThrusterDown += OnRightThrusterDown;
                    _rightThrusterAddValue = controller.Multiplier * _gameManager.RightThrusterStepValue;
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

                case ControllerType.ButtonD3:
                    _gameManager.OnD3Pressed += OnButtonD3;
                    _D3AddValue = controller.Multiplier * _gameManager.D3StepValue;
                    break;
            }
        }
    }

    private void OnWheelUp()
    {
        m_value += _wheelAddValue;

        m_value = m_value > 1 ? 1 : m_value;
        m_value = m_value < 0 ? 0 : m_value;

        _fillMaterial.SetFloat("_FillAmount", m_value);
    }

    private void OnWheelDown()
    {
        m_value -= _wheelAddValue;

        m_value = m_value > 1 ? 1 : m_value;
        m_value = m_value < 0 ? 0 : m_value;

        _fillMaterial.SetFloat("_FillAmount", m_value);
    }

    private void LoseCheck()
    {
        if (m_value >= 1)
        {
            m_value = 1;
            _gameManager.OnLose();

            return;
        }

        if(m_value <= 0)
        {
            m_value = 0;
            _gameManager.OnLose();

            return;
        }

    }

    private void OnLeftThrusterUp()
    {
        m_value += _leftThrusterAddValue;

        LoseCheck();

        _fillMaterial.SetFloat("_FillAmount", m_value);
    }

    private void OnLeftThrusterDown()
    {
        m_value -= _leftThrusterAddValue;

        LoseCheck();

        _fillMaterial.SetFloat("_FillAmount", m_value);
    }

    private void OnRightThrusterUp()
    {
        m_value += _rightThrusterAddValue;

        LoseCheck();

        _fillMaterial.SetFloat("_FillAmount", m_value);
    }

    private void OnRightThrusterDown()
    {
        m_value -= _rightThrusterAddValue;

        LoseCheck();

        _fillMaterial.SetFloat("_FillAmount", m_value);
    }

    private void OnButtonU1()
    {
        m_value += _U1AddValue;

        LoseCheck();

        _fillMaterial.SetFloat("_FillAmount", m_value);
    }

    private void OnButtonU2()
    {
        m_value += _U2AddValue;

        LoseCheck();

        _fillMaterial.SetFloat("_FillAmount", m_value);
    }

    private void OnButtonU3()
    {
        m_value += _U3AddValue;

        LoseCheck();

        _fillMaterial.SetFloat("_FillAmount", m_value);
    }

    private void OnButtonD1()
    {
        m_value += _D1AddValue;

        LoseCheck();

        _fillMaterial.SetFloat("_FillAmount", m_value);
    }

    private void OnButtonD2()
    {
        m_value += _D2AddValue;

        LoseCheck();

        _fillMaterial.SetFloat("_FillAmount", m_value);
    }

    private void OnButtonD3()
    {
        m_value += _D3AddValue;

        LoseCheck();

        _fillMaterial.SetFloat("_FillAmount", m_value);
    }
}
