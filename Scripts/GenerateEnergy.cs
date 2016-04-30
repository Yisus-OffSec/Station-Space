using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GenerateEnergy : MonoBehaviour {

	public GameObject sliderEnergy;

	// Use this for initialization
	void Start ()
	{
		sliderEnergy = GameObject.Find ("SliderEnergia");
	}

	// Update is called once per frame
	void Update ()
	{
		sliderEnergy.GetComponent<Slider> ().value = sliderEnergy.GetComponent<Slider> ().value + 0.0001f;
	}
}
