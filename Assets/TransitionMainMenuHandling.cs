using UnityEngine;

public class TransitionMainMenuHandling : MonoBehaviour
{
    public Animator anim;

    public void EnterChat()
    {
        anim.SetTrigger("ChatIn");
    }

    public void ExitChat()
    {
        anim.SetTrigger("ChatOut");
    }
}
