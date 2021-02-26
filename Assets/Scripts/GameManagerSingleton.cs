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
    public string placeState;
    public void init()
    {
        placeState = "map";
    }

}
