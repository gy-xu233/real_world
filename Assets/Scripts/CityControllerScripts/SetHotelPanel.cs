using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SetHotelPanel : MonoBehaviour
{
    public InputField inputName;
    public Text news;

    public void RefreshPanel()              //现在是每次打开hotel panel时更新页面，可以改成每天更新，这样同一天打听的消息，
    {                                       //每次打开酒馆都会看见，不会消失。
        inputName.text = "";
        news.text = "";
        news.gameObject.SetActive(false);
    }

    public void ObtainNews()
    {
        string t_inputName = inputName.text;
        if(GameManagerSingleton.GetInstance.characterName2Index.ContainsKey(t_inputName) &&
            CityList.cityList[GameManagerSingleton.GetInstance.placeState].
                characterNewsInCity[GameManagerSingleton.GetInstance.characterName2Index[t_inputName]] != null)
        {
            news.text = "听游人谈论过，这位爷最近的行踪是： \n" + 
                CityList.cityList[GameManagerSingleton.GetInstance.placeState].
                characterNewsInCity[GameManagerSingleton.GetInstance.characterName2Index[t_inputName]].newsContent;
        }
        else
        {
            news.text = "小店没有这位爷的消息";
        }
        news.gameObject.SetActive(true);
    }
}
