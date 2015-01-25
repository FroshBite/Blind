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
		if (PlayerStats.currentHP > 98) {
				txt.text = "I'm in trouble";
		} else if (PlayerStats.currentHP > 90) {
			txt.text = "2";
		} else if (PlayerStats.currentHP > 80) {
			txt.text = "1";
		} else if (PlayerStats.currentHP > 70) {
			txt.text = "3";
		} else if (PlayerStats.currentHP > 60) {
			txt.text = "4";
		} else if (PlayerStats.currentHP > 50) {
			txt.text = "5";
		} else if (PlayerStats.currentHP > 40) {
			txt.text = "6";
		} else if (PlayerStats.currentHP > 30) {
			txt.text = "7";
		} else if (PlayerStats.currentHP > 20) {
			txt.text = "8";
		} else if (PlayerStats.currentHP > 10) {
			txt.text = "9";
		} else {
			txt.text = "10";
		}
	}
}
