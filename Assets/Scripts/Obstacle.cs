using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

	public int[] position = new int[2];
	private DungeonMaster dungeonMaster;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartGame(DungeonMaster dm, Vector3 startingPosition) {
		dungeonMaster = dm;
		transform.position = startingPosition;
		print (position [0] + " " + position [1]);
	}
}
