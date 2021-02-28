﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class CityUIController : MonoBehaviour
{
    // Start is called before the first frame update
    public Image background;
    public Text nameText;
    public GameObject tempGameObject;
    public ScrollRect tempScrollRect;
    private List<Character> charactersInCity;
    private List<GameObject> characterRowCash;
    private int cityIndex;
    public CharacterInformationPanelController infoPanel;

    private void Awake()
    {
        cityIndex = GameManagerSingleton.GetInstance.placeState;
    }
    private void Start()
    {
        City localCity = CityList.cityList[cityIndex];
        characterRowCash = new List<GameObject>();
        nameText.text = localCity.hanName;
        background.sprite =Resources.Load<Sprite>("Image/City/" + localCity.pyName);
        RefreshCharacterPanel();
    }

    public void RefreshCharacterPanel()
    {
        charactersInCity = CityList.cityList[cityIndex].charactersInCity;
        GameObject temporaryGo;
        int i;
        for(i = 0; i < charactersInCity.Count;i++)
        {
            if(i < characterRowCash.Count)
            {
                temporaryGo = characterRowCash[i];
            }
            else
            {
                temporaryGo = GameObject.Instantiate(tempGameObject, tempScrollRect.content);
                characterRowCash.Add(temporaryGo);
            }
            int temporaryCharacterIndex = charactersInCity[i].chaIndex;
            temporaryGo.GetComponent<SetCharacterRow>().setInformation(charactersInCity[i]);
            temporaryGo.GetComponent<Button>().onClick.AddListener(()=>
            {
                infoPanel.SetPanel(temporaryCharacterIndex);
                infoPanel.openPanel();
            });
            temporaryGo.SetActive(true);
        }
        if(i < characterRowCash.Count)
        {
            for(; i < characterRowCash.Count; i++)
            {
                characterRowCash[i].SetActive(false);
            }
        }
    }

    public void changePanelEnabled()
    {
        tempScrollRect.gameObject.SetActive(!tempScrollRect.gameObject.activeSelf);
    }

    public void LoadMapScene()
    {
        GameManagerSingleton.GetInstance.placeState = 0;
        SceneManager.LoadScene("MainScene");
    }
}