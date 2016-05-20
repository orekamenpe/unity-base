using UnityEngine;
using System.Collections;

public class RotateTo : MonoBehaviour {

    private Transform thisTransform = null;
    public float RotSpeed = 90f;

	// Use this for initialization
	void Awake ()
    {
        thisTransform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //thisTransform.rotation = Quaternion.Euler(0f, 90f, 0f);

        thisTransform.rotation *= Quaternion.AngleAxis(RotSpeed * Time.deltaTime, Vector3.up);
	}
}
