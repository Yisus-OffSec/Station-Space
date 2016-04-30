using UnityEngine;
using System.Collections;

public class PickPlant : MonoBehaviour {

	public bool flagPickObject;
	public string nameObject;
	public int contPick;

	// Use this for initialization
	void Start ()
	{
		contPick = 0;
		nameObject = "";
		flagPickObject = false;
	}

	// Update is called once per frame
	void Update ()
	{
		if (flagPickObject && SixenseInput.Controllers[0].GetButton(SixenseButtons.TRIGGER))
		{
			contPick++;
			if(contPick == 1)
			{
				Vector3 amountPick = new Vector3 (0f, 0f, 0f);
				GameObject.Find(nameObject).gameObject.transform.parent = gameObject.transform;
				GameObject.Find(nameObject).gameObject.transform.position = GameObject.Find(nameObject).gameObject.transform.position + amountPick;
				GameObject.Find (nameObject).GetComponent<Rigidbody> ().useGravity = false;
				GameObject.Find (nameObject).GetComponent<Rigidbody> ().isKinematic = true;
			}
		}
		if(flagPickObject && SixenseInput.Controllers[0].GetButtonUp(SixenseButtons.TRIGGER))
		{
			GameObject.Find (nameObject).gameObject.transform.parent = null;
			GameObject.Find (nameObject).GetComponent<Rigidbody> ().useGravity = true;
			GameObject.Find (nameObject).GetComponent<Rigidbody> ().isKinematic = false;
			flagPickObject = false;
			contPick = 0;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Seed" || other.tag == "Soil" || other.tag == "Maicena" || other.tag == "Agua" || other.tag == "Glicerina" || other.tag == "Vinagre")
		{
			flagPickObject = true;
			nameObject = other.name;
		}
	}
}
