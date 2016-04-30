using UnityEngine;
using System.Collections;

public class onOff : MonoBehaviour {

	bool flagOnOffa;
	public GenerateWater scripta;

	// Use this for initialization
	void Start ()
	{
		flagOnOffa = true;
		scripta = gameObject.GetComponent<GenerateWater> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(SixenseInput.Controllers[1].GetButtonDown(SixenseButtons.ONE))
		{
			flagOnOffa = !flagOnOffa;
		}
		if(flagOnOffa)
		{
			scripta.enabled = true;
		}
		else
		{
			scripta.enabled = false;
		}
	}
}
