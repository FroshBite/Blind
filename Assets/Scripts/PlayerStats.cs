using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

	public int DieCount = 1;
	public int DiceSize = 6;

	public static int hp=15;
	public int atk=10;
	public int def=5;
	
	public static int currentHP=15;

	public GameObject CombatManagerObject;
	MainCombat combatManager;

	// Use this for initialization
	void Start () {
		int currentHP = 15;
		combatManager = CombatManagerObject.GetComponent<MainCombat>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Roll(){
		if(!combatManager.isWaiting){
			int damageCount;
			for (int diceNumber = 1; diceNumber <= DieCount; diceNumber++) {
				int roll = Random.Range (1, DiceSize + 1);
				damageCount += roll;
			}
			combatManager.isWaiting = true;

		}

	}

	public void GetHit(int damage){
		currentHP -= damage;
		if (currentHP <= 0 && combatManager.isAlive) {
			this.renderer.enabled = false;

			combatManager.isAlive = false;
		}
		else {

		}
	}
}
