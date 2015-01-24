using UnityEngine;
using System.Collections;

public class MainCombat : MonoBehaviour {
	bool isAlive = true;
	bool waiting = false;
	
	public GameObject enemyObject;
	Enemy enemy;

	// Use this for initialization
	void Start () {
		enemy = enemyObject.GetComponent<Enemy>();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void Attack(){
		int damage = 15;
		enemy.GetHit(damage);
	
	}

}
