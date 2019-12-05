using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

	public PlayerHealth playerHealth;
	public GameObject[] enemy;
	public float spawnTime = 3f;
	public Transform[] spawnPoint;
	public int spawnCount = 30;

	public Wave[] waves;
	Wave curruntWave;
	int curruntWaveNumber;
	int enemyRemainingAlive;

    public bool waveStart;

    CountDownManager cdm;

  
    
	public event System.Action<int> OnNewWave;

    void Awake()
    {
        cdm = GameObject.Find("CountDownManager").GetComponent<CountDownManager>();
    }

    private void Start()
    {
        NextWave();
    }


    void Spawn ()
	{
		if (spawnCount > 0) 
		{	
			if (playerHealth.currentHealth <= 0f) {
				return;
			}

			int spawnPointIndex = Random.Range (0, spawnPoint.Length);
			int enemyIndex = Random.Range (0, enemy.Length);


			GameObject spawnedEnemy = Instantiate (enemy[enemyIndex], spawnPoint [spawnPointIndex].position + Vector3.up , Quaternion.identity)as GameObject;
			EnemyHealth spawnedEnemyHealth = spawnedEnemy.GetComponent<EnemyHealth> ();
			EnemyMovement spawnedEnemyMove = spawnedEnemy.GetComponent<EnemyMovement> ();

			spawnedEnemyMove.SetWaveValue (curruntWave.moveSpeed, curruntWave.hitDamage);
			spawnedEnemyHealth.SetWaveValue (curruntWave.enemyHealth);


			spawnCount--;
			spawnedEnemyHealth.OnDeath += OnEnemyDeath;

		}
        
	}


        void OnEnemyDeath()
	{
		enemyRemainingAlive--;

		if (enemyRemainingAlive == 0)
        {
			NextWave ();
           
         }
	}

	public void NextWave() {
	
		curruntWaveNumber++;
		print ("Wave: " + curruntWaveNumber);
       
            if (curruntWaveNumber - 1 < waves.Length)
            {
               
                curruntWave = waves[curruntWaveNumber - 1];

                spawnCount = curruntWave.enemyCount;
                spawnTime = curruntWave.timeBetweenSpawns;
                enemyRemainingAlive = spawnCount;

                InvokeRepeating("Spawn", 0, spawnTime);
              
                if (OnNewWave != null)
                {
                    OnNewWave(curruntWaveNumber);
                }
            }
              
        
	}



	[System.Serializable]
	public class Wave {

		public bool infinite;
		public int enemyCount;
		public float timeBetweenSpawns;

		public float moveSpeed;
		public int hitDamage;
		public float enemyHealth;
	}


}



	


