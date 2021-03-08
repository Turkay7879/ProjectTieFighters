using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AtStart : MonoBehaviour
{
    public TMP_Text HighScoreText;

    void Start()
    {
        if (!PlayerPrefs.HasKey("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", 0);
            PlayerPrefs.Save();
        }
        int LastHighScore = PlayerPrefs.GetInt("HighScore");
        HighScoreText.text = "En Yuksek Skor: " + LastHighScore.ToString();
    }
}
