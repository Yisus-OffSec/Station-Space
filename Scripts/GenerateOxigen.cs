using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GenerateOxigen : MonoBehaviour {

	public GameObject sliderOxigen;
	public GameObject sliderEnergyo;

	// Use this for initialization
	void Start ()
	{
		sliderOxigen = GameObject.Find ("SliderOxigeno");
		sliderEnergyo = GameObject.Find ("SliderEnergia");
	}

	// Update is called once per frame
	void Update ()
	{
		sliderOxigen.GetComponent<Slider> ().value = sliderOxigen.GetComponent<Slider> ().value + 0.0002f;
		sliderEnergyo.GetComponent<Slider> ().value = sliderEnergyo.GetComponent<Slider> ().value - 0.0003f;
	}
}
