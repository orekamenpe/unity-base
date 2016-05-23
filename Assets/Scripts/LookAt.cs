using UnityEngine;
using System.Collections;

// Make the gameObject look at a target
// 2 methods:
// - RotateTowardsWithDamp (with smooth rotation)
// - RotateTowards (more mechanic)


public class LookAt : MonoBehaviour {

    private Transform thisTransform = null;
    public float RotSpeed = 90f;

    public Transform target = null;

    public float Damping = 55.0f;
	public bool isDamping = false;

    // Use this for initialization
    void Awake()
    {
        thisTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
		if (isDamping) 
		{
			RotateTowardsWithDamp ();
		} 
		else 
		{
			RotteTowards ();
		}
    }

    void RotteTowards()
    {
        Quaternion DestRot = Quaternion.LookRotation(target.position - thisTransform.position, Vector3.up);

        thisTransform.rotation = Quaternion.RotateTowards(thisTransform.rotation, DestRot, RotSpeed * Time.deltaTime);
    }

    void RotateTowardsWithDamp()
    {
        // Get Look to rotation
        Quaternion DestRot = Quaternion.LookRotation(target.position - thisTransform.position, Vector3.up);

        // Calc smooth rotate
        thisTransform.rotation = Quaternion.Slerp(thisTransform.rotation, DestRot, 1f - (Time.deltaTime * Damping));

    }
}
