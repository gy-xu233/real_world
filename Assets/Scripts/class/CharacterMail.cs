using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMail
{
    public int outCityIndex;
    public int outDay;
    public int sendCharacter;
    public int receiveCharacter;
    public string mailContent;
    public CharacterMail(int _sendCharacter, int _receiveCharacter, int _outCityIndex, int _outDay, string _mailContent)
    {
        sendCharacter = _sendCharacter;
        receiveCharacter = _receiveCharacter;
        outCityIndex = _outCityIndex;
        outDay = _outDay;
        mailContent = _mailContent;
    }
}
