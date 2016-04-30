using UnityEngine;
using System.Collections;

public class CarInOut : MonoBehaviour {

	RCCCarControllerV2 CarControl;
	GameObject ObjectcarControl;
	Camera carCamera;
	GameObject ObjectcarCamera;
	int contCarCamera;
	bool flagTriggerCar;

	ThirdPersonControllerNET scriptMove;
	GameObject pointSitting;
	public GameObject meshPlayer;

	public bool flagCarRazor;
	public bool flagTrigger;
	float posRazorz;
	// Use this for initialization
	void Start ()
	{
		flagTrigger = false;
		posRazorz = 0f;
		flagCarRazor = false;
		pointSitting = GameObject.Find ("pointSitting");
		scriptMove = gameObject.GetComponent<ThirdPersonControllerNET> ();
		flagTriggerCar = false;
		contCarCamera = 0;
		ObjectcarCamera = GameObject.FindGameObjectWithTag ("RCCMainCamera");
		carCamera = ObjectcarCamera.GetComponent<Camera> ();
		ObjectcarControl = GameObject.Find ("Buggy");
		CarControl = ObjectcarControl.GetComponent<RCCCarControllerV2> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (SixenseInput.Controllers[0].GetButtonDown(SixenseButtons.TRIGGER))
		{
			flagTrigger = true;
			posRazorz = SixenseInput.Controllers [0].Position.z;
			Debug.Log (posRazorz);
		}
//		if (SixenseInput.Controllers[0].GetButton(SixenseButtons.TRIGGER))
//		{
//			Debug.Log (posRazorz);
//			Debug.Log (SixenseInput.Controllers [0].Position.z);
			if (SixenseInput.Controllers [0].Position.z > (posRazorz + 10f) && SixenseInput.Controllers[0].GetButtonDown(SixenseButtons.BUMPER))
			{
				flagCarRazor = true;
			}
//		}
//		if(Input.GetKeyDown(KeyCode.E) && flagTriggerCar)
		if(SixenseInput.Controllers [0].Position.z > (posRazorz + 10f) && SixenseInput.Controllers[0].GetButtonDown(SixenseButtons.BUMPER) && flagTriggerCar)
		{
			contCarCamera++;
			if(contCarCamera%2 != 0)
			{
				scriptMove.enabled = false;
				carCamera.enabled = true;
				CarControl.enabled = true;
			}
			else
			{
				scriptMove.enabled = true;
				carCamera.enabled = false;
				CarControl.enabled = false;
				meshPlayer.SetActive (true);
				Vector3 plus = new Vector3 (-2f, 0f, 0f);
				transform.position = pointSitting.transform.position + plus;
			}
		}
		if(contCarCamera%2 != 0)
		{
			meshPlayer.SetActive (false);
			transform.position = pointSitting.transform.position;
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if(other.tag == "Car")
		{
			flagTriggerCar = true;
		}
	}

	void OnTriggerExit (Collider other)
	{
		if(other.tag == "Car")
		{
			flagTriggerCar = false;
		}
	}
}
