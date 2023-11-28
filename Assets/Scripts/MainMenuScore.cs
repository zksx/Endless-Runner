using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScore : MonoBehaviour
{
    private Text MMScore;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Score.score);
        // Check if a score has been set
        if(Score.score > -1)
        {
            MMScore = GetComponent<Text>();
            score = Score.score;

            MMScore.text = score.ToString("Distance: #");
        }
    }
}
