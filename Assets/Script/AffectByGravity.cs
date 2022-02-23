using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AffectByGravity : MonoBehaviour
{
    [SerializeField, Tooltip("To be affected by gravity")]
    protected float m_Gravity = -9.81f;

    [SerializeField, Tooltip("Current velocity of Y")]
    protected float m_velocityY = 0f;

    [SerializeField, Tooltip("Trigger flag")]
    protected bool m_TriggerGroundFlag = false;



    // Update is called once per frame
    protected virtual void Update()
    {
        if (!m_TriggerGroundFlag)
        {
            m_velocityY += m_Gravity * Time.deltaTime;
            transform.position += new Vector3(0, m_velocityY * Time.deltaTime);
        }
    }

}
