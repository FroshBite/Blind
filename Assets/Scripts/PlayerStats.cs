using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

	public bool isAlive = true;
	public bool isWaiting = false;

	public int DieCount = 1;
	public int DiceSize = 6;

	public static int hp=100;
	public int atk=10;
	public int def=5;
	public int damageCount;
	
	public static int currentHP=100;

	public GameObject enemyObject;
	Enemy enemy;

	// Use this for initialization
	void Start () {
		int currentHP = 100;
		enemy = enemyObject.GetComponent<Enemy>();
	}
	
	// Update is called once per frame
	void Update () {

		if (!isAlive) {
			Debug.Log ("GAME OVER");
		}
	
	}

	public void Roll(){
		if(!isWaiting){

			for (int diceNumber = 1; diceNumber <= DieCount; diceNumber++) {
				int roll = Random.Range (1, DiceSize + 1);
				damageCount += roll;
			}


		}

	}

	public void Attack(){
		if (!isWaiting) {
			Roll ();
			int damage = damageCount;
			Debug.Log (damageCount);
			enemy.GetHit (damage);
			isWaiting = true;
			enemy.isWaiting = false;
		}
	}


	public void GetHit(int damage){
		currentHP -= damage;
		if (currentHP <= 0 && isAlive) {
			this.renderer.enabled = false;

			isAlive = false;
		}
		else {

		}
	}
}
