using UnityEngine;
using System.Collections;

public class HeadHold : MonoBehaviour {

	public GameObject startingFace;
	public Transform faceHold;
	public GameObject startingHead;
	public Transform headHold;
	public GameObject equipedFace = null;
	public GameObject equipedHead = null;

	void Start () {

		if (startingFace != null) 
		{
			EquipFace (startingFace) ;
		}

		if (startingHead != null) 
		{
			EquipHead (startingHead) ;
		}

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void EquipFace (GameObject newFace)
	{

		if (equipedFace != null) 
		{
			Destroy (equipedFace.gameObject);
		}


		equipedFace = Instantiate (newFace, faceHold.position, faceHold.rotation) as GameObject;
		equipedFace.transform.parent = faceHold;

	}

	public void EquipHead (GameObject newHead)
	{

		if (equipedHead != null) 
		{
			Destroy (equipedHead.gameObject);
		}


		equipedHead = Instantiate (newHead, headHold.position, headHold.rotation) as GameObject;
		equipedHead.transform.parent = headHold;

	}

}
