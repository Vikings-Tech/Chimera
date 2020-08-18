using System;
using UnityEngine;

public class WAMPauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    

    public void GamePause()
    {

        Time.timeScale = 0f;
        isPaused = true;
    }



    public void GameUnpaused()
    {
        Time.timeScale = 1f;
        isPaused = false;
    }
}
