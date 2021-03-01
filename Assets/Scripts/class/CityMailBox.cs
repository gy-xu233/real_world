using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityMailBox
{
    public List<CityMail> mailList;
    public int countTime;
    public CityMailBox(int _countTime)
    {
        countTime = _countTime;
        mailList = new List<CityMail>();
    }
}
