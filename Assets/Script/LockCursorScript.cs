using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// purely to lock the mouse state
/// </summary>
public class LockCursorScript : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
    }
}
