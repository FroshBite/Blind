﻿using UnityEngine;
using System.Collections;


public class EnemyOverworld : MonoBehaviour {
	public float MoveSpeed = 0.25f;
	private bool isMoving = false;
	private Vector3 targetPosition;
	public int[] currentPosition = new int[2];

	private DungeonMaster dungeonMaster;
	public string enemyName;

	// Use this for initialization
	void Start () {
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
				transform.position = Vector3.Lerp(transform.position, targetPosition, MoveSpeed);
			}
		}
	}

	public void StartGame(DungeonMaster dm, int xPos, int yPos, Vector3 startingPosition) {
		dungeonMaster = dm;
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