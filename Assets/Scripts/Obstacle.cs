using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

	public int[] position = new int[2];
	private Sprite[] wallSprites;

	// Use this for initialization
	void Start () {
		position [0] = (int)transform.position.x;
		position [1] = (int)transform.position.y;

		wallSprites = Resources.LoadAll<Sprite>("Tiles");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartGame(Vector3 startingPosition, bool floorRight, bool floorDown, bool floorDiagonal) {
		transform.position = startingPosition;

		if (floorRight && floorDown)
			GetComponent<SpriteRenderer>().sprite = wallSprites[33];

		else if (floorRight)
			GetComponent<SpriteRenderer>().sprite = wallSprites[13];

		else if (floorDown)
			GetComponent<SpriteRenderer>().sprite = wallSprites[1];

		else if (floorDiagonal)
			GetComponent<SpriteRenderer>().sprite = wallSprites[0];
	}
}