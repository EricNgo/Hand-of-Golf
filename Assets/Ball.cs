using UnityEngine;
using System.Collections;


public class Ball : MonoBehaviour {
	public GameObject follow;
	private MonoBehaviour followScript;
	public Club club;
//	public HandController hand;
//	public GameObject hole;
	public int swings = 0;
	private float previousSwingTime;

	// Use this for initialization
	void Start () {
		previousSwingTime = Time.time;
		followScript = follow.GetComponent("SmoothFollow") as MonoBehaviour;
		followScript.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (followScript.enabled && swings >= 1) {
			if(GetComponent<Rigidbody>().velocity.magnitude <= .02) {
				Debug.Log("Ball Stopped");
				GetComponent<Rigidbody>().velocity = Vector3.zero;
				//stop following the ball
				followScript.enabled = false;
				//set position of club
				club.setHandPosition();
			}
		}
	}

	private bool IsHand(Collider other)
	{
		if (other.transform.parent && other.transform.parent.parent && other.transform.parent.parent.GetComponent<HandModel>())
			return true;
		else
			return false;
	}
	
	void OnTriggerEnter(Collider other) 
	{
		if (IsHand(other))
		{
			if (previousSwingTime <= (Time.time - 1f)) {
				//previous swing was a second ago
//				follow.enabled = true;
				followScript.enabled = true;
				Debug.Log("Swing!");
				swings++;
				previousSwingTime = Time.time;
			}
		}  
	}

}
