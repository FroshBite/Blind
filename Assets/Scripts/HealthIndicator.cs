using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthIndicator : MonoBehaviour {

	public GameObject playerObject;
	PlayerStats player;

	Text txt;

	// Use this for initialization
	void Start () {
		player = playerObject.GetComponent<PlayerStats>();
		txt = gameObject.GetComponent<Text>();

	
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerStats.currentHP < 100) {
				txt.text = "I'm in trouble";
		}
	}
}
