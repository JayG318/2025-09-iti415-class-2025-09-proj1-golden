using UnityEngine;
using UnityEngine.UI;

public class SurvivalScore : MonoBehaviour
{
    [Header("Inscribed")]
    public Text scoreText;
    public float pointsPerSecond = 10f;

    [Header("Dynamic")]
    public float score = 0f;
    public bool scoringEnabled = true;

    void Update()
    {
        if (!scoringEnabled) return;

        score += pointsPerSecond * Time.deltaTime;
        if (scoreText != null)
            scoreText.text = "Score: " + Mathf.FloorToInt(score);
    }

    public void StopScoring()
    {
        scoringEnabled = false;
    }
}
