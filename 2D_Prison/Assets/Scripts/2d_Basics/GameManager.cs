using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    /*
    public GameObject homeScreen; // Reference to your home screen UI panel
    private bool isGamePaused = false;

    private void Awake()
    {
        homeScreen.SetActive(true);
        IsHomeScreenActive();
    }
    void Update()
    {
        if (IsHomeScreenActive())
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }

    private bool IsHomeScreenActive()
    {
        return homeScreen.activeSelf; // Check if the home screen is active
       // homeScreen.SetActive(true);
    }

    private void PauseGame()
    {
        if (!isGamePaused)
        {
            Time.timeScale = 0f; // Pause the game by setting time scale to 0
            isGamePaused = true;

            // Optionally, disable player controls or other gameplay mechanics
            // Example: FindObjectOfType<PlayerController>().enabled = false;
        }
    }

    private void ResumeGame()
    {
        if (isGamePaused)
        {
            Time.timeScale = 1f; // Resume the game by setting time scale to 1
            isGamePaused = false;

            // Optionally, re-enable player controls or other gameplay mechanics
            // Example: FindObjectOfType<PlayerController>().enabled = true;
        }
    }
*/
    public GameObject homeScreen;
   // public GameObject reload;

    public void Homescreen()
    {
        homeScreen.SetActive(false);
    }

    public void Reload()
    {
        SceneManager.LoadScene(0);
    }
}
