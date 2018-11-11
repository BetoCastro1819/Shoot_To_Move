﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_Player : MonoBehaviour
{
	public Text playerHealth;
	public Text score;
	public Text waveNumber;
	public Text enemiesKilled;

    public Text currenWeapon;
    public Text ammo;

	private GameManager gm;
	private int currentScore;
	private int currentHealth;
	private int currentWave;
	private int currentEnemiesKilled;

    #region Singleton
    private static UI_Player instance;
    public static UI_Player Get()
    {
        return instance;
    }

    private void Awake()
    {
        instance = this;
    }
    #endregion

    private void Start()
	{
		gm = GameManager.GetInstance();

		if (score != null)
		{
			currentScore = gm.GetPlayerScore();
			score.text = "Score: " + currentScore.ToString("00000000");
		}

		if (waveNumber != null)
		{
			currentWave = gm.GetWaveNumber();
			waveNumber.text = "Wave Nro: " + currentWave.ToString("0");
		}

		if (playerHealth != null)
		{
			currentHealth = gm.GetPlayer().Health;
			playerHealth.text = "Health: " + currentHealth.ToString("0");
		}

		if (enemiesKilled != null)
		{
			currentEnemiesKilled = gm.enemiesKilled;
			enemiesKilled.text = "Enemies Killed: " + currentEnemiesKilled.ToString("0");
		}
	}


	void Update ()
	{
		// Writes values on screen, only when they have changed

		if (playerHealth != null)
		{
			if (currentHealth != gm.GetPlayer().Health)
			{
				currentHealth = gm.GetPlayer().Health;
				playerHealth.text = "Health: " + currentHealth.ToString("0");
			}
		}

		if (score != null)
		{
			if (gm.GetPlayerScore() != currentScore)
			{
				currentScore = gm.GetPlayerScore();
				score.text = "Score: " + currentScore.ToString("00000000");
			}
		}

		if (waveNumber != null)
		{
			if (currentWave != gm.GetWaveNumber())
			{
				currentWave = gm.GetWaveNumber();
				waveNumber.text = "Wave Nro: " + currentWave.ToString("0");
			}
		}

		if (enemiesKilled != null)
		{
			if (currentEnemiesKilled != gm.enemiesKilled)
			{
				currentEnemiesKilled = gm.enemiesKilled;
				enemiesKilled.text = "Enemies Killed: " + currentEnemiesKilled.ToString("0");
			}
		}
	}
}
