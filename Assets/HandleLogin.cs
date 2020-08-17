using UnityEngine;

public class HandleLogin : MonoBehaviour
{
    FacebookLoginFunctions FB;

    private void Start()
    {
        FB = GetComponent<FacebookLoginFunctions>();
    }

    public void FacebookLogin()
    {
        FB.FBLogin();
    }

    public void GuestLogin()
    {

    }

    public void SetUserProfile(string name, string email, string usrName, Sprite profilePic)
    {

    }
}
