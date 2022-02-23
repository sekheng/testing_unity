using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UserMoveObj : MonoBehaviour
{
    [SerializeField, Tooltip("speed")]
    protected float m_Speed;

    [Header("Debugging Fields")]
    [SerializeField, Tooltip("Movement Dir")]
    protected Vector2 m_MoveDir;

    /// <summary>
    /// To update the movement
    /// </summary>
    protected Coroutine m_Routine = null;


    protected virtual void OnDisable()
    {
        if (m_Routine != null)
        {
            StopCoroutine(m_Routine);
            m_Routine = null;
        }
    }

    public virtual void OnMove(InputValue _value)
    {
        m_MoveDir = _value.Get<Vector2>() * m_Speed;
        if (m_MoveDir == Vector2.zero)
        {
            OnDisable();
        }
        else if (m_Routine == null)
        {
            m_Routine = StartCoroutine(MoveRoutine());
        }
    }

    protected virtual IEnumerator MoveRoutine()
    {
        while (true)
        {
            transform.position += m_MoveDir.x * Time.deltaTime * transform.right;
            transform.position += m_MoveDir.y * Time.deltaTime * transform.forward;
            
            yield return null;
        }
    }
}
