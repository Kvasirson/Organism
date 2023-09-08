using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Transition : MonoBehaviour
{
    [SerializeField]
    Image m_transition;

    [SerializeField]
    float m_transitionTime;

    private static Transition _instance;
    public static Transition Instance
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

    void Start()
    {
        StartCoroutine(TransitionUp());
    }

    public void StartTransition()
    {
        StartCoroutine(TransitionDown());
    }
    
    IEnumerator TransitionUp()
    {
        float curTime = 0;
        Color tColor = Color.black;
        tColor.a = 0;

        while (curTime < m_transitionTime)
        {
            m_transition.color = Color.Lerp(Color.black, tColor, curTime / m_transitionTime);
            curTime += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }

        m_transition.color = tColor;
    }

    IEnumerator TransitionDown()
    {
        float curTime = 0;
        Color tColor = Color.black;
        tColor.a = 0;

        while (curTime < m_transitionTime)
        {
            m_transition.color = Color.Lerp(tColor,Color.black, curTime / m_transitionTime);
            curTime += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }

        m_transition.color = Color.black;
        LevelLoader.Instance.LoadNextLevel();
    }
}
