﻿using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour, IDamageble {

	public int startingHealth = 100;
	public float currentHealth;
	public float sinkSpeed ;
	public float nuckBackSpeed ;
	public int scoreValue = 10;
	public AudioClip deathClip;
	public ParticleSystem deathEffect;

	protected Animator anim;
	protected AudioSource enemyAudio;


	protected CapsuleCollider capsuleCollider;
	protected bool isDead;
	protected bool isSinking;

	public GameObject littleMon;
	public Transform[] littleMonSpawn;

	public event System.Action OnDeath;


	protected  void Awake()
	{

		anim = GetComponent<Animator> ();
		enemyAudio = GetComponent <AudioSource>();


		capsuleCollider = GetComponent <CapsuleCollider> ();

		currentHealth = startingHealth;
	}


	void Update()
	{
		if (isSinking) 
		{
			transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
		}
	}

	public void SetWaveValue(float enemyHealth)
	{
		currentHealth += enemyHealth; 
	}


	public virtual void TakeDamage (float amount)
	{
		if (isDead)
			return;

		enemyAudio.Play ();

		currentHealth -= amount;

		//		transform.Translate (-Vector3.forward *nuckBackSpeed * Time.deltaTime);

		if (currentHealth <= 0) 
		{
			Death ();
			Split ();
		}

	}

	void Death()
	{
		isDead = true;

		capsuleCollider.isTrigger = true;

		anim.SetTrigger ("IsDead");


		enemyAudio.clip = deathClip;
		enemyAudio.Play ();
		Destroy(Instantiate (deathEffect.gameObject, transform.position, Quaternion.AngleAxis(-90f, Vector3.right) )as GameObject, deathEffect.startLifetime);
		GetComponent <UnityEngine.AI.NavMeshAgent> ().enabled = false;
		GetComponent <Rigidbody> ().isKinematic = true;
		isSinking = true;
		ScoreManager.score += scoreValue;

		if (OnDeath != null) {
			OnDeath ();
		}

		Destroy (gameObject, 1f);

	}

	void Split()
	{
		for (int i = 0; i < littleMonSpawn.Length; i++) {

			Instantiate (littleMon, littleMonSpawn [i].position, transform.rotation);
		}
	}



	public void StartSinking()
	{
		GetComponent <UnityEngine.AI.NavMeshAgent> ().enabled = false;
		GetComponent <Rigidbody> ().isKinematic = true;
		isSinking = true;

		Destroy (gameObject, 2f);
	}
}
