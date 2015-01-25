using UnityEngine;
using System.Collections;

public class DungeonMaster : MonoBehaviour {

	public Player player;
	public EnemyOverworld[] enemies;

	private int Columns = 100;
	private int Rows = 100;

	public float NodeSpacing = 0.25f;
	private Vector3[,] gameNodes;

	private bool drawGizmos = false;
	public bool playerTurn = true;

	// Use this for initialization
	void Start () {
		gameNodes = new Vector3[Rows, Columns];

		for(int y = 0; y < Columns; y++){
			for( int x = 0; x < Rows; x++ ){

				float xPos = (x * 1.0f) * NodeSpacing;
				float yPos = (y * 1.0f) * NodeSpacing;

				gameNodes[x, y] = new Vector3(xPos, yPos, transform.position.z);
			}
		}

		player.StartGame(this, 50, 50, gameNodes[50,50]);

		for(int i=0; i<enemies.Length; i++){
			enemies[i].StartGame(this, 51, 50+i, gameNodes[51, 50+i]);
		}

		drawGizmos = true;
	}

	void OnDrawGizmos()
	{
		if(drawGizmos)
		{
			for(int y = 0; y < Columns; y++){
				for( int x = 0; x < Rows; x++ ){
					Gizmos.color = Color.white;
					Gizmos.DrawWireSphere(gameNodes[x, y], 0.25f);
				}
			}
		}
	}

	// Update is called once per frame
	void Update () {
		if (playerTurn){

			if(Input.GetKeyDown(KeyCode.W)){
				int[] newNode =  new int[2] {player.currentPosition[0], player.currentPosition[1]+1};
				player.Move(newNode[0], newNode[1], gameNodes[newNode[0], newNode[1]]);
			}

			if(Input.GetKeyDown(KeyCode.A)){
				int[] newNode =  new int[2] {player.currentPosition[0]-1, player.currentPosition[1]};
				player.Move(newNode[0], newNode[1], gameNodes[newNode[0], newNode[1]]);
			}

			if(Input.GetKeyDown(KeyCode.S)){
				int[] newNode =  new int[2] {player.currentPosition[0], player.currentPosition[1]-1};
				player.Move(newNode[0], newNode[1], gameNodes[newNode[0], newNode[1]]);
			}

			if(Input.GetKeyDown(KeyCode.D)){
				int[] newNode =  new int[2] {player.currentPosition[0]+1, player.currentPosition[1]};
				player.Move(newNode[0], newNode[1], gameNodes[newNode[0], newNode[1]]);
			}
		}

		else {
			for(int i=0; i<enemies.Length; i++){
				int direction = Random.Range(0,4);

				if(enemies[i].currentPosition[1] == player.currentPosition[1]-1)
					direction = 0;
				else if(enemies[i].currentPosition[0] == player.currentPosition[0]+1)
					direction = 1;
				else if(enemies[i].currentPosition[1] == player.currentPosition[1]+1)
					direction = 2;
				else if(enemies[i].currentPosition[0] == player.currentPosition[0]-1)
					direction = 3;
				else if((enemies[i].currentPosition[0] == player.currentPosition[0]) && 
				        (enemies[i].currentPosition[1] == player.currentPosition[1]))
					direction = 4;

				if(direction == 0){
					int[] newNode =  new int[2] {enemies[i].currentPosition[0], enemies[i].currentPosition[1]+1};
					enemies[i].Move(newNode[0], newNode[1], gameNodes[newNode[0], newNode[1]]);
				}
				
				if(direction == 1){
					int[] newNode =  new int[2] {enemies[i].currentPosition[0]-1, enemies[i].currentPosition[1]};
					enemies[i].Move(newNode[0], newNode[1], gameNodes[newNode[0], newNode[1]]);
				}
				
				if(direction == 2){
					int[] newNode =  new int[2] {enemies[i].currentPosition[0], enemies[i].currentPosition[1]-1};
					enemies[i].Move(newNode[0], newNode[1], gameNodes[newNode[0], newNode[1]]);
				}
				
				if(direction == 3){
					int[] newNode =  new int[2] {enemies[i].currentPosition[0]+1, enemies[i].currentPosition[1]};
					enemies[i].Move(newNode[0], newNode[1], gameNodes[newNode[0], newNode[1]]);
				}
			}
			playerTurn = true;
		}
	}

	public void DoneMove(){
		for (int i = 0; i < enemies.Length; i++){
			if(enemies[i].currentPosition == player.currentPosition){
				Application.LoadLevelAdditive(1);
				playerTurn = true;
			}
		}
	}
}