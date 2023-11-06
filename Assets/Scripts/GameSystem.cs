using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameSystem : MonoBehaviour
{
    // private GameManager gameManager;

    public int startigScore = 0;
    private int currentScore;
    public Text scoreText;

    public int startingLives = 5;
    private int currentLives = 0;
    public Text livesText;

    private void Awake()
    {
        // gameManager = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        ResetAllSystem();
    }

    private void ResetAllSystem()
    {
        currentScore = startigScore;
        currentLives = startingLives;
        UpdateScore();
        UpdateLives();
    }

    public void IncreaseScore(int extraScore)
    {
        currentScore += extraScore;
        UpdateScore();
    }

    public void DecreaseLives()
    {
        currentLives--;
        UpdateLives();
    }

    public int GetCurrentLives()
    {
        return currentLives;
    }

    private void UpdateScore()
    {
        scoreText.text = currentScore.ToString();
    }

    private void UpdateLives()
    {
        livesText.text = currentLives.ToString();
    }
}
