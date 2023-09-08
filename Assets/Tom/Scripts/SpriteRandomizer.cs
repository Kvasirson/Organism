using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRandomizer : MonoBehaviour
{
    [SerializeField]
    private List<Sprite> m_spriteList;

    [SerializeField]
    private SpriteRenderer m_renderer;

    void Start()
    {
        m_renderer.sprite = m_spriteList[Random.Range(0, m_spriteList.Count)];
    }

    private void Reset()
    {
        m_renderer = TryGetComponent(out SpriteRenderer sp) ? sp : null;
    }
}
