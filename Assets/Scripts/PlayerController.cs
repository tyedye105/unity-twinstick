using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	private Rigidbody myRigidbody;

	private Vector3 moveInput;
	private Vector3 moveVelocity;

	private Camera mainCamera;
	public GunController theGun;


	public bool useController;


	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody>();
		mainCamera = FindObjectOfType<Camera>();

	}
	
	// Update is called once per frame
	void Update () 
	{
		moveInput = new Vector3(Input.GetAxisRaw("Horizontal"),0, Input.GetAxisRaw("Vertical"));
		moveVelocity =moveInput * moveSpeed;

		// Rotate with Mouse

		if(!useController)
		{
			Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
			Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
			float rayLength;

			if(groundPlane.Raycast(cameraRay, out rayLength))
				{
					Vector3 pointToLook = cameraRay.GetPoint(rayLength);
					Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);
					transform.LookAt(new Vector3(pointToLook.x,transform.position.y, pointToLook.z));
				}
			if(Input.GetMouseButtonDown(0))
				{
					theGun.isFiring = true;
				}
			if(Input.GetMouseButtonUp(0))
				{
				theGun.isFiring = false;
				}
		}

		// Rotate with Controller
		if(useController)
		{
			Vector3 playerDirection = Vector3.right * Input.GetAxisRaw("RHorizontal") + Vector3.forward * -Input.GetAxisRaw("RVertical");
				if(playerDirection.sqrMagnitude > 0.0f)
					{
						transform.rotation = Quaternion.LookRotation(playerDirection, Vector3.up);
						Debug.DrawLine(playerDirection, Vector3.up, Color.red);
						Debug.Log(Input.GetAxisRaw("RHorizontal"));
						Debug.Log(Input.GetAxisRaw("RVertical"));
					}
		}
	}

	void FixedUpdate () {
		myRigidbody.velocity = moveVelocity;
	}
}
