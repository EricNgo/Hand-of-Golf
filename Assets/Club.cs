using UnityEngine;
using System.Collections;

public class Club : MonoBehaviour {
	//public GameObject tee;
	public GameObject ball;
	public GameObject hole;
	public GameObject handCamera;
	public float handHeight = 0f;
	// Use this for initialization
	void Start () {
//		setHandPosition();
		//transform.rotation = Camera.main.transform.rotation;

	}

	public void setHandPosition() {


		//Ball Looks at the Hole
		ball.transform.LookAt(hole.transform);
		
		//The Hand Moves to the Ball
		transform.position = ball.transform.position;
		
		//The Hand looks at the Ball
		transform.LookAt(ball.transform);

		//Move the Hand Back
		transform.Translate(0,handHeight,0);
		transform.rotation = handCamera.transform.rotation;
/*		Quaternion cameraAngle = handCamera.transform.rotation;
		cameraAngle.x = 0;
		cameraAngle.y += 75; 
		cameraAngle.z = 0;
		transform.rotation = cameraAngle;
*/
	
	}
	// Update is called once per frame
	void Update () {
	
	}
}
