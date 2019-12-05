using UnityEngine;
using System.Collections;

public class ParticleManager : MonoBehaviour {

	public GameObject memoryParticle;
	public float mapSize =40f;

	float curruntCount;
	float startCount=10;

	public float respawnTime = 6f;
	float timer;

	void Awake()
	{
		curruntCount = startCount;
	}

	void Start()
	{
		

		StartCoroutine (RandomParticle ());

	}

	void Update()
	{
		timer += Time.deltaTime;

		if (timer > 5f) 
		{
			timer = 0f;
		
			curruntCount = 5f;
			StartCoroutine (RandomParticle ());

		
		}
	}


	IEnumerator RandomParticle ()
	{
		int i = 0;

		while (i < curruntCount) 
		{
			i++;
			float randomX = Random.Range (-mapSize / 2, mapSize / 2);
			float randomZ = Random.Range (-mapSize / 2, mapSize / 2);
			Vector3 randomPosition = new Vector3 (randomX, 1f, randomZ);
			float randomScale = Random.Range (0, .5f);

			GameObject newParticle = Instantiate (memoryParticle, randomPosition, Quaternion.identity) as GameObject;
			newParticle.transform.localScale = Vector3.one * (1 - randomScale);
				
			yield return new WaitForSeconds (respawnTime);
		}

		curruntCount = 0;
//		Debug.Log ("recieve Count 0 "+ curruntCount);
		yield return null;
	}


}
