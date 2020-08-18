using UnityEngine.UI;
using UnityEngine;

public class ProfileSetup : MonoBehaviour
{
    public Text nameText, usrNameText, BioText, AchievementsText;
    public Image ProfilePic;

    public void Update()
    {
        nameText.text = GameManager.usrName;
        ProfilePic.sprite = GameManager.profilePic;
    }
}
