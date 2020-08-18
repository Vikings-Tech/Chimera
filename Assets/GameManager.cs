using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static string usrName;
    public Profile profile;
    public static string id;
    public static Sprite profilePic;

    //public Sprite DefaultProfilePic;

    private void Awake()
    {
        //Debug.Log("Entered Game Manager Start");
        if (string.IsNullOrEmpty(usrName))
        {
            usrName = "Anonymous";
            //Debug.Log("Assigned Username as Anonymous");
        }
        
        //if(profilePic == null)
        //{

        //}
    }
}
