using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [Header("Dynamic")]

    public static int score = -1;
    private Text uiText;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        uiText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        score = (int)playermovement.ballObject.transform.position.z;
        uiText.text = score.ToString("Distance: #");
    }
}
