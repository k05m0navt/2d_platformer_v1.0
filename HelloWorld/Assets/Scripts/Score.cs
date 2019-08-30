using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int scoreAmount;
    Text scoreText;

    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreAmount = Character.scoreAmount;
    }

    void Update()
    {
        scoreText.text = "Score: " + scoreAmount;
        Character.scoreAmount = scoreAmount;
    }
}
