using TMPro;
using UnityEngine;

public class LevelBestTime : MonoBehaviour
{

    public TextMeshProUGUI BestTime;

    public string levelName;
    void Update()
    {
        string bestTimeKey = "BestTime_" + levelName;
        BestTime.text = PlayerPrefs.GetFloat(bestTimeKey).ToString("0.00");
    }
}
