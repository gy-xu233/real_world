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
        chaListPanel.gameObject.SetActive(!chaListPanel.gameObject.activeSelf);
        chaListPanel.CloseChaInfoPanel();
        if(chaListPanel.gameObject.activeSelf == true)
        {
            chaListPanel.RefreshCharacterPanel();
        }
    }
    
    public void CloseAllPanel()
    {
        chaListPanel.gameObject.SetActive(false);
        hotelPanel.gameObject.SetActive(false);
    }

    public void LoadMapScene()
    {
        GameManagerSingleton.GetInstance.placeState = 0;
        SceneManager.LoadScene("MainScene");
    }
}
