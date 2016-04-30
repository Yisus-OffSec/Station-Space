using UnityEngine;
using System.Collections;

public class Drag : MonoBehaviour {

	public void OnDrag(){ 
		transform.position = Input.mousePosition; 
	}
}
