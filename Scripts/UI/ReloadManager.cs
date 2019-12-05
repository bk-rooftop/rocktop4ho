using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ReloadManager : MonoBehaviour {

	Text text;
	public float flashSpeed = 1f;
	bool isReloading;
//	public Color flashColor;
//	Color originColor;

	void Awake ()
	{
		text = GetComponent<Text> ();
//		originColor = text.color;
	}

	void Start()
	{
		text.enabled = false;
		isReloading = false;

	}

	public void ReloadText()
	{
		isReloading = false;
		StartCoroutine (ShowText ());
	}


	public void Reloaded()
	{
		isReloading = true;
	}

	IEnumerator ShowText()
	{
		

			
		while (!isReloading)
		{
			
			text.enabled = true;
			yield return new WaitForSeconds (0.2f);

			text.enabled = false;
			yield return new WaitForSeconds (0.2f);


		}
			
		yield return null;
	}
	

}
