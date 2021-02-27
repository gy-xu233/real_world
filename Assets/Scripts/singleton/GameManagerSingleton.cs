using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerSingleton
{
    private static GameManagerSingleton instance;
    public static GameManagerSingleton GetInstance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameManagerSingleton();
            }
            return instance;
        }
    }


    public int placeState;
    public int timeYear;
    public int timeMonth;
    public int timeDay;
    public List<Character> characterList;


    public void init()
    {
        if(characterList == null)
        {
            characterList = new List<Character>();
            placeState = 0;
            timeYear = 100;
            timeMonth = 1;
            timeDay = 1;
            for (int i = 0; i < 100; i++)
            {
                Character temporaryCharacter = RandomCharacter(i);
                characterList.Add(temporaryCharacter);
                CityList.cityList[temporaryCharacter.localPlaceIndex].addCharacter(characterList[i]);
            }
        }
    }

    private Character RandomCharacter(int characterIndex)
    {
        int gender = Random.Range(1, 3);
        string xing = RandomName.Xing[Random.Range(0, 501)];
        int ifTowMing = Random.Range(0, 2);   //名是否为双字
        string ming;
        if(ifTowMing == 0 && gender == 1)    //女、单名
        {
            ming = RandomName.lastNameWoMan.Substring(Random.Range(0, 151), 1);
        }
        else if(ifTowMing == 1 && gender == 1) //女、双名
        {
            ming = RandomName.lastNameWoMan.Substring(Random.Range(0, 151), 1) + RandomName.lastNameWoMan.Substring(Random.Range(0, 151), 1);
        }
        else if (ifTowMing == 0 && gender == 2) //男、单名
        {
            ming = RandomName.lastNameMan.Substring(Random.Range(0, 151), 1);
        }
        else                                    //男、双名
        {
            ming = RandomName.lastNameMan.Substring(Random.Range(0, 151), 1) + RandomName.lastNameMan.Substring(Random.Range(0, 151), 1);
        }
        int cityIndex = Random.Range(1, 7);
        return new Character(characterIndex, xing, ming, cityIndex, gender);
    }

    public void DailyRefresh()
    {
        foreach (var city in CityList.cityList)
        {
            city.charactersInCity.Clear();
        }
        foreach (var character in characterList)
        {
            character.Tick();
            if (character.state == Character.STATE.Idle)
            {
                CityList.cityList[character.localPlaceIndex].charactersInCity.Add(character);
            }
        }
        if (timeMonth == 1 || timeMonth == 3 || timeMonth == 5 || timeMonth == 7 ||
            timeMonth == 8 || timeMonth == 10 || timeMonth == 12)
        {
            timeMonth = timeMonth + (timeDay + 1) / 32;
            timeDay = (timeDay + 1) % 32 + (timeDay + 1) / 32;
        }
        else if (timeMonth == 2)
        {
            timeMonth = timeMonth + (timeDay + 1) / 29;
            timeDay = (timeDay + 1) % 29 + (timeDay + 1) / 29;
        }
        else
        {
            timeMonth = timeMonth + (timeDay + 1) / 31;
            timeDay = (timeDay + 1) % 31 + (timeDay + 1) / 31;
        }
        timeYear += timeMonth / 13;
        timeMonth = timeMonth % 13 + timeMonth / 13;
    }
    

}
