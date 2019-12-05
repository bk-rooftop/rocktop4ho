using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Projectile : MonoBehaviour {
	
	public enum Guns {Pistol, MachineGun, ShotGun, Rocket};
	Guns curruntGun = Guns.Pistol;

	public float radius = 10f;

	public LayerMask collisionMask;

	public float speed = 30;
	public int damage = 20;

	float lifetime = 2f;
	float skinWidth = .1f;

	public GameObject bulletEffect;
	public Transform effectHold;





	void Start(){
		

		Destroy (gameObject, lifetime);

		Collider[] initialCollisions = Physics.OverlapSphere (transform.position, .1f, collisionMask);
		if (initialCollisions.Length > 0) {
			OnHitObject (initialCollisions [0]);
		}


		BulletEffect ();
	}



	public void SetSpeed(float newSpeed){
		speed = newSpeed;

	}

	public void MyGun(int gunNumber)
	{
		switch (gunNumber)
		{
		case(0):
			curruntGun = Guns.Pistol;
			Debug.Log ("Pistol");
			break;
		case(1):
			curruntGun = Guns.MachineGun;
			Debug.Log ("Machine");
			break;
		case(2):
			curruntGun = Guns.ShotGun;
			Debug.Log ("ShotGun");
			break;
		case(3):
			curruntGun = Guns.Rocket;
			Debug.Log ("Rocket");
			break;
		}
	}



	void Update ()
	{
		float moveDistance = speed * Time.deltaTime;
		CheckCollisions (moveDistance);
		transform.Translate (Vector3.forward * moveDistance);
	}



	void CheckCollisions (float moveDistance) 
	{
		Ray ray = new Ray (transform.position, transform.forward);
		RaycastHit hit;

		if (Physics.Raycast (ray, out hit, moveDistance + skinWidth, collisionMask, QueryTriggerInteraction.Collide)) {


			if (curruntGun == Guns.Rocket) {
				Collider[] colliders = Physics.OverlapSphere (transform.position, radius);


				for (int i = 0; i < colliders.Length; i++) {
					OnHitObject (colliders [i]);

				}
			}

			else
			{
				OnHitObject (hit.collider);
			}

		}
	}



	void OnHitObject(Collider c)
	{
		EnemyHealth damageableObject = c.GetComponent<EnemyHealth> ();
		LittleEnemyHealth damageableLitteObject = c.GetComponent<LittleEnemyHealth> ();
		if (damageableObject != null) {
			damageableObject.TakeDamage (damage);
		} else if(damageableLitteObject !=null){
			damageableLitteObject.TakeDamage (damage);
		}
		GameObject.Destroy (gameObject);
	}

	void BulletEffect()
	{
		GameObject newBulletEffect = Instantiate (bulletEffect.gameObject, effectHold.transform.position, effectHold.transform.rotation )as GameObject;
		newBulletEffect.transform.parent = effectHold.transform;
	}

}

