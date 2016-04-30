using UnityEngine;
using System.Collections;

public class PlaceInfrastructure5 : MonoBehaviour {

	public GameObject infra6;
	GameObject newInfra1;
	Vector3 amountInfra1;
	int contInfra1;
	public bool flagInfra6;
	public PlaceInfrastructure4 scriptinfra5;

	// Use this for initialization
	void Start ()
	{
		scriptinfra5 = gameObject.GetComponent<PlaceInfrastructure4> ();
		flagInfra6 = false;
		contInfra1 = 0;
		amountInfra1 = new Vector3 (-0.5f, 3.5f, 10f);
	}

	// Update is called once per frame
	void Update ()
	{
		if(!flagInfra6 && scriptinfra5.flagInfra5)
		{
			if(SixenseInput.Controllers[0].GetButton(SixenseButtons.BUMPER) && SixenseInput.Controllers[1].GetButton(SixenseButtons.BUMPER))
			{
				contInfra1++;
				if(contInfra1 == 1)
				{
					newInfra1 = (GameObject)Instantiate (infra6, gameObject.transform.position + amountInfra1, Quaternion.identity);
					newInfra1.gameObject.transform.Rotate (-90f, 90f, 0f);
					newInfra1.gameObject.transform.parent = gameObject.transform;
				}
				if(newInfra1)
				{
					//		newInfra1.gameObject.transform.position = gameObject.transform.position + amountInfra1;
					newInfra1.GetComponent<Rigidbody> ().useGravity = false;
					newInfra1.GetComponent<Rigidbody> ().isKinematic = true;
				}
			}
			if(SixenseInput.Controllers[0].GetButtonUp(SixenseButtons.BUMPER) && SixenseInput.Controllers[1].GetButtonUp(SixenseButtons.BUMPER))
			{
				newInfra1.gameObject.transform.parent = null;
				newInfra1.GetComponent<Rigidbody> ().useGravity = true;
				newInfra1.GetComponent<Rigidbody> ().isKinematic = false;
				flagInfra6 = true;
			}
		}
	}
}
