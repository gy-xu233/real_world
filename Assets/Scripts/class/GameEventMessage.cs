using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventMessage
{
    public int outCityIndex;
    public int outDay;
    public string messageContent;
    public GameEventMessage(int _outCityIndex, int _outDay, string _messageContent)
    {
        outCityIndex = _outCityIndex;
        outDay = _outDay;
        messageContent = _messageContent;
    }
}
