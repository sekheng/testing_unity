using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UserRotateObj : MonoBehaviour
{
    [SerializeField, Tooltip("Rotation Speed")]
    protected float m_Speed;

    [Header("Debugging purpose")]
    [SerializeField, Tooltip("the rotation along x-axis, allowing for looking up and down")]
    float m_XRotation = 0f;
    [SerializeField, Tooltip("rotation along y-axis, allowing for looking left and right")]
    float m_YRotation = 0f;

    /// <summary>
    /// to ensure the mouse dont have a suddent jerk movement due to the initial update
    /// </summary>
    bool initializedFlag = false;

    private void OnEnable()
    {
        initializedFlag = false;
    }

    public virtual void OnLook(InputValue _val)
    {
        if (initializedFlag)
        {
            // since it calls everytime it moves, no need for coroutine
            Vector2 mouseMoveDt = _val.Get<Vector2>();
            float mouseX = mouseMoveDt.x * m_Speed * Time.deltaTime;
            float mouseY = mouseMoveDt.y * m_Speed * Time.deltaTime;

            m_XRotation -= mouseY;
            m_YRotation += mouseX;
            m_XRotation = Mathf.Clamp(m_XRotation, -90f, 90f);
            transform.localRotation = Quaternion.Euler(m_XRotation, m_YRotation, 0f);
        }
        else
        {
            initializedFlag = true;
        }
    }
}
