using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MovementPlayer : MonoBehaviour {

	// public GameObject player1;

	Rigidbody player;
	Rigidbody player2r;
	Animator anim;

	public float speed=6f;
	Vector3 movement;
	Vector3 movement1;


	// Use this for initialization
	void Start ()
	{
		player = this.gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");

		Move (h,v);
	}

	void Move(float h, float v) 
	{
		// envia el movimiento atravez de las entradas por teclado.
		movement.Set (h, 0f, v);

		//normalizamos el movimiento y lo acemos proporcional a la velocidad por segundo
		movement = movement.normalized * speed * Time.deltaTime;

		// movimiento al jugador por el rigidbody posicion actual + el moviento.
		player.MovePosition(transform.position+movement);
	}
}
