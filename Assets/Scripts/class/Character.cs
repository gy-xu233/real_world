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
    public string CharacterName;
    public int characterImageIndex;
    public string xing;
    public string ming;
    public int chaIndex;
    public int targetPlaceIndex;
    public int localPlaceIndex;
    public STATE state;
    public int arriveDuration;
    public int randomTarget;
    public List<ChacterRelationship> chacterRelation;
    public List<GameEventMessage> messagesReceived;
    private List<GameEventMessage> messagesOnTheWay;



    public Character(int _chaIndex, string _xing, string _ming, int _cityIndex,int _gender)
    {
        gender = _gender;
        chaIndex = _chaIndex;
        xing = _xing;
        ming = _ming;
        CharacterName = xing + ming;
        targetPlaceIndex = localPlaceIndex = _cityIndex;
        state = STATE.Idle;
        arriveDuration = 0;
        randomTarget = -1;
        
        messagesReceived = new List<GameEventMessage>();     //TODO:写一个单调队列来装消息。
        messagesOnTheWay = new List<GameEventMessage>();
        characterImageIndex = Random.Range(1, 101);
        chacterRelation = new List<ChacterRelationship>();
    }

    public void AddRelation(ChacterRelationship _relation)
    {
        bool flag = false;
        for (int i = 0; i < chacterRelation.Count; i++)
        {
            if(chacterRelation[i].characterIndex == _relation.characterIndex)
            {
                chacterRelation[i] = _relation;
                flag = true;
                break;
            }
        }
        if (!flag) chacterRelation.Add(_relation);
    }

    public void Tick()
    {
        List<GameEventMessage> temporaryMessages = new List<GameEventMessage>();
        int nowDay = GameManagerSingleton.GetInstance.countDay;
        foreach (var eventMessage in messagesOnTheWay)
        {
            if((nowDay - eventMessage.outDay) * 2 >= CityList.cityDistance[eventMessage.outCityIndex, localPlaceIndex])
            {
                temporaryMessages.Add(eventMessage);
            }
        }
        foreach (var eventmessage in temporaryMessages)
        {
            messagesReceived.Add(eventmessage);
            Debug.Log(CharacterName + "在" + CityList.cityList[localPlaceIndex].hanName
                + "前往" + CityList.cityList[targetPlaceIndex].hanName +  "的途中收到消息： " + eventmessage.messageContent);
            messagesOnTheWay.Remove(eventmessage);
        }

        if(state == STATE.Running)
        {
            if (arriveDuration > 0) arriveDuration--;
            else
            {
                state = STATE.Idle;                                //到达某地
                localPlaceIndex = targetPlaceIndex;
                sendArriveMessage(0, localPlaceIndex);
            }
        }
        else if(state == STATE.Idle)
        {
            if(randomTarget > 0 && randomTarget != targetPlaceIndex)   //idle状态的人物每一天生成randomTarget，
            {                                                          //    大于0则进入running状态，去下一个城市
                state = STATE.Running;
                targetPlaceIndex = randomTarget;
                arriveDuration = CityList.cityDistance[localPlaceIndex,targetPlaceIndex];
            }
        }
    }

    public void receiveCharacterMessage(GameEventMessage _message)
    {
        messagesOnTheWay.Add(_message);
    }

    private void sendArriveMessage(int _targetIndex, int _placeIndex)
    {
        int nowDay = GameManagerSingleton.GetInstance.countDay;
        string content = CharacterName + " 于 " + GameManagerSingleton.GetInstance.timeText + " 到达 " + CityList.cityList[_placeIndex].hanName;
        foreach (var t_relation in chacterRelation)
        {
            GameManagerSingleton.GetInstance.characterList[t_relation.characterIndex].
                receiveCharacterMessage(new GameEventMessage(_placeIndex, nowDay, content));
        }
    }
}
