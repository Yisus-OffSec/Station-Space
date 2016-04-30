using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TriggerRocks : MonoBehaviour {

	public GameObject sliderMinerals;

	// Use this for initialization
	void Start ()
	{
		sliderMinerals = GameObject.Find ("SliderMineral");
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Rock")
		{
			Destroy (other.gameObject);
			sliderMinerals.GetComponent<Slider> ().value = sliderMinerals.GetComponent<Slider> ().value + 0.05f;
		}
	}
}
