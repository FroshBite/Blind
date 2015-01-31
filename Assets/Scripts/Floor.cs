using UnityEngine;
using System.Collections;

public class Floor : MonoBehaviour {

	private Sprite[] floorSprites = new Sprite[103];

	// Use this for initialization
	void Start () {
		floorSprites = Resources.LoadAll<Sprite>("Tiles");

		int spriteNum = Random.Range(0,5);

		if(spriteNum == 0)
			GetComponent<SpriteRenderer>().sprite = floorSprites[15];
		else if(spriteNum == 1)
			GetComponent<SpriteRenderer>().sprite = floorSprites[16];
		else if(spriteNum == 2)
			GetComponent<SpriteRenderer>().sprite = floorSprites[21];
		else if(spriteNum == 3)
			GetComponent<SpriteRenderer>().sprite = floorSprites[44];
	}
	
	// Update is called once per frame
	void Update () {
	}
}
