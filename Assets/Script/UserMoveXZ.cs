using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserMoveXZ : UserMoveObj
{
    protected override IEnumerator MoveRoutine()
    {
        while (true)
        {
            Vector3 dist = m_MoveDir.x * Time.deltaTime * transform.right + m_MoveDir.y * Time.deltaTime * transform.forward;
            dist.y = 0;
            transform.position += dist;
            yield return null;
        }
    }
}
