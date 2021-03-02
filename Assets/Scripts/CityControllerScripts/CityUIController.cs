using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class CityUIController : MonoBehaviour
{
    // Start is called before the first frame update
    public Image background;
    public Text nameText;
    private int cityIndex;
    public SetCharacterListPanel chaListPanel;
    public SetHotelPanel hotelPanel;

    private void Awake()
    {
        cityIndex = GameManagerSingleton.GetInstance.placeState;
    }
    private void Start()
    {
        City localCity = CityList.cityList[cityIndex];
        nameText.text = localCity.hanName;
        background.sprite =Resources.Load<Sprite>("Image/City/" + localCity.pyName);
    }

    

    public void ChangeChaPanelEnabled()
    {
        if(chaListPanel.gameObject.activeInHierarchy == false)
        {
            CloseAllPanel();
            chaListPanel.gameObject.SetActive(true);
            chaListPanel.RefreshPanel();
        }
        else
        {
            CloseAllPanel();
        }
    }
    
    public void ChangeHotelPanelEnabled()
    {
        if (hotelPanel.gameObject.activeInHierarchy == false)
        {
            CloseAllPanel();
            hotelPanel.gameObject.SetActive(true);
            hotelPanel.RefreshPanel();
        }
        else
        {
            CloseAllPanel();
        }
    }

    public void CloseAllPanel()
    {
        chaListPanel.CloseChaInfoPanel();
        chaListPanel.gameObject.SetActive(false);
        hotelPanel.gameObject.SetActive(false);
    }

    public void LoadMapScene()
    {
        GameManagerSingleton.GetInstance.placeState = 0;
        SceneManager.LoadScene("MainScene");
    }
}
