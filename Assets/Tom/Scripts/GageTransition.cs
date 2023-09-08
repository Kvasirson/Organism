using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class GageTransition : MonoBehaviour
{
    #region Variables
    [Header("Init")]
    [SerializeField]
    private SpriteRenderer m_fillRenderer;

    [SerializeField]
    private SpriteRenderer m_backgroundRender;

    [SerializeField]
    private SpriteRenderer m_foreGroundRender;

    [SerializeField]
    private SpriteRenderer m_organRenderer;

    [SerializeField]
    private SortingGroup m_organSortingGroup;

    [Header("Fill")]
    [SerializeField]
    private Color m_lowFillColor;

    [SerializeField]
    private Color m_midFillColor;

    [SerializeField]
    private Color m_highFillColor;

    [Header("Bubbles")]
    [SerializeField]
    private Color m_lowBubbleColor;

    [SerializeField]
    private Color m_midBubbleColor;

    [SerializeField]
    private Color m_highBubbleColor;

    [Header("Highlight")]
    [SerializeField]
    private float m_highlightSpeed;

    private Material _fillMaterial;
    private Material _backMaterial;
    private Material _frontMaterial;

    private Vector2 _startScale;
    private Vector2 _organStartScale;
    private bool _valueIsChanged;
    private float _higlightProgress = 0f;
    private bool _isButton;
    #endregion

    private void Awake()
    {
        _startScale = transform.localScale;
        _fillMaterial = m_fillRenderer.material;
        _backMaterial = m_backgroundRender.material;
        _frontMaterial = m_foreGroundRender.material;

        _organStartScale = m_organRenderer.transform.localScale;
    }

    private void Update()
    {
        if (_valueIsChanged)
        {
            _valueIsChanged = false;

            if (_higlightProgress >= 1)
            {
                return;
            }

            float curProgress;
            if (_isButton)
            {
                curProgress = 1f;
            }
            else
            {
                curProgress = _higlightProgress + m_highlightSpeed * Time.deltaTime;
            }
            _higlightProgress = curProgress <= 1 ? curProgress : 1;
            transform.localScale = Vector3.Lerp(_startScale, _startScale * 1.2f, _higlightProgress);
            _fillMaterial.SetFloat("_Alpha", Mathf.Lerp(0.5f, 1f, curProgress));
            Color fadeColor = Color.white;
            fadeColor.a = Mathf.Lerp(0.5f, 1f, curProgress);
            _backMaterial.color = fadeColor;
            _frontMaterial.color = fadeColor;


            if (curProgress > 0.25)
            {
                m_organSortingGroup.sortingLayerName = "Foreground";
            }
            m_organRenderer.transform.localScale = Vector3.Lerp(_organStartScale, _organStartScale * 1.2f, _higlightProgress);
        }
        else
        {
            if (_higlightProgress <= 0)
            {
                return;
            }

            float curProgress = _higlightProgress - m_highlightSpeed * Time.deltaTime;
            _higlightProgress = curProgress >= 0 ? curProgress : 0;
            transform.localScale = Vector3.Lerp(_startScale, _startScale * 1.2f, _higlightProgress);
            _fillMaterial.SetFloat("_Alpha", Mathf.Lerp(0.5f, 1f, curProgress));
            Color fadeColor = Color.white;
            fadeColor.a = Mathf.Lerp(0.5f, 1f, curProgress);
            _backMaterial.color = fadeColor;
            _frontMaterial.color = fadeColor;

            if(curProgress < 0.25)
            {
                m_organSortingGroup.sortingLayerName = "Game Elements";
            }
            m_organRenderer.transform.localScale = Vector3.Lerp(_organStartScale, _organStartScale * 1.2f, _higlightProgress);
        }
    }

    public void SetFill(float value, bool isButton)
    {
        _valueIsChanged = true;
        _isButton = isButton;
        
        _fillMaterial.SetFloat("_FillAmount", value);
        
        if(value < 0.5f)
        {
            _fillMaterial.SetColor("_FillColor", Color.Lerp(m_lowFillColor, m_midFillColor, value * 2));
            _fillMaterial.SetColor("_BubblesColor", Color.Lerp(m_lowBubbleColor, m_midBubbleColor, value * 2));
            _fillMaterial.SetFloat("_BigBubblesSize", Mathf.Lerp(0, 1, value * 2));
            _fillMaterial.SetFloat("_BigBubblesSpeed", Mathf.Lerp(0.5f, 1, value * 2));
            _fillMaterial.SetFloat("_TinyBubblesSize", 0f);
            _fillMaterial.SetFloat("_WaveAmmount", Mathf.Lerp(0, 1, value * 2));
            _fillMaterial.SetFloat("_WaveSize", Mathf.Lerp(0.02f, 0.05f, value * 2));
            _fillMaterial.SetFloat("_WaveSpeed", Mathf.Lerp(0, 2, value * 2));
        }
        else if (value >= 0.5f)
        {
            _fillMaterial.SetColor("_FillColor", Color.Lerp(m_midFillColor, m_highFillColor, (value - 0.5f) * 2));
            _fillMaterial.SetColor("_BubblesColor", Color.Lerp(m_midBubbleColor, m_highBubbleColor, (value - 0.5f) * 2));
            _fillMaterial.SetFloat("_BigBubblesSize", 1f);
            _fillMaterial.SetFloat("_BigBubblesSpeed", Mathf.Lerp(1, 2, (value - 0.5f) * 2));
            if (value < 0.75f)
            {
                _fillMaterial.SetFloat("_TinyBubblesSize", Mathf.Lerp(0, 1, (value - 0.5f) * 4));
            }
            else
            {
                _fillMaterial.SetFloat("_TinyBubblesSize", 1);
            }
            _fillMaterial.SetFloat("_TinyBubblesSpeed", Mathf.Lerp(1, 2, (value - 0.5f) * 2));
            _fillMaterial.SetFloat("_WaveAmmount", 1);
            _fillMaterial.SetFloat("_WaveSize", Mathf.Lerp(0.05f, 0.07f, (value - 0.5f) * 2));
            _fillMaterial.SetFloat("_WaveSpeed", Mathf.Lerp(2, 3, (value - 0.5f) * 2));
        }
    }
}
