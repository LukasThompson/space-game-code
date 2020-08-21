using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWaitMin;
    public float spawnWaitMax;
    public float startWait;
    public float waveWait;

    public Text restartText;
    public Text gameOverText;
    private bool gameOver;
    private bool restart;
    public Text scoreText;
    private int score;
    private int waveCount = 1;

    void Start()
    {
        score = 0;
        gameOver = false;
        restart = false;
        gameOverText.text = "";
        restartText.text = "";
        UpdateScore();
        StartCoroutine(SpawnWaves());
    }

    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[UnityEngine.Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(UnityEngine.Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(UnityEngine.Random.Range(spawnWaitMin, spawnWaitMax));
            }
            waveCount += 1;
            hazardCount += UnityEngine.Random.Range(1, 7);
            gameOverText.text = "Wave " + waveCount;
            yield return new WaitForSeconds(waveWait);
            gameOverText.text = "";

            if (gameOver)
            {
                restartText.text = "Press 'R' for Restart...";
                restart = true;
                break;
            }
        }
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void AddScore(int scoreValue)
    {
        score += scoreValue;
        UpdateScore();
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;

    }
}
