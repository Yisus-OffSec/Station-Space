using UnityEngine;
using System.Collections;

public class ChangeVR : MonoBehaviour {

	public GameObject cameraVR;
	int contVRCamera;

	// Use this for initialization
	void Start ()
	{
		contVRCamera = 0;

		cameraVR.SetActive (false);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(SixenseInput.Controllers[0].GetButtonDown(SixenseButtons.ONE))
		{
			contVRCamera++;
			if(contVRCamera % 2 != 0)
			{
				cameraVR.SetActive (true);
			}
			else
			{
				cameraVR.SetActive (false);
			}

		}
	}
}
