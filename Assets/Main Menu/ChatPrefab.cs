using UnityEngine.UI;
using UnityEngine;

public class ChatPrefab : MonoBehaviour
{
    public Text message, Sender;

    public void SetPrefab(Message msg)
    {
        message.text = msg.text;
        Sender.text = msg.sender;
    }
}
