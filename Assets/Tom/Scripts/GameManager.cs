using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    #region Variables

    public Canvas endgame;

    private PlayerActions _playerActions;
    public ref PlayerActions PlayerActions
    {
        get => ref _playerActions;
    }

    private int _score;
    public int Score
    {
        get => _score;
    }
    
    private bool _hasLost = false;

    private Coroutine _curTimer;

    [SerializeField]
    private static GameManager _instance;
    public static GameManager Instance
    {
        get => _instance;
    }

    public event Action GetScores;

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

    [Header("Game Variables")]

    [SerializeField]
    private int m_scorePerOrgan;

    [SerializeField]
    private AnimationCurve m_scoreCurve;

    [SerializeField]
    private float m_gameTime;

    [Header("Controller values")]

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

    [Header("Init")]
    [SerializeField]
    private TMP_Text m_scoreText;

    [SerializeField]
    private TMP_Text m_timerText;

    #endregion


    private void Awake()
    {
        if(_instance != null)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;

        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        _curTimer = StartCoroutine(Timer());
        m_scoreText.text = "Score : 000000";
    }

    IEnumerator Timer()
    {
        float curTimer = m_gameTime;

        while(curTimer > 0)
        {
            curTimer -= Time.deltaTime;
            m_timerText.text = "Time : " + Mathf.RoundToInt(curTimer);
            yield return new WaitForSeconds(Time.deltaTime);
        }

        EndGame();
    }

    public void OnLose()
    {
        Debug.Log("You Lose");
        _hasLost = true;
        if (_curTimer != null)
        {
            StopCoroutine(_curTimer);
        }
        GetScores?.Invoke();
        //Set active canvas GameOver
        endgame.gameObject.SetActive(true);

        Debug.Log("Final score is : " + _score);
    }

    void OnLevelFinish()
    {
        int prevScore = _score;
        GetScores?.Invoke();
        Debug.Log("Level score is : " + (_score - prevScore));
        Transition.Instance.StartTransition();
    }

    public void EndGame()
    {
        _hasLost = true;
        if (_curTimer != null)
        {
            StopCoroutine(_curTimer);
        }
        GetScores?.Invoke();
        Debug.Log("Final score is : " + _score);
        endgame.gameObject.SetActive(true);
    }

    public void AddScore(float value)
    {
        _score += Mathf.RoundToInt(m_scoreCurve.Evaluate(value) * m_scorePerOrgan);

        string scoreString = _score.ToString();
        if (scoreString.Length < 6)
        {
            int addNb = 6 - scoreString.Length;

            for(int i = 0; i < addNb; i++)
            {
                scoreString = "0" + scoreString;
            }
        }

        m_scoreText.text = "Score : " + scoreString;
    }

    public void Update()
    {
        if (_hasLost)
        {
            return;
        }

        if (Input.GetAxis("Mouse X") > 0)
        {
            OnWheelUp?.Invoke();
        }

        if (Input.GetAxis("Mouse X") < 0)
        {
            OnWheelDown?.Invoke();
        }

        if (Input.GetKey(KeyCode.J))
        {
            OnLeftThrusterUp?.Invoke();
        }

        if (Input.GetKey(KeyCode.V))
        {
            OnLeftThrusterDown?.Invoke();
        }

        if (Input.GetKey(KeyCode.L))
        {
            OnRightThrusterUp?.Invoke();
        }

        if (Input.GetKey(KeyCode.Minus))
        {
            OnRightThrusterDown?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            OnU1Pressed?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            OnU2Pressed?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            OnU3Pressed?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            OnD1Pressed?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            OnD2Pressed?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            OnLevelFinish();
        }
    }
}
