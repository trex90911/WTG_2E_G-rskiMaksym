using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenuScript : MonoBehaviour
{
    public GameObject DeathMenu;

    void Start()
    {
        DeathMenu.SetActive(false);
    }
    public void Die()
    {
        Time.timeScale = 0f;
        DeathMenu.SetActive(true);
    }

    public void PlayAgain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync(1);
    }
}
