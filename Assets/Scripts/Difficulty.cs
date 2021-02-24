using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Difficulty : MonoBehaviour
{
    public static string UsrDifficulty;
    
    void Start()
    {
        UsrDifficulty = "";
    }

    public void SelectEasy()
    {
        UsrDifficulty = "Easy";
        SceneManager.LoadScene("MainScene");
    }

    public void SelectMedium()
    {
        UsrDifficulty = "Medium";
        SceneManager.LoadScene("MainScene");
    }

    public void SelectHard()
    {
        UsrDifficulty = "Hard";
        SceneManager.LoadScene("MainScene");
    }

    public string GetDifficulty()
    {
        return UsrDifficulty;
    }
}
