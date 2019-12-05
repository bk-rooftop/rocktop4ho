using UnityEngine;
using System.Collections;

public class Particle : MonoBehaviour {

	public ParticleSystem particleDestoryEffect;
	GameObject player;

	void Awake () 
	{
		player = GameObject.FindGameObjectWithTag ("Player");

	}

	void Update()
	{
		
	}


	void OnTriggerEnter (Collider other)
	{
		
		if (other.gameObject == player) 
		{
			Destroy(Instantiate (particleDestoryEffect.gameObject, transform.position , Quaternion.identity)as GameObject, particleDestoryEffect.startLifetime);
			Destroy (gameObject, 0f);
		}
	}


}
