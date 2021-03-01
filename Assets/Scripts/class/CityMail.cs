using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityMail
{
    public string mailContent;
    public int sendCityIndex;
    public int receiveCityIndex;
    public int outDay;
    public CityMail(string _mailContent, int _sendCityIndex, int _receiveCityIndex, int _outDay)
    {
        mailContent = _mailContent;
        sendCityIndex = _sendCityIndex;
        receiveCityIndex = _receiveCityIndex;
        outDay = _outDay;
    }
}
