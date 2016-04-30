using UnityEngine;
using System.Collections;

public class noParents : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		gameObject.transform.parent = null;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
