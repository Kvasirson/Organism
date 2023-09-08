using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GageTransition : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer m_fillRenderer;

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


    private Material _fillMaterial;

    public void SetFill(float value)
    {
        _fillMaterial = m_fillRenderer.material;
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
