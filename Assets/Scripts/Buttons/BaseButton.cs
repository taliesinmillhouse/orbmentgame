using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseButton : MonoBehaviour
{
    protected int m_iParentListIndex = 0;
    public int ParentListIndex { get { return m_iParentListIndex; } set { m_iParentListIndex = value; } }

    protected float m_fGrowShrinkSpeed = 0.1f;
    protected float m_fGrowMultiplier = 1.5f;
    protected float m_fShrinkMultiplier = 1.0f;

    protected bool m_bIsMousedOver = false;
    public bool IsMousedOver { get { return m_bIsMousedOver; } set { m_bIsMousedOver = value; } }

    protected AudioClip m_menuClickAudioClip;

    protected Button m_button;

    public string m_strOnClickParameter;

    protected virtual void Awake()
    {
        m_menuClickAudioClip = Resources.Load("Audio/Beta/UI/Menu_Click") as AudioClip;

        m_button = GetComponent<Button>();
    }

    protected virtual void Update()
    {
        if (m_bIsMousedOver)
        {
            Grow();
        }
        else
        {
            Shrink();
        }
    }

    public virtual void OnCursorEnter()
    {
        m_bIsMousedOver = true;
    }

    public virtual void OnCursorExit()
    {
        
    }

    public virtual void OnClick()
    {
        if (!m_bIsMousedOver)
        {
            Debug.Log(gameObject.name + " button cannot be clicked because 'm_bIsMouseOver' is " + m_bIsMousedOver + '.');
            return;
        }
    }

    public virtual void OnClick(string a_strParameter)
    {
        if (!m_bIsMousedOver)
        {
            Debug.Log(gameObject.name + " button cannot be clicked because 'm_bIsMouseOver' is " + m_bIsMousedOver + '.');
            return;
        }
    }

    protected virtual void Grow()
    {
        if (transform.localScale.x < m_fGrowMultiplier)
        {
            transform.localScale += new Vector3(m_fGrowShrinkSpeed, m_fGrowShrinkSpeed, 0.0f);
        }
    }

    protected virtual void Shrink()
    {
        if (transform.localScale.x > m_fShrinkMultiplier)
        {
            transform.localScale -= new Vector3(m_fGrowShrinkSpeed, m_fGrowShrinkSpeed, 0.0f);
        }
    }
}
