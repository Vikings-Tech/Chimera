using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unpause : MonoBehaviour
{
    private void OnDestroy()
    {
        Time.timeScale = 1f;
    }
}
