using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class Move : MonoBehaviour {

	private NetworkView Nw;

	public float speed = 6.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
	private Vector3 moveDirection = Vector3.zero;
	public float sense;

	void Awake(){
		Nw = GetComponent<NetworkView> ();
		if(Nw.isMine){
			Variables.JugadorTransform = transform;
		}
	}
	
	void Update() {
		if (Nw.isMine && Chat.t == "") {
			CharacterController controller = GetComponent<CharacterController> ();
			if (controller.isGrounded) {
				moveDirection = new Vector3 (0, 0, Input.GetAxis ("Vertical"));
				moveDirection = transform.TransformDirection (moveDirection);
				moveDirection *= speed;
				if (Input.GetButton ("Jump"))
					moveDirection.y = jumpSpeed;
			
			}
			moveDirection.y -= gravity * Time.deltaTime;
			controller.Move (moveDirection * Time.deltaTime);
			transform.Rotate(0,Input.GetAxis("Mouse X")*sense,0);

		}else{
			gameObject.GetComponent<Datasend>().SyncedMovement();

		}
	}

	
	
}
