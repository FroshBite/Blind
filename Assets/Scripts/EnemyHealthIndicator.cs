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

		if (enemy.currentHP > 98) {
			txt.text = "This mate ain't so strong!";
		} else if (enemy.currentHP > 90) {
			txt.text = "2";
		} else if (enemy.currentHP > 80) {
			txt.text = "1";
		} else if (enemy.currentHP > 70) {
			txt.text = "3";
		} else if (enemy.currentHP > 60) {
			txt.text = "4";
		} else if (enemy.currentHP > 50) {
			txt.text = "5";
		} else if (enemy.currentHP > 40) {
			txt.text = "6";
		} else if (enemy.currentHP > 30) {
			txt.text = "7";
		} else if (enemy.currentHP > 20) {
			txt.text = "8";
		} else if (enemy.currentHP > 10) {
			txt.text = "9";
		} else {
			txt.text = "10";
		}
	}

}
