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
    }
    public void LoadTargetScene(int cityIndex)
    {
        GameManagerSingleton.GetInstance.placeState = cityIndex;
        SceneManager.LoadScene(cityScene);
    }
}
