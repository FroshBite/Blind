using UnityEngine;
using System.Collections;

public class EnemyOverworld : MonoBehaviour {
	
	public string enemyName;
	public bool isMoving;

	private int[] currentPosition = new int[2];
	private Vector3 targetPosition;
	private float moveSpeed;

	// Use this for initialization
	void Start () {
		isMoving = false;
		moveSpeed = 0.25f;
	}
	
	// Update is called once per frame
	void Update () {
		if( isMoving )
		{
			float dist = Vector3.Distance( transform.position, targetPosition);
			if( dist < 0.1f )
			{
				transform.position = targetPosition;
				isMoving = false;
			}
			else
			{
				transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed);
			}
		}
	}

	public int[] getPosition(){
		return currentPosition;
	}

	public void StartGame(int xPos, int yPos, Vector3 startingPosition) {
		currentPosition[0] = xPos;
		currentPosition[1] = yPos;
		transform.position = startingPosition;
	}
	
	public void Move(int xPos, int yPos, Vector3 position) {
		currentPosition[0] = xPos;
		currentPosition[1] = yPos;
		targetPosition = position;
		
		isMoving = true;
	}
}