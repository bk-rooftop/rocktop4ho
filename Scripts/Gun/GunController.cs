using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GunController : MonoBehaviour {

	public GameObject[] guns;
	public GameObject currentGun = null;


	public GameObject equipedGun = null;
	public Transform weaponHold;
	public GameObject startingGun;


	Vector3 adjust;

	int i = 0;

	public GameObject changeEffect;

	Transform playerTr;
	GameObject newBulletEffect;


	void Start ()
	{
		playerTr = GetComponent<Transform> ();

		if (startingGun != null) 
		{
			EquipGun (0) ;
		}
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			
			if(i < 3)
			{
				i++;
				EquipGun(i);

			}
			else 
			{
				i = 0;
				EquipGun(i);

			}

			GunChangeEffect ();
		}
	}

	public void EquipGun (int gunNumber)
	{
		
		if (equipedGun != null) 
		{
			Destroy (equipedGun.gameObject);
			Debug.Log ("destory gun");
		}

		int myGunNumber = gunNumber;

		equipedGun = Instantiate (guns[myGunNumber], weaponHold.position , weaponHold.rotation) as GameObject;
		equipedGun.transform.parent = weaponHold;
		Gun myGun = equipedGun.GetComponent<Gun> ();
		myGun.MyGun (myGunNumber);



	}

	public void GunChangeEffect ()
	{
		newBulletEffect = Instantiate (changeEffect.gameObject, playerTr.position, playerTr.rotation)as GameObject;
		newBulletEffect.transform.parent = playerTr.transform;
		Destroy (newBulletEffect, 1.5f);
	}

}
