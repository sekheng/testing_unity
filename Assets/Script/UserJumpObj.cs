using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UserJumpObj : MonoBehaviour
{
    [SerializeField, Tooltip("Character jump height")]
    protected float m_JumpHeight = 3f;
    [SerializeField, Tooltip("To work with gravity")]
    CharacterGravity m_Gravity;

    public void OnJump(InputValue _val)
    {
        if (m_Gravity.GetGroundFlag() == true)
        {
            m_Gravity.m_velocityY = Mathf.Sqrt(m_JumpHeight * -2f * m_Gravity.GetGravity());
        }
    }
}
