using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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
        SceneManager.LoadScene(1);
    }
    public void QuitButtonAction()
    { 
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }
}
