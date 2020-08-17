using UnityEngine;
using UnityEngine.UI;

public class TopBarHandler : MonoBehaviour
{
    public Image ProfilePicImg;

    private void Update()
    {
        ProfilePicImg.sprite = GameManager.profilePic;
    }
}
