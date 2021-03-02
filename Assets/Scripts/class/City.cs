using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City
{
    public int index;
    public string pyName;
    public string hanName;
    public List<Character> charactersInCity;
    public List<string> mailContentInCity;

    public City(int _index, string _pyName, string _hanName)
    {
        index = _index;
        pyName = _pyName;
        hanName = _hanName;
        charactersInCity = new List<Character>();
        mailContentInCity = new List<string>();
    }
    public void addCharacter(Character _character)
    {
        charactersInCity.Add(_character);
    }

    public void sendMail(string mailContent)
    {
        int outDay = GameManagerSingleton.GetInstance.timeCountDay;
        for (int i = 1; i < CityList.cityList.Count; i++)
        {
            if(i != index)
            {
                MailManagerSingleton.GetInstance.AddCityMail(new CityMail(mailContent, index, i, outDay));
            }
        }
    }

    public void receiveMail(string mailContent)
    {
        mailContentInCity.Add(mailContent);
        Debug.Log(hanName + "的酒馆收到消息：   " + mailContent);
    }
}
