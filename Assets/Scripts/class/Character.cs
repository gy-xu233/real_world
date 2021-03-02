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
    public CharacterNews[] mailInCharacter;



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

        mailInCharacter = new CharacterNews[101];
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
        List<CharacterMail> temporaryMessages = new List<CharacterMail>();
        int nowDay = GameManagerSingleton.GetInstance.timeCountDay;

        if(state == STATE.Running)
        {
            arriveDuration--;
            if (arriveDuration == 0)
            {
                state = STATE.Idle;                                //到达某地
                localPlaceIndex = targetPlaceIndex;

                string cityMailContentString = CharacterName + " 于 " + GameManagerSingleton.GetInstance.timeText + " 到达 " + 
                    CityList.cityList[localPlaceIndex].hanName;
                CharacterNews cityMailContent = new CharacterNews(chaIndex, cityMailContentString, nowDay);
                CityList.cityList[localPlaceIndex].sendMail(cityMailContent);
            }
        }
        else if(state == STATE.Idle)
        {
            if(randomTarget > 0 && randomTarget != targetPlaceIndex)   //idle状态的人物每一天生成randomTarget，
            {                                                          //    大于0则进入running状态，去下一个城市
                state = STATE.Running;
                targetPlaceIndex = randomTarget;
                arriveDuration = CityList.cityDistance[localPlaceIndex,targetPlaceIndex];  
                sendLeaveMail(localPlaceIndex, targetPlaceIndex);                              
            }
        }
    }

    public void receiveCharacterMail(CharacterNews mailContent)
    {
        int newIndex = mailContent.characterIndex;
        if(mailInCharacter[newIndex] == null || mailInCharacter[newIndex].newsDay <= mailContent.newsDay)
        {
            mailInCharacter[newIndex] = mailContent;
        }
    }

    private void sendLeaveMail(int _localPlaceIndex, int _targetPlaceIndex)
    {
        int nowDay = GameManagerSingleton.GetInstance.timeCountDay;
        string content = CharacterName + " 于 " + GameManagerSingleton.GetInstance.timeText + " 从 " +
            CityList.cityList[_localPlaceIndex].hanName + " 前往 " + CityList.cityList[_targetPlaceIndex].hanName;
        foreach (var t_relation in chacterRelation)
        {
            MailManagerSingleton.GetInstance.AddCharacterMail(new CharacterMail(chaIndex, 
                t_relation.characterIndex, _localPlaceIndex, nowDay, new CharacterNews(chaIndex,content,nowDay)));
        }
    }
}
