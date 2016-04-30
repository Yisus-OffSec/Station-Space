using UnityEngine;
using System.Collections;

public class onOff1 : MonoBehaviour {

	bool flagOnOffo;
	public GenerateOxigen scripto;

	// Use this for initialization
	void Start ()
	{
		flagOnOffo = true;
		scripto = gameObject.GetComponent<GenerateOxigen> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(SixenseInput.Controllers[1].GetButtonDown(SixenseButtons.TWO))
		{
			flagOnOffo = !flagOnOffo;
		}
		if(flagOnOffo)
		{
			scripto.enabled = true;
		}
		else
		{
			scripto.enabled = false;
		}
	}
}
