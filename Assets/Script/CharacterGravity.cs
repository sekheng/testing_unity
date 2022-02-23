using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGravity : MonoBehaviour
{
    [SerializeField, Tooltip("Character Controller")]
    protected CharacterController m_CharControl;
    [SerializeField, Tooltip("To be affected by gravity")]
    protected float m_Gravity = -9.81f;
    [Tooltip("Current velocity of Y")]
    public float m_velocityY = 0f;
    [SerializeField, Tooltip("Trigger flag")]
    protected bool m_TriggerGroundFlag = false;
    [SerializeField, Tooltip("Ground mask")]
    protected LayerMask m_GroundMask;
    [SerializeField, Tooltip("Ground check transform")]
    protected Transform m_GroundCheckTransform;
    [SerializeField, Tooltip("estimated ground distance")]
    protected float m_GroundDist;

    // Update is called once per frame
    protected virtual void Update()
    {
        bool currCheck = Physics.CheckSphere(m_GroundCheckTransform.position, m_GroundDist, m_GroundMask);

        if (currCheck)
        {
            if (!m_TriggerGroundFlag)
            {
                m_velocityY = -2;
            }
        }
        else if (!m_TriggerGroundFlag)
        {
            m_velocityY += m_Gravity * Time.deltaTime;
        }
         m_CharControl.Move(new Vector3(0, m_velocityY * Time.deltaTime, 0));
        m_TriggerGroundFlag = currCheck;
    }

    public bool GetGroundFlag()
    {
        return m_TriggerGroundFlag;
    }

    public float GetGravity()
    {
        return m_Gravity;
    }
}
