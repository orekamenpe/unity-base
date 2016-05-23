using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

// PlayerController using Rigidbody

[RequireComponent (typeof (Rigidbody))]
public class PlayerController_wRigidbody : MonoBehaviour {

    public float moveSpeed = 5.0f;
    public float rotationSpeed = 5.0f;
    private Rigidbody rgbody;

    // Use this for initialization
    void Awake()
    {
        rgbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        InputMovement();
    }

    void InputMovement()
    {
        float horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
        float vertical = CrossPlatformInputManager.GetAxis("Vertical");

		// update position
        rgbody.MovePosition(rgbody.position + vertical * transform.forward * moveSpeed * Time.deltaTime);

		// update rotation
        Quaternion deltaRotation = Quaternion.Euler(new Vector3(0, horizontal * rotationSpeed, 0));
        rgbody.MoveRotation(rgbody.rotation * deltaRotation);
    }
}
