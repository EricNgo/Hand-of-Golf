using UnityEngine;
using System.Collections;

public class Club : MonoBehaviour {
	public GameObject tee;
	public GameObject ball;

	// Use this for initialization
	void Start () {
		transform.position = tee.transform.position;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
