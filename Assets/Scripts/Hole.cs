using UnityEngine;
using System.Collections;

public class Hole : MonoBehaviour {

	Vector3 currentPos = new Vector3(0, 0, 0);
	Quaternion currentRot = new Quaternion();
	Quaternion endRot = new Quaternion();
	Vector3 endPos = new Vector3(0, 0, 10);
	float startingScale = .001f;
	public Camera playerCam;
	public Transform hole;
	public GameObject player;
	public bool reachedPlayer = false;

	// Use this for initialization
	void Start () {
		currentPos = hole.position;
		currentRot = hole.rotation;
		endPos = player.transform.position;
		endRot = player.transform.rotation;
		playerCam.enabled = true;
	}

	// Update is called once per frame
	void Update () {

		if (!reachedPlayer) {
			// calculate current time within our lerping time range
			currentPos = Vector3.Lerp(currentPos, endPos, Time.deltaTime * startingScale);
//			float cTime = Time.time * 0.2f;
			startingScale += .001f;
			if (startingScale >= 1f) {
				startingScale = 1;
			}

			currentRot = Quaternion.Lerp (currentRot, endRot, Time.deltaTime);
			// add a value to Y, using Sine to give a curved trajectory in the Y direction
			//currentPos.y += trajectoryHeight * Mathf.Sin(Mathf.Clamp01(cTime) * Mathf.PI);
			
			// finally assign the computed position to our gameObject:

			playerCam.transform.position = currentPos;
			playerCam.transform.rotation = currentRot;
	//		mapCam.transform.rotation = currentRot;
			var distance = Vector3.Distance(currentPos, endPos);
			
			if(distance < 0.1f) {
				Debug.Log("Finished Camera Movement");
				reachedPlayer = true;
//				FollowTarget fs = (FollowTarget) player.GetComponent("FollowTarget");
//				fs.enabled = true;

			}

		}
		RaycastHit hit;

		if (Physics.Raycast(playerCam.transform.position, -Vector3.up, out hit)) {
		//		currentPos.y = hit.collider.transform.position.y + endPos.y;
		}
		else if(Physics.Raycast(playerCam.transform.position, Vector3.down, out hit)){
//			float wantElevation = Mathf.SmoothDamp(playerCam.transform.position.y, hit.point.y+endPos.y, 0, 1f);
		//	currentPos.y= hit.collider.transform.position.y + endPos.y;
		}



	}
	
}
