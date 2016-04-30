using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TakeWater : MonoBehaviour {

	public GameObject sliderWater;

	// Use this for initialization
	void Start ()
	{
		sliderWater = GameObject.Find ("SliderAgua");
	}
	
	// Update is called once per frame
	void Update ()
	{
		sliderWater.GetComponent<Slider> ().value = sliderWater.GetComponent<Slider> ().value - 0.0001f;
	}
}
