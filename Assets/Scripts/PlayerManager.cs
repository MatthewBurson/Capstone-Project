using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public int CoinCount;

    public static bool isGameOver;
    public static bool isGameWon;
    public static bool isGamePaused;
    public GameObject gameOverScreen;
    public GameObject gameWonScreen;
    public GameObject PauseScreen;

    public TimerController tc;

    private void Awake()
    {
        isGameOver = false;
        isGameWon = false;
        isGamePaused = false;
    }
    private void Update()
    {
        if (isGameOver)
        {
            gameOverScreen.SetActive(true);
            Time.timeScale = 0f; 
        }
        else
        {
            gameOverScreen.SetActive(false);
        }

       
       

        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                PauseScreen.SetActive(false);
                isGamePaused = false;
            }
            else if (!isGameOver && !isGameWon) 
            {
                PauseScreen.SetActive(true);
                isGamePaused = true;
            }
        }
        if (CoinCount == 3)
        {
            if (isGameWon)
            {
                gameWonScreen.SetActive(true);
                Time.timeScale = 0f;

                tc.BestTimeUpdate();   
            }
            else
            {
                gameWonScreen.SetActive(false);
            }
        }


        if (isGamePaused || isGameOver || isGameWon)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }


    }
    


}
