using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MainScenesController : MonoBehaviour
{
    public string cityScene = "CityScene";
    private void Awake()
    {
        GameManagerSingleton.GetInstance.init();
        Debug.Log(GameManagerSingleton.GetInstance.placeState);
    }
    public void LoadTargetScene(string CityName)
    {
        GameManagerSingleton.GetInstance.placeState = CityName;
        SceneManager.LoadScene(cityScene);
    }
}
