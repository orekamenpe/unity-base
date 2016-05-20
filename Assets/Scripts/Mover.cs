using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
    public float MaxSpeed = 1f;
    private Rigidbody rgbody = null;

	// Use this for initialization
	void Awake ()
    {
        rgbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        rgbody.position += rgbody.transform.forward * MaxSpeed * Time.deltaTime;
	}
}
