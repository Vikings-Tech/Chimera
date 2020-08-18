using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeSceneAfterWait : MonoBehaviour
{
    void Awake()
    {
        Invoke("LoadAfterWait", 3.5f);
    }
    
    public void LoadAfterWait()
    {
    SceneManager.LoadScene("LoginScenes");
    }
}
