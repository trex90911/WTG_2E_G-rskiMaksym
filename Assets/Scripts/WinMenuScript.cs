using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WinMenuScript : MonoBehaviour
{
    public GameObject WinMenu;
    void Start()
    {
        WinMenu.SetActive(false);
    }
    public void Win()
    {
        WinMenu.SetActive(true);
        Time.timeScale = 0f;
    }
}
