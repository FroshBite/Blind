using UnityEngine;
using System.Collections;

public class HealthIndicator : MonoBehaviour {

	public GameObject playerObject;
	PlayerStats player;

	// Use this for initialization
	void Start () {
		player = playerObject.GetComponent<PlayerStats>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
