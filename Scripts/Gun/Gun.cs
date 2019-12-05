using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Gun : MonoBehaviour {
	
	public float timeBetweenBullets = .3f;
	public int ammo =6;
	public float reloadTimer = -1f;
	int currentAmmo;
	public Projectile projectile;

	public Transform[] muzzle;
	public float muzzleVelocity = 35;

	float timer;


	ParticleSystem gunParticles;

	AudioSource gunAudio;
	public AudioClip reloadAudio;
	public AudioClip shotAudio;
	bool isReloaded;
	Light gunLight;
	float effectsDisplayTime = 0.2f;

	Animator anim;
	GameObject player;
	float trigger;
	int myGunNumber;


	public ReloadManager reloadText;

	PlayerHealth playerHealth;



	void Awake()
	{
		gunParticles = GetComponentInChildren <ParticleSystem> ();
		gunAudio = GetComponentInChildren <AudioSource> ();
		gunLight = GetComponentInChildren <Light> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent<PlayerHealth> ();
		anim = player.GetComponent<Animator> ();
		currentAmmo = ammo;
		reloadText = GameObject.FindGameObjectWithTag ("Text").GetComponent<ReloadManager> ();
	}



	public void MyGun(int gunNumber)
	{
		myGunNumber = gunNumber;
	}



	void Update()
	{
		timer += Time.deltaTime;

		bool trigger = Input.GetButton ("Fire1");

		if (playerHealth.currentHealth > 0)
		{
			if (Input.GetButton ("Fire1") && timer >= timeBetweenBullets && currentAmmo > 0) {
				Shoot ();
			}
			if (Input.GetButtonUp ("Fire1")) {
				Reload ();
			}
		}


		if (timer >= timeBetweenBullets * effectsDisplayTime) 
		{
			DisableEffects ();
		}

		if (currentAmmo == 0) 
		{
			reloadText.ReloadText ();
		}

		Animating(trigger);
	}




	public void DisableEffects()
	{
		gunLight.enabled = false;
	}


	void Shoot()
	{
		
			timer = 0f;
			currentAmmo--;
			gunAudio.clip = shotAudio;
			gunAudio.Play ();

			gunLight.enabled = true;

			gunParticles.Stop ();
			gunParticles.Play ();

			for (int i = 0; i < muzzle.Length; i++) {
				Projectile newProjectile = Instantiate (projectile, muzzle [i].position, muzzle [i].rotation) as Projectile;
				newProjectile.SetSpeed (muzzleVelocity);
				newProjectile.MyGun (myGunNumber);
			}

	}


	void Reload()
	{
		gunAudio.clip = reloadAudio;
		gunAudio.Play ();
	
		currentAmmo = ammo;
		timer = reloadTimer;

		reloadText.Reloaded ();
	}

	void Animating(bool button)
	{
		bool attack = button ;
		anim.SetBool ("Attack", attack);
	}




}
