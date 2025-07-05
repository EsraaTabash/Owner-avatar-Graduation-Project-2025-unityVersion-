using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{

    public TextMeshProUGUI scoreTMP;

    public int scoreInt;

    private void Start()
    {
        scoreInt = PlayerPrefs.GetInt("Score");
    }

    public void ClickButton()
    {
        PlayerPrefs.SetInt("Score", ++scoreInt);
    }

    private void Update()
    {
        scoreTMP.text = "Score: " + PlayerPrefs.GetInt("Score").ToString();
    }

}
