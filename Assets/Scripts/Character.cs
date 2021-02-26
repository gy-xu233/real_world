using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    public enum STATE
    {
        Idle,
        Running
    }
    public string name;
    public int chaIndex;
    public int targetPlaceIndex;
    public int localPlaceIndex;
    public STATE state;
    public Character(int _chaIndex, string _name, int _cityIndex)
    {
        chaIndex = _chaIndex;
        name = _name;
        targetPlaceIndex = localPlaceIndex = _cityIndex;
        state = STATE.Idle;
    }

}
