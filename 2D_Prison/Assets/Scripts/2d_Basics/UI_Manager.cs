using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    public GameObject HomeScreen;
    public GameObject GameOverScreen;

    public GameObject Climbtext;
    private bool hasDisplayedClimbText = false; // Flag to track first-time display

    //public GameObject MainGame;

    // Start is called before the first frame update
    void Start()
    {
        ShowHomeScreen();
        ClimbTextDisable();

    }
    // Update is called once per frame
    void Update()
    {
        
    }

   public  void ShowHomeScreen()
    {
        HomeScreen.SetActive(true);
        GameOverScreen.SetActive(false);
       // MainGame.SetActive(false);
        Time.timeScale = 0;  // Pause game at home screen
    }

    public void StartGame()
    {
        HomeScreen.SetActive(false);
        GameOverScreen.SetActive(false);
       // MainGame.SetActive(true);
        Time.timeScale = 1;  // Resume game
    }

    public void GameOver()
    {
        HomeScreen.SetActive(false);
        GameOverScreen.SetActive(true);
       // MainGame.SetActive(false);
        Time.timeScale = 0;  // Pause game when over
    }

    public void ClimbTextEnable()
    {
        if (!hasDisplayedClimbText) // Display only once
        {
            Climbtext.SetActive(true);
            hasDisplayedClimbText = true; // Ensure text won't appear again
            StartCoroutine(DisableClimbTextAfterDelay());
        }


    }

    public void ClimbTextDisable()
    {
        Climbtext.SetActive(false);


    }

    private IEnumerator DisableClimbTextAfterDelay()
    {
        yield return new WaitForSeconds(3f);
        Climbtext.SetActive(false);

    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1; // Reset time scale when restarting
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
