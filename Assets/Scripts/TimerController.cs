using UnityEngine;
using System;
using TMPro;

public class TimerController : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    public float currentTime;
    public bool CountDown;

    public bool hasLimit;
    public float timerLimit;

    public TextMeshProUGUI finalTime;
    public TextMeshProUGUI BestTime;

    public string levelName;

    private void Update()
    {
        currentTime = CountDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;

        gameOverTimer();

        SetTimerText();
    }

    private void SetTimerText()
    {
        timerText.text = currentTime.ToString("0.00");
    }

    public void gameOverTimer()
    {
        if (hasLimit && ((CountDown && currentTime <= timerLimit) || (!CountDown && currentTime >= timerLimit)))
        {
            currentTime = timerLimit;
            SetTimerText();
            timerText.color = Color.red;
            enabled = false;
            PlayerManager.isGameOver = true;
        }
    }

    public void BestTimeUpdate()
    {
        string bestTimeKey = "BestTime_" + levelName;

        if (PlayerPrefs.HasKey(bestTimeKey))
        {
            if (currentTime < PlayerPrefs.GetFloat(bestTimeKey))
            {
                PlayerPrefs.SetFloat(bestTimeKey, currentTime);
            }
        }
        else
        {
            PlayerPrefs.SetFloat(bestTimeKey, currentTime);
        }

        BestTime.text = PlayerPrefs.GetFloat(bestTimeKey).ToString("0.00");
        finalTime.text = currentTime.ToString("0.00");
    }
   
    
}
