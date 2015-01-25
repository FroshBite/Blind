using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public int hp=15;
	public int atk=10;
	public int def=5;
	
	public int currentHP=15;


	// Use this for initialization
	void Start () {
		int currentHP=15;
	}

	
	// Update is called once per frame
	void Update () {
	
	}

	public void GetHit(int damage){
		currentHP -= damage;
		if (currentHP <= 0) {
			this.renderer.enabled = false;
		}
	}
	
}

