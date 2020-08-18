using UnityEngine.UI;
using UnityEngine;
using System;

public class ChatHandler : MonoBehaviour
{
    public InputField messageInput;
    public DatabaseAPI database;

    public ChatPrefab messagePrefab;
    public Transform messagesContainer;

    private void Start()
    {
        database.ListenForMessages(InstantiateMessage, Debug.Log );
    }

    public void SendMessage()
    {
        Debug.Log(GameManager.usrName);
        database.PostMessage(new Message(messageInput.text, GameManager.usrName), () => 
        {
            Debug.Log("Message Was sent");
        },exception =>
        {
            Debug.Log(exception);
        }
        );
    }

    private void InstantiateMessage(Message message)
    {
        var msg = Instantiate(messagePrefab, transform.position, Quaternion.identity);
        msg.transform.SetParent(messagesContainer, false);
        msg.SetPrefab(message);
    }
}
