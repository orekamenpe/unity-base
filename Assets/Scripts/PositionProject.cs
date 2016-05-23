using UnityEngine;
using System.Collections;

// Projection of a vector delimited between 2 points (LineStart & LineEnd)

public class PositionProject : MonoBehaviour 
{
	public Transform Target = null;
	private Transform myTransform = null;

	public Transform LineStart = null;
	public Transform LineEnd = null;

	// Use this for initialization
	void Awake () 
	{
		myTransform = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 Normal = (LineEnd.position - LineStart.position).normalized;

		// Projected position
		Vector3 Pos = LineStart.position + Vector3.Project (Target.position - LineStart.position, Normal);

		// Clamp between the LineStart and LineEnd
		Pos.x = Mathf.Clamp (Pos.x, Mathf.Min (LineStart.position.x, LineEnd.position.x), Mathf.Max (LineStart.position.x, LineEnd.position.x));
		Pos.y = Mathf.Clamp (Pos.y, Mathf.Min (LineStart.position.y, LineEnd.position.y), Mathf.Max (LineStart.position.y, LineEnd.position.y));
		Pos.z = Mathf.Clamp (Pos.z, Mathf.Min (LineStart.position.z, LineEnd.position.z), Mathf.Max (LineStart.position.z, LineEnd.position.z));

		myTransform.position = Pos;
	}
}
