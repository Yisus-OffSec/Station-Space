using UnityEngine;
using System.Collections;

public class HideShow : MonoBehaviour {

	public float time;
	public GameObject objHide;
	public GameObject objShow;

	// Use this for initialization
	void Start ()
	{
		objHide.SetActive (true);
		objShow.SetActive (false);
		time = 30f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		time = time - Time.deltaTime;
		if(time <= 0)
		{
			objHide.SetActive (false);
			objShow.SetActive (true);
		}
	}
}
