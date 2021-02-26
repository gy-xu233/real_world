using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City
{
    public int index;
    public string pyName;
    public string hanName;
    public List<Character> charactersInCity;
    public City(int _index, string _pyName, string _hanName)
    {
        index = _index;
        pyName = _pyName;
        hanName = _hanName;
        charactersInCity = new List<Character>();
    }
    public void addCharacter(Character _character)
    {
        charactersInCity.Add(_character);
    }
}
