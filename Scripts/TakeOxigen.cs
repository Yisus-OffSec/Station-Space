using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TakeOxigen : MonoBehaviour {

	public GameObject sliderOxigen;

	// Use this for initialization
	void Start ()
	{
		sliderOxigen = GameObject.Find ("SliderOxigeno");
	}
	
	// Update is called once per frame
	void Update ()
	{
		sliderOxigen.GetComponent<Slider> ().value = sliderOxigen.GetComponent<Slider> ().value - 0.0001f;
	}
}
