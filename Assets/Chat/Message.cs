using System;
using UnityEngine;

[Serializable]
public class Message
{
    public string text, sender;

    public Message(string _text, string _sender)
    {
        text = _text;
        sender = _sender;
    }
}
