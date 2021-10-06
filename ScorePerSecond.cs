using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePerSecond : MonoBehaviour
{

    public Text scoreText;
    public Text highscoreText;

    public float scoreAmount;
    public float pointIncreasedPerSecond;
    public float highScore;

    // Start is called before the first frame update
    void Start()
    {
        scoreAmount = 0f;
        pointIncreasedPerSecond = 1f;

        highScore = PlayerPrefs.GetFloat("highScore");
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = (int)scoreAmount + "";
        scoreAmount += pointIncreasedPerSecond * Time.deltaTime;

        highscoreText.text = highScore.ToString();

        if (scoreAmount > highScore)
        {
            PlayerPrefs.SetFloat("highScore", scoreAmount);
        }
        
    }
}
