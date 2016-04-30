using UnityEngine;
using System.Collections;

public class resetPosition : MonoBehaviour {

	Vector3 amountReset;

	// Use this for initialization
	void Start ()
	{
		amountReset = new Vector3 (0f, 6f, 0f);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(SixenseInput.Controllers[1].GetButtonDown(SixenseButtons.START))
		{
			transform.position = transform.position + amountReset;
		}
	}
}
