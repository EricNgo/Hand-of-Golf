using UnityEngine;
using System.Collections;

public class Hole : MonoBehaviour {
	public Follow follow;
	public TerrainCollider terrain;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "ball") {
			Debug.Log("Ball Hit Hole");
			follow.enabled = false;
			terrain.collider.enabled = false;
		}
	}

}
