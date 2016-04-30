using UnityEngine;
using System.Collections;

public class Datasend : MonoBehaviour {

	private float lastSynchronizationTime = 0f;
	private float syncDelay = 0f;
	private float syncTime = 0f;
	private Vector3 syncStartPosition = Vector3.zero;
	private Vector3 syncEndPosition = Vector3.zero;

	
	private void OnSerializeNetworkView(BitStream stream , NetworkMessageInfo info){
		Vector3 syncPosition = Vector3.zero;

		Quaternion rot = new Quaternion();


		if(stream.isWriting){
			syncPosition = transform.position;
			stream.Serialize(ref syncPosition);
			rot = gameObject.transform.rotation;
			stream.Serialize(ref rot);

		}else {
			stream.Serialize(ref syncPosition);

			syncTime = 0f;
			syncDelay = Time.time - lastSynchronizationTime;

			lastSynchronizationTime = Time.time;

			syncStartPosition = transform.position;
			syncEndPosition = syncPosition;

			stream.Serialize(ref rot);
			transform.rotation = rot;

		}
	}
	public void SyncedMovement(){
		syncTime += Time.deltaTime;
		transform.position = Vector3.Lerp(syncStartPosition, syncEndPosition, syncTime/syncDelay);
	}

}
