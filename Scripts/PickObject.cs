using UnityEngine;
using System.Collections;

public class PickObject : MonoBehaviour {

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
		if (flagPickObject && SixenseInput.Controllers[0].GetButton(SixenseButtons.TRIGGER) && SixenseInput.Controllers[1].GetButton(SixenseButtons.TRIGGER))
		{
			contPick++;
			if(contPick == 1)
			{
				Vector3 amountPick = new Vector3 (0.35f, 1f, 0.35f);
				GameObject.Find(nameObject).gameObject.transform.parent = gameObject.transform;
				GameObject.Find(nameObject).gameObject.transform.position = GameObject.Find(nameObject).gameObject.transform.position + amountPick;
				GameObject.Find (nameObject).GetComponent<Rigidbody> ().useGravity = false;
				GameObject.Find (nameObject).GetComponent<Rigidbody> ().isKinematic = true;
			}
		}
		if(flagPickObject && SixenseInput.Controllers[0].GetButtonUp(SixenseButtons.TRIGGER) && SixenseInput.Controllers[1].GetButtonUp(SixenseButtons.TRIGGER))
		{
			GameObject.Find(nameObject).gameObject.transform.parent = GameObject.Find("Oxigen").transform;
			GameObject.Find (nameObject).GetComponent<Rigidbody> ().useGravity = true;
			GameObject.Find (nameObject).GetComponent<Rigidbody> ().isKinematic = false;
			flagPickObject = false;
			contPick = 0;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Oxigen")
		{
			flagPickObject = true;
			nameObject = other.name;
		}
	}
}
