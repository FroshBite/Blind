using UnityEngine;
using System.Collections;

public class MainCombat : MonoBehaviour {
	public bool isAlive = true;
	public bool isWaiting = false;
	
	public GameObject enemyObject;
	Enemy enemy;

	public GameObject playerObject;
	PlayerStats player;



	// Use this for initialization
	void Start () {
		enemy = enemyObject.GetComponent<Enemy>();
		player = playerObject.GetComponent<PlayerStats> ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void Attack(){
		int damage = playerObject.Roll();
		enemy.GetHit(damage);
	
	}

}
