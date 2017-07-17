using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public Vector3 launchVelocity;
    public bool inPlay = false;

    private Rigidbody rigidBody;
	private AudioSource audioSource;
    private Vector3 startPosition;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody>();
		audioSource = GetComponent<AudioSource>();
        startPosition = transform.position;

        rigidBody.useGravity = false;
	}

	public void Launch (Vector3 velocity)
	{
        rigidBody.velocity = velocity;
        rigidBody.useGravity = true;

        audioSource.Play();
        inPlay = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Reset() {
        transform.position = startPosition;
        inPlay = false;
        rigidBody.velocity = Vector3.zero;
        rigidBody.angularVelocity = Vector3.zero;
        rigidBody.rotation = Quaternion.identity;
        rigidBody.useGravity = false;
    }
}
