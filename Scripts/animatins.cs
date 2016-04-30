using UnityEngine;
using System.Collections;

public class animatins : MonoBehaviour {

	Animator anim;
	float contIsJumping;
	bool isJumping;
	bool isWalking;
	bool isRunning;
	bool isLifting;

	ThirdPersonControllerNET scriptSpeed;

	// Use this for initialization
	void Start ()
	{
		scriptSpeed = gameObject.GetComponentInParent<ThirdPersonControllerNET> ();
		isLifting = false;
		isWalking = false;
		isJumping = false;
		isRunning = false;
		contIsJumping = 2f;
		anim = gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (SixenseInput.Controllers[1].JoystickX > 0f || SixenseInput.Controllers[0].JoystickY > 0f || SixenseInput.Controllers[1].JoystickX < 0f || SixenseInput.Controllers[0].JoystickY < 0f)
		{
			isWalking = true;
			if (SixenseInput.Controllers[1].JoystickY > 0f)
			{
				isRunning = true;
			}
			else
			{
				isRunning = false;
			}
		}
		else
		{
			isWalking = false;
		}
		if(SixenseInput.Controllers[0].GetButtonDown(SixenseButtons.BUMPER))
		{
			isJumping = true;
		}
		if(!isJumping && !isWalking)
		{
			anim.Play ("Iddle");
		}
		else if(isJumping)
		{
			JumpPlayer ();
		}
		else if(isRunning)
		{
			RunPlayer ();
		}
		else if(isWalking)
		{
			WalkPlayer ();
		}
	}

	void JumpPlayer()
	{
		isWalking = false;
		anim.Play ("Jump");
		contIsJumping = contIsJumping - Time.deltaTime;
		if(contIsJumping <= 0)
		{
			isJumping = false;
			contIsJumping = 2f;
		}
	}

	void WalkPlayer()
	{
		isJumping = false;
		anim.Play ("Walk");
		scriptSpeed.speed = 0.3f;
	}

	void RunPlayer()
	{
		isJumping = false;
		isWalking = false;
		anim.Play ("Run");
		scriptSpeed.speed = 0.7f;
	}
}