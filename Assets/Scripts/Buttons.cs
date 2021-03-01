using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    GameManagement management;
    GameObject pauseMenuCanvas;
    
    void Start()
    {

    }

    void Update()
    {
        
    }

    public void MainMenuExit()
    {
        pauseMenuCanvas = GameObject.Find("MainMenuCanvas").transform.Find("MainCanvas").gameObject;
        pauseMenuCanvas.SetActive(false);
        SceneManager.LoadScene("ExitScreen", LoadSceneMode.Additive);
    }

    public void ExitGame()
    {
        EditorApplication.isPlaying = false;
        //Application.Quit();
    }

    public void TryAgainYes()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    public void TryAgainNo()
    {
        SceneManager.LoadScene("DifficultyMenu");
    }

    public void Pause()
    {
        management = GameObject.Find("GameManagement").GetComponent<GameManagement>();
        management.HideElements();
        SceneManager.LoadScene("PauseScene", LoadSceneMode.Additive);
    }

    public void Resume()
    {
        management = GameObject.Find("GameManagement").GetComponent<GameManagement>();
        management.ShowElements();
        SceneManager.UnloadSceneAsync("PauseScene");
    }

    public void Replay()
    {
        management = GameObject.Find("GameManagement").GetComponent<GameManagement>();
        string lastDiff = management.GameDiff;
        Debug.Log("Before replay: " + lastDiff);
        PlayerPrefs.SetString("Difficulty", lastDiff);
        SceneManager.LoadScene("MainScene");
    }

    public void PauseMenuQuit()
    {
        pauseMenuCanvas = GameObject.Find("PauseMenuCanvas").transform.Find("PauseCanvas").gameObject;
        pauseMenuCanvas.SetActive(false);
        SceneManager.LoadScene("ExitScreen", LoadSceneMode.Additive);
    }

    public void GoBack()
    {
        if (SceneManager.GetActiveScene().name.Equals("MainScene"))
        {
            pauseMenuCanvas = GameObject.Find("PauseMenuCanvas").transform.Find("PauseCanvas").gameObject;
            pauseMenuCanvas.SetActive(true);
            SceneManager.UnloadSceneAsync("ExitScreen");
        }

        else if (SceneManager.GetActiveScene().name.Equals("DifficultyMenu"))
        {
            pauseMenuCanvas = GameObject.Find("MainMenuCanvas").transform.Find("MainCanvas").gameObject;
            pauseMenuCanvas.SetActive(true);
            SceneManager.UnloadSceneAsync("ExitScreen");
        }
    }

    public void HowToPlayOpen()
    {
        SceneManager.LoadScene("HowToPlay");
    }

    public void HowToPlayClose()
    {
        SceneManager.LoadScene("DifficultyMenu");
    }

}
