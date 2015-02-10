using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {
	public Transform target;
	public float smooth = 5.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 modifiedTarget = new Vector3(target.position.x, target.position.y, target.position.z);
		transform.position = Vector3.Lerp(transform.position, modifiedTarget, Time.deltaTime * smooth);
	}
}
