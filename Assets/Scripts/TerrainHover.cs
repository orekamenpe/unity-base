using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class TerrainHover : MonoBehaviour {

	private Transform myTransform = null;

	public float MaxSpeed = 10.0f;

	public float DistanceFromGround = 2f;
	private Vector3 DestUp = Vector3.zero;

	public float AngleSpeed = 5.0f;

	// Use this for initialization
	void Awake () 
	{
		myTransform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		float Horz = CrossPlatformInputManager.GetAxis ("Horizontal");
		float Vert = CrossPlatformInputManager.GetAxis ("Vertical");

		Vector3 NewPos = myTransform.position;

		NewPos += myTransform.forward * Vert * Time.deltaTime * MaxSpeed;
		NewPos += myTransform.right * Horz * Time.deltaTime * MaxSpeed;

		RaycastHit hit;

		if (Physics.Raycast (myTransform.position, Vector3.down, out hit)) 
		{
			NewPos.y = (hit.point + DistanceFromGround * Vector3.up).y;
			DestUp = hit.normal;
		}

		myTransform.position = NewPos;

		myTransform.up = Vector3.Slerp (myTransform.up, DestUp, AngleSpeed * Time.deltaTime);
	}
}
