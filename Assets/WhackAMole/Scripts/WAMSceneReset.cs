using UnityEngine;
using UnityEngine.SceneManagement;

public class WAMSceneReset : MonoBehaviour
{
    public void SceneReset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
        WAMPauseMenu.isPaused = false;
    }
}
