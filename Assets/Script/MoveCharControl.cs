using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharControl : UserMoveObj
{
    [SerializeField, Tooltip("Character Controller")]
    protected CharacterController m_Controller;

    protected override IEnumerator MoveRoutine()
    {
        while (true)
        {
            Vector3 move = transform.right * m_MoveDir.x + transform.forward * m_MoveDir.y;
            //Debug.Log(move);
            move.y = 0;
            m_Controller.Move(move * m_Speed * Time.deltaTime);
            yield return null;
        }
    }
}
