using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public int hp=30;
	public int diceAtk=10;
	public int diceDef=5;
	public int damageCount;
	
	public int currentHP=30;

	public static int DieCount = 1;

	public AudioSource[] sounds;
	public AudioSource hitSound;
	public AudioSource deathSound;

	public bool isAlive = true;
	public bool isWaiting = true;

	public GameObject playerObject;
	PlayerStats player;



	// Use this for initialization
	void Start () {
		player = playerObject.GetComponent<PlayerStats>();
		sounds = GetComponents<AudioSource> ();
		hitSound = sounds [0];
		deathSound = sounds[1];
	}

	
	// Update is called once per frame
	void Update () {
	}

	public IEnumerator Turn(int waitTime){
		patchworkPlayerPressDelay ();
		yield return new WaitForSeconds(waitTime);
		Attack ();
	}

	public void patchworkPlayerPressDelay(){
		player.isPressed = false;
	}

	public void Roll(){
		if(!isWaiting){
			damageCount = 0;
			for (int diceNumber = 1; diceNumber <= DieCount; diceNumber++) {
				int roll = Random.Range (1, diceAtk + 1);
				damageCount += roll;
			}
		}
		
	}

	public void Attack(){
		if (isAlive){
			Roll ();
			int damage = damageCount;
			player.GetHit (damage);
			Debug.Log (string.Format ("GOT HIT FOR {0}", damage));
			isWaiting = true;
			player.isWaiting = false;
		}
	}

	//IEnumerator HitFlash(float flashTime){
	//hitSound.Play();
	//renderer.material.color = Color.red;
	//yield return new WaitForSeconds(flashTime);
	//renderer.material.color = Color.white;
	//}

	public void GetHit(int damage){
		currentHP -= damage;
		if (currentHP <= 0 && isAlive) {
			deathSound.Play();
			isAlive= false;
			Debug.Log ("VICTORY");

			exitBattle ();
		
		}
		else if(isAlive) {
			hitSound.Play();
			//HitFlash();
		}
	}

	//Rolls the player's stat gains after a level up.
	public int rollLevel(){
		return Random.Range (0,7);
	}

	//General battle exit function, use this at the end of every battle
	public void exitBattle(){
		//Level up stuff starts here :o
		Debug.Log ("LEVEL UP:");
		PlayerStats.diceAtk+=rollLevel ();
		PlayerStats.hp+=rollLevel ();
		
		//Reset stats to default values
		PlayerStats.dmgMult=0;
		PlayerStats.currentHP = PlayerStats.hp;
		PlayerStats.currentMP = PlayerStats.mp;

		//Exit Scene
		// Application.LoadLevel (0);
	}
}

