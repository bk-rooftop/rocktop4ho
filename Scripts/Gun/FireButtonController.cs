﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class FireButtonController : MonoBehaviour ,IPointerUpHandler, IPointerDownHandler, IDragHandler
{

	bool isPress ;
	public bool b;

	private Image bgImg;
	private Image joystickImg;
	private Vector3 inputVector;

	private void Start()
	{
		bgImg = GetComponent<Image> ();
		joystickImg = transform.GetChild (0).GetComponent<Image> ();
	}

	public virtual void OnDrag(PointerEventData ped)
	{
		isPress = true;
		Vector2 pos;
		if (RectTransformUtility.ScreenPointToLocalPointInRectangle (bgImg.rectTransform, ped.position, ped.pressEventCamera, out pos)) {
			pos.x = (pos.x / bgImg.rectTransform.sizeDelta.x);
			pos.y = (pos.y / bgImg.rectTransform.sizeDelta.y);

			inputVector = new Vector3 (pos.x*2+1 , 0, pos.y*2-1 );
			inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

			joystickImg.rectTransform.anchoredPosition = new Vector3 (inputVector.x * (bgImg.rectTransform.sizeDelta.x / 2), inputVector.z * (bgImg.rectTransform.sizeDelta.y / 2));

						Debug.Log (inputVector);
		}

	}
	public virtual void OnPointerDown(PointerEventData ped)
	{
		OnDrag (ped);

		Debug.Log ("1");
	}
	public virtual void OnPointerUp(PointerEventData ped)
	{
		isPress = false;
//		inputVector = Vector3.zero;
		joystickImg.rectTransform.anchoredPosition = Vector3.zero;
		Debug.Log ("2");
	}


	public bool Firetrigger ()
	{
		
		if (isPress) {
			b = true;
		} 
		else 
		{
			b = false;
		}
		return b;
	}
	public float Horizontal()
	{
		if (inputVector.x != 0)
			return inputVector.x;
		else
			return Input.GetAxis ("Horizontal");
	}


	public float Vertical()
	{
		if (inputVector.z != 0)
			return inputVector.z;
		else
			return Input.GetAxis ("Vertical");
	}
}
