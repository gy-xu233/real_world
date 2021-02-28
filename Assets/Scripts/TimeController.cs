using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class TimeController : MonoBehaviour
{
    private bool timePause;
    public Text timeText;
    public GameObject screenMask;
    private int timeYear;
    private int timeMonth;
    private int timeDay;
    private Thread dailyRefresh;

    void Start()
    {
        timePause = true;
        refreshTimeText();
    }

    // Update is called once per frame
    void Update()
    {
        if(!timePause)
        {
            if(dailyRefresh != null && dailyRefresh.ThreadState == ThreadState.Stopped)
            {
                refreshTimeText();
                screenMask.SetActive(false);
                timePause = true;
                dailyRefresh.Abort();
            }
        }
    }

    public void RunTime()
    {  
        screenMask.SetActive(true);
        timePause = false;
        foreach (var character in GameManagerSingleton.GetInstance.characterList)
        {
            if(character.state == Character.STATE.Idle)
            {
                character.randomTarget = Random.Range(-10, 7);
            }
        }
        dailyRefresh = new Thread(new ThreadStart(GameManagerSingleton.GetInstance.DailyRefresh));
        dailyRefresh.Start();
    }

    private void refreshTimeText()
    {
        timeText.text = GameManagerSingleton.GetInstance.timeText;
    }

}
