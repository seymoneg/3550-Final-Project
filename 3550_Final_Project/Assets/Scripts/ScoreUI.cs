using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ScoreUI : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    private string score;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    public void updateText(ScoreKeeper scorekeeper)
    {
        score = scorekeeper.score.ToString();
        scoreText.text = (score + "/10"); //TODO: CHANGE THE 10 TO THE NUMBER OF BLOOD BAGS
    }
}
