using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public int hp=15;
	public int atk=10;
	public int def=5;
	
	public int currentHP=15;

	public AudioSource[] sounds;
	public AudioSource hitsound;
	public AudioSource deathsound;

	public bool isAlive = true;
	public bool isWaiting = true;

	public GameObject playerObject;
	PlayerStats player;


	// Use this for initialization
	void Start () {
		player = playerObject.GetComponent<PlayerStats>();

		int currentHP=15;
		sounds = GetComponents<AudioSource> ();
		hitsound = sounds [0];
		deathsound = sounds[1];
	}

	
	// Update is called once per frame
	void Update () {
		if (!isWaiting && isAlive) {
			Invoke("Attack", 1);
			isWaiting = true;
			player.isWaiting = false;
		}
	}

	public void Attack(){
		int damage = atk;
		player.GetHit (damage);
		Debug.Log (string.Format ("GOT HIT FOR {0}", damage));

	}

	public void GetHit(int damage){
		currentHP -= damage;
		if (currentHP <= 0 && isAlive) {
			this.renderer.enabled = false;
			deathsound.Play();
			isAlive= false;
			Debug.Log ("VICTORY");
			exitBattle ();

		}
		else if(isAlive) {
			hitsound.Play();
		}
	}

	//Rolls the player's stat gains after a level up.
	public int rollLevel(){
		return Random.Range (0,7);
	}

	//General battle exit function, use this at the end of every battle
	//Still has to exit scene
	public void exitBattle(){
		//Level up stuff starts here :o
		Debug.Log ("LEVEL UP:");
		PlayerStats.atk+=rollLevel ();
		PlayerStats.hp+=rollLevel ();
		PlayerStats.DiceSize+=1;

		//Reset stats to default values
		PlayerStats.dmgMult=0;
		PlayerStats.currentHP = PlayerStats.hp;
		PlayerStats.currentMP = PlayerStats.mp;
	}
	
}

