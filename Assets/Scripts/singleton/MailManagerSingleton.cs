using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailManagerSingleton
{
    private static MailManagerSingleton instance;
    private int maxDistanceBetweenCities = 40;
    private int mailBoxOffset;

    public static MailManagerSingleton GetInstance
    {
        get
        {
            if (instance == null)
            {
                instance = new MailManagerSingleton();
            }
            return instance;
        }
    }

    public List<CharacterMail> characterMailBox;          // 需要频繁删改，可以用更好地数据结构优化
    public List<CityMailBox> cityMailBoxManager;   // 同上，List和dictionary效率未知

    public void init()
    {
        characterMailBox = new List<CharacterMail>();
        cityMailBoxManager = new List<CityMailBox>();
        for (int i = 0; i < maxDistanceBetweenCities; i++)
        {
            cityMailBoxManager.Add(new CityMailBox(i + 1));
        }
        mailBoxOffset = 1;
    }

    public void RefreshMail()
    {
        int nowDay = GameManagerSingleton.GetInstance.timeCountDay;
        List<CharacterMail> removeMail = new List<CharacterMail>();
        foreach (var mail in characterMailBox)
        {
            if((nowDay - mail.outDay) * 2 >= 
                CityList.cityDistance[mail.outCityIndex, GameManagerSingleton.GetInstance.characterList[mail.receiveCharacter].localPlaceIndex] )
            {
                GameManagerSingleton.GetInstance.characterList[mail.receiveCharacter].receiveCharacterMail(mail.mailContent);
                removeMail.Add(mail);
            }
        }
        foreach (var mail in removeMail)
        {
            characterMailBox.Remove(mail);
        }
        removeMail.Clear();

        for (int i = 0; i < cityMailBoxManager.Count; i++)
        {
            cityMailBoxManager[i].countTime--;
        }
        int beClearedBox = (maxDistanceBetweenCities + 1 - mailBoxOffset) % maxDistanceBetweenCities;
        //Debug.Log("offset: " + mailBoxOffset.ToString());
        //Debug.Log("clear:" + beClearedBox.ToString());
        //Debug.Log(cityMailBoxManager[beClearedBox].countTime);
        foreach (var mail in cityMailBoxManager[beClearedBox].mailList)
        {

            CityList.cityList[mail.receiveCityIndex].receiveMail(mail.mailContent);
        }
        cityMailBoxManager[beClearedBox].mailList.Clear();
        cityMailBoxManager[beClearedBox].countTime = maxDistanceBetweenCities;
        mailBoxOffset = cityMailBoxManager[0].countTime;
    }

    public void AddCharacterMail(CharacterMail _characterMail)
    {
        characterMailBox.Add(_characterMail);
    }

    public void AddCityMail(CityMail _cityMail)
    {
        int boxIndex = (CityList.cityDistance[_cityMail.receiveCityIndex, _cityMail.sendCityIndex] + 
            maxDistanceBetweenCities - mailBoxOffset) % maxDistanceBetweenCities;
        //Debug.Log(_cityMail.mailContent + "  发送到  " + CityList.cityList[_cityMail.receiveCityIndex].hanName +
        //    "    index是： " + boxIndex.ToString() + "    offset是：" + mailBoxOffset.ToString());
        cityMailBoxManager[boxIndex].mailList.Add(_cityMail);
    }

}
