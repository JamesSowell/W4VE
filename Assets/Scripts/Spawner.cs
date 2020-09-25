using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{

    public GameObject[] spawnPoints;

    public float seconds;

    public GameObject gameOverPanel;

    public GameObject uiDisable;

    public GameObject victoryPanel;

    public GameObject pausePanel;

    public Animator musicFade;
    
    public static int killCount;
    //private int totalKills = 0;

    public Text waveDisplay;
    public Text killCountDisplay;
    public Text waveNumberDisplay, killTotalDisplay, highScoreDisplay;

    public static bool playerIsDead = false;
    public static bool wonGame = false;

    public static bool isPause;

    private int waveNumber;

    public static bool waveOne;
    public static bool waveTwo;
    public static bool waveThree;
    public static bool waveFour;

    void Start()
    {
        wonGame = false;
        isPause = false;
        pausePanel.SetActive(false);
        victoryPanel.SetActive(false);
        uiDisable.SetActive(true);
        playerIsDead = false;
        gameOverPanel.SetActive(false);
        waveOne = true;
        waveTwo = false;
        waveThree = false;
        waveFour = false;
        killCount = 0;
        waveDisplay.text = "WAVE: 1";
        waveNumber = 1;
        WaveOne();
    }

    void Update()
    {
        
        if(wonGame == true)
        {
            victoryPanel.SetActive(true);
            uiDisable.SetActive(false);
            musicFade.SetTrigger("Fade Out");
            TurnOffSpawner();
        }
        
        
        if(killCount == 5)
        {
            waveNumber = 2;
            WaveTwo();
            waveOne = false;
            waveTwo = true;
            waveDisplay.text = "WAVE: 2";
        }
        if (killCount == 15)
        {
            waveNumber = 3;
            waveTwo = false;
            waveThree = true;
            WaveThree();
            waveDisplay.text = "WAVE: 3";
        }
        if(killCount == 40)
        {
            waveNumber = 4;
            WaveFour();
            waveThree = false;
            waveFour = true;
            waveDisplay.text = "WAVE: 4";
        }
        if (killCount >= 100 && playerIsDead == false)
        {
            wonGame = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) && playerIsDead == false && wonGame == false)
        {
            if (isPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        killCountDisplay.text = "KillCount: " + killCount;

        if (playerIsDead)
        {
            uiDisable.SetActive(false);
            gameOverPanel.SetActive(true);
            if(killCount > PlayerPrefs.GetInt("TotalScore", 0)){
                PlayerPrefs.SetInt("TotalScore", killCount);
            }
            killTotalDisplay.text = "TOTAL KILLS: " + killCount;
            waveNumberDisplay.text = waveNumber.ToString();
            highScoreDisplay.text = "HIGH SCORE: " + PlayerPrefs.GetInt("TotalScore");
            musicFade.SetTrigger("Fade Out");
            TurnOffSpawner();
        }
    }

    void Pause()
    {
        isPause = true;
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }

    void Resume()
    {
        isPause = false;
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    void WaveOne()
    {
        spawnPoints[0].SetActive(true);
        spawnPoints[1].SetActive(false);
        spawnPoints[2].SetActive(false);
        spawnPoints[3].SetActive(false);
    }

    void WaveTwo()
    {             
        spawnPoints[0].SetActive(true);
        spawnPoints[1].SetActive(true);
        spawnPoints[2].SetActive(false);
        spawnPoints[3].SetActive(false);
    }

    void WaveThree()
    {
        spawnPoints[0].SetActive(true);
        spawnPoints[1].SetActive(true);
        spawnPoints[2].SetActive(true);
        spawnPoints[3].SetActive(false);
    }

    void WaveFour()
    {
        spawnPoints[0].SetActive(true);
        spawnPoints[1].SetActive(true);
        spawnPoints[2].SetActive(true);
        spawnPoints[3].SetActive(true);
    }

    void TurnOffSpawner()
    {
        spawnPoints[0].SetActive(false);
        spawnPoints[1].SetActive(false);
        spawnPoints[2].SetActive(false);
        spawnPoints[3].SetActive(false);
    }
}
