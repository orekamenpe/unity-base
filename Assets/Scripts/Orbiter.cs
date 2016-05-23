using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

// Orbit around a target (pivot)

public class Orbiter : MonoBehaviour {

    public Transform pivot = null;
    private Transform thisTransform = null;
    private Quaternion destRot = Quaternion.identity;

    // Distance to maintain from pivot
    public float pivotDistance = 5f;
    public float rotSpeed = 10f;
    private float rotX = 0f;
    private float rotY = 0f;

	// Use this for initialization
	void Awake () {
        thisTransform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        float Horz = CrossPlatformInputManager.GetAxis("Horizontal");
        float Vert = CrossPlatformInputManager.GetAxis("Vertical");

        rotX += Vert * Time.deltaTime * rotSpeed;
        rotY -= Horz * Time.deltaTime * rotSpeed;

		// Apply Y rotation on X rotation YRot * XRot = destRot
        Quaternion YRot = Quaternion.Euler(0f, rotY, 0f);
        destRot = YRot * Quaternion.Euler(rotX, 0f, 0f);

        thisTransform.rotation = destRot;

        // Adjust position
        thisTransform.position = pivot.position + thisTransform.rotation * Vector3.forward * -pivotDistance;
    }
}
