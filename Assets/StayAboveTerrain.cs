using UnityEngine;
using System.Collections;

public class StayAboveTerrain : MonoBehaviour {
	private Transform mTransform;
	private RaycastHit hit;
	public float HeightFromGround = 3.7f;
	public bool moveToBall = false;
	public Transform ballTransform;
	private Vector3 ballOffset;
	public Transform holeTransform;
	public float speed = 1.0F;
	private float startTime;
	private float journeyLength;
	public float smooth = 5.0F;

	// Use this for initialization
	void Start () {
		ballOffset = new Vector3(ballTransform.position.x-3, ballTransform.position.y, ballTransform.position.z+7);
		mTransform = transform;
		startTime = Time.time;
		journeyLength = Vector3.Distance(holeTransform.position, ballOffset);
		transform.position = holeTransform.position;
		camera.transform.rotation = holeTransform.rotation;
	}
	
	// Update is called once per frame

	void Update () {
		camera.transform.LookAt(holeTransform);
		if (!moveToBall) {
			float distCovered = (Time.time - startTime) * speed;
			float fracJourney = distCovered / journeyLength;
			if (fracJourney >= 1) {
				Debug.Log("Reached Ball");
				moveToBall = true;

			}
					transform.position = Vector3.Lerp(holeTransform.position, ballOffset, fracJourney);
		}
		//check distance above
		if(Physics.Raycast(transform.position, -Vector3.up, out hit)) {
			if (hit.transform.tag == ("ground")){
				transform.position = new Vector3(hit.point.x, hit.point.y + HeightFromGround , hit.point.z);
			}
		}

		//check distance below
		if(Physics.Raycast(transform.position, Vector3.up, out hit)) {
			if (hit.transform.tag == ("ground")){
				
				transform.position = new Vector3(hit.point.x, hit.point.y + HeightFromGround , hit.point.z);
			}
		}



	
	
	}




}
