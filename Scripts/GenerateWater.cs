using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GenerateWater : MonoBehaviour {

	public GameObject sliderWater;
	public GameObject sliderEnergyw;

	// Use this for initialization
	void Start ()
	{
		sliderWater = GameObject.Find ("SliderAgua");
		sliderEnergyw = GameObject.Find ("SliderEnergia");
	}
	
	// Update is called once per frame
	void Update ()
	{
		sliderWater.GetComponent<Slider> ().value = sliderWater.GetComponent<Slider> ().value + 0.0002f;
		sliderEnergyw.GetComponent<Slider> ().value = sliderEnergyw.GetComponent<Slider> ().value - 0.0003f;
	}
}
