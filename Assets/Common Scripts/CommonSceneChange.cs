using UnityEngine;
using UnityEngine.SceneManagement;
public class CommonSceneChange : MonoBehaviour
{
    public void ChangeSceneTo(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}
