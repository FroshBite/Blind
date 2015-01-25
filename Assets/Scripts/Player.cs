using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public int stamina = 5;
	public float MoveSpeed = 0.25f;
	
	public int[] currentPosition = new int[2];
	
	private bool isMoving = false;
	private Vector3 targetPosition;
	private DungeonMaster dungeonMaster;

	// Use this for initialization
	void Start () {
		currentPosition[0] = 0;
		currentPosition[1] = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if( isMoving )
		{
			float dist = Vector3.Distance( transform.position, targetPosition );
			if( dist < 0.1f )
			{
				transform.position = targetPosition;
				isMoving = false;

				dungeonMaster.DoneMove();
			}
			else
			{
				transform.position = Vector3.Lerp(transform.position, targetPosition, MoveSpeed);
			}
		}
	}

	public void StartGame( DungeonMaster dm, Vector3 startingPosition ) {
		dungeonMaster = dm;
		transform.position = startingPosition;
	}
	
	public void Move(int[] nodeCoordinates, Vector3 position) {
		currentPosition = nodeCoordinates;
		targetPosition = position;
		
		isMoving = true;
	}
}