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
    public int gender; //1:女 2：男
    public string name;
    public string xing;
    public string ming;
    public int chaIndex;
    public int targetPlaceIndex;
    public int localPlaceIndex;
    public STATE state;
    public int arriveDuration;
    public int randomTarget;

    public Character(int _chaIndex, string _xing, string _ming, int _cityIndex,int _gender)
    {
        gender = _gender;
        chaIndex = _chaIndex;
        xing = _xing;
        ming = _ming;
        name = xing + ming;
        targetPlaceIndex = localPlaceIndex = _cityIndex;
        state = STATE.Idle;
        arriveDuration = 0;
        randomTarget = -1;
    }

    public void Tick()
    {
        if(state == STATE.Running)
        {
            if (arriveDuration > 0) arriveDuration--;
            else
            {
                state = STATE.Idle;
                localPlaceIndex = targetPlaceIndex;
            }
        }
        else if(state == STATE.Idle)
        {
            if(randomTarget > 0 && randomTarget != targetPlaceIndex)   //idle状态的人物每一天生成randomTarget，
            {                                                          //    大于0则进入running状态，去下一个城市
                state = STATE.Running;
                targetPlaceIndex = randomTarget;
                arriveDuration = 10;
            }
        }
    }

}
