using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeIn : MonoBehaviour {

	public Image fade;

	// Use this for initialization
	void Start ()
	{
		fade.gameObject.SetActive (true);
	}
	
	// Update is called once per frame
	void Update ()
	{
		fade.CrossFadeAlpha (0f, 5f, false);
	}
}
