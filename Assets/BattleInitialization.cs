using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleInitialization : MonoBehaviour {
	public GameObject enemyObject;
	Enemy enemy;

	// Use this for initialization
	void Start () {
		GameObject obj = (GameObject)Resources.Load("Slime");
		GameObject go;
		go=Instantiate(obj,new Vector3(0,0,0),Quaternion.identity) as GameObject; 
		go.transform.parent=GameObject.Find("Placeholder").transform;
		go.transform.position = go.transform.parent.position;

		enemy = enemyObject.GetComponent<Enemy>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space")) {
			Application.LoadLevelAdditive(1);
		}
	}
}
