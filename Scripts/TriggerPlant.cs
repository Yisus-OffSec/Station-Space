using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TriggerPlant : MonoBehaviour {

	public bool flagSeed;
	public bool flagSoil;
	public GameObject plantGrow;
	public GameObject SliderComida;
	int contFood;

	// Use this for initialization
	void Start ()
	{
		plantGrow.SetActive (false);
		contFood = 0;
		flagSeed = false;
		flagSoil = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(flagSeed)
		{
			if(flagSoil)
			{
				contFood++;
				if(contFood == 1)
				{
					SliderComida.gameObject.GetComponent<Slider> ().value = SliderComida.gameObject.GetComponent<Slider> ().value + 0.1f;
					plantGrow.SetActive (true);
				}
			}
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Seed")
		{
			flagSeed = true;
		}
		if(other.tag == "Soil")
		{
			flagSoil = true;
		}
	}
}
