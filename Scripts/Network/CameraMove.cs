using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

	public Vector3 PosicionDeDesface;


	void Update () {
		if(Variables.JugadorTransform != null){

			transform.LookAt(Variables.JugadorTransform.position);
			transform.parent = Variables.JugadorTransform.transform;

			transform.localPosition = PosicionDeDesface;

		}
	}
	void OnDisconnectedFromServer(NetworkDisconnection info) {
		Variables.JugadorTransform = null;
		transform.parent = null;

		foreach(MonoBehaviour c in GetComponents<MonoBehaviour>())
		{
			c.enabled = true;
		}
		gameObject.GetComponent<Camera>().enabled = true;
		gameObject.GetComponent<GUILayer>().enabled= true;
		gameObject.GetComponent<AudioListener>().enabled= true;
		gameObject.GetComponent<FlareLayer>().enabled= true;

	}
}
