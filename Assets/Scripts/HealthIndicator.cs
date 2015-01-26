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
		if (PlayerStats.currentHP > PlayerStats.hp * 0.95f) {
				txt.text = "I'm really feeling it!";
		} else if (PlayerStats.currentHP > PlayerStats.hp * 0.9f) {
			txt.text = "Don't worry, I got this!";
		} else if (PlayerStats.currentHP > PlayerStats.hp * 0.8f) {
			txt.text = "Just a scratch or two.";
		} else if (PlayerStats.currentHP > PlayerStats.hp * 0.7f) {
			txt.text = "Maybe it's more of a gash.";
		} else if (PlayerStats.currentHP > PlayerStats.hp * 0.6f) {
			txt.text = "Cripes, that's painful.";
		} else if (PlayerStats.currentHP > PlayerStats.hp * 0.5f) {
			txt.text = "The glass is still half full!";
		} else if (PlayerStats.currentHP > PlayerStats.hp * 0.4f) {
			txt.text = "Not feeling it so much anymore.";
		} else if (PlayerStats.currentHP > PlayerStats.hp * 0.3f) {
			txt.text = "Ribs grow back, right?";
		} else if (PlayerStats.currentHP > PlayerStats.hp * 0.2f) {
			txt.text = "WELP.";
		} else if (PlayerStats.currentHP > PlayerStats.hp * 0.1f) {
			txt.text = "I have no blood left in my body.";
		} else if(PlayerStats.currentHP > 0){
			txt.text = "Well, it was nice knowing you!";
		}
		else if(!player.isAlive){
			txt.text = "GAME OVER";
		}
	}
}
