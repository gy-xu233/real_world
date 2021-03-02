using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City
{
    public int index;
    public string pyName;
    public string hanName;
    public List<Character> charactersInCity;
    public CharacterNews[] characterNewsInCity;


    public City(int _index, string _pyName, string _hanName)
    {
        index = _index;
        pyName = _pyName;
        hanName = _hanName;
        charactersInCity = new List<Character>();
        characterNewsInCity = new CharacterNews[101];
    }
    public void addCharacter(Character _character)
    {
        charactersInCity.Add(_character);
    }

    public void sendMail(CharacterNews mailContent)
    {
        int newsIndex = mailContent.characterIndex;
        characterNewsInCity[newsIndex] = mailContent;
        int outDay = GameManagerSingleton.GetInstance.timeCountDay;
        for (int i = 1; i < CityList.cityList.Count; i++)
        {
            if(i != index)
            {
                MailManagerSingleton.GetInstance.AddCityMail(new CityMail(mailContent, index, i, outDay));
            }
        }
    }

    public void receiveMail(CharacterNews mailContent)
    {
        int newsIndex = mailContent.characterIndex;
        if(characterNewsInCity[newsIndex] == null || (characterNewsInCity[newsIndex].newsDay < mailContent.newsDay))
        {
            characterNewsInCity[newsIndex] = mailContent;
        }
        Debug.Log(hanName + "的酒馆收到消息：   " + mailContent.newsContent);
    }
}
