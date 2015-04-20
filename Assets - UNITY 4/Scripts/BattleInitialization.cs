using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleInitialization : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject obj = (GameObject)Resources.Load(PlayerStats.enemyName);
		GameObject go;
		go=Instantiate(obj,new Vector3(0,0,0),Quaternion.identity) as GameObject; 
		go.transform.parent=GameObject.Find("Enemy").transform;
		go.transform.position = go.transform.parent.position;

	}
	
	// Update is called once per frame
	void Update () {

	}
}
