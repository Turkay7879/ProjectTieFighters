using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Difficulty : MonoBehaviour
{
    static string UsrDifficulty;
    // Start is called before the first frame update
    void Start()
    {
        UsrDifficulty = "";
    }

    // Update is called once per frame
    void Update()
    {
        
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
