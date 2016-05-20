using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

    private Transform thisTransform = null;
    private CharacterController chrController = null;

    public float moveSpeed = 10.0f;
    public float rotationSpeed = 90.0f;

    public float jumpForce = 10.0f;
    public float groundedDist = 0.1f;
    public bool isGrounded = false;
    private Vector3 velocity = Vector3.zero;
    public LayerMask groundLayer;


    // Use this for initialization
    void Awake()
    {
        thisTransform = GetComponent<Transform>();
        chrController = GetComponent<CharacterController>();
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

        // Update rotation
        thisTransform.rotation *= Quaternion.Euler(0f, rotationSpeed * horizontal * Time.deltaTime, 0f);

        // Calculate Move dir
        velocity.z = vertical * moveSpeed;

        // Are we grounded?
        isGrounded = (DistanceToGround() < groundedDist) ? true : false;

        // Can jump?
        if (CrossPlatformInputManager.GetAxisRaw("Jump") != 0 && isGrounded)
        {
            velocity.y = jumpForce;
        }
            
        // Apply gravity
        velocity.y += Physics.gravity.y * Time.deltaTime;

        // Update motion
        chrController.Move(thisTransform.TransformDirection(velocity) * Time.deltaTime);

    }

    float DistanceToGround()
    {
        RaycastHit hit;
        float distanceToGround = 0.0f;
        if (Physics.Raycast(thisTransform.position, -Vector3.up, out hit, Mathf.Infinity, groundLayer))
        {
            distanceToGround = hit.distance;
        }

        Debug.Log("Distance to ground: " + distanceToGround);
        return distanceToGround;
    }
}
