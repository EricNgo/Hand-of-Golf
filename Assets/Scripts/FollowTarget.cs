using UnityEngine;
using System.Collections;

public class FollowTarget : MonoBehaviour
{
	public Transform target;
	public Vector3 offset = new Vector3(0f, 7.5f, 0f);
	public float smooth = 5.0f;

	
	void Update ()
	{
		Vector3 smoothTarget = target.position + offset;
//		transform.position = target.position + offset;
		transform.position = Vector3.Lerp (transform.position, smoothTarget, Time.deltaTime * smooth);

	}
}
