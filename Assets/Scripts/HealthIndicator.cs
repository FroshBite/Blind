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
				txt.text = "I'm really feeling it!";
		} else if (PlayerStats.currentHP > 90) {
			txt.text = "Don't worry, I got this!";
		} else if (PlayerStats.currentHP > 80) {
			txt.text = "Just a scratch or two.";
		} else if (PlayerStats.currentHP > 70) {
			txt.text = "Maybe it's more of a gash.";
		} else if (PlayerStats.currentHP > 60) {
			txt.text = "Cripes, that's painful.";
		} else if (PlayerStats.currentHP > 50) {
			txt.text = "The glass is still half full!";
		} else if (PlayerStats.currentHP > 40) {
			txt.text = "Not feeling it so much anymore.";
		} else if (PlayerStats.currentHP > 30) {
			txt.text = "Ribs grow back, right?";
		} else if (PlayerStats.currentHP > 20) {
			txt.text = "WELP.";
		} else if (PlayerStats.currentHP > 10) {
			txt.text = "I have no blood left in my body.";
		} else {
			txt.text = "I am dead mates.";
		}
	}
}
