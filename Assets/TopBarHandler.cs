using UnityEngine;
using UnityEngine.UI;

public class TopBarHandler : MonoBehaviour
{
    public Image ProfilePicImg;

    private void Update()
    {
        if (GameManager.profilePic != null && ProfilePicImg != null)
        {
            ProfilePicImg.sprite = GameManager.profilePic;
        }
    }
}
