using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public GameObject PauseMenu;
    public bool IsPaused = false;
    void Start()
    {
        PauseMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused) { ResumeGame(); } //taki zapis ifa jest nieczytelny
            else { PauseGame(); }

            //Lepiej coś takiego:
            /*
            if (IsPaused) 
                ResumeGame();
            else
                PauseGame(); 
             */
        }

    }

    //Zamiast dwóch metod możesz mieć jedną
    public void TogglePause(bool value)
    {
        PauseMenu.SetActive(value);
        Time.timeScale = value ? 0f : 1f;
        IsPaused = value;
    }

    public void PauseGame() 
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
    }
    public void ResumeGame()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
