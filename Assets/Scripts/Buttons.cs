using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class Buttons : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("ExitScreen");
    }

    public void Exit()
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
}
