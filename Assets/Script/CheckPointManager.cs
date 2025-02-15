﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointManager : MonoBehaviour {

    private GameObject gc;
    public bool playerWins;
    public bool enemyWins;

    public enum CheckPoints
    {
        one,
        two,
        three,
        four,
    };

    public CheckPoints cp = new CheckPoints();

    void Start ()
    {
        gc = GameObject.Find("GameController");
        gc.GetComponent<GameController>().playLapStarter = false;
        gc.GetComponent<GameController>().numCheckPoint = 0;
        gc.GetComponent<GameController>().numLapPlayer = 0;
        gc.GetComponent<GameController>().bestTimeEnemy = 1000;
        gc.GetComponent<GameController>().bestTimePlayer = 1000;
        gc.GetComponent<GameController>().playerTime = 60f;

    }
	
	void Update ()
    {
		
	}

    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Player")
        {
            if (cp == CheckPoints.one && gc.GetComponent<GameController>().numCheckPoint == 0 && gc.GetComponent<GameController>().numLapPlayer == 0)
            {
                gc.GetComponent<GameController>().playLapStarter = true;
                gc.GetComponent<GameController>().numCheckPoint = 1;
                Debug.Log("CheckPoint 1");
            }


            else if (cp == CheckPoints.two && gc.GetComponent<GameController>().numCheckPoint == 1)
            {
                gc.GetComponent<GameController>().numCheckPoint = 2;
                gc.GetComponent<GameController>().playerTime = gc.GetComponent<GameController>().playerTime + 15f;
                Debug.Log("CheckPoint 2");
            }

            else if (cp == CheckPoints.three && gc.GetComponent<GameController>().numCheckPoint == 2)
            {
                gc.GetComponent<GameController>().numCheckPoint = 3;
                gc.GetComponent<GameController>().playerTime = gc.GetComponent<GameController>().playerTime + 15f;
                Debug.Log("CheckPoint 3");
            }

            else if (cp == CheckPoints.four && gc.GetComponent<GameController>().numCheckPoint == 3)
            {
                gc.GetComponent<GameController>().numCheckPoint = 4;
                gc.GetComponent<GameController>().playerTime = gc.GetComponent<GameController>().playerTime + 15f;
                Debug.Log("CheckPoint 4");
            }

            if (cp == CheckPoints.one && gc.GetComponent<GameController>().numCheckPoint == 4)
            {
                gc.GetComponent<GameController>().numLapPlayer++;
                gc.GetComponent<GameController>().playLapStarter = false;
                gc.GetComponent<GameController>().lastTimePlayer = gc.GetComponent<GameController>().playerTime;

                if (gc.GetComponent<GameController>().lastTimePlayer < gc.GetComponent<GameController>().bestTimePlayer)
                {
                    gc.GetComponent<GameController>().bestTimePlayer = gc.GetComponent<GameController>().lastTimePlayer;
                }

                gc.GetComponent<GameController>().playerTime = 0;
                gc.GetComponent<GameController>().playLapStarter = true;
                gc.GetComponent<GameController>().numCheckPoint = 1;
            }

            if (cp == CheckPoints.one && gc.GetComponent<GameController>().numCheckPoint == 1 && gc.GetComponent<GameController>().numLapPlayer == 3)
            {
                gc.GetComponent<GameController>().playWins = true;
            }
        }


        if (coll.tag == "Enemy")
        {
            if (cp == CheckPoints.one && gc.GetComponent<GameController>().numCheckPointEnemy == 0
            && gc.GetComponent<GameController>().numLapEnemy == 0)
            {
                gc.GetComponent<GameController>().playLapStartEnemy = true;
                gc.GetComponent<GameController>().numCheckPointEnemy = 1;
            }


            else if (cp == CheckPoints.two && gc.GetComponent<GameController>().numCheckPointEnemy == 1)
            {
                gc.GetComponent<GameController>().numCheckPointEnemy = 2;
            }

            else if (cp == CheckPoints.three && gc.GetComponent<GameController>().numCheckPointEnemy == 2)
            {
                gc.GetComponent<GameController>().numCheckPointEnemy = 3;
            }

            else if (cp == CheckPoints.four && gc.GetComponent<GameController>().numCheckPointEnemy == 3)
            {
                gc.GetComponent<GameController>().numCheckPointEnemy = 4;
            }

            if (cp == CheckPoints.one && gc.GetComponent<GameController>().numCheckPointEnemy == 4)
            {
                gc.GetComponent<GameController>().numLapEnemy++;
                gc.GetComponent<GameController>().playLapStartEnemy = false;
                gc.GetComponent<GameController>().lastTimeEnemy = gc.GetComponent<GameController>().enemyTime;

                if (gc.GetComponent<GameController>().lastTimeEnemy < gc.GetComponent<GameController>().bestTimeEnemy)
                {
                    gc.GetComponent<GameController>().bestTimeEnemy = gc.GetComponent<GameController>().lastTimeEnemy;
                }

                gc.GetComponent<GameController>().enemyTime = 0;
                gc.GetComponent<GameController>().playLapStartEnemy = true;
                gc.GetComponent<GameController>().numCheckPointEnemy = 1;
            }


            if (cp == CheckPoints.one && gc.GetComponent<GameController>().numCheckPointEnemy == 1
            && gc.GetComponent<GameController>().numLapEnemy == 3)
            {
                gc.GetComponent<GameController>().playWinsEnemy = true;
            }

        }


    }

}
