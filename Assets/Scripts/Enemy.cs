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

	Vector3 startingPosition;


	// Use this for initialization
	void Start () {
		startingPosition = transform.position;
		player = playerObject.GetComponent<PlayerStats>();
		sounds = GetComponents<AudioSource> ();
		hitsound = sounds [0];
		deathsound = sounds[1];
	}

	
	// Update is called once per frame
	void Update () {
		if (!isWaiting && isAlive) {
			Invoke ("patchworkPlayerPressDelay", 1);
			Invoke("Attack", 1);
			isWaiting = true;
			player.isWaiting = false;
		}
	}

	public void patchworkPlayerPressDelay(){
		player.isPressed = false;
	}

	public void Attack(){
		transform.position = new Vector3 (transform.position.x, transform.position.y - 1, transform.position.x);
		int damage = atk;
		player.GetHit (damage);
		Debug.Log (string.Format ("GOT HIT FOR {0}", damage));
		transform.position = startingPosition;

	}

	public void patchworkHitFlash(){
		this.renderer.material.color = Color.white;
	}

	public void GetHit(int damage){
		currentHP -= damage;
		if (currentHP <= 0 && isAlive) {
			this.renderer.enabled = false;
			deathsound.Play();
			isAlive= false;
			Debug.Log ("VICTORY");
		
		}
		else if(isAlive) {
			hitsound.Play();
			this.renderer.material.color = Color.red;
			Invoke ("patchworkHitFlash", 0.1f);
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

