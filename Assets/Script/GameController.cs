using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //Variaveis do jogador
    public int numCheckPoint; 
    public int numLapPlayer;
    public int lapsLimit;
    public GameObject unity;

    public bool playLapStarter;
    public bool playWins;

    public float playerTime;
    public float lastTimePlayer;
    public float bestTimePlayer;

    public Text cronometer;

    //Variaveis do adversario
    public int numCheckPointEnemy;
    public int numLapEnemy;

    public bool playLapStartEnemy;
    public bool playWinsEnemy;

    public float enemyTime;
    public float lastTimeEnemy;
    public float bestTimeEnemy;
    
    void Start()
    {
        Time.timeScale = 1;

        numLapPlayer = 0;
        playerTime = 0.0f;
        playWins = false;

        numLapEnemy = 0;
        enemyTime = 0.0f;
        playWinsEnemy = false;
    }

    
    void Update()
    {
        PlayerLapsCount();
        EnemyLapCount();
    }

    //Metodo que fará a conta do número de voltas
    public void PlayerLapsCount() {

        if (playLapStarter) {
            playerTime -= Time.deltaTime;
            cronometer.text = playerTime.ToString();
        }

    }

    public void EnemyLapCount() {
        if (playLapStartEnemy) {
            enemyTime += Time.deltaTime;
        }

    }
}
