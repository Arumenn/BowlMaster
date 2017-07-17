using UnityEngine;
using System.Collections;

public class Pin : MonoBehaviour {

    public float distanceToRaise = 40f;

    private float standingThreshold = 2f;
    private Rigidbody rigidBody;

    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    public bool IsStanding() {
        Vector3 rotationInEuler = transform.rotation.eulerAngles;
        float tiltInX = Mathf.Abs(270 - rotationInEuler.x);
        float tiltInZ = Mathf.Abs(rotationInEuler.z);

        return (tiltInX < standingThreshold && tiltInZ < standingThreshold);
    }

    public void RaiseIfStanding() {
        if (IsStanding()) {
            rigidBody.useGravity = false;
            transform.Translate(new Vector3(0, distanceToRaise, 0), Space.World);
            transform.rotation = Quaternion.Euler(270f, 0, 0);
        }
    }

    public void Lower() {
        transform.Translate(new Vector3(0, -distanceToRaise, 0), Space.World);
        rigidBody.useGravity = true;
    }
}
