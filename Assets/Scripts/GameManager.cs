using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int enemyCount;
    public int score = 0;
    public Text scoreText;

    public Text gameOverText;
    public Text restartText;
    public Text toMainMenuText;

    void Start()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    private void LateUpdate()
    {
        if (score >= enemyCount)
        {
            Victory();
        }
    }

    void UpdateScore()
    {
        scoreText.text = "УБИТО ВРАЖЕСКИХЪ NeDoTankOFF: " + score;
    }

    public void AddScore()
    {
        score ++;
        UpdateScore();
    }

    public void GameOver()
    {
        gameOverText.enabled = true;
        restartText.enabled= true;
        toMainMenuText.enabled= true;
    }

    public void Victory()
    {
        gameOverText.text = "ПАБЕДА!111";
        gameOverText.enabled = true;
        restartText.enabled= true;
        toMainMenuText.enabled= true;
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void RestatrGame()
    {
        SceneManager.LoadScene(1);
    }
}
