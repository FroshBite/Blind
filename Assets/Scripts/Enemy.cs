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
		if (!isWaiting) {
			Attack ();
		}
	}

	public void Attack(){
		int damage = atk;
		player.GetHit (damage);
		Debug.Log (damage);
		isWaiting = true;
		player.isWaiting = false;
	}

	public void GetHit(int damage){
		currentHP -= damage;
		if (currentHP <= 0 && isAlive) {
			this.renderer.enabled = false;
			deathsound.Play();
			isAlive= false;
		}
		else {
			hitsound.Play();
		}
	}
	
}

