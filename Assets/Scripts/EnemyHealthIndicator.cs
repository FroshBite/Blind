using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyHealthIndicator : MonoBehaviour {

	public GameObject enemyObject;
	Enemy enemy;
	
	Text txt;

	// Use this for initialization
	void Start () {
		enemy = enemyObject.GetComponent<Enemy>();
		txt = gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {

		if (enemy.currentHP == enemy.hp) {
			txt.text = "Looks tough!";
		} else if (enemy.currentHP > enemy.hp * 0.9f) {
			txt.text = "Just grazed.";
		} else if (enemy.currentHP > enemy.hp * 0.75f) {
			txt.text = "It doesn't look so strong!";
		} else if (enemy.currentHP > enemy.hp * 0.5f) {
			txt.text = "This mate's looking pretty beat.";
		} else if (enemy.currentHP > enemy.hp * 0.25f) {
			txt.text = "Victory is at hand!";
		} else if (enemy.currentHP > enemy.hp * 0.1f) {
			txt.text = "A sneeze would kill this mate.";
		} else if (enemy.currentHP > 0){
			txt.text = "R.I.P. in Peace.";
		}
		else if(!enemy.isAlive){
			txt.text = "GAME OVER";
		}
	}

}
