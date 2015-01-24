using UnityEngine;
using System.Collections;

public class MainCombat : MonoBehaviour {

	bool isAlive = true;
	bool waiting = false;
	public GameObject enemy; 
	public GameObject playerStats;

	// Use this for initialization
	void Start () {
		enemy = GameObject.Find ("Enemy");
		enemyScript = enemy.GetComponent<Enemy> ();
		playerStats = GameObject.Find ("playerStats");
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Attack(){
		damage = 15;
		enemyScript.SendMessage ("GetHit", damage);
	
	}

}
