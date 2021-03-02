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
    public int timeYear;       //日
    public int timeMonth;      //月
    public int timeDay;        //日
    public int timeCountDay;    // 游戏开始后的天数
    public string timeText;
    public List<Character> characterList;
    public Dictionary<string, int> characterName2Index;
    public Character characterPlayer;

    public void init()
    {
        if(characterList == null)
        {
            characterList = new List<Character>();
            characterName2Index = new Dictionary<string, int>();
            placeState = 0;
            timeYear = 100;
            timeMonth = 1;
            timeDay = 1;
            timeCountDay = 1;
            characterPlayer = RandomCharacter(0);
            timeText = timeYear.ToString() + "年" + timeMonth.ToString() + "月" + timeDay.ToString() + "日";
            for (int i = 0; i < 101; i++)
            {
                Character temporaryCharacter = RandomCharacter(i);
                while(characterName2Index.ContainsKey(temporaryCharacter.CharacterName))
                {
                    temporaryCharacter = RandomCharacter(i);
                }
                characterName2Index.Add(temporaryCharacter.CharacterName, i);
                characterList.Add(temporaryCharacter);
                CityList.cityList[temporaryCharacter.localPlaceIndex].addCharacter(characterList[i]);
            }
            for (int i = 0; i < 1000; i++)
            {
                int j = Random.Range(0, 101);
                int k = Random.Range(0, 101);
                if(j != k)
                {
                    characterList[j].AddRelation(new ChacterRelationship(k, ChacterRelationship.RELATIONSHIP.FRIEND));
                    characterList[k].AddRelation(new ChacterRelationship(j, ChacterRelationship.RELATIONSHIP.FRIEND));
                }
            }
        }
    }

    private Character CreateCharcterPlayer()
    {
        return new Character(-1, "杨", "过", 1, 2);
    }


    private Character RandomCharacter(int characterIndex)
    {
        int gender = Random.Range(1, 3);
        string xing = RandomName.Xing[Random.Range(0, RandomName.Xing.Count)];
        int ifTowMing = Random.Range(0, 2);   //名是否为双字
        string ming;
        if(ifTowMing == 0 && gender == 1)    //女、单名
        {
            ming = RandomName.lastNameWoMan.Substring(Random.Range(0, RandomName.lastNameWoMan.Length), 1);
        }
        else if(ifTowMing == 1 && gender == 1) //女、双名
        {
            ming = RandomName.lastNameWoMan.Substring(Random.Range(0, RandomName.lastNameWoMan.Length), 1) + RandomName.lastNameWoMan.Substring(Random.Range(0, RandomName.lastNameWoMan.Length), 1);
        }
        else if (ifTowMing == 0 && gender == 2) //男、单名
        {
            ming = RandomName.lastNameMan.Substring(Random.Range(0, RandomName.lastNameMan.Length), 1);
        }
        else                                    //男、双名
        {
            ming = RandomName.lastNameMan.Substring(Random.Range(0, RandomName.lastNameMan.Length), 1) + RandomName.lastNameMan.Substring(Random.Range(0, RandomName.lastNameMan.Length), 1);
        }
        int cityIndex = Random.Range(1, CityList.cityList.Count);
        return new Character(characterIndex, xing, ming, cityIndex, gender);
    }

    public void DailyRefresh()
    {
        RefreshTimeText();                                    //游戏世界刷新时间在每天早上，
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
        characterPlayer.Tick();
        MailManagerSingleton.GetInstance.RefreshMail();
    }

    private void RefreshTimeText()
    {
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
        timeCountDay++;
        timeText = timeYear.ToString() + "年" + timeMonth.ToString() + "月" + timeDay.ToString() + "日";
    }

}
