using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Chat : MonoBehaviour {

	public InputField Textfield;
	public Text chatb;
	public Toggle ChatToggle;
	public Scrollbar scroll;


	NetworkView nv;
	public static string t;

	void Update(){
		t = Textfield.text;
		if(Input.GetButtonDown("Enter"))
			send();

	}

	void Start(){
		chatb.text = "";
		nv = GetComponent<NetworkView> ();
	}
	private void OnConnectedToServer(){
		chatb.text = "Bienvido "+Variables.Username+" Te has conectado correctamente";
	}
	private void OnServerInitialized(){
		chatb.text = "Bienvido "+Variables.Username+" El servidor ha sido creado correctamente en "+Network.player.externalIP+":"+Network.player.externalPort;
	}


	public void send(){
		if (Textfield.text != "") {
			nv.RPC("recivir",RPCMode.AllBuffered,Textfield.text,Variables.Username);
		}
		Textfield.text = "";
	}


	[PunRPC]
	public void recivir(string text, string usuario){
		chatb.text += "\n-" + usuario + ": " + text;
		scroll.value -= 0.0003f;


	}


}
