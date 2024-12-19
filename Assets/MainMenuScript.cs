using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    private void Start()
    {
        SceneManager.UnloadSceneAsync(1);
    }
    public void StartButtonAction()
    {
        SceneManager.LoadSceneAsync(1); //Używaj LoadSyncAsync.
    }
    public void QuitButtonAction()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }
}
