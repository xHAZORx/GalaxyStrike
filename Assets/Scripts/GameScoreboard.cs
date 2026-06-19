using UnityEngine;
using TMPro;

public class GameScoreboard : MonoBehaviour
{
    int score = 0;
    [SerializeField] private TMP_Text scoreText;

    public void IncreaseScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score;
    }
}