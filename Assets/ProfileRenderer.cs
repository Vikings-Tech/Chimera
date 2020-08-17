using UnityEngine.UI;
using UnityEngine;

public class ProfileRenderer : MonoBehaviour
{
    public Image ProfilePic;
    public Text Name;

    public void SetProfilePic(Sprite _ProfilePic)
    {
        if(ProfilePic != null)
        ProfilePic.sprite = _ProfilePic;
    }

    public void SetName(string _name)
    {
        if(Name != null)
        Name.text = _name;
    }
}
