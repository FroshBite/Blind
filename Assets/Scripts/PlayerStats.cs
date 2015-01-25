using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

	public bool isAlive = true;
	public bool isWaiting = false;
	public bool isVictorious = false;

	public int DieCount = 1;
	public int DiceSize = 6;

	public static int hp=100;
	public int atk=10;
	public int def=5;
	public int damageCount;
	
	public static int currentHP=100;

	public GameObject enemyObject;
	Enemy enemy;

	public AudioSource[] sounds;
	public AudioSource hitsound;
	public AudioSource deathsound;
	
	// Use this for initialization
	void Start () {
		sounds = GetComponents<AudioSource> ();
		hitsound = sounds [0];
		deathsound = sounds[1];

		enemy = enemyObject.GetComponent<Enemy>();
	}
	
	// Update is called once per frame
	void Update () {

		if (!isAlive) {
			Debug.Log ("GAME OVER");
		}

		if (!enemy.isAlive) {
			isVictorious = true;
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
			Debug.Log (string.Format ("HIT FOR {0}", damageCount));
			enemy.GetHit (damage);
			isWaiting = true;
			enemy.isWaiting = false;
		}
	}

	public void Escape(){
		if (!isWaiting) {
			Roll ();
			int escapism = damageCount;
			Debug.Log (string.Format ("ESCAPE CHECK: {0}", damageCount));
			if (escapism > enemy.atk){
				Debug.Log ("ESCAPE SUCCESS");
				Debug.Log ("Application.LoadLevel (0)");
			}
			else{
				Debug.Log ("COULDN'T ESCAPE");
				isWaiting = true;
				enemy.isWaiting = false;
			}

		}
	}


	public void GetHit(int damage){
		currentHP -= damage;
		if (currentHP <= 0 && isAlive) {
			deathsound.Play();
			isAlive = false;
		}
		else {
			hitsound.Play();
		}
	}
}
