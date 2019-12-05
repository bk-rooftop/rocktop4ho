using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownManager : MonoBehaviour
{
    public Text countdownText;
    

    public float currentTime = 0f;
    float startingTime = 10f;

    EnemyManager em;
    GameUI gu;
    bool countOver = true;

    void Awake()
    {
        em = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
        gu = GameObject.Find("Canvas").GetComponent<GameUI>();
        currentTime = startingTime;
       
    }

    

    void Update()
    {
        currentTime -= Time.deltaTime;
        countdownText.text = currentTime.ToString("00");
        if (currentTime <= 0f)
        {
            currentTime = 0f;
            startingTime = 5f;
               
        }
    }
    void WaveStart()
    {
        
        gu.uiStart = true;
        em.waveStart = true;
        em.NextWave();
        Debug.Log("2");

    }
}
