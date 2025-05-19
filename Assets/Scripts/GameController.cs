using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public int spawnCount;
    public float spawnWait;
    public float startSpawn;
    public float waveWait;

    public Text ScoreText;
    public Text GameOverText;
    public Text RestartText;
    public Text QuitText;
    public int score;

    private bool gameOver;
    private bool restart;

    void Update()
    {
        if (restart == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(0);
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Application.Quit();
            }
        }
    }
    IEnumerator SpawnValues()
    {
        yield return new WaitForSeconds(startSpawn);
        while (true)
        {
            for (int i = 0; i < spawnCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-3, 3), 0, 10);
                Quaternion spawnRotation = Quaternion.identity;

                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
            if (gameOver == true)
            {
                RestartText.text = "Press 'R' to Restart";
                QuitText.text = "Press 'Q' to Quit";              
                restart = true;
                break;
            }
        }
    }

    public void UpdateScore()
    {
        score += 10;
        ScoreText.text = "Score: " + score;
    }
    
    public void GameOver()
    {
        GameOverText.text = "Game Over!";
        gameOver = true;
    }
    void Start()
    {
        GameOverText.text = "";
        RestartText.text = "";
        QuitText.text = "";
        gameOver = false;
        restart = false;
        StartCoroutine(SpawnValues());
    }
}
