using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

	public GameObject player;


	void OnNetworkLoadedLevel () {
		GameObject p =  Network.Instantiate (player,transform.position,Quaternion.identity,0) as GameObject;
	}
	void OnPlayerDisconnected (NetworkPlayer player){
		Network.RemoveRPCs(player, 0);
		Network.DestroyPlayerObjects(player);
	}
}

