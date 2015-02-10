using UnityEngine;
using System.Collections;

public class BallDropDetection : MonoBehaviour {
	public TerrainCollider terrain;
	public Camera holeCam;
	public GameObject ball;
	public GameObject pole;
	private bool ballDropped = false;

	

	// Use this for initialization
	void Start () {
		holeCam.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (ballDropped) {
		}
	}

	void OnTriggerEnter(Collider other) {
		ballDropped = true;
		terrain.collider.enabled = false;
		holeCam.enabled = true;
		ball.rigidbody.velocity = Vector3.zero;
		ball.transform.LookAt(pole.transform);
		ball.rigidbody.AddRelativeForce(Vector3.forward, ForceMode.Force);
		ball.rigidbody.AddForce(0,-10f,0);

	}

}
