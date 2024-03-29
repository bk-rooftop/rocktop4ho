﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class GameUI : MonoBehaviour {
	public Image fadePlane;
	public GameObject gameOverUI;

	public RectTransform newWaveBanner;
	public Text newWaveTitle;
	public Text newWaveEnemyCount;

    public bool uiStart;
      
	EnemyManager spawner;

	void Awake()
	{
		spawner = FindObjectOfType<EnemyManager> ();
		spawner.OnNewWave += OnNewWave;
    }


	void Start () 
	{
       		FindObjectOfType<PlayerHealth> ().OnPlayerDeath += OnGameOver;
  	}

   

	void OnNewWave(int waveNumber) 
	{
		string[] numbers = { "One", "Two", "Three", "Four", "Five" };
		newWaveTitle.text = "- Wave " + numbers[waveNumber -1] + " -";
		newWaveEnemyCount.text = "Enemies: " + spawner.waves [waveNumber - 1].enemyCount;
        if (uiStart)
        {
            StartCoroutine(AnimateNewWaveBanner());
            uiStart = false;
        }
         
    }



    IEnumerator AnimateNewWaveBanner()
    {
            float delayTime = 1.5f;
            float speed = 3f;
            float animatePercent = 0f;
            int dir = 1;

            float endDelayTime = Time.time + 1 / speed + delayTime;
            
           
                    while (animatePercent >= 0)
                    {
                        animatePercent += Time.deltaTime * speed * dir;

                        if (animatePercent >= 1)
                        {
                            animatePercent = 1;
                            if (Time.time > endDelayTime)
                            {
                                dir = -1;
                            }
                        }

                        newWaveBanner.anchoredPosition = Vector2.up * Mathf.Lerp(-400, 50, animatePercent);
                 
                        yield return null;
                    }
   
    }

	void OnGameOver() 
	{
		StartCoroutine (Fade (Color.clear, Color.black, 1));
		gameOverUI.SetActive (true);
	}

	IEnumerator Fade(Color from, Color to, float time)
	{
		float speed = 1 / time;
		float percent = 0;

		while (percent < 1) 
		{
			percent += Time.deltaTime * speed;
			fadePlane.color = Color.Lerp (from, to, percent);
			yield return null;
		}
	}

	// UI Input
	public void StartNewGame()
	{
		SceneManager.LoadScene ("Fight");
		print ("button Down");
	}
}
