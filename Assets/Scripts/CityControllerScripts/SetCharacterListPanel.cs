using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetCharacterListPanel : MonoBehaviour
{
    public GameObject tempGameObject;
    public ScrollRect tempScrollRect;
    private List<Character> charactersInCity;
    private List<GameObject> characterRowCash;
    public SetInformationPanel infoPanel;
    private int cityIndex;

    private void Awake()
    {
        cityIndex = GameManagerSingleton.GetInstance.placeState;
        characterRowCash = new List<GameObject>();
    }

    private void Start()
    {
        RefreshCharacterPanel();
    }

    public void RefreshCharacterPanel()
    {
        charactersInCity = CityList.cityList[cityIndex].charactersInCity;
        GameObject temporaryGo;
        int i;
        for (i = 0; i < charactersInCity.Count; i++)
        {
            if (i < characterRowCash.Count)
            {
                temporaryGo = characterRowCash[i];
            }
            else
            {
                temporaryGo = GameObject.Instantiate(tempGameObject, tempScrollRect.content);
                characterRowCash.Add(temporaryGo);
            }
            int temporaryCharacterIndex = charactersInCity[i].chaIndex;
            temporaryGo.GetComponent<SetCharacterListRow>().setInformation(charactersInCity[i]);
            temporaryGo.GetComponent<Button>().onClick.AddListener(() =>
            {
                infoPanel.SetPanel(temporaryCharacterIndex);
                OpenChaInfoPanel();
            });
            temporaryGo.SetActive(true);
        }
        if (i < characterRowCash.Count)
        {
            for (; i < characterRowCash.Count; i++)
            {
                characterRowCash[i].SetActive(false);
            }
        }
    }
    public void OpenChaInfoPanel()
    {
        infoPanel.gameObject.SetActive(true);
    }

    public void CloseChaInfoPanel()
    {
        infoPanel.gameObject.SetActive(false);
    }
}
