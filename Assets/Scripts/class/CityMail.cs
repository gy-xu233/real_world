using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityMail
{
    public CharacterNews mailContent;
    public int sendCityIndex;
    public int receiveCityIndex;
    public int outDay;
    public CityMail(CharacterNews _mailContent, int _sendCityIndex, int _receiveCityIndex, int _outDay)
    {
        mailContent = _mailContent;
        sendCityIndex = _sendCityIndex;
        receiveCityIndex = _receiveCityIndex;
        outDay = _outDay;
    }
}
