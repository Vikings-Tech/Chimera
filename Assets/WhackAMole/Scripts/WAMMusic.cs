using UnityEngine;

public class WAMMusic : MonoBehaviour
{
    private AudioSource musicSource;
    // Start is called before the first frame update
    void Start()
    {
        musicSource = GetComponent<AudioSource>();
    }

    public void AudioToggle()
    {
        musicSource.mute = !musicSource.mute;
    }

    
}
