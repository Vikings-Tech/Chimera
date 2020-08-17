using UnityEngine;

public class CommonScreenOrientation : MonoBehaviour
{
    public bool isPortrait;
    
    void Awake()
    {
        if (isPortrait)
        {
            Screen.orientation = ScreenOrientation.Portrait;
        }
        else
        {
            Screen.orientation = ScreenOrientation.Landscape;
        }
    }
    
    }
