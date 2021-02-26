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
    public List<Character> characterList;
    public void init()
    {
        if(characterList == null)
        {
            characterList = new List<Character>();
            placeState = 0;
            for (int i = 0; i < 100; i++)
            {
                string name = "人物" + i.ToString();
                int cityIndex = Random.Range(1, 7);
                characterList.Add(new Character(i, name, cityIndex));
                CityList.cityList[cityIndex].addCharacter(characterList[i]);
            }
        }
    }

}
