using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

	public int[] position = new int[2];
	private Sprite[] wallSprites = new Sprite[103];

	// Use this for initialization
	void Start () {
		transform.position = new Vector3(position[0], position [1], 5);
		wallSprites = Resources.LoadAll<Sprite>("Tiles");
	}
	
	// Update is called once per frame
	void Update () {
	}

	public int[] getPosition(){
		return position;
	}

	public void StartGame(bool floorRight, bool floorDown, bool floorDiagonal) {
		if (floorRight && floorDown)
			GetComponent<SpriteRenderer>().sprite = wallSprites[33];

		else if (floorRight)
			GetComponent<SpriteRenderer>().sprite = wallSprites[13];

		else if (floorDown)
			GetComponent<SpriteRenderer>().sprite = wallSprites[1];

		else if (floorDiagonal)
			GetComponent<SpriteRenderer>().sprite = wallSprites[0];

		else
			GetComponent<SpriteRenderer>().sprite = wallSprites[72];
	}
}