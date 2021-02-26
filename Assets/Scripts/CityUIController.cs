using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class CityUIController : MonoBehaviour
{
    // Start is called before the first frame update
    private Image background;
    private Text nameText;
    private string cityName;
    private void Awake()
    {
        background = GetComponent<Image>();
        nameText = GetComponent<Text>();
        cityName = GameManagerSingleton.GetInstance.placeState;
    }
    private void Start()
    {
        Debug.Log(cityName);
        //nameText.text = cityName;
        background.sprite =(Sprite)Resources.Load("Image/" + cityName + ".jpg");
    }
    public void LoadMapScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
