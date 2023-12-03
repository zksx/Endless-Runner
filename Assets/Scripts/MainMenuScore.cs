using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScore : MonoBehaviour
{
    private Text MMScore;

    // Start is called before the first frame update
    void Start()
    {
        if(GameData.Score > -1)
        {
            MMScore = GetComponent<Text>();
            int score = GameData.Score;

            MMScore.text = score.ToString("Distance: #");
        }
    }
}
