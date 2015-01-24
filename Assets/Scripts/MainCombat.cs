using UnityEngine;
using System.Collections;

public class MainCombat : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Attack(){
		GameObject.Find("Gorilla").GetComponent(Enemy).currentHP = 0;
	
	}

}
