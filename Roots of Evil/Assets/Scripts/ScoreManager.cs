using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    int score = 0;
    float scoref = 0.0f;
    int highscore = 0;

	// Start is called before the first frame update
	void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text ="SCORE: " + score.ToString();
        highScoreText.text = "HIGHSCORE: " + highscore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        scoref += 1 * Time.deltaTime;
        score = Mathf.RoundToInt(scoref);
        scoreText.text = "SCORE: " + score.ToString();

        if (highscore < score)
		{
            PlayerPrefs.SetInt("highscore", score);
        }
        
    }
}
